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
	private const string cToken_SortingMethod = "SORTING_METHOD";

	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.Entity;

	#endregion

	public void Run(ServiceGenModel svcGenModel, ObservableCollection<ServiceModel> services, string servicesNamespace)
	{
		if (!svcGenModel.Enabled)
			return;

		// Get absolute paths
		var templateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.TemplateFilepath);
		var outputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.OutputFolder);

		Validate(outputFolder, templateFilepath);

		var template = File.ReadAllText(templateFilepath);

		foreach (var service in services.Where(e => e.Enabled)) {
			var cleanTemplate = $"{template}";
			GenerateService(service, svcGenModel, $"{cleanTemplate}", outputFolder, servicesNamespace);
		}
	}

	private void Validate(string outputFolder, string templateFilepath)
	{
		if (!File.Exists(templateFilepath))
			throw new ApplicationException($"Template file does not exist: {templateFilepath}");

		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {outputFolder}");
	}

	private void GenerateService(ServiceModel service, ServiceGenModel serviceGen, string template, string outputFolder, string servicesNamespace)
	{
		var serviceName = $"{service.Entity.Name}Service";

		// Addl usings
		var addlUsings = BuildAddlUsings(service);

		// Interface signatures
		var interfaceOutput = new List<string>();

		var singleMethodsOutput = new List<string>();
		foreach (SingleSvcMethodModel singleMethod in service.ServiceMethods.Where(m => m.Type == ServiceMethodType.GetSingle))
			this.GenerateSingleSvcMethod(service.Entity, singleMethod, singleMethodsOutput, interfaceOutput);

		var listMethodsOutput = new List<string>();
		var queryMethodsOutput = new List<string>();
		var sortingMethodOutput = new List<string>();

		// Property names
		var propNames = GeneratePropNames(service);

		// Replace tokens in template
		var fileContents = ReplaceTemplateTokens(template, serviceName, addlUsings, singleMethodsOutput, listMethodsOutput, queryMethodsOutput, sortingMethodOutput, interfaceOutput, servicesNamespace);

		var outputFile = Path.Combine(outputFolder, $"{service.Entity.Name}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	private List<string> BuildAddlUsings(ServiceModel service)
	{
		var usings = new List<string>();

		service.AddlUsings?.ToList().ForEach(u => usings.Add(u));

		return usings;
	}

	private void GenerateSingleSvcMethod(EntityModel entity, SingleSvcMethodModel method, List<string> output, List<string> interfaceOutput)
	{
		var tc = 1;

		// Attributes
		if (method.Attributes.Any())
			foreach (var attr in method.Attributes)
				output.AddLine(tc, $"[{attr}]");

		// Interface
		var signature = $"Task<{entity.Name}>{method.Name}({method.ArgType} {method.ArgName})";
		interfaceOutput.Add(signature);

		// Method
		output.AddLine();
		output.AddLine(tc, $"public async {signature}");
		output.AddLine(tc, "{");
		output.AddLine(tc+1, "var db = _dbContextFactory.CreateDbContext();");
		output.AddLine(tc+1, $"return await db.{entity.Name}.FirstOrDefaultAsync(x => x.{method.PropName} == {method.ArgName});");	
		output.AddLine(tc, "}");
	}

	private string GeneratePropNames(ServiceModel service)
	{
		var sb = new StringBuilder();

		foreach (var prop in service.Entity.Properties) {
			if (sb.Length > 0)
				sb.Append(Environment.NewLine);
			sb.Append($"\t\tpublic const string {prop.Name} = nameof({service.Entity.Name}.{prop.Name});");	
		}
			
		return sb.ToString();
	}

	private string ReplaceTemplateTokens(string template, string serviceName, List<string> addlUsings, List<string> singleMethodsOutput, List<string> listMethodsOutput, List<string> queryMethodsOutput, List<string> sortingMethodOutput, List<string> interfaceOutput, string servicesNamespace)
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

		// Sorting method
		sb = new StringBuilder();
		sortingMethodOutput.ForEach(x => sb.AppendLine(x));
		template = template.Replace(Utils.FmtToken(cToken_SortingMethod), sb.ToString());

		return template;
	}
}
