//using Dyvenix.Genit.Extensions;
//using Dyvenix.Genit.Misc;
//using Dyvenix.Genit.Models.Generators;
//using Dyvenix.Genit.Models.Services;
//using Dyvenix.Genit.Models;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dyvenix.Genit.Generators;

//internal class ServiceClientGenerator
//{
//	private const string cToken_CurrTimestamp = "CURR_TIMESTAMP";
//	private const string cToken_AddlUsings = "ADDL_USINGS";
//	private const string cToken_ApiClientsNs = "API_CLIENTS_NS";
//	private const string cToken_ApiClientName = "API_CLIENT_NAME";
//	private const string cToken_IntfSignatures = "INTERFACE_SIGNATURES";
//	private const string cToken_ServiceVarName = "SERVICE_VAR_NAME";
//	private const string cToken_CudControllerMethods = "CUD_METHODS";
//	private const string cToken_SingleMethods = "SINGLE_METHODS";
//	private const string cToken_ListMethods = "LIST_METHODS";
//	private const string cToken_QueryMethods = "QUERY_METHODS";

//	private void GenerateApiClient(EntityModel entity, ServiceGenModel serviceGen, string template, string outputFolder, string servicesNamespace, string queriesNamespace)
//	{
//		var serviceName = $"{entity.Name}ApiClient";

//		// Addl usings
//		var addlUsings = Utils.BuildAddlUsingsList(entity.Service.AddlServiceUsings);
//		addlUsings.AddIfNotExists(queriesNamespace);

//		// Interface signatures
//		var interfaceOutput = new List<string>();

//		// Create/Update/Delete
//		var crudMethodsOutput = new List<string>();
//		if (entity.Service.InclCreate || entity.Service.InclUpdate || entity.Service.InclDelete)
//			this.GenerateCUDMethods(entity, crudMethodsOutput, interfaceOutput);

//		// GetSingle methods
//		var singleMethodsOutput = new List<string>();
//		foreach (GetSvcMethodModel singleMethod in entity.Service.GetMethods.Where(m => !m.IsList))
//			this.GenerateSingleMethod(entity, singleMethod, singleMethodsOutput, interfaceOutput);

//		// Get list methods
//		var listMethodsOutput = new List<string>();
//		foreach (GetSvcMethodModel listMethod in entity.Service.GetMethods.Where(m => m.IsList))
//			this.GenerateListMethod(entity, listMethod, listMethodsOutput, interfaceOutput);

//		// Query methods
//		var queryMethodsOutput = new List<string>();
//		if (entity.Service.QueryMethods.Any()) {
//			queryMethodsOutput.AddLine(1, "#region Queries");

//			foreach (QuerySvcMethodModel queryMethod in entity.Service.QueryMethods)
//				this.GenerateQueryMethod(entity, queryMethod, queryMethodsOutput, interfaceOutput);

//			// Sorting method
//			this.GenerateSortingMethod(entity, queryMethodsOutput);
//			queryMethodsOutput.AddLine();
//			queryMethodsOutput.AddLine(1, "#endregion");
//		}

//		// Replace tokens in template
//		var fileContents = ReplaceServiceTemplateTokens(template, serviceName, addlUsings, crudMethodsOutput, singleMethodsOutput, listMethodsOutput, queryMethodsOutput, interfaceOutput, servicesNamespace);

//		var outputFile = Path.Combine(outputFolder, $"{serviceName}.cs");
//		if (File.Exists(outputFile))
//			File.Delete(outputFile);
//		File.WriteAllText(outputFile, fileContents);
//	}

//	private void GenerateCUDMethods(EntityModel entity, List<string> output, List<string> interfaceOutput)
//	{
//		var tc = 1;
//		var className = entity.Name;
//		var varName = Utils.ToCamelCase(className);

//		output.AddLine(tc, "// Create / Update / Delete");

//		if (entity.Service.InclCreate) {
//			// Interface
//			var signature = $"Task Create{className}({className} {varName})";
//			interfaceOutput.Add(signature);

