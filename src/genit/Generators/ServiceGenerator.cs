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

namespace Dyvenix.Genit.Generators;

public class ServiceGenerator
{
	#region Constants

	private const string cToken_CurrTimestamp = "CURR_TIMESTAMP";
	private const string cToken_AddlUsings = "ADDL_USINGS";

	private const string cToken_ServicesNs = "SERVICES_NS";
	private const string cToken_ServiceName = "SERVICE_NAME";
	private const string cToken_IntfSignatures = "INTERFACE_SIGNATURES";
	private const string cToken_SingleMethods = "SINGLE_METHODS";
	private const string cToken_ListMethods = "LIST_METHODS";
	private const string cToken_QueryMethods = "QUERY_METHODS";

	private const string cToken_QueriesNs = "QUERIES_NS";
	private const string cToken_QueryClassName = "QUERY_CLASS_NAME";
	private const string cToken_FilterProps = "FILTER_PROPERTIES";

	private const string cToken_ControllersNs = "CONTROLLERS_NS";
	private const string cToken_ControllerName = "CONTROLLER_NAME";
	private const string cToken_ServiceVarName = "SERVICE_VAR_NAME";

	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.Entity;

	#endregion

	public void Run(ServiceGenModel svcGenModel, ObservableCollection<ServiceModel> services, string servicesNamespace, string queriesNamespace, string controllersNamespace, string entitiesNamespace)
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

		foreach (var service in services.Where(e => e.Enabled)) {
			// Generate service class
			GenerateService(service, svcGenModel, $"{serviceTemplate}", outputFolder, servicesNamespace, queriesNamespace);

			// Generate query classes
			foreach (var queryMethod in service.QueryMethods) {
				GenerateQueryClass(service, svcGenModel, $"{queryTemplate}", queryOutputFolder, queriesNamespace);
			}

			// Generate controller
			if (service.InclController)
				GenerateController(service, svcGenModel, $"{controllerTemplate}", controllersOutputFolder, controllersNamespace, servicesNamespace, queriesNamespace, entitiesNamespace);
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

	private void GenerateService(ServiceModel service, ServiceGenModel serviceGen, string template, string outputFolder, string servicesNamespace, string queriesNamespace)
	{
		var serviceName = $"{service.Entity.Name}Service";

		// Addl usings
		var addlUsings = BuildAddlUsings(service);
		addlUsings.AddIfNotExists(queriesNamespace);

		// Interface signatures
		var interfaceOutput = new List<string>();

		// GetSingle methods
		var singleMethodsOutput = new List<string>();
		foreach (GetSvcMethodModel singleMethod in service.GetMethods.Where(m => !m.IsList))
			this.GenerateSingleMethod(service.Entity, singleMethod, singleMethodsOutput, interfaceOutput);

		// Get list methods
		var listMethodsOutput = new List<string>();
		foreach (GetSvcMethodModel listMethod in service.GetMethods.Where(m => m.IsList))
			this.GenerateListMethod(service.Entity, listMethod, listMethodsOutput, interfaceOutput);

		// Query methods
		var queryMethodsOutput = new List<string>();
		if (service.QueryMethods.Any()) {
			queryMethodsOutput.AddLine(1, "#region Queries");

			foreach (QuerySvcMethodModel queryMethod in service.QueryMethods)
				this.GenerateQueryMethod(service.Entity, queryMethod, queryMethodsOutput, interfaceOutput);

			// Sorting method
			this.GenerateSortingMethod(service.Entity, queryMethodsOutput);
			queryMethodsOutput.AddLine();
			queryMethodsOutput.AddLine(1, "#endregion");
		}

		// Replace tokens in template
		var fileContents = ReplaceServiceTemplateTokens(template, serviceName, addlUsings, singleMethodsOutput, listMethodsOutput, queryMethodsOutput, interfaceOutput, servicesNamespace);

		var outputFile = Path.Combine(outputFolder, $"{serviceName}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
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
		var args = !string.IsNullOrWhiteSpace(method.ArgType) ? $"{method.ArgType} {method.ArgName}" : null;
		var signature = $"Task<List<{entity.Name}>>{method.Name}({args})";
		interfaceOutput.Add(signature);

		// Method
		output.AddLine(tc, $"public async {signature}");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "var db = _dbContextFactory.CreateDbContext();");

		var whereClause = !string.IsNullOrWhiteSpace(method.ArgType) ? $".Where(x => x.{method.PropName} == {method.ArgName})" : string.Empty;
		output.AddLine(tc + 1, $"return await db.{entity.Name}{whereClause}.AsNoTracking().ToListAsync();");

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
		output.AddLine(tc + 1, $"var dbQuery = _dbContextFactory.CreateDbContext().{entity.Name}.AsNoTracking().AsQueryable();");
		output.AddLine(tc + 1, $"var result = new EntityList<{entity.Name}>();");
		output.AddLine();

		output.AddLine(tc + 1, $"// Filters");
		foreach (var prop in queryMethod.FilterProperties) {
			if (prop.PrimitiveType == PrimitiveType.String) {
				output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace(query.{prop.Name}))");
				output.AddLine(tc + 2, $"dbQuery = dbQuery.Where(x => EF.Functions.Like(x.{prop.Name}, query.{prop.Name}));");
			} else if (prop.PrimitiveType == PrimitiveType.Int || prop.PrimitiveType == PrimitiveType.Bool || prop.PrimitiveType == PrimitiveType.Guid) {
				var indent = tc + 1;
				if (prop.Nullable) {
					output.AddLine(tc + 1, $"if ({prop.Name}.HasValue)");
					indent++;
				}
				output.AddLine(indent, $"dbQuery = dbQuery.Where(x => x.{prop.Name} == query.{prop.Name});");
			}
		}

		output.AddLine();
		output.AddLine(tc + 1, "// Sorting");
		output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace(query.SortBy))");
		output.AddLine(tc + 1, $"this.AddSorting(ref dbQuery, query);");
		output.AddLine();

