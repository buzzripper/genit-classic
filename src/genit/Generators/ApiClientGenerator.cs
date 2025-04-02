using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models.Services;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;

namespace Dyvenix.Genit.Generators;

internal class ApiClientGenerator
{
	private const string cToken_CurrTimestamp = "CURR_TIMESTAMP";
	private const string cToken_AddlUsings = "ADDL_USINGS";
	private const string cToken_ApiClientsNs = "API_CLIENTS_NS";
	private const string cToken_ApiClientName = "API_CLIENT_NAME";
	private const string cToken_IntfSignatures = "INTERFACE_SIGNATURES";
	private const string cToken_EntityName = "ENTITY_NAME";
	private const string cToken_CudMethods = "CUD_METHODS";
	private const string cToken_SingleMethods = "SINGLE_METHODS";
	private const string cToken_ListMethods = "LIST_METHODS";
	private const string cToken_QueryMethods = "QUERY_METHODS";

	internal void GenerateApiClient(EntityModel entity, ServiceGenModel serviceGen, string template, string outputFolder, string apiClientsNamespace, string queriesNamespace, string entitiesNamespace)
	{
		var apiClientName = $"{entity.Name}ApiClient";

		// Addl usings
		var addlUsings = Utils.BuildAddlUsingsList(entity.Service.AddlServiceUsings);
		addlUsings.AddIfNotExists(queriesNamespace);
		addlUsings.AddIfNotExists(entitiesNamespace);

		// Interface signatures
		var interfaceOutput = new List<string>();

		// Create/Update/Delete
		var crudMethodsOutput = new List<string>();
		if (entity.Service.InclCreate || entity.Service.InclUpdate || entity.Service.InclDelete) {
			crudMethodsOutput.AddLine(1, "#region Create / Update / Delete");
			this.GenerateCUDMethods(entity, crudMethodsOutput, interfaceOutput);
			crudMethodsOutput.AddLine();
			crudMethodsOutput.AddLine(1, "#endregion");
		}

		// GetSingle methods
		var singleMethodsOutput = new List<string>();
		if (entity.Service.Methods.Where(m => !m.IsList).Any()) {
			singleMethodsOutput.AddLine(1, "#region Single Methods");
			foreach (ServiceMethodModel singleMethod in entity.Service.Methods.Where(m => !m.IsList))
				this.GenerateReadMethod(entity, singleMethod, singleMethodsOutput, interfaceOutput);
			singleMethodsOutput.AddLine();
			singleMethodsOutput.AddLine(1, "#endregion");
		}

		// Get list methods
		var listMethodsOutput = new List<string>();
		if (entity.Service.Methods.Where(m => m.IsList).Any()) {
			listMethodsOutput.AddLine(1, "#region List Methods");
			foreach (ServiceMethodModel listMethod in entity.Service.Methods.Where(m => m.IsList))
				this.GenerateReadMethod(entity, listMethod, listMethodsOutput, interfaceOutput);
			listMethodsOutput.AddLine();
			listMethodsOutput.AddLine(1, "#endregion");
		}

		// Query methods
		var queryMethodsOutput = new List<string>();
		if (entity.Service.Methods.Where(m => m.UseQuery).Any()) {
			queryMethodsOutput.AddLine(1, "#region Queries");
			foreach (ServiceMethodModel queryMethod in entity.Service.Methods.Where(m => m.UseQuery))
				this.GenerateQueryMethod(entity, queryMethod, queryMethodsOutput, interfaceOutput);
			queryMethodsOutput.AddLine(1, "#endregion");
		}

		// Replace tokens in template
		var fileContents = ReplaceServiceTemplateTokens(template, apiClientName, entity.Name, addlUsings, crudMethodsOutput, singleMethodsOutput, listMethodsOutput, queryMethodsOutput, interfaceOutput, apiClientsNamespace);

		var outputFile = Path.Combine(outputFolder, $"{apiClientName}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	private void GenerateCUDMethods(EntityModel entity, List<string> output, List<string> interfaceOutput)
	{
		var tc = 1;
		var className = entity.Name;
		var varName = Utils.ToCamelCase(className);

		if (entity.Service.InclCreate) {
			// Interface
			var signature = $"Task<{className}> Create{className}({className} {varName})";
			interfaceOutput.Add(signature);

			output.AddLine();
			output.AddLine(tc, $"public async {signature}");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, $"ArgumentNullException.ThrowIfNull({varName});");
			output.AddLine();
			output.AddLine(tc + 1, $"return await PostAsync<{className}>(\"api/v1/{className}/Create{className}\", {varName});");
			output.AddLine(tc, "}");
		}

		if (entity.Service.InclUpdate) {
			// Interface
			var signature = $"Task Update{className}({className} {varName})";
			interfaceOutput.Add(signature);

			output.AddLine();
			output.AddLine(tc, $"public async {signature}");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, $"ArgumentNullException.ThrowIfNull({varName});");
			output.AddLine();
			output.AddLine(tc + 1, $"await PostAsync<{className}>(\"api/v1/{className}/Update{className}\", {varName});");
			output.AddLine(tc, "}");
		}

		if (entity.Service.InclDelete) {
			// Interface
			var signature = $"Task Delete{className}(Guid id)";
			interfaceOutput.Add(signature);

			output.AddLine();
			output.AddLine(tc, $"public async {signature}");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, $"await PostAsync<string>($\"api/v1/{className}/Delete{className}/{{id}}\", null);");
			output.AddLine(tc, "}");
		}
	}

	private void GenerateReadMethod(EntityModel entity, ServiceMethodModel method, List<string> output, List<string> interfaceOutput)
	{
		var tc = 1;
		var className = entity.Name;
		var varName = Utils.ToCamelCase(className);

		output.AddLine();

		// Attributes
		if (method.Attributes.Any())
			foreach (var attr in method.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Build signature
		string returnType = method.IsList ? $"List<{entity.Name}>" : entity.Name;

		var sbSigParams = new StringBuilder();
		var sbFilterRoute = new StringBuilder();

		var c = 0;
		foreach (var filterProp in method.FilterProperties) {
			if (c++ > 0) {
				sbSigParams.Append(", ");
				sbFilterRoute.Append(", ");
			}
			sbSigParams.Append($"{filterProp.DatatypeName} {filterProp.FilterArgName}");
			sbFilterRoute.Append($"/{{{filterProp.FilterArgName}}}");
		}
		if (method.InclPaging) {
			if (sbSigParams.Length > 0) {
				sbSigParams.Append(", ");
				sbFilterRoute.Append(", ");
			}
			sbSigParams.Append("int pageSize, int pageOffset");
			sbFilterRoute.Append("/{pageSize}/{pageOffset}");
		}

		var signature = $"Task<{returnType}> {method.Name}({sbSigParams})";

		// Interface
		interfaceOutput.Add(signature);

		// Method
		output.AddLine(tc, $"public async {signature}");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"return await GetAsync<{returnType}>($\"api/v1/{className}/{method.Name}{sbFilterRoute}\");");
		output.AddLine(tc, "}");
	}

	private void GenerateQueryMethod(EntityModel entity, ServiceMethodModel queryMethod, List<string> output, List<string> interfaceOutput)
	{
		var tc = 1;
		var className = entity.Name;
		var queryClassName = $"{queryMethod.Name}Query";

		output.AddLine();

		// Attributes
		if (queryMethod.Attributes.Any())
			foreach (var attr in queryMethod.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Interface
		var signature = $"Task<EntityList<{className}>>{queryMethod.Name}({queryClassName} query)";
		interfaceOutput.Add(signature);

		// Method
		output.AddLine(tc, $"public async {signature}");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"ArgumentNullException.ThrowIfNull(query);");
		output.AddLine();
		output.AddLine(tc + 1, $"return await PostAsync<EntityList<{className}>>(\"api/v1/{className}/{queryMethod.Name}\", query);");
		output.AddLine(tc, "}");
	}

	private string ReplaceServiceTemplateTokens(string template, string apiClientName, string entityName, List<string> addlUsings, List<string> crudMethodsOutput, List<string> singleMethodsOutput, List<string> listMethodsOutput, List<string> queryMethodsOutput, List<string> interfaceOutput, string apiClientsNamespace)
	{
		// Header
		template = template.Replace(Utils.FmtToken(cToken_CurrTimestamp), DateTime.Now.ToString("g"));

		// Namespace
		template = template.Replace(Utils.FmtToken(cToken_ApiClientsNs), apiClientsNamespace);

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

		// ApiClient name
		template = template.Replace(Utils.FmtToken(cToken_ApiClientName), apiClientName);

		// Entity name
		template = template.Replace(Utils.FmtToken(cToken_EntityName), entityName);

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
}
