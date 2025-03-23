using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

public class EnumGenerator
{
	#region Constants

	private const string cToken_CurrTimestamp = "CURR_TIMESTAMP";
	private const string cToken_EnumsNs = "ENUMS_NS";
	private const string cToken_EnumName = "ENUM_NAME";
	private const string cToken_Members = "MEMBERS";

	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.Enum;

	#endregion

	public void Run(EnumGenModel genModel, ObservableCollection<EnumModel> enumMdls, string enumsNamespace)
	{
		if (!genModel.Enabled)
			return;

		// Get absolute paths
		var templateFilepath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, genModel.TemplateFilepath);
		var outputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, genModel.OutputFolder);

		Validate(outputFolder, templateFilepath);

		var template = File.ReadAllText(templateFilepath);

		foreach (var enumMdl in enumMdls.Where(e => e.Enabled && !e.IsExternal)) {
			var cleanTemplate = $"{template}";
			GenerateEnum(enumMdl, enumsNamespace, $"{cleanTemplate}", outputFolder);
		}
	}

	private void Validate(string outputFolder, string templateFilepath)
	{
		if (!File.Exists(templateFilepath))
			throw new ApplicationException($"Template file does not exist: {templateFilepath}");

		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {outputFolder}");
	}

	private void GenerateEnum(EnumModel enumMdl, string enumsNamespace, string template, string outputFolder)
	{
		var membersOutput = new List<string>();

		foreach (var member in enumMdl.Members)
			membersOutput.AddLine(1, member);

		// Replace tokens in template
		var fileContents = ReplaceTemplateTokens(template, enumsNamespace, enumMdl, membersOutput);

		var outputFile = Path.Combine(outputFolder, $"{enumMdl.Name}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	private string ReplaceTemplateTokens(string template, string enumsNamespace, EnumModel enumMdl, List<string> output)
	{
		// Header
		template = template.Replace(Utils.FmtToken(cToken_CurrTimestamp), DateTime.Now.ToString("g"));

		// Namespace 		
		template = template.Replace(Utils.FmtToken(cToken_EnumsNs), enumsNamespace);

		// Enum name
		template = template.Replace(Utils.FmtToken(cToken_EnumName), enumMdl.Name);

		// Members
		var sb = new StringBuilder();
		output.ForEach(x => sb.AppendLine($"{x},"));
		template = template.Replace(Utils.FmtToken(cToken_Members), sb.ToString());

		return template;
	}
}




