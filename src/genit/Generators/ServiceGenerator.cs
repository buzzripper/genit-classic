using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Dyvenix.Genit.Models.Generators;
using System.Threading.Tasks;

namespace Dyvenix.Genit.Generators;

public class ServiceGenerator
{
	#region Constants

	private const string cToken_CurrTimestamp = "CURR_TIMESTAMP";
	private const string cToken_AddlUsings = "ADDL_USINGS";

	private const string cToken_ServicesNs = "SERVICES_NS";
	private const string cToken_ServiceAttrs = "SERVICE_ATTRS";
	private const string cToken_ServiceName = "SERVICE_NAME";
	private const string cToken_IntfSignatures = "INTERFACE_SIGNATURES";
	private const string cToken_CudMethods = "CUD_METHODS";
	private const string cToken_SingleMethods = "SINGLE_METHODS";
	private const string cToken_ListMethods = "LIST_METHODS";
	private const string cToken_QueryMethods = "QUERY_METHODS";

	private const string cToken_QueriesNs = "QUERIES_NS";
	private const string cToken_QueryClassName = "QUERY_CLASS_NAME";
	private const string cToken_QueryIntfDecl = "QUERY_INTF_DECL";
	private const string cToken_FilterProps = "FILTER_PROPERTIES";
	private const string cToken_QueryInclSorting = "QRY_INCL_SORTING";
	private const string cToken_QueryInclPaging = "QRY_INCL_PAGING";

	private const string cToken_ControllersNs = "CONTROLLERS_NS";
	private const string cToken_ControllerName = "CONTROLLER_NAME";
	private const string cToken_ServiceVarName = "SERVICE_VAR_NAME";
	private const string cToken_CudControllerMethods = "CUD_METHODS";

	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.Entity;

	#endregion