//			output.AddLine();
//			output.AddLine(tc, $"public async {signature}");
//			output.AddLine(tc, "{");
//			output.AddLine(tc + 1, $"if ({varName} == null)");
//			output.AddLine(tc + 2, $"throw new ArgumentNullException(nameof({varName}));");
//			output.AddLine();
//			output.AddLine(tc + 1, $"using var db = _dbContextFactory.CreateDbContext();");
//			output.AddLine(tc + 1, $"db.Add({varName});");
//			output.AddLine();
//			output.AddLine(tc + 1, $"await db.SaveChangesAsync();");
//			output.AddLine(tc, "}");
//		}

//		if (entity.Service.InclUpdate) {
//			// Interface
//			var signature = $"Task Update{className}({className} {varName})";
//			interfaceOutput.Add(signature);

//			output.AddLine();
//			output.AddLine(tc, $"public async {signature}");
//			output.AddLine(tc, "{");
//			output.AddLine(tc + 1, $"if ({varName} == null)");
//			output.AddLine(tc + 2, $"throw new ArgumentNullException(nameof({varName}));");
//			output.AddLine();
//			output.AddLine(tc + 1, $"using var db = _dbContextFactory.CreateDbContext();");
//			output.AddLine(tc + 1, $"db.Attach({varName});");
//			output.AddLine(tc + 1, $"db.Entry({varName}).State = EntityState.Modified;");
//			output.AddLine();
//			output.AddLine(tc + 1, $"await db.SaveChangesAsync();");
//			output.AddLine(tc, "}");
//		}

//		if (entity.Service.InclDelete) {
//			// Interface
//			var signature = $"Task Delete{className}(Guid id)";
//			interfaceOutput.Add(signature);

//			output.AddLine();
//			output.AddLine(tc, $"public async {signature}");
//			output.AddLine(tc, "{");
//			output.AddLine(tc + 1, $"using var db = _dbContextFactory.CreateDbContext();");
//			output.AddLine(tc + 1, $"await db.{className}.Where(a => a.Id == id).ExecuteDeleteAsync();");
//			output.AddLine(tc, "}");
//		}
//	}

//	private void GenerateSingleMethod(EntityModel entity, GetSvcMethodModel method, List<string> output, List<string> interfaceOutput)
//	{
//		var tc = 1;
//		output.AddLine();

//		// Attributes
//		if (method.Attributes.Any())
//			foreach (var attr in method.Attributes)
//				output.AddLine(tc, $"[{attr}]");

//		// Interface
//		var signature = $"Task<{entity.Name}>{method.Name}({method.ArgType} {method.ArgName})";
//		interfaceOutput.Add(signature);

//		// Method
//		output.AddLine(tc, $"public async {signature}");
//		output.AddLine(tc, "{");
//		output.AddLine(tc + 1, "var db = _dbContextFactory.CreateDbContext();");
//		output.AddLine(tc + 1, $"return await db.{entity.Name}.FirstOrDefaultAsync(x => x.{method.PropName} == {method.ArgName});");
//		output.AddLine(tc, "}");
//	}

//	private void GenerateListMethod(EntityModel entity, GetSvcMethodModel method, List<string> output, List<string> interfaceOutput)
//	{
//		var tc = 1;
//		output.AddLine();

//		// Attributes
//		if (method.Attributes.Any())
//			foreach (var attr in method.Attributes)
//				output.AddLine(tc, $"[{attr}]");

//		// Interface
//		var sbArgs = new StringBuilder();

//		// Paging
//		if (!string.IsNullOrWhiteSpace(method.ArgType))
//			sbArgs.Append($"{method.ArgType} {method.ArgName}");
//		if (method.InclPaging) {
//			if (sbArgs.Length > 0)
//				sbArgs.Append(", ");
//			sbArgs.Append("int pageSize, int rowOffset");
//		}
//		var signature = $"Task<List<{entity.Name}>>{method.Name}({sbArgs.ToString()})";
//		interfaceOutput.Add(signature);

