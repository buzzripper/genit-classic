using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

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

	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.Entity;

	#endregion

	public void Run(ServiceGenModel svcGenModel, ObservableCollection<EntityModel> entities, string servicesNamespace, string queriesNamespace, string controllersNamespace, string entitiesNamespace, string apiClientsNamespace)
	{
		if (!svcGenModel.Enabled)
			return;

		// Load templates

		var templateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.TemplateFilepath);
		var outputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.OutputFolder);
		Validate(templateFilepath, outputFolder);
		var serviceTemplate = File.ReadAllText(templateFilepath);

		var queryTemplateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.QueryTemplateFilepath);
		var queryOutputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.QueryOutputFolder);
		Validate(queryTemplateFilepath, queryOutputFolder);
		var queryTemplate = File.ReadAllText(queryTemplateFilepath);

		var controllerTemplateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.ControllerTemplateFilepath);
		var controllersOutputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.ControllerOutputFolder);
		Validate(controllerTemplateFilepath, controllersOutputFolder);
		var controllerTemplate = File.ReadAllText(controllerTemplateFilepath);

		var apClientTemplateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.ApiClientTemplateFilepath);
		var apiClientOutputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.ApiClientOutputFolder);
		Validate(apClientTemplateFilepath, apiClientOutputFolder);
		var apiClientTemplate = File.ReadAllText(apClientTemplateFilepath);

		// Generate services

		var apiClientEntities = new List<EntityModel>();
		foreach (var entity in entities.Where(e => e.Service.Enabled)) {
			// Generate service class
			GenerateService(entity, svcGenModel, $"{serviceTemplate}", outputFolder, servicesNamespace, queriesNamespace);

			// Generate query classes
			foreach (var queryMethod in entity.Service.Methods.Where(m => m.UseQuery))
				new ServiceQueryGenerator().GenerateQueryClass(entity.Service, svcGenModel, $"{queryTemplate}", queryOutputFolder, queriesNamespace);

			// Generate controller / client
			if (entity.Service.InclController) { 
				new ServiceControllerGenerator().GenerateController(entity, svcGenModel, $"{controllerTemplate}", controllersOutputFolder, controllersNamespace, servicesNamespace, queriesNamespace, entitiesNamespace);
				new ApiClientGenerator().GenerateApiClient(entity, svcGenModel, $"{apiClientTemplate}", apiClientOutputFolder, apiClientsNamespace, queriesNamespace, entitiesNamespace);
				apiClientEntities.Add(entity);
			}
		}

		// Register any ApiClient classes
		if (apiClientEntities.Any()) {
			new ApiClientCollExtGenerator().GenerateApiClientRegistrations(apiClientEntities, svcGenModel);
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
		var addlUsings = Utils.BuildAddlUsingsList(entity.Service.AddlServiceUsings);
		addlUsings.AddIfNotExists(queriesNamespace);

		// Interface signatures
		var interfaceOutput = new List<string>();

		// Attributes
		var attrsOutput = new List<string>();
		foreach (var attr in entity.Service.ServiceClassAttributes)
			attrsOutput.Add($"[{attr}]");

		var serviceMethodGenerator = new ServiceMethodGenerator();

		// Create/Update/Delete
		var crudMethodsOutput = new List<string>();
		if (entity.Service.InclCreate || entity.Service.InclUpdate || entity.Service.InclDelete)
			serviceMethodGenerator.GenerateCUDMethods(entity, crudMethodsOutput, interfaceOutput);

		// GetSingle methods
		var singleMethodsOutput = new List<string>();
		foreach (var singleMethod in entity.Service.Methods.Where(m => !m.UseQuery && !m.IsList))
			serviceMethodGenerator.GenerateReadMethod(entity, singleMethod, singleMethodsOutput, interfaceOutput);

		// Get list methods
		var listMethodsOutput = new List<string>();
		foreach (var listMethod in entity.Service.Methods.Where(m => !m.UseQuery && m.IsList))
			serviceMethodGenerator.GenerateReadMethod(entity, listMethod, listMethodsOutput, interfaceOutput);

		// Query methods
		var queryMethodsOutput = new List<string>();
		if (entity.Service.Methods.Any(m => m.UseQuery)) {
			queryMethodsOutput.AddLine(1, "#region Queries");

			foreach (var queryMethod in entity.Service.Methods.Where(m => m.UseQuery))
				serviceMethodGenerator.GenerateQueryMethod(entity, queryMethod, queryMethodsOutput, interfaceOutput);
		}

		// Sorting method
		if (entity.Service.Methods.Where(m => m.UseQuery && m.InclSorting).Any()) {
			serviceMethodGenerator.GenerateSortingMethod(entity, queryMethodsOutput);
			queryMethodsOutput.AddLine();
		}

		queryMethodsOutput.AddLine(1, "#endregion");

		// Replace tokens in template
		var fileContents = ReplaceServiceTemplateTokens(template, serviceName, addlUsings, attrsOutput, crudMethodsOutput, singleMethodsOutput, listMethodsOutput, queryMethodsOutput, interfaceOutput, servicesNamespace);

		var outputFile = Path.Combine(outputFolder, $"{serviceName}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}


	//private void GenerateSingleMethod(EntityModel entity, ServiceMethodModel method, List<string> output, List<string> interfaceOutput)
	//{
	//	var tc = 1;
	//	output.AddLine();

	//	// Attributes
	//	if (method.Attributes.Any())
	//		foreach (var attr in method.Attributes)
	//			output.AddLine(tc, $"[{attr}]");

	//	// Interface
	//	var signature = $"Task<{entity.Name}>{method.Name}({method.ArgType} {method.ArgName})";
	//	interfaceOutput.Add(signature);

	//	// Method
	//	output.AddLine(tc, $"public async {signature}");
	//	output.AddLine(tc, "{");
	//	output.AddLine(tc + 1, "var db = _dbContextFactory.CreateDbContext();");
	//	output.AddLine(tc + 1, $"return await db.{entity.Name}.FirstOrDefaultAsync(x => x.{method.PropName} == {method.ArgName});");
	//	output.AddLine(tc, "}");
	//}

	//private void GenerateListMethod(EntityModel entity, ServiceMethodModel method, List<string> output, List<string> interfaceOutput)
	//{
	//	var tc = 1;
	//	output.AddLine();

	//	// Attributes
	//	if (method.Attributes.Any())
	//		foreach (var attr in method.Attributes)
	//			output.AddLine(tc, $"[{attr}]");

	//	// Interface
	//	var sbArgs = new StringBuilder();

	//	// Paging
	//	if (!string.IsNullOrWhiteSpace(method.ArgType))
	//		sbArgs.Append($"{method.ArgType} {method.ArgName}");
	//	if (method.InclPaging) {
	//		if (sbArgs.Length > 0)
	//			sbArgs.Append(", ");
	//		sbArgs.Append("int pageSize, int pageOffset");
	//	}
	//	var signature = $"Task<List<{entity.Name}>>{method.Name}({sbArgs.ToString()})";
	//	interfaceOutput.Add(signature);

	//	// Method
	//	output.AddLine(tc, $"public async {signature}");
	//	output.AddLine(tc, "{");
	//	output.AddLine(tc + 1, $"var dbQuery = _dbContextFactory.CreateDbContext().{entity.Name}.AsQueryable();");
	//	output.AddLine();

	//	if (!string.IsNullOrWhiteSpace(method.ArgType)) {
	//		var indent = tc + 1;
	//		if (method.FilterProperty.PrimitiveType == PrimitiveType.String) {
	//			output.AddLine(tc + 1, $"if (!string.IsNullOrWhiteSpace({method.ArgName}))");
	//			indent++;
	//		} else if (method.FilterProperty.Nullable) {
	//			output.AddLine(tc + 1, $"if ({method.ArgName} != null)");
	//			indent++;
	//		}
	//		output.AddLine(indent, $"dbQuery = dbQuery.Where(x => EF.Functions.Like(x.{method.PropName}, {method.ArgName}));");
	//		output.AddLine();
	//	}

	//	if (method.InclPaging) {
	//		output.AddLine(tc + 1, $"if (pageSize > 0)");
	//		output.AddLine(tc + 2, $"dbQuery = dbQuery.Skip(pageOffset).Take(pageSize);");
	//		output.AddLine();
	//	}

	//	output.AddLine(tc + 1, $"return await dbQuery.AsNoTracking().ToListAsync();");

	//	output.AddLine(tc, "}");
	//}

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
}
