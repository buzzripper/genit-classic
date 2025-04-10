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
using System.Data;

namespace Dyvenix.Genit.Generators;

internal enum ArgType
{
	Required,
	Optional,
	Paging
}

internal enum ValType
{
	Good,
	NotSupplied,
	NotExist
}

internal class ArgDef
{
	internal ArgDef(FilterPropertyModel filterProp, ArgType argItemType)
	{
		FilterProperty = filterProp;
		ArgItemType = argItemType;
	}
	public ArgType ArgItemType { get; set; }
	public FilterPropertyModel FilterProperty { get; set; }
	public List<ArgVal> Values { get; set; } = new List<ArgVal>();
}

internal class ArgVal
{
	public ArgVal(ValType valType, string value)
	{
		ValType = valType;
		Value = value;
	}
	public ValType ValType { get; set; }
	public string Value { get; set; }

	public override string ToString()
	{
		return ValType.ToString();
	}
}

internal class ArgSet
{
	public List<ArgItem> ArgItems { get; set; } = new List<ArgItem>();

	public override string ToString()
	{
		var sb = new StringBuilder();
		foreach (var argItem in ArgItems) {
			if (sb.Length > 0)
				sb.Append(", ");
			sb.Append($"{argItem.PropName}:{argItem.ArgVal.ValType}");
		}
		return sb.ToString();
	}
}

internal class ArgItem
{
	public FilterPropertyModel FilterProperty { get; set; }
	public ArgType ArgType { get; set; }
	public ArgVal ArgVal { get; set; }

	public string PropName { get; set; }
	public string VarName { get; set; }
	public bool Nullable { get; set; }

	public override string ToString()
	{
		return PropName;
	}
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

		// Build all the combinations

		var argDefs = new List<ArgDef>();

		// Required
		foreach (var filterProp in method.FilterProperties.Where(fp => !fp.IsOptional && !fp.IsInternal)) {
			var argDef = new ArgDef(filterProp, ArgType.Required);
			var nulStr = (filterProp.Property.Nullable && !IsString(filterProp.Property)) ? ".Value" : string.Empty;
			argDef.Values.Add(new ArgVal(ValType.Good, $"ds{entity.Name}.{filterProp.Property.Name}{nulStr}"));
			// Skip 'NotExists' for a non-null enum
			if (!(filterProp.Property.EnumType != null && !filterProp.Property.Nullable))
				argDef.Values.Add(new ArgVal(ValType.NotExist, NotExistsArg(filterProp)));
			argDefs.Add(argDef);
		}
		// Optional
		foreach (var filterProp in method.FilterProperties.Where(fp => fp.IsOptional && !fp.IsInternal)) {
			var argDef = new ArgDef(filterProp, ArgType.Optional);
			var nulStr = (filterProp.Property.Nullable && !IsString(filterProp.Property)) ? ".Value" : string.Empty;
			argDef.Values.Add(new ArgVal(ValType.Good, $"ds{entity.Name}.{filterProp.Property.Name}{nulStr}"));
			// Skip 'NotExists' for a non-null enum
			if (!(filterProp.Property.EnumType != null && !filterProp.Property.Nullable))
				argDef.Values.Add(new ArgVal(ValType.NotExist, NotExistsArg(filterProp)));
			argDef.Values.Add(new ArgVal(ValType.NotSupplied, "null"));
			argDefs.Add(argDef);
		}
		// Paging
		if (method.InclPaging) {
			var argDef = new ArgDef(null, ArgType.Paging);
			argDef.Values.Add(new ArgVal(ValType.Good, null));
			argDef.Values.Add(new ArgVal(ValType.NotSupplied, null));
			argDefs.Add(argDef);
		}