	public void Run(ServiceGenModel svcGenModel, ObservableCollection<EntityModel> entities, string servicesNamespace, string queriesNamespace, string controllersNamespace, string entitiesNamespace)
	{
		if (!svcGenModel.Enabled)
			return;

		// Services
		var templateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.TemplateFilepath);
		var outputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.OutputFolder);
		Validate(templateFilepath, outputFolder);
		var serviceTemplate = File.ReadAllText(templateFilepath);

		// Query classes
		var queryTemplateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.QueryTemplateFilepath);
		var queryOutputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.QueryOutputFolder);
		Validate(queryTemplateFilepath, queryOutputFolder);
		var queryTemplate = File.ReadAllText(queryTemplateFilepath);

		// Controllers
		var controllerTemplateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.ControllerTemplateFilepath);
		var controllersOutputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.ControllerOutputFolder);
		Validate(controllerTemplateFilepath, controllersOutputFolder);
		var controllerTemplate = File.ReadAllText(controllerTemplateFilepath);

		foreach (var entity in entities.Where(e => e.Service.Enabled)) {
			// Generate service class
			GenerateService(entity, svcGenModel, $"{serviceTemplate}", outputFolder, servicesNamespace, queriesNamespace);

			// Generate query classes
			foreach (var queryMethod in entity.Service.QueryMethods)
				GenerateQueryClass(entity.Service, svcGenModel, $"{queryTemplate}", queryOutputFolder, queriesNamespace);

			// Generate controller
			if (entity.Service.InclController)
				GenerateController(entity, svcGenModel, $"{controllerTemplate}", controllersOutputFolder, controllersNamespace, servicesNamespace, queriesNamespace, entitiesNamespace);
		}
	}

	private void Validate(string templateFilepath, string outputFolder)
	{
		if (!File.Exists(templateFilepath))
			throw new ApplicationException($"Template file does not exist: {templateFilepath}");

		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {outputFolder}");
	}

	#region Services

	private void GenerateService(EntityModel entity, ServiceGenModel serviceGen, string template, string outputFolder, string servicesNamespace, string queriesNamespace)
	{
		var serviceName = $"{entity.Name}Service";

		// Addl usings
		var addlUsings = BuildAddlUsings(entity.Service.AddlServiceUsings);
		addlUsings.AddIfNotExists(queriesNamespace);

		// Interface signatures
		var interfaceOutput = new List<string>();

		// Attributes
		var attrsOutput = new List<string>();
		foreach (var attr in entity.Service.ServiceClassAttributes)
			attrsOutput.Add($"[{attr}]");

		// Create/Update/Delete
		var crudMethodsOutput = new List<string>();
		if (entity.Service.InclCreate || entity.Service.InclUpdate || entity.Service.InclDelete)
			this.GenerateCUDMethods(entity, crudMethodsOutput, interfaceOutput);

		// GetSingle methods
		var singleMethodsOutput = new List<string>();
		foreach (GetSvcMethodModel singleMethod in entity.Service.GetMethods.Where(m => !m.IsList))
			this.GenerateSingleMethod(entity, singleMethod, singleMethodsOutput, interfaceOutput);

		// Get list methods
		var listMethodsOutput = new List<string>();
		foreach (GetSvcMethodModel listMethod in entity.Service.GetMethods.Where(m => m.IsList))
			this.GenerateListMethod(entity, listMethod, listMethodsOutput, interfaceOutput);

		// Query methods
		var queryMethodsOutput = new List<string>();
		if (entity.Service.QueryMethods.Any()) {
			queryMethodsOutput.AddLine(1, "#region Queries");

			foreach (QuerySvcMethodModel queryMethod in entity.Service.QueryMethods)
				this.GenerateQueryMethod(entity, queryMethod, queryMethodsOutput, interfaceOutput);

			// Sorting method
			this.GenerateSortingMethod(entity, queryMethodsOutput);
			queryMethodsOutput.AddLine();
			queryMethodsOutput.AddLine(1, "#endregion");
		}

		// Replace tokens in template
		var fileContents = ReplaceServiceTemplateTokens(template, serviceName, addlUsings, attrsOutput, crudMethodsOutput, singleMethodsOutput, listMethodsOutput, queryMethodsOutput, interfaceOutput, servicesNamespace);

		var outputFile = Path.Combine(outputFolder, $"{serviceName}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	private void GenerateCUDMethods(EntityModel entity, List<string> output, List<string> interfaceOutput)
	{
		var tc = 1;
		var className = entity.Name;	
		var varName = Utils.ToCamelCase(className);

		output.AddLine(tc, "// Create / Update / Delete");

		if (entity.Service.InclCreate) {
			// Interface
			var signature = $"Task Create{className}({className} {varName})";
			interfaceOutput.Add(signature);

			output.AddLine();
			output.AddLine(tc, $"public async {signature}");
			output.AddLine(tc, "{");
			output.AddLine(tc+1, $"if ({varName} == null)");
			output.AddLine(tc+2, $"throw new ArgumentNullException(nameof({varName}));");
			output.AddLine();
			output.AddLine(tc+1, $"using var db = _dbContextFactory.CreateDbContext();");
			output.AddLine(tc+1, $"db.Add({varName});");
			output.AddLine();
			output.AddLine(tc+1, $"await db.SaveChangesAsync();");
			output.AddLine(tc, "}");
		}

		if (entity.Service.InclUpdate) {
			// Interface
			var signature = $"Task Update{className}({className} {varName})";
			interfaceOutput.Add(signature);

			output.AddLine();
			output.AddLine(tc, $"public async {signature}");
			output.AddLine(tc, "{");
			output.AddLine(tc+1, $"if ({varName} == null)");
			output.AddLine(tc+2, $"throw new ArgumentNullException(nameof({varName}));");
			output.AddLine();
			output.AddLine(tc+1, $"using var db = _dbContextFactory.CreateDbContext();");
			output.AddLine(tc+1, $"db.Attach({varName});");
			output.AddLine(tc+1, $"db.Entry({varName}).State = EntityState.Modified;");
			output.AddLine();
			output.AddLine(tc+1, $"await db.SaveChangesAsync();");
			output.AddLine(tc, "}");
		}

		if (entity.Service.InclDelete) {
			// Interface
			var signature = $"Task Delete{className}(Guid id)";
			interfaceOutput.Add(signature);

			output.AddLine();
			output.AddLine(tc, $"public async {signature}");
			output.AddLine(tc, "{");
			output.AddLine(tc+1, $"using var db = _dbContextFactory.CreateDbContext();");
			output.AddLine(tc+1, $"await db.{className}.Where(a => a.Id == id).ExecuteDeleteAsync();");
			output.AddLine(tc, "}");
		}
	}

	private void GenerateSingleMethod(EntityModel entity, GetSvcMethodModel method, List<string> output, List<string> interfaceOutput)
	{
		var tc = 1;
		output.AddLine();

		// Attributes
		if (method.Attributes.Any())
			foreach (var attr in method.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Interface
		var signature = $"Task<{entity.Name}>{method.Name}({method.ArgType} {method.ArgName})";
		interfaceOutput.Add(signature);

		// Method
		output.AddLine(tc, $"public async {signature}");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "var db = _dbContextFactory.CreateDbContext();");
		output.AddLine(tc + 1, $"return await db.{entity.Name}.FirstOrDefaultAsync(x => x.{method.PropName} == {method.ArgName});");
		output.AddLine(tc, "}");
	}

	private void GenerateListMethod(EntityModel entity, GetSvcMethodModel method, List<string> output, List<string> interfaceOutput)
	{
		var tc = 1;
		output.AddLine();

		// Attributes
		if (method.Attributes.Any())
			foreach (var attr in method.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Interface
		var sbArgs = new StringBuilder();

		// Paging
		if (!string.IsNullOrWhiteSpace(method.ArgType))
			sbArgs.Append($"{method.ArgType} {method.ArgName}");
		if (method.InclPaging) {
			if (sbArgs.Length > 0)
				sbArgs.Append(", ");
			sbArgs.Append("int pageSize, int rowOffset");
		}
		var signature = $"Task<List<{entity.Name}>>{method.Name}({sbArgs.ToString()})";
		interfaceOutput.Add(signature);

		// Method
		output.AddLine(tc, $"public async {signature}");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"var dbQuery = _dbContextFactory.CreateDbContext().{entity.Name}.AsQueryable();");
		output.AddLine();

		if (!string.IsNullOrWhiteSpace(method.ArgType)) { 
			var indent = tc + 1;
			if (method.FilterProperty.PrimitiveType == PrimitiveType.String) {
				output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace({method.ArgName}))");
				indent++;
			} else if (method.FilterProperty.Nullable) {
				output.AddLine(tc + 1, $"if ({method.ArgName} != null)");
				indent++;
			}
			output.AddLine(indent, $"dbQuery = dbQuery.Where(x => EF.Functions.Like(x.{method.PropName}, {method.ArgName}));");
			output.AddLine();
		}

		if (method.InclPaging) {
			output.AddLine(tc + 1, $"if (pageSize > 0)");
			output.AddLine(tc + 2, $"dbQuery = dbQuery.Skip(rowOffset).Take(pageSize);");
			output.AddLine();
		}

		output.AddLine(tc + 1, $"return await dbQuery.AsNoTracking().ToListAsync();");

		output.AddLine(tc, "}");
	}

	private void GenerateQueryMethod(EntityModel entity, QuerySvcMethodModel queryMethod, List<string> output, List<string> interfaceOutput)
	{
		var tc = 1;
		output.AddLine();
		var queryClassName = $"{queryMethod.Name}Query";
		//var queryVarName = Utils.ToCamelCase(queryClassName);

		// Attributes
		if (queryMethod.Attributes.Any())
			foreach (var attr in queryMethod.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Interface
		var signature = $"Task<EntityList<{entity.Name}>>{queryMethod.Name}({queryClassName} query)";
		interfaceOutput.Add(signature);

		// Method
		output.AddLine(tc, $"public async {signature}");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"var dbQuery = _dbContextFactory.CreateDbContext().{entity.Name}.AsQueryable();");
		output.AddLine(tc + 1, $"var result = new EntityList<{entity.Name}>();");
		output.AddLine();

		output.AddLine(tc + 1, $"// Filters");
		foreach (var prop in queryMethod.FilterProperties) {
			if (prop.PrimitiveType == PrimitiveType.String) {
				output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace(query.{prop.Name}))");
				output.AddLine(tc + 2, $"dbQuery = dbQuery.Where(x => EF.Functions.Like(x.{prop.Name}, query.{prop.Name}));");
			} else if (prop.PrimitiveType == PrimitiveType.Int || prop.PrimitiveType == PrimitiveType.Bool || prop.PrimitiveType == PrimitiveType.Guid) {
				output.AddLine(tc + 1, $"if (query.{prop.Name}.HasValue)");
				output.AddLine(tc + 2, $"dbQuery = dbQuery.Where(x => x.{prop.Name} == query.{prop.Name});");
			}
		}

		if (queryMethod.InclPaging) {
			output.AddLine();
			output.AddLine(tc + 1, "// Paging");
			output.AddLine(tc + 1, "if (query.RecalcRowCount || query.GetRowCountOnly)");
			output.AddLine(tc + 2, "result.TotalRowCount = dbQuery.Count();");
			output.AddLine(tc + 1, "if (query.GetRowCountOnly)");
			output.AddLine(tc + 2, "return result;");
			output.AddLine(tc + 1, "if (query.PageSize > 0)");
			output.AddLine(tc + 2, "dbQuery = dbQuery.Skip(query.RowOffset).Take(query.PageSize);");
		}

		if (queryMethod.InclSorting) {
			output.AddLine();
			output.AddLine(tc + 1, "// Sorting");
			output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace(query.SortBy))");
			output.AddLine(tc + 2, $"this.AddSorting(ref dbQuery, query);");
		}

		output.AddLine();
		output.AddLine(tc + 1, "result.Data = await dbQuery.AsNoTracking().ToListAsync();");
		output.AddLine();
		output.AddLine(tc + 1, "return result;");
		output.AddLine(tc, "}");
	}

	private void GenerateSortingMethod(EntityModel entity, List<string> output)
	{
		var tc = 1;
		output.AddLine();

		// Method
		output.AddLine(tc, $"private void AddSorting(ref IQueryable<{entity.Name}> dbQuery, ISortingQuery sortingQuery)");
		output.AddLine(tc, "{");

		var c = 0;
		foreach (var prop in entity.Properties) {
			if (c++ > 0)
				output.AddLine();

			output.AddLine(tc + 1, $"if (string.Equals(sortingQuery.SortBy, {entity.Name}.PropNames.{prop.Name}, StringComparison.OrdinalIgnoreCase))");
			output.AddLine(tc + 2, "if (sortingQuery.SortDesc)");
			output.AddLine(tc + 3, $"dbQuery.OrderByDescending(x => x.{prop.Name});");
			output.AddLine(tc + 2, "else");
			output.AddLine(tc + 3, $"dbQuery.OrderBy(x => x.{prop.Name});");
		}
		output.AddLine(tc, "}");
	}

	private string ReplaceServiceTemplateTokens(string template, string serviceName, List<string> addlUsings, List<string> attrsOutput, List<string> crudMethodsOutput, List<string> singleMethodsOutput, List<string> listMethodsOutput, List<string> queryMethodsOutput, List<string> interfaceOutput, string servicesNamespace)
	{
		// Header
		template = template.Replace(Utils.FmtToken(cToken_CurrTimestamp), DateTime.Now.ToString("g"));

		// Namespace
		template = template.Replace(Utils.FmtToken(cToken_ServicesNs), servicesNamespace);

		// Usings
		var sb = new StringBuilder();
		addlUsings.ForEach(x => {
			if (sb.Length > 0)
				sb.AppendLine();
			sb.Append($"using {x};");
		});
		template = template.Replace(Utils.FmtToken(cToken_AddlUsings), sb.ToString());

		// Interface
		sb = new StringBuilder();
		interfaceOutput.ForEach(x => {
			if (sb.Length > 0)
				sb.AppendLine();
			sb.Append($"\t{x};");
		});
		template = template.Replace(Utils.FmtToken(cToken_IntfSignatures), sb.ToString());

		// Class Attributes
		sb = new StringBuilder();
		attrsOutput.ForEach(x => {
			if (sb.Length > 0)
				sb.AppendLine();
			sb.Append(x);
		});
		template = template.Replace(Utils.FmtToken(cToken_ServiceAttrs), sb.ToString());

		// Service name
		template = template.Replace(Utils.FmtToken(cToken_ServiceName), serviceName);

		// cToken_IntfSignatures

		// CRUD Methods
		sb = new StringBuilder();
		crudMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_CudMethods), sb.ToString());

		// Single Methods
		sb = new StringBuilder();
		singleMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_SingleMethods), sb.ToString());

		// List Methods
		sb = new StringBuilder();
		listMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_ListMethods), sb.ToString());

		// Query Methods
		sb = new StringBuilder();
		queryMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_QueryMethods), sb.ToString());

		return template;
	}

	#endregion

	#region Query Classes

	private void GenerateQueryClass(ServiceModel service, ServiceGenModel serviceGen, string template, string outputFolder, string queriesNamespace)
	{
		foreach (var queryMethod in service.QueryMethods) {
			var className = $"{queryMethod.Name}Query";
			string interfaceDecl = null;

			// Addl usings
			var addlUsings = new List<string>();
			if (queryMethod.InclSorting)
				addlUsings.Add("Dyvenix.Core.Queries");

			// Sorting
			var sortingSb = new StringBuilder();
			if (queryMethod.InclSorting) {
				interfaceDecl = ": ISortingQuery";
				sortingSb.AppendLine("\tpublic string SortBy { get; set; }");
				sortingSb.AppendLine("\tpublic bool SortDesc { get; set; }");
			}

			// Paging
			var pagingSb = new StringBuilder();
			if (queryMethod.InclPaging) {
				pagingSb.AppendLine("\tpublic int PageSize { get; set; }");
				pagingSb.AppendLine("\tpublic int RowOffset { get; set; }");
				pagingSb.AppendLine("\tpublic bool RecalcRowCount { get; set; }");
				pagingSb.AppendLine("\tpublic bool GetRowCountOnly { get; set; }");
			}

			// Filter properties
			var propsOutput = new List<string>();
			foreach (var filterProp in queryMethod.FilterProperties) {
				var nullStr = filterProp.DatatypeName != "string" ? "?" : null;
				propsOutput.AddLine(1, $"public {filterProp.DatatypeName}{nullStr} {filterProp.Name} {{ get; set; }}");
			}

			// Replace tokens in template
			var fileContents = ReplaceQueryTemplateTokens(template, className, interfaceDecl, addlUsings, queriesNamespace, sortingSb.ToString(), pagingSb.ToString(), propsOutput);

			var outputFile = Path.Combine(outputFolder, $"{className}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, fileContents);
		}
	}

	private string ReplaceQueryTemplateTokens(string template, string className, string interfaceDecl, List<string> addlUsings, string queriesNamespace, string sorting, string paging, List<string> propsOutput)
	{
		// Header
		var fileContents = template.Replace(Utils.FmtToken(cToken_CurrTimestamp), DateTime.Now.ToString("g"));

		// Addl Usings
		var sb = new StringBuilder();
		addlUsings.ForEach(x => {
			if (sb.Length > 0)
				sb.AppendLine();
			sb.Append($"using {x};");
		});
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_AddlUsings), sb.ToString());

		// Namespace
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueriesNs), queriesNamespace);

		// Class name
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueryClassName), className);

		// Interface
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueryIntfDecl), interfaceDecl);

		// Sorting
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueryInclSorting), sorting);

		// Paging
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueryInclPaging), paging);

		// Filter properties
		sb = new StringBuilder();
		propsOutput.ForEach(x => sb.AppendLine(x));
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_FilterProps), sb.ToString());

		return fileContents;
	}

	#endregion

	#region Controllers

	private void GenerateController(EntityModel entity, ServiceGenModel serviceGen, string template, string outputFolder, string controllersNamespace, string servicesNamespace, string queriesNamespace, string entitiesNamespace)
	{
		var controllerName = $"{entity.Name}Controller";
		var serviceName = $"{entity.Name}Service";
		var serviceVarName = Utils.ToCamelCase(serviceName);

		// Addl usings
		var addlUsings = BuildAddlUsings(entity.Service.AddlControllerUsings);
		addlUsings.AddIfNotExists(servicesNamespace);
		addlUsings.AddIfNotExists(queriesNamespace);
		addlUsings.AddIfNotExists(entitiesNamespace);

		// Create/Update/Delete
		var crudMethodsOutput = new List<string>();
		if (entity.Service.InclCreate || entity.Service.InclUpdate || entity.Service.InclDelete)
			this.GenerateCUDControllerMethods(entity, serviceVarName, crudMethodsOutput);

		// GetSingle methods
		var singleMethodsOutput = new List<string>();
		foreach (GetSvcMethodModel singleMethod in entity.Service.GetMethods.Where(m => !m.IsList))
			this.GenerateSingleControllerMethod(entity, singleMethod, serviceVarName, singleMethodsOutput);

		// Get list methods
		var listMethodsOutput = new List<string>();
		foreach (GetSvcMethodModel listMethod in entity.Service.GetMethods.Where(m => m.IsList))
			this.GenerateListControllerMethod(entity, listMethod, serviceVarName, listMethodsOutput);

		// Query methods
		var queryMethodsOutput = new List<string>();
		var sortingMethodOutput = new List<string>();
		if (entity.Service.QueryMethods.Any()) {
			queryMethodsOutput.AddLine();
			queryMethodsOutput.AddLine(1, "#region Queries");
			foreach (QuerySvcMethodModel queryMethod in entity.Service.QueryMethods)
				this.GenerateQueryControllerMethod(entity, queryMethod, serviceVarName, queryMethodsOutput);
			queryMethodsOutput.AddLine();
			queryMethodsOutput.AddLine(1, "#endregion");
		}

		// Replace tokens in template
		var fileContents = ReplaceControllerTemplateTokens(template, addlUsings, controllersNamespace, controllerName, serviceName, serviceVarName, crudMethodsOutput, singleMethodsOutput, listMethodsOutput, queryMethodsOutput);

		var outputFile = Path.Combine(outputFolder, $"{controllerName}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	private void GenerateCUDControllerMethods(EntityModel entity, string svcVarName, List<string> output)
	{
		var tc = 1;
		var className = entity.Name;	
		var varName = Utils.ToCamelCase(className);

		output.AddLine(tc, "// Create / Update / Delete");

		if (entity.Service.InclCreate) {
			output.AddLine();
			output.AddLine(tc, $"[HttpPost, Route(\"[action]\")]");
			output.AddLine(tc, $"public async Task<ActionResult> Create{className}({className} {varName})");
			output.AddLine(tc, "{");
			output.AddLine(tc+1, "try {");
			output.AddLine(tc+2, "var svcResponse =new ServiceResponse();");
			output.AddLine();
			output.AddLine(tc+2, $"await _{svcVarName}.Create{className}({varName});");
			output.AddLine();
			output.AddLine(tc+2, "svcResponse.Message = \"Success\";");
			output.AddLine(tc+2, "return Ok(svcResponse);");
			output.AddLine();
			output.AddLine(tc+1, "} catch (Exception ex) {");
			output.AddLine(tc+2, "return LogErrorAndReturnErrorResponse(ex);");
			output.AddLine(tc+1, "}");
			output.AddLine(tc, "}");
		}

		if (entity.Service.InclUpdate) {
			output.AddLine();
			output.AddLine(tc, $"[HttpPatch, Route(\"[action]\")]");
			output.AddLine(tc, $"public async Task<ActionResult> Update{className}({className} {varName})");
			output.AddLine(tc, "{");
			output.AddLine(tc+1, "try {");
			output.AddLine(tc+2, "var svcResponse =new ServiceResponse();");
			output.AddLine();
			output.AddLine(tc+2, $"await _{svcVarName}.Update{className}({varName});");
			output.AddLine();
			output.AddLine(tc+2, "svcResponse.Message = \"Success\";");
			output.AddLine(tc+2, "return Ok(svcResponse);");
			output.AddLine();
			output.AddLine(tc+1, "} catch (Exception ex) {");
			output.AddLine(tc+2, "return LogErrorAndReturnErrorResponse(ex);");
			output.AddLine(tc+1, "}");
			output.AddLine(tc, "}");
		}

		if (entity.Service.InclDelete) {
			output.AddLine();
			output.AddLine(tc, $"[HttpPost, Route(\"[action]\")]");
			output.AddLine(tc, $"public async Task<ActionResult> Delete{className}(Guid id)");
			output.AddLine(tc, "{");
			output.AddLine(tc+1, "try {");
			output.AddLine(tc+2, "var svcResponse =new ServiceResponse();");
			output.AddLine();
			output.AddLine(tc+2, $"await _{svcVarName}.Delete{className}(id);");
			output.AddLine();
			output.AddLine(tc+2, "svcResponse.Message = \"Success\";");
			output.AddLine(tc+2, "return Ok(svcResponse);");
			output.AddLine();
			output.AddLine(tc+1, "} catch (Exception ex) {");
			output.AddLine(tc+2, "return LogErrorAndReturnErrorResponse(ex);");
			output.AddLine(tc+1, "}");
			output.AddLine(tc, "}");
		}
	}

	private void GenerateSingleControllerMethod(EntityModel entity, GetSvcMethodModel method, string svcVarName, List<string> output)
	{
		var tc = 1;
		output.AddLine();

		// Attributes
		if (method.Attributes.Any())
			foreach (var attr in method.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Method
		output.AddLine(tc, $"[HttpGet, Route(\"[action]/{{{method.ArgName}}}\")]");
		output.AddLine(tc, $"public async Task<ActionResult<{entity.Name}>> {method.Name}({method.ArgType} {method.ArgName})");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "try {");
		output.AddLine(tc + 2, $"return await _{svcVarName}.{method.Name}({method.ArgName});");
		output.AddLine(tc + 1, "} catch (Exception ex) {");
		output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(ex);");
		output.AddLine(tc + 1, "}");
		output.AddLine(tc, "}");
	}

	private void GenerateListControllerMethod(EntityModel entity, GetSvcMethodModel method, string svcVarName, List<string> output)
	{
		var tc = 1;
		output.AddLine();

		// Attributes
		if (method.Attributes.Any())
			foreach (var attr in method.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Method
		string varUriSegment = null;
		string argDecl = null;
		if (!string.IsNullOrWhiteSpace(method.ArgName)) {
			varUriSegment = $"/{{{method.ArgName}}}";
			argDecl = $"{method.ArgType} {method.ArgName}";
		}

		var argSep = (argDecl != null && method.InclPaging) ? ", " : null;

		var pagingRoute = method.InclPaging ? $"/{{pageSize?}}/{{rowOffset?}}" : null;
		var pagingArgs = method.InclPaging ? "int pageSize = 0, int rowOffset = 0" : null;
		var pagingVars = method.InclPaging ? "pageSize, rowOffset" : null;

		output.AddLine(tc, $"[HttpGet, Route(\"[action]{varUriSegment}{pagingRoute}\")]");
		output.AddLine(tc, $"public async Task<ActionResult<List<{entity.Name}>>> {method.Name}({argDecl}{argSep}{pagingArgs})");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "try {");
		output.AddLine(tc + 2, $"return await _{svcVarName}.{method.Name}({method.ArgName}{argSep}{pagingVars});");
		output.AddLine(tc + 1, "} catch (Exception ex) {");
		output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(ex);");
		output.AddLine(tc + 1, "}");
		output.AddLine(tc, "}");
	}

	private void GenerateQueryControllerMethod(EntityModel entity, QuerySvcMethodModel queryMethod, string svcVarName, List<string> output)
	{
		var tc = 1;
		output.AddLine();
		var queryClassName = $"{queryMethod.Name}Query";
		var queryVarName = Utils.ToCamelCase(queryClassName);

		// Attributes
		if (queryMethod.Attributes.Any())
			foreach (var attr in queryMethod.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Method
		output.AddLine(tc, "[HttpPost, Route(\"[action]\")]");
		output.AddLine(tc, $"public async Task<ActionResult<EntityList<{entity.Name}>>> {queryMethod.Name}([FromBody] {queryClassName} {queryVarName})");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "try {");
		output.AddLine(tc + 2, $"return await _{svcVarName}.{queryMethod.Name}({queryVarName});");
		output.AddLine(tc + 1, "} catch (Exception ex) {");
		output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(ex);");
		output.AddLine(tc + 1, "}");
		output.AddLine(tc, "}");
	}

	private string ReplaceControllerTemplateTokens(string template, List<string> addlUsings, string controllersNamespace, string controllerName, string serviceName, string serviceVarName, List<string> crudMethodsOutput, List<string> singleMethodsOutput, List<string> listMethodsOutput, List<string> queryMethodsOutput)
	{
		// Header
		template = template.Replace(Utils.FmtToken(cToken_CurrTimestamp), DateTime.Now.ToString("g"));

		// Addl Usings
		var sb = new StringBuilder();
		addlUsings.ForEach(x => {
			if (sb.Length > 0)
				sb.AppendLine();
			sb.Append($"using {x};");
		});
		template = template.Replace(Utils.FmtToken(cToken_AddlUsings), sb.ToString());

		// Various
		template = template.Replace(Utils.FmtToken(cToken_ControllersNs), controllersNamespace);
		template = template.Replace(Utils.FmtToken(cToken_ControllerName), controllerName);
		template = template.Replace(Utils.FmtToken(cToken_ServiceName), serviceName);
		template = template.Replace(Utils.FmtToken(cToken_ServiceVarName), serviceVarName);

		// CUD Methods
		sb = new StringBuilder();
		crudMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_CudControllerMethods), sb.ToString());

		// Single Methods
		sb = new StringBuilder();
		singleMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_SingleMethods), sb.ToString());

		// List Methods
		sb = new StringBuilder();
		listMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_ListMethods), sb.ToString());

		// Query Methods
		sb = new StringBuilder();
		queryMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_QueryMethods), sb.ToString());

		return template;
	}

	#endregion

	#region Utility methods

	private List<string> BuildAddlUsings(ObservableCollection<string> attrs)
	{
		var usings = new List<string>();
		attrs?.ToList().ForEach(a => usings.Add(a));
		return usings;
	}

	#endregion
}