		output.AddLine(tc + 1, "// Paging");
		output.AddLine(tc + 1, "dbQuery = dbQuery.Skip(query.RowOffset).Take(query.PageSize);");
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

	private string ReplaceServiceTemplateTokens(string template, string serviceName, List<string> addlUsings, List<string> singleMethodsOutput, List<string> listMethodsOutput, List<string> queryMethodsOutput, List<string> interfaceOutput, string servicesNamespace)
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

		// Service name
		template = template.Replace(Utils.FmtToken(cToken_ServiceName), serviceName);

		// cToken_IntfSignatures

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
			// Addl usings
			var addlUsings = BuildAddlUsings(service);
			var className = $"{queryMethod.Name}Query";

			var propsOutput = new List<string>();
			foreach (var filterProp in queryMethod.FilterProperties) {
				propsOutput.AddLine(1, $"public {filterProp.DatatypeName} {filterProp.Name} {{ get; set; }}");
			}

			// Replace tokens in template
			var fileContents = ReplaceQueryTemplateTokens(template, className, addlUsings, queriesNamespace, propsOutput);

			var outputFile = Path.Combine(outputFolder, $"{className}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, fileContents);
		}
	}

	private string ReplaceQueryTemplateTokens(string template, string className, List<string> addlUsings, string queriesNamespace, List<string> propsOutput)
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

		// Filter properties
		sb = new StringBuilder();
		propsOutput.ForEach(x => sb.AppendLine(x));
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_FilterProps), sb.ToString());

		return fileContents;
	}

	#endregion

	#region Controllers

	private void GenerateController(ServiceModel service, ServiceGenModel serviceGen, string template, string outputFolder, string controllersNamespace, string servicesNamespace, string queriesNamespace, string entitiesNamespace)
	{
		var controllerName = $"{service.Entity.Name}Controller";
		var serviceName = $"{service.Entity.Name}Service";
		var serviceVarName = Utils.ToCamelCase(serviceName);

		// Addl usings
		var addlUsings = BuildAddlUsings(service);
		addlUsings.AddIfNotExists(servicesNamespace);
		addlUsings.AddIfNotExists(queriesNamespace);
		addlUsings.AddIfNotExists(entitiesNamespace);

		// GetSingle methods
		var singleMethodsOutput = new List<string>();
		foreach (GetSvcMethodModel singleMethod in service.GetMethods.Where(m => !m.IsList))
			this.GenerateSingleControllerMethod(service.Entity, singleMethod, serviceVarName, singleMethodsOutput);

		// Get list methods
		var listMethodsOutput = new List<string>();
		foreach (GetSvcMethodModel listMethod in service.GetMethods.Where(m => m.IsList))
			this.GenerateListControllerMethod(service.Entity, listMethod, serviceVarName, listMethodsOutput);

		// Query methods
		var queryMethodsOutput = new List<string>();
		var sortingMethodOutput = new List<string>();
		if (service.QueryMethods.Any()) {
			queryMethodsOutput.AddLine();
			queryMethodsOutput.AddLine(1, "#region Queries");
			foreach (QuerySvcMethodModel queryMethod in service.QueryMethods)
				this.GenerateQueryControllerMethod(service.Entity, queryMethod, serviceVarName, queryMethodsOutput);
			queryMethodsOutput.AddLine();
			queryMethodsOutput.AddLine(1, "#endregion");
		}

		// Replace tokens in template
		var fileContents = ReplaceControllerTemplateTokens(template, addlUsings, controllersNamespace, controllerName, serviceName, serviceVarName, singleMethodsOutput, listMethodsOutput, queryMethodsOutput);

		var outputFile = Path.Combine(outputFolder, $"{controllerName}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
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
		output.AddLine(tc, $"[HttpGet, Route(\"[action]{varUriSegment}\")]");
		output.AddLine(tc, $"public async Task<ActionResult<List<{entity.Name}>>> {method.Name}({argDecl})");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "try {");
		output.AddLine(tc + 2, $"return await _{svcVarName}.{method.Name}({method.ArgName});");
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
		output.AddLine(tc, $"public async Task<ActionResult<EntityList<{entity.Name}>>> Query([FromBody] {queryClassName} {queryVarName})");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "try {");
		output.AddLine(tc + 2, $"return await _{svcVarName}.{queryMethod.Name}({queryVarName});");
		output.AddLine(tc + 1, "} catch (Exception ex) {");
		output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(ex);");
		output.AddLine(tc + 1, "}");
		output.AddLine(tc, "}");
	}

	private string ReplaceControllerTemplateTokens(string template, List<string> addlUsings, string controllersNamespace, string controllerName, string serviceName, string serviceVarName, List<string> singleMethodsOutput, List<string> listMethodsOutput, List<string> queryMethodsOutput)
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

	private List<string> BuildAddlUsings(ServiceModel service)
	{
		var usings = new List<string>();

		service.AddlUsings?.ToList().ForEach(u => usings.Add(u));

		return usings;
	}

	#endregion
}
