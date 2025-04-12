using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dyvenix.Genit.Generators;

internal class ServiceCollExtGenerator
{
	#region Constants

	private const string cTemplateFilename = "ServiceCollExt.tmpl";
	private const string cToken_ServiceRegistrations = "SERVICE_REGISTRATIONS";

	#endregion

	internal void GenerateServiceRegistrations(List<EntityModel> serviceEntities, ServiceGenModel serviceGen, string templatesFolderpath)
	{
		// Template / Output files

		var templateFilepath = Path.Combine(templatesFolderpath, cTemplateFilename);
		var outputFile = Utils.ResolveRelativePath(Globals.CurrDocFilepath, serviceGen.ServicesExtOutputFilepath);
		Validate(templateFilepath, Path.GetDirectoryName(outputFile));
		var templateContents = File.ReadAllText(templateFilepath);

		// Build the registrations
		var registrations = new List<string>();
		var t = 2;

		foreach (var entity in serviceEntities) {
			var className = $"{entity.Name}Service";
			registrations.AddLine(t, $"services.AddTransient<I{className}, {className}>();");
		}

		var registrationsOutput = string.Join(Environment.NewLine, registrations);

		// Replace tokens in template
		templateContents = templateContents.Replace(Utils.FmtToken(cToken_ServiceRegistrations), registrationsOutput);

		// Write output file
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, templateContents);
	}

	private void Validate(string templateFilepath, string outputFolder)
	{
		if (!File.Exists(templateFilepath))
			throw new ApplicationException($"Template file does not exist: {templateFilepath}");

		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {outputFolder}");
	}
}