//		// Method
//		output.AddLine(tc, $"public async {signature}");
//		output.AddLine(tc, "{");
//		output.AddLine(tc + 1, $"var dbQuery = _dbContextFactory.CreateDbContext().{entity.Name}.AsQueryable();");
//		output.AddLine();

//		if (!string.IsNullOrWhiteSpace(method.ArgType)) {
//			var indent = tc + 1;
//			if (method.FilterProperty.PrimitiveType == PrimitiveType.String) {
//				output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace({method.ArgName}))");
//				indent++;
//			} else if (method.FilterProperty.Nullable) {
//				output.AddLine(tc + 1, $"if ({method.ArgName} != null)");
//				indent++;
//			}
//			output.AddLine(indent, $"dbQuery = dbQuery.Where(x => EF.Functions.Like(x.{method.PropName}, {method.ArgName}));");
//			output.AddLine();
//		}

//		if (method.InclPaging) {
//			output.AddLine(tc + 1, $"if (pageSize > 0)");
//			output.AddLine(tc + 2, $"dbQuery = dbQuery.Skip(rowOffset).Take(pageSize);");
//			output.AddLine();
//		}

//		output.AddLine(tc + 1, $"return await dbQuery.AsNoTracking().ToListAsync();");

//		output.AddLine(tc, "}");
//	}

//	private void GenerateQueryMethod(EntityModel entity, QuerySvcMethodModel queryMethod, List<string> output, List<string> interfaceOutput)
//	{
//		var tc = 1;
//		output.AddLine();
//		var queryClassName = $"{queryMethod.Name}Query";
//		//var queryVarName = Utils.ToCamelCase(queryClassName);

//		// Attributes
//		if (queryMethod.Attributes.Any())
//			foreach (var attr in queryMethod.Attributes)
//				output.AddLine(tc, $"[{attr}]");

//		// Interface
//		var signature = $"Task<EntityList<{entity.Name}>>{queryMethod.Name}({queryClassName} query)";
//		interfaceOutput.Add(signature);

//		// Method
//		output.AddLine(tc, $"public async {signature}");
//		output.AddLine(tc, "{");
//		output.AddLine(tc + 1, $"var dbQuery = _dbContextFactory.CreateDbContext().{entity.Name}.AsQueryable();");
//		output.AddLine(tc + 1, $"var result = new EntityList<{entity.Name}>();");
//		output.AddLine();

//		output.AddLine(tc + 1, $"// Filters");
//		foreach (var prop in queryMethod.FilterProperties) {
//			if (prop.PrimitiveType == PrimitiveType.String) {
//				output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace(query.{prop.Name}))");
//				output.AddLine(tc + 2, $"dbQuery = dbQuery.Where(x => EF.Functions.Like(x.{prop.Name}, query.{prop.Name}));");
//			} else if (prop.PrimitiveType == PrimitiveType.Int || prop.PrimitiveType == PrimitiveType.Bool || prop.PrimitiveType == PrimitiveType.Guid) {
//				output.AddLine(tc + 1, $"if (query.{prop.Name}.HasValue)");
//				output.AddLine(tc + 2, $"dbQuery = dbQuery.Where(x => x.{prop.Name} == query.{prop.Name});");
//			}
//		}

//		if (queryMethod.InclPaging) {
//			output.AddLine();
//			output.AddLine(tc + 1, "// Paging");
//			output.AddLine(tc + 1, "if (query.RecalcRowCount || query.GetRowCountOnly)");
//			output.AddLine(tc + 2, "result.TotalRowCount = dbQuery.Count();");
//			output.AddLine(tc + 1, "if (query.GetRowCountOnly)");
//			output.AddLine(tc + 2, "return result;");
//			output.AddLine(tc + 1, "if (query.PageSize > 0)");
//			output.AddLine(tc + 2, "dbQuery = dbQuery.Skip(query.RowOffset).Take(query.PageSize);");
//		}

