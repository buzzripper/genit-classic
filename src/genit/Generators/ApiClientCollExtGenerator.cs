using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dyvenix.Genit.Generators;

internal class ApiClientCollExtGenerator
{
	#region Constants

	private const string cTemplateFilename = "ApiClientCollExt.tmpl";
	private const string cToken_ApiClientRegistrations = "API_CLIENT_REGISTRATIONS";

	#endregion

	internal void GenerateApiClientRegistrations(List<EntityModel> apiClientEntities, ServiceGenModel serviceGen, string templatesFolderpath)
	{
		// Template / Output files

		var apClientCollExtTemplateFilepath = Path.Combine(templatesFolderpath, cTemplateFilename);
		var apiClientCollExtOutputFile = Utils.ResolveRelativePath(Globals.CurrDocFilepath, serviceGen.ApiClientExtOutputFilepath);
		Validate(apClientCollExtTemplateFilepath, Path.GetDirectoryName(apiClientCollExtOutputFile));
		var apiClientCollExtTemplate = File.ReadAllText(apClientCollExtTemplateFilepath);

		// Build the registrations
		var registrations = new List<string>();
		var t = 2;

		foreach (var entity in apiClientEntities) {
			var className = $"{entity.Name}ApiClient";
			registrations.AddLine(t, $"services.AddTransient<I{className}, {className}>();");
		}

		var registrationsOutput = string.Join(Environment.NewLine, registrations);

		// Replace tokens in template
		apiClientCollExtTemplate = apiClientCollExtTemplate.Replace(Utils.FmtToken(cToken_ApiClientRegistrations), registrationsOutput);

		// Write output file
		if (File.Exists(apiClientCollExtOutputFile))
			File.Delete(apiClientCollExtOutputFile);
		File.WriteAllText(apiClientCollExtOutputFile, apiClientCollExtTemplate);
	}

	private void Validate(string templateFilepath, string outputFolder)
	{
		if (!File.Exists(templateFilepath))
			throw new ApplicationException($"Template file does not exist: {templateFilepath}");

		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {outputFolder}");
	}
}
