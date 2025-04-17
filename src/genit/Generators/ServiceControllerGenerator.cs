using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

internal class ServiceControllerGenerator
{
	private const string cToken_AddlUsings = "ADDL_USINGS";
	private const string cToken_ControllersNs = "CONTROLLERS_NS";
	private const string cToken_ControllerAttrs = "CONTROLLER_ATTRS";
	private const string cToken_ControllerVersion = "CONTROLLER_VERSION";
	private const string cToken_ControllerName = "CONTROLLER_NAME";
	private const string cToken_ServiceName = "SERVICE_NAME";
	private const string cToken_EntityName = "SERVICE_NAME";
	private const string cToken_ServiceVarName = "SERVICE_VAR_NAME";
	private const string cToken_CudControllerMethods = "CUD_METHODS";
	private const string cToken_UpdControllerMethods = "UPDATE_METHODS";
	private const string cToken_SingleMethods = "SINGLE_METHODS";
	private const string cToken_ListMethods = "LIST_METHODS";
	private const string cToken_QueryMethods = "QUERY_METHODS";

	internal void GenerateController(EntityModel entity, ServiceGenModel serviceGen, string template, string outputFolder, string entitiesNamespace)
	{
		var controllerName = $"{entity.Name}Controller";
		var serviceName = $"{entity.Name}Service";
		var serviceVarName = Utils.ToCamelCase(serviceName);

		// Addl usings
		var addlUsings = Utils.BuildAddlUsingsList(entity.Service.AddlControllerUsings);
		addlUsings.AddIfNotExists(serviceGen.ServicesNamespace);
		addlUsings.AddIfNotExists(serviceGen.QueriesNamespace);
		addlUsings.AddIfNotExists(entitiesNamespace);
		if (entity.Service.UpdateMethods.Any())
			addlUsings.AddIfNotExists(serviceGen.DtoNamespace);

		// Attributes
		var attrsOutput = new List<string>();
		foreach (var attr in entity.Service.ServiceClassAttributes)
			attrsOutput.Add($"[{attr}]");

		// Create/Update/Delete
		var cudMethodsOutput = new List<string>();
		if (entity.Service.InclCreate || entity.Service.InclUpdate || entity.Service.InclDelete)
			this.GenerateCUDControllerMethods(entity, serviceVarName, cudMethodsOutput);

		// Update methods
		var updMethodsOutput = new List<string>();
		foreach (UpdateMethodModel updMethod in entity.Service.UpdateMethods) {
			if (updMethodsOutput.Count > 0)
				updMethodsOutput.AddLine();
			this.GenerateUpdateMethod(entity, updMethod, serviceVarName, updMethodsOutput);
		}

		// Read methods - single
		var singleMethodsOutput = new List<string>();
		foreach (ReadMethodModel singleMethod in entity.Service.ReadMethods.Where(m => !m.IsList)) {
			if (singleMethodsOutput.Count > 0)
				singleMethodsOutput.AddLine();
			this.GenerateSingleControllerMethod(entity, singleMethod, serviceVarName, singleMethodsOutput);
		}

		// Read methods - list
		var listMethodsOutput = new List<string>();
		foreach (ReadMethodModel listMethod in entity.Service.ReadMethods.Where(m => m.IsList && !m.UseQuery)) {
			if (singleMethodsOutput.Count > 0)
				singleMethodsOutput.AddLine();
			this.GenerateListControllerMethod(entity, listMethod, serviceVarName, listMethodsOutput);
		}

		// Read methods - query
		var queryMethodsOutput = new List<string>();
		var sortingMethodOutput = new List<string>();
		if (entity.Service.ReadMethods.Any(m => m.UseQuery)) {
			queryMethodsOutput.AddLine();
			queryMethodsOutput.AddLine(1, "#region Queries");
			foreach (ReadMethodModel queryMethod in entity.Service.ReadMethods.Where(m => m.UseQuery))
				this.GenerateQueryControllerMethod(entity, queryMethod, serviceVarName, queryMethodsOutput);
			queryMethodsOutput.AddLine();
			queryMethodsOutput.AddLine(1, "#endregion");
		}

		// Replace tokens in template
		var fileContents = ReplaceControllerTemplateTokens(template, addlUsings, attrsOutput, entity.Service.ControllerVersion, serviceGen.ControllersNamespace, controllerName, serviceName, serviceVarName, cudMethodsOutput, updMethodsOutput, singleMethodsOutput, listMethodsOutput, queryMethodsOutput, entity.Name);

		var outputFile = Path.Combine(outputFolder, $"{controllerName}.g.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	internal void GenerateCUDControllerMethods(EntityModel entity, string svcVarName, List<string> output)
	{
		var tc = 1;
		var className = entity.Name;
		var varName = Utils.ToCamelCase(className);

		output.AddLine(tc, "// Update methods");

		if (entity.Service.InclCreate) {
			output.AddLine();
			output.AddLine(tc, $"[HttpPost, Route(\"[action]\")]");
			output.AddLine(tc, $"public async Task<ActionResult> Create{className}({className} {varName})");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, "var apiResponse = CreateApiResponse<Guid>();");
			output.AddLine(tc + 1, "try {");
			output.AddLine(tc + 2, $"apiResponse.Data = await _{svcVarName}.Create{className}({varName});");
			output.AddLine();
			output.AddLine(tc + 2, "return Ok(apiResponse);");
			output.AddLine();
			output.AddLine(tc + 1, "} catch (Exception ex) {");
			output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(apiResponse, ex);");
			output.AddLine(tc + 1, "}");
			output.AddLine(tc, "}");
		}

		if (entity.Service.InclUpdate) {
			output.AddLine();
			output.AddLine(tc, $"[HttpPut, Route(\"[action]\")]");
			output.AddLine(tc, $"public async Task<ActionResult> Update{className}({className} {varName})");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, $"var apiResponse = CreateApiResponse<byte[]>();");
			output.AddLine(tc + 1, "try {");
			if (entity.InclRowVersion) {
				output.AddLine(tc + 2, $"apiResponse.Data = await _{svcVarName}.Update{className}({varName});");
			} else {
				output.AddLine(tc + 2, $"var apiResponse =new ApiResponse();");
				output.AddLine();
				output.AddLine(tc + 2, $"await _{svcVarName}.Update{className}({varName});");
			}
			output.AddLine();
			output.AddLine(tc + 2, "return Ok(apiResponse);");
			output.AddLine();
			output.AddLine(tc + 1, "} catch (Exception ex) {");
			output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(apiResponse, ex);");
			output.AddLine(tc + 1, "}");
			output.AddLine(tc, "}");
		}

		if (entity.Service.InclDelete) {
			output.AddLine();
			output.AddLine(tc, $"[HttpPost, Route(\"[action]\")]");
			output.AddLine(tc, $"public async Task<ActionResult> Delete{className}(Guid id)");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, "var apiResponse = CreateApiResponse();");
			output.AddLine(tc + 1, "try {");
			output.AddLine(tc + 2, $"await _{svcVarName}.Delete{className}(id);");
			output.AddLine();
			output.AddLine(tc + 2, "return Ok(apiResponse);");
			output.AddLine();
			output.AddLine(tc + 1, "} catch (Exception ex) {");
			output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(apiResponse, ex);");
			output.AddLine(tc + 1, "}");
			output.AddLine(tc, "}");
		}
	}

	internal void GenerateUpdateMethod(EntityModel entity, UpdateMethodModel method, string svcVarName, List<string> output)
	{
		var tc = 1;

		var updateProps = new List<UpdatePropertyModel>();
		foreach (var updProp in method.UpdateProperties.Where(p => !p.IsOptional))
			updateProps.Add(updProp);
		foreach (var updProp in method.UpdateProperties.Where(p => p.IsOptional))
			updateProps.Add(updProp);

		var args = new StringBuilder();
		args.Append("request.Id");
		if (entity.InclRowVersion)
			args.Append(", request.RowVersion");
		foreach (var updProp in updateProps)
			args.Append($", request.{updProp.Property.Name}");

		output.AddLine(tc, "[HttpPatch, Route(\"[action]\")]");
		output.AddLine(tc, $"public async Task<ActionResult> {method.Name}({method.Name}Req request)");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"var apiResponse = CreateApiResponse();");
		output.AddLine(tc + 1, "try {");
		output.AddLine(tc + 2, $"await _{svcVarName}.{method.Name}({args});");
		output.AddLine();
		output.AddLine(tc + 2, $"return Ok(apiResponse);");
		output.AddLine();
		output.AddLine(tc + 1, "} catch (Exception ex) {");
		output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(apiResponse, ex);");
		output.AddLine(tc + 1, "}");
		output.AddLine(tc, "}");
	}

	internal void GenerateSingleControllerMethod(EntityModel entity, ReadMethodModel method, string svcVarName, List<string> output)
	{
		var tc = 1;

		// Attributes
		if (method.Attributes.Any())
			foreach (var attr in method.Attributes)
				output.AddLine(tc, $"[{attr}]");

		var filterArg = string.Empty;
		var filterRoute = string.Empty;
		var filterParams = string.Empty;
		if (method.FilterProperties.Count > 0) {
			filterArg = method.FilterProperties[0].Property.ArgName;
			filterRoute = $"/{{{filterArg}}}";
			filterParams = $"{method.FilterProperties[0].Property.DatatypeName} {method.FilterProperties[0].Property.ArgName}";
		}

		output.AddLine(tc, $"[HttpGet, Route(\"[action]{filterRoute}\")]");
		output.AddLine(tc, $"public async Task<ActionResult<{entity.Name}>> {method.Name}({filterParams})");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"var apiResponse = CreateApiResponse<{entity.Name}>();");
		output.AddLine(tc + 1, "try {");
		output.AddLine(tc + 2, $"apiResponse.Data =  await _{svcVarName}.{method.Name}({filterArg});");
		output.AddLine(tc + 2, $"return Ok(apiResponse);");
		output.AddLine();
		output.AddLine(tc + 1, "} catch (Exception ex) {");
		output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(apiResponse, ex);");
		output.AddLine(tc + 1, "}");
		output.AddLine(tc, "}");
	}

	internal void GenerateListControllerMethod(EntityModel entity, ReadMethodModel method, string svcVarName, List<string> output)
	{
		var tc = 1;

		// Attributes
		if (method.Attributes.Any())
			foreach (var attr in method.Attributes)
				output.AddLine(tc, $"[{attr}]");

		StringBuilder sbRoute = new StringBuilder();
		StringBuilder sbArgs = new StringBuilder();

		var reqFilterProps = method.FilterProperties.Where(fp => !fp.IsOptional && !fp.IsInternal);
		var optFilterProps = method.FilterProperties.Where(fp => fp.IsOptional && !fp.IsInternal);

		// Required
		foreach (var filterProp in reqFilterProps) {
			// Required arguments go in the route
			sbRoute.Append($"/{{{filterProp.Property.ArgName}}}");
			if (sbArgs.Length > 0)
				sbArgs.Append(", ");
			sbArgs.Append($"[FromRoute] {filterProp.Property.DatatypeName} {filterProp.Property.ArgName}");
		}

		// Optional
		foreach (var filterProp in optFilterProps) {
			if (sbArgs.Length > 0)
				sbArgs.Append(", ");
			var nullChar = filterProp.Property.PrimitiveType?.Id != PrimitiveType.String.Id ? "?" : string.Empty;
			sbArgs.Append($"[FromQuery] {filterProp.Property.DatatypeName}{nullChar} {filterProp.Property.ArgName} = null");
		}

		// Paging is always optional
		if (method.InclPaging) {
			if (sbArgs.Length > 0)
				sbArgs.Append(", ");
			sbArgs.Append("[FromQuery] int pgSize = 0, [FromQuery] int pgOffset = 0");
		}

		// Vars
		StringBuilder sbVars = new StringBuilder();
		foreach (var filterProp in reqFilterProps) {
			if (sbVars.Length > 0)
				sbVars.Append(", ");
			sbVars.Append(filterProp.Property.ArgName);
		}
		foreach (var filterProp in optFilterProps) {
			if (sbVars.Length > 0)
				sbVars.Append(", ");
			sbVars.Append(filterProp.Property.ArgName);
		}
		if (method.InclPaging) {
			if (sbVars.Length > 0)
				sbVars.Append(", ");
			sbVars.Append("pgSize, pgOffset");
		}

		output.AddLine(tc, $"[HttpGet, Route(\"[action]{sbRoute}\")]");
		output.AddLine(tc, $"public async Task<ActionResult<List<{entity.Name}>>> {method.Name}({sbArgs})");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"var apiResponse = CreateApiResponse<List<{entity.Name}>>();");
		output.AddLine(tc + 1, "try {");
		output.AddLine(tc + 2, $"apiResponse.Data =  await _{svcVarName}.{method.Name}({sbVars});");
		output.AddLine(tc + 2, $"return Ok(apiResponse);");
		output.AddLine();
		output.AddLine(tc + 1, "} catch (Exception ex) {");
		output.AddLine(tc + 2, "return LogErrorAndReturnErrorResponse(apiResponse, ex);");
		output.AddLine(tc + 1, "}");
		output.AddLine(tc, "}");
	}

	internal void GenerateQueryControllerMethod(EntityModel entity, ReadMethodModel queryMethod, string svcVarName, List<string> output)
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

	internal string ReplaceControllerTemplateTokens(string template, List<string> addlUsings, List<string> attrsOutput, string controllerVersion, string controllersNamespace, string controllerName, string serviceName, string serviceVarName, List<string> cudMethodsOutput, List<string> updMethodsOutput, List<string> singleMethodsOutput, List<string> listMethodsOutput, List<string> queryMethodsOutput, string entityName)
	{
		// Addl Usings
		var sb = new StringBuilder();
		addlUsings.ForEach(x => {
			if (sb.Length > 0)
				sb.AppendLine();
			sb.Append($"using {x};");
		});
		template = template.Replace(Utils.FmtToken(cToken_AddlUsings), sb.ToString());

		// Class Attributes
		sb = new StringBuilder();
		attrsOutput.ForEach(x => {
			if (sb.Length > 0)
				sb.AppendLine();
			sb.Append(x);
		});
		template = template.Replace(Utils.FmtToken(cToken_ControllerAttrs), sb.ToString());

		template = template.Replace(Utils.FmtToken(cToken_ControllerVersion), controllerVersion);

		// Various
		template = template.Replace(Utils.FmtToken(cToken_ControllersNs), controllersNamespace);
		template = template.Replace(Utils.FmtToken(cToken_ControllerName), controllerName);
		template = template.Replace(Utils.FmtToken(cToken_ServiceName), serviceName);
		template = template.Replace(Utils.FmtToken(cToken_ServiceVarName), serviceVarName);
		template = template.Replace(Utils.FmtToken(cToken_EntityName), entityName);

		// CUD Methods
		sb = new StringBuilder();
		cudMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_CudControllerMethods), sb.ToString());

		// Update Methods
		sb = new StringBuilder();
		updMethodsOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_UpdControllerMethods), sb.ToString());

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
}