//		if (queryMethod.InclSorting) {
//			output.AddLine();
//			output.AddLine(tc + 1, "// Sorting");
//			output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace(query.SortBy))");
//			output.AddLine(tc + 2, $"this.AddSorting(ref dbQuery, query);");
//		}

//		output.AddLine();
//		output.AddLine(tc + 1, "result.Data = await dbQuery.AsNoTracking().ToListAsync();");
//		output.AddLine();
//		output.AddLine(tc + 1, "return result;");
//		output.AddLine(tc, "}");
//	}

//	private void GenerateSortingMethod(EntityModel entity, List<string> output)
//	{
//		var tc = 1;
//		output.AddLine();

//		// Method
//		output.AddLine(tc, $"private void AddSorting(ref IQueryable<{entity.Name}> dbQuery, ISortingQuery sortingQuery)");
//		output.AddLine(tc, "{");

//		var c = 0;
//		foreach (var prop in entity.Properties) {
//			if (c++ > 0)
//				output.AddLine();

//			output.AddLine(tc + 1, $"if (string.Equals(sortingQuery.SortBy, {entity.Name}.PropNames.{prop.Name}, StringComparison.OrdinalIgnoreCase))");
//			output.AddLine(tc + 2, "if (sortingQuery.SortDesc)");
//			output.AddLine(tc + 3, $"dbQuery.OrderByDescending(x => x.{prop.Name});");
//			output.AddLine(tc + 2, "else");
//			output.AddLine(tc + 3, $"dbQuery.OrderBy(x => x.{prop.Name});");
//		}
//		output.AddLine(tc, "}");
//	}

//	private string ReplaceServiceTemplateTokens(string template, string serviceName, List<string> addlUsings, List<string> crudMethodsOutput, List<string> singleMethodsOutput, List<string> listMethodsOutput, List<string> queryMethodsOutput, List<string> interfaceOutput, string servicesNamespace)
//	{
//		// Header
//		template = template.Replace(Utils.FmtToken(cToken_CurrTimestamp), DateTime.Now.ToString("g"));

//		// Namespace
//		template = template.Replace(Utils.FmtToken(cToken_ServicesNs), servicesNamespace);

//		// Usings
//		var sb = new StringBuilder();
//		addlUsings.ForEach(x => {
//			if (sb.Length > 0)
//				sb.AppendLine();
//			sb.Append($"using {x};");
//		});
//		template = template.Replace(Utils.FmtToken(cToken_AddlUsings), sb.ToString());

//		// Interface
//		sb = new StringBuilder();
//		interfaceOutput.ForEach(x => {
//			if (sb.Length > 0)
//				sb.AppendLine();
//			sb.Append($"\t{x};");
//		});
//		template = template.Replace(Utils.FmtToken(cToken_IntfSignatures), sb.ToString());

//		// Service name
//		template = template.Replace(Utils.FmtToken(cToken_ServiceName), serviceName);

//		// cToken_IntfSignatures

//		// CRUD Methods
//		sb = new StringBuilder();
//		crudMethodsOutput.ForEach(x => sb.AppendLine(x));
//		template = template.Replace(Utils.FmtToken(cToken_CudMethods), sb.ToString());

//		// Single Methods
//		sb = new StringBuilder();
//		singleMethodsOutput.ForEach(x => sb.AppendLine(x));
//		template = template.Replace(Utils.FmtToken(cToken_SingleMethods), sb.ToString());

//		// List Methods
//		sb = new StringBuilder();
//		listMethodsOutput.ForEach(x => sb.AppendLine(x));
//		template = template.Replace(Utils.FmtToken(cToken_ListMethods), sb.ToString());

//		// Query Methods
//		sb = new StringBuilder();
//		queryMethodsOutput.ForEach(x => sb.AppendLine(x));
//		template = template.Replace(Utils.FmtToken(cToken_QueryMethods), sb.ToString());

//		return template;
//	}
//}
