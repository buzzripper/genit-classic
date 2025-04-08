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
using System.Data;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.DirectoryServices.ActiveDirectory;

namespace Dyvenix.Genit.Generators;

internal enum ArgType
{
	Required,
	Optional,
	PgSize,
	PgOffset
}

internal class ArgDef
{
	internal ArgDef(string propName, string varName, ArgType argItemType)
	{
		PropName = propName;
		VarName = varName;
		ArgItemType = argItemType;
	}
	public ArgType ArgItemType { get; set; }
	public string PropName { get; set; }
	public string VarName { get; set; }
	public List<string> Values { get; set; } = new List<string>();
}

internal class ArgSet
{
	public List<ArgItem> ArgItems { get; set; } = new List<ArgItem>();
}

internal class ArgItem
{
	public ArgType ArgItemType { get; set; }
	public string PropName { get; set; }
	public string VarName { get; set; }
	public string Value { get; set; }
}

internal class ApiClientIntTestsGenerator
{
	private const string cTemplateFilename = "IntTests_ApiClients_Read.tmpl";
	private const string cToken_CurrTimestamp = "CURR_TIMESTAMP";
	private const string cToken_IntTestsNs = "INT_TESTS_NS";
	private const string cToken_EntityName = "ENTITY_NAME";
	private const string cToken_TestMethods = "TEST_METHODS";

	public void Run(EntityModel entity, IntTestsGenModel intTestsGenModel, string templatesFolderpath)
	{
		var templateFilepath = Path.Combine(templatesFolderpath, cTemplateFilename);
		var outputFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, intTestsGenModel.OutputFolder);
		Validate(templateFilepath, outputFolder);
		var template = File.ReadAllText(templateFilepath);

		var output = new List<string>();

		// Read Methods - Single
		var singleMethods = entity.Service.Methods.Where(m => !m.IsList).ToList();
		if (singleMethods.Any()) {
			output.AddLine();
			output.AddLine(1, "#region Single Methods");
			foreach (var serviceMethod in singleMethods)
				GenerateReadTestsSingle(entity, intTestsGenModel, serviceMethod, output);
			output.AddLine();
			output.AddLine(1, "#endregion");
		}

		// Read Methods - List
		var listMethods = entity.Service.Methods.Where(m => m.IsList).ToList();
		if (listMethods.Any()) {
			output.AddLine();
			output.AddLine(1, "#region List Methods");
			foreach (var serviceMethod in listMethods)
				GenerateReadTestsList(entity, intTestsGenModel, serviceMethod, output);
			output.AddLine();
			output.AddLine(1, "#endregion");
		}

		if (output.Count == 0)
			return;

		// Replace tokens in template
		var fileContents = ReplaceServiceTemplateTokens(template, entity.Name, intTestsGenModel.Namespace, output);