		// No filter properties, treat as special case to make things easier
		if (!method.FilterProperties.Any()) {
			output.AddLine();
			output.AddLine(tc, "[Fact]");
			output.AddLine(tc, $"public async Task {method.Name}()");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, $"var {varName} = await _apiClient.{method.Name}();");
			output.AddLine(tc + 1, $"Assert.Equal(_ds.{entCollName}.Count, {varName}.Count);");
			output.AddLine(tc, "}");
			return;
		}

		var argSets = GetAllCombinations(argDefs);
		var c = 0;

		// Create the tests from the combinations

		foreach (var argSet in argSets) {
			// Build the comment line
			var sbComment = new StringBuilder();
			foreach (var argItem in argSet.ArgItems) {
				if (sbComment.Length > 0)
					sbComment.Append(", ");
				if (argItem.ArgType != ArgType.Paging) {
					sbComment.Append($"{argItem.PropName}:{argItem.ArgVal.ValType}");
				} else {
					sbComment.Append($"Paging:{argItem.ArgVal.ValType}");
				}
			}

			// Build the linq to get the sample entity, used to build the linq for the dataset query for the asserts
			var sbSampleLinq = new StringBuilder();
			foreach (var argItem in argSet.ArgItems.Where(a => a.Nullable)) {
				var prefix = sbSampleLinq.Length == 0 ? "x =>" : " &&";
				if (argItem.FilterProperty.Property.PrimitiveType?.Id == PrimitiveType.String.Id)
					sbSampleLinq.Append($"{prefix} x.{argItem.PropName} != null");
				else
					sbSampleLinq.Append($"{prefix} x.{argItem.PropName}.HasValue");
			}

			// Build the linq args to call the dataset, for the asserts
			var sbLinq = new StringBuilder();
			foreach (var argItem in argSet.ArgItems) {
				if (argItem.ArgVal.ValType != ValType.NotSupplied) {
					if (argItem.ArgType != ArgType.Paging) {
						var prefix = sbLinq.Length == 0 ? ".Where(x =>" : " &&";
						sbLinq.Append($"{prefix} x.{argItem.PropName} == {argItem.ArgVal.Value}");
					}
				}
			}
			// Add in any internal filters
			foreach (var filterProp in method.FilterProperties.Where(fp => fp.IsInternal)) {
				var prefix = sbLinq.Length == 0 ? ".Where(x =>" : " &&";
				sbLinq.Append($"{prefix} {BuildInternalFilter(filterProp)}");
			}
			if (sbLinq.Length > 0)
				sbLinq.Append(")");

			var hasPaging = argSet.ArgItems.Any(a => a.ArgType == ArgType.Paging);
			var hasNotExists = argSet.ArgItems.Any(a => a.ArgVal.ValType == ValType.NotExist);

			// Build the args to call the api client
			var sbApiArgs = new StringBuilder();
			foreach (var argItem in argSet.ArgItems) {
				if (argItem.ArgVal.ValType != ValType.NotSupplied) {
					if (sbApiArgs.Length > 0)
						sbApiArgs.Append(", ");
					if (!(argItem.ArgType == ArgType.Paging && hasNotExists))
						sbApiArgs.Append($"{argItem.VarName}: {argItem.ArgVal.Value}");
					else if (argItem.VarName == "pgSize")
						sbApiArgs.Append($"{argItem.VarName}: 10"); // pgSize dummy value - result s/b 0 because it's a NotExists test
					else
						sbApiArgs.Append($"{argItem.VarName}: 0"); // pgOffset dummy value - result s/b 0 because it's a NotExists test
				}
			}

			// Success
			output.AddLine();
			output.AddLine(tc, $"// {method.Name}() - {sbComment}");
			output.AddLine(tc, "[Fact]");
			output.AddLine(tc, $"public async Task {method.Name}_{++c:D2}()");
			output.AddLine(tc, "{");

			if (!hasPaging || hasNotExists) {
				output.AddLine(tc + 1, "// Arrange");
				output.AddLine(tc + 1, $"var {dsSingleVarName} = _ds.{entCollName}.First({sbSampleLinq});");
				output.AddLine(tc + 1, $"var {dsListVarName} = _ds.{entCollName}{sbLinq}.ToList();");

				foreach (var navProp in method.InclNavProperties)
					output.AddLine(tc + 1, $"var ds{navProp.Name}Count = {dsListVarName}.Sum(x => x.{navProp.Name}?.Count);");

				output.AddLine();
				output.AddLine(tc + 1, "// Act");
				output.AddLine(tc + 1, $"var {listVarName} = await _apiClient.{method.Name}({sbApiArgs});");
				foreach (var navProp in method.InclNavProperties)
					output.AddLine(tc + 1, $"var {Utils.ToCamelCase(navProp.Name)}Count = {listVarName}.Sum(x => x.{navProp.Name}?.Count);");

				output.AddLine();
				output.AddLine(tc + 1, "// Assert");
				output.AddLine(tc + 1, $"Assert.Equal({dsListVarName}.Count, {listVarName}.Count);");
				foreach (var navProp in method.InclNavProperties)
					output.AddLine(tc + 1, $"Assert.Equal(ds{navProp.Name}Count, {Utils.ToCamelCase(navProp.Name)}Count);");

			} else {
				// Paging
				output.AddLine(tc + 1, "// Arrange");
				output.AddLine(tc + 1, $"var {dsSingleVarName} = _ds.{entCollName}.First({sbSampleLinq});");
				output.AddLine(tc + 1, $"var {dsListVarName} = _ds.{entCollName}{sbLinq}.ToList();");
				if (!hasNotExists) {
					output.AddLine(tc + 1, $"var pgr = new Pager({dsListVarName}.Count);");
					output.AddLine();
					output.AddLine(tc + 1, "// Act / Assert");
					output.AddLine(tc + 1, $"for (var i = 0; i < pgr.TotalPages; i++) {{");
					output.AddLine(tc + 2, $"var {listVarName} = await _apiClient.{method.Name}({sbApiArgs});");
					output.AddLine(tc + 2, $"Assert.Equal(pgr.Expected[i], {listVarName}.Count);");
					output.AddLine(tc + 1, "}");
				} else {
					output.AddLine();
					output.AddLine(tc + 1, "// Act");
					output.AddLine(tc + 1, $"var {listVarName} = await _apiClient.{method.Name}({sbApiArgs});");
				}
			}

			output.AddLine(tc, "}");
		}
	}

	private bool IsString(PropertyModel property)
	{
		return property.PrimitiveType?.Id == PrimitiveType.String.Id;
	}

	private string BuildInternalFilter(FilterPropertyModel filterProp)
	{
		if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.String.Id) {
			return "EF.Functions.Like(x.{filterProp.Property.Name}, \"{filterProp.InternalValue}\"";
		} else {
			if (filterProp.IsOptional)
				return $"x.{filterProp.Property.FilterArgName}.HasValue)";
			else if (filterProp.Property.EnumType != null)
				return $"x.{filterProp.Property.Name} == {filterProp.Property.EnumType.Name}.{filterProp.InternalValue}";
			else
				return $"x.{filterProp.Property.Name} == {filterProp.InternalValue}";
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
				var argDef = argDefs[i];
				var argVal = argDef.Values[indices[i]];

				ArgItem argItem = null;
				if (argDef.ArgItemType != ArgType.Paging) {
					argItem = new ArgItem {
						FilterProperty = argDef.FilterProperty,
						ArgType = argDef.ArgItemType,
						ArgVal = argVal,
						VarName = argDef.FilterProperty.Property.FilterArgName,
						PropName = argDef.FilterProperty.Property.Name,
						Nullable = argDef.FilterProperty.Property.Nullable
					};
					argSet.ArgItems.Add(argItem);

				} else {
					argItem = new ArgItem {
						FilterProperty = argDef.FilterProperty,
						ArgType = argDef.ArgItemType,
						ArgVal = new ArgVal(argVal.ValType, "pgr.PageSize"),
						VarName = "pgSize",
						PropName = "",
						Nullable = false
					};
					argSet.ArgItems.Add(argItem);
					argItem = new ArgItem {
						FilterProperty = argDef.FilterProperty,
						ArgType = argDef.ArgItemType,
						ArgVal = new ArgVal(argVal.ValType, "i"),
						VarName = "pgOffset",
						PropName = "",
						Nullable = false
					};
					argSet.ArgItems.Add(argItem);
				}
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
			if (0 < filterProp.Property.MaxLength && filterProp.Property.MaxLength < 36)
				return $"Guid.NewGuid().ToString()[{filterProp.Property.MaxLength}..]";
			else
				return "Guid.NewGuid().ToString()";

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