		var outputFile = Path.Combine(outputFolder, $"{entity.Name}ReadTests.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	private void GenerateReadTestsSingle(EntityModel entity, IntTestsGenModel intTestsGenModel, ServiceMethodModel method, List<string> output)
	{
		var tc = 1;
		var dsVarName = $"ds{entity.Name}";
		var dbCollName = $"{entity.Name}s";
		var varName = Utils.ToCamelCase(entity.Name);

		// Single read methods always have 1 arg
		var filterProp = method.FilterProperties[0];

		// Success
		output.AddLine();
		output.AddLine(tc, "[Fact]");
		output.AddLine(tc, $"public async Task {method.Name}_Success()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"var {dsVarName} = _ds.{dbCollName}.First();");
		output.AddLine(tc + 1, $"var {varName} = await _apiClient.{method.Name}({dsVarName}.{filterProp.Property.Name});");
		output.AddLine(tc + 1, $"Assert.Equal({dsVarName}.Id, {varName}.Id);");
		output.AddLine(tc, "}");

		// Not found
		output.AddLine();
		output.AddLine(tc, "[Fact]");
		output.AddLine(tc, $"public async Task {method.Name}_NotFound()");
		output.AddLine(tc, "{");

		string arg = NotExistsArg(filterProp);

		output.AddLine(tc + 1, $"var {varName} = await _apiClient.{method.Name}({arg});");
		output.AddLine(tc + 1, $"Assert.Null({varName});");
		output.AddLine(tc, "}");
	}

	private void GenerateReadTestsList(EntityModel entity, IntTestsGenModel intTestsGenModel, ServiceMethodModel method, List<string> output)
	{
		var tc = 1;
		var dsSingleVarName = $"ds{entity.Name}";
		var dsListVarName = $"ds{entity.Name}s";
		var entCollName = $"{entity.Name}s";
		var varName = Utils.ToCamelCase(entity.Name);
		var listVarName = $"{Utils.ToCamelCase(entity.Name)}s";

		var argDefs = new List<ArgDef>();

		// Required
		foreach (var filterProp in method.FilterProperties.Where(fp => !fp.IsOptional && !fp.IsInternal)) {
			var argDef = new ArgDef(filterProp.Property.Name, filterProp.Property.FilterArgName, ArgType.Required);
			argDef.Values.Add($"ds{entity.Name}.{filterProp.Property.Name}");
			argDef.Values.Add(NotExistsArg(filterProp));
			argDefs.Add(argDef);
		}
		// Optional
		foreach (var filterProp in method.FilterProperties.Where(fp => fp.IsOptional && !fp.IsInternal)) {
			var argDef = new ArgDef(filterProp.Property.Name, filterProp.Property.FilterArgName, ArgType.Optional);
			argDef.Values.Add($"ds{entity.Name}.{filterProp.Property.Name}");
			argDef.Values.Add(NotExistsArg(filterProp));
			argDef.Values.Add("null");
			argDefs.Add(argDef);
		}
		// Paging
		foreach (var filterProp in method.FilterProperties.Where(fp => fp.IsOptional && !fp.IsInternal)) {
			var argDef = new ArgDef(null, "pgSize", ArgType.PgSize);
			argDef.Values.Add("3");
			argDef.Values.Add("0");
			argDefs.Add(argDef);
		}

		var sbComment = new StringBuilder();
		sbComment.Append("// ");
		sbComment.Append(method.Name);

		// No filter properties, treat as special case to make things easier
		if (!method.FilterProperties.Any()) {
			output.AddLine();
			output.AddLine(tc, "[Fact]");
			output.AddLine(tc, $"public async Task {method.Name}()");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, $"var {varName} = await _apiClient.{method.Name}();");
			output.AddLine(tc + 1, $"Assert.Equal({varName}.Count, _ds.{entCollName}.Count);");
			output.AddLine(tc, "}");
			return;
		}

		var argSets = GetAllCombinations(argDefs);
		var c = 0;

		foreach (var argSet in argSets) {
			// Build the linq args to call the dataset, for the asserts
			var sbLinq = new StringBuilder();
			foreach (var argItem in argSet.ArgItems) {
				if (argItem.ArgItemType != ArgType.PgSize) {
					if (sbLinq.Length > 0)
						sbLinq.Append("&& ");
					sbLinq.Append($"x.{argItem.PropName} == {dsSingleVarName}.{argItem.PropName}");
				} else {

				}
			}
			// Build the args to call the api client
			var sbApiArgs = new StringBuilder();
			foreach (var argItem in argSet.ArgItems) {
				if (sbApiArgs.Length > 0)
					sbApiArgs.Append(", ");
				sbApiArgs.Append($"{argItem.VarName}: {argItem.Value}");
			}
			// Success
			output.AddLine();
			output.AddLine(tc, $"{sbComment} - {sbApiArgs}");
			output.AddLine(tc, "[Fact]");
			output.AddLine(tc, $"public async Task {method.Name}_{++c}()");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, $"var {dsSingleVarName} = _ds.{entCollName}.First();");
			output.AddLine(tc + 1, $"var {dsListVarName} = _ds.{entCollName}.Where(x => {sbLinq});");
			output.AddLine(tc + 1, $"var {listVarName} = await _apiClient.{method.Name}({sbApiArgs});");
			output.AddLine(tc + 1, $"Assert.Equal({listVarName}.Count, _ds.{entCollName}.Count);");
			output.AddLine(tc, "}");
		}
	}

	public static List<ArgSet> GetAllCombinations(List<ArgDef> argDefs)
	{
		var result = new List<ArgSet>();

		if (argDefs == null || argDefs.Count == 0)
			return result;

		// Track indices for each ArgDef.Values list
		int[] indices = new int[argDefs.Count];

		while (true) {
			var argSet = new ArgSet();

			for (int i = 0; i < argDefs.Count; i++) {
				var def = argDefs[i];
				var value = def.Values[indices[i]];

				argSet.ArgItems.Add(new ArgItem {
					PropName = def.PropName,
					VarName = def.VarName,
					ArgItemType = def.ArgItemType,
					Value = value
				});
			}

			result.Add(argSet);

			// Increment indices for next combination
			int listIndex = argDefs.Count - 1;
			while (listIndex >= 0) {
				indices[listIndex]++;
				if (indices[listIndex] < argDefs[listIndex].Values.Count) {
					break;
				}
				indices[listIndex] = 0;
				listIndex--;
			}

			if (listIndex < 0)
				break;
		}

		return result;
	}


	private string ReplaceServiceTemplateTokens(string template, string entityName, string testsNamespace, List<string> output)
	{
		// Header
		template = template.Replace(Utils.FmtToken(cToken_CurrTimestamp), DateTime.Now.ToString("g"));

		// Namespace
		template = template.Replace(Utils.FmtToken(cToken_IntTestsNs), testsNamespace);

		// Entity name
		template = template.Replace(Utils.FmtToken(cToken_EntityName), entityName);

		// Tests
		template = template.Replace(Utils.FmtToken(cToken_TestMethods), output.AsString());

		return template;
	}

	private void Validate(string templateFilepath, string outputFolder)
	{
		if (!File.Exists(templateFilepath))
			throw new ApplicationException($"Template file does not exist: {templateFilepath}");

		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {outputFolder}");
	}

	private string NotExistsArg(FilterPropertyModel filterProp)
	{
		if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Guid.Id)
			return "Guid.Empty";

		else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.String.Id) {
			var guidStr = Guid.NewGuid().ToString();
			if (guidStr.Length > filterProp.Property.MaxLength)
				guidStr = guidStr.Substring(filterProp.Property.MaxLength);
			return guidStr;

		} else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Int.Id)
			return "int.MaxValue";

		else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Long.Id)
			return "long.MaxValue";

		else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Short.Id)
			return "short.MaxValue";

		else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Short.Id)
			return "short.MaxValue";

		else
			return "null";
	}
}
