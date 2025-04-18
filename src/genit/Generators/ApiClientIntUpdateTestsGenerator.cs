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

internal class ApiClientIntUpdateTestsGenerator : ApiClientIntTestsGenBase
{
	private const string cTemplateFilename = "IntTests_ApiClients_Update.tmpl";
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

		// Create Tests
		if (entity.Service.InclCreate) {
			output.AddLine();
			output.AddLine(1, "#region Create");
			GenerateCreateTests(entity, intTestsGenModel, output);
			output.AddLine();
			output.AddLine(1, "#endregion");
		}

		// Delete Tests
		if (entity.Service.InclDelete) {
			output.AddLine();
			output.AddLine(1, "#region Delete");
			GenerateDeleteTests(entity, intTestsGenModel, output);
			output.AddLine();
			output.AddLine(1, "#endregion");
		}

		// Update
		if (entity.Service.InclUpdate || entity.Service.UpdateMethods.Any()) {
			output.AddLine();
			output.AddLine(1, "#region Update");

			// Full udpate
			if (entity.Service.InclUpdate)
				this.GenerateFullUpdateTests(entity, intTestsGenModel, output);

			//// Normal updates
			//foreach (UpdateMethodModel method in entity.Service.UpdateMethods)
			//	this.GenerateUpdateMethod(entity, method, updMethodsOutput, output);

			output.AddLine();
			output.AddLine(1, "#endregion");
		}

		if (output.Count == 0)
			return;

		GenerateHelperMethods(entity, output);

		// Replace tokens in template
		var fileContents = ReplaceServiceTemplateTokens(template, entity.Name, intTestsGenModel.Namespace, output);

		var outputFile = Path.Combine(outputFolder, $"{entity.Name}UpdateTests.g.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	private void GenerateCreateTests(EntityModel entity, IntTestsGenModel intTestsGenModel, List<string> output)
	{
		var tc = 1;
		var dsVarName = $"ds{entity.Name}";
		var dbCollName = $"{entity.Name}s";
		var varName = Utils.ToCamelCase(entity.Name);

		// Valid Id - success
		output.AddLine();
		output.AddLine(tc, "[Fact]");
		output.AddLine(tc, $"public async Task Create_ValidId()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"// Arrange");
		output.AddLine(tc + 1, $"var {varName} = Create{entity.Name}();");

		output.AddLine(tc + 1, $"// Act");
		output.AddLine(tc + 1, $"var newId = await _apiClient.Create{entity.Name}({varName});");

		output.AddLine(tc + 1, $"// Assert");
		output.AddLine(tc + 1, $"Assert.Equal({varName}.Id, newId);");
		output.AddLine(tc + 1, $"var ret{entity.Name} = await _db.{entity.Name}.FindAsync(newId);");
		output.AddLine(tc + 1, $"Assert.NotNull(ret{entity.Name});");
		output.AddLine(tc + 1, $"Assert.Equal(newId, ret{entity.Name}.Id);");
		output.AddLine(tc, "}");

		// Id not provided - should create one server-side
		output.AddLine();
		output.AddLine(tc, "[Fact]");
		output.AddLine(tc, $"public async Task Create_InvalidId()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"// Arrange");
		output.AddLine(tc + 1, $"var {varName} = Create{entity.Name}();");
		output.AddLine(tc + 1, $"{varName}.Id = Guid.Empty;");
		output.AddLine();
		output.AddLine(tc + 1, $"// Act");
		output.AddLine(tc + 1, $"var newId = await _apiClient.Create{entity.Name}({varName});");
		output.AddLine();
		output.AddLine(tc + 1, $"// Assert");
		output.AddLine(tc + 1, "Assert.NotEqual(Guid.Empty, newId);");
		output.AddLine(tc + 1, $"var ret{entity.Name} = await _db.{entity.Name}.FindAsync(newId);");
		output.AddLine(tc + 1, $"Assert.NotNull(ret{entity.Name});");
		output.AddLine(tc + 1, $"Assert.Equal(newId, ret{entity.Name}.Id);");
		output.AddLine(tc, "}");

		// Null entity - should throw
		output.AddLine();
		output.AddLine(tc, "[Fact]");
		output.AddLine(tc, $"public async Task Create_Null{entity.Name}()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"// Act / Assert");
		output.AddLine(tc + 1, $"await Assert.ThrowsAsync<ArgumentNullException>(async () => await _apiClient.Create{entity.Name}(null));");
		output.AddLine(tc, "}");
	}

	private void GenerateDeleteTests(EntityModel entity, IntTestsGenModel intTestsGenModel, List<string> output)
	{
		var tc = 1;
		var dsVarName = $"ds{entity.Name}";
		var dbCollName = $"{entity.Name}s";
		var varName = Utils.ToCamelCase(entity.Name);

		// Success
		output.AddLine();
		output.AddLine(tc, "[Fact]");
		output.AddLine(tc, "public async Task Delete_Success()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "// Arrange");
		output.AddLine(tc + 1, "var ds = await _dataManager.ResetDataSet(DataSetType.Default);");
		output.AddLine(tc + 1, $"var {varName} = ds.{entity.Name}.Skip(RndInt(0, ds.{entity.Name}.ToList().Count)).First();");
		output.AddLine(tc + 1, $"var id = {varName}.Id;");
		output.AddLine();
		output.AddLine(tc + 1, "// Act");
		output.AddLine(tc + 1, $"var result = await _apiClient.Delete{entity.Name}(id);");
		output.AddLine();
		output.AddLine(tc + 1, "// Assert");
		output.AddLine(tc + 1, "Assert.True(result);");
		output.AddLine(tc, "}");

		// Not Found
		output.AddLine();
		output.AddLine(tc, "[Fact]");
		output.AddLine(tc, "public async Task Delete_NotFound()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "// Arrange");
		output.AddLine(tc + 1, $"var id = Guid.NewGuid();");
		output.AddLine();
		output.AddLine(tc + 1, "// Act");
		output.AddLine(tc + 1, $"var result = await _apiClient.Delete{entity.Name}(id);");
		output.AddLine();
		output.AddLine(tc + 1, "// Assert");
		output.AddLine(tc + 1, "Assert.False(result);");
		output.AddLine(tc, "}");
	}

	private void GenerateFullUpdateTests(EntityModel entity, IntTestsGenModel intTestsGenModel, List<string> output)
	{
		var tc = 1;
		var dsVarName = $"ds{entity.Name}";
		var dbCollName = $"{entity.Name}s";
		var varName = Utils.ToCamelCase(entity.Name);

		var props = entity.Properties.Where(x => !x.IsPrimaryKey && !x.IsForeignKey && !x.IsIdentity && !x.IsIndexUnique);

		// Success
		output.AddLine();
		output.AddLine(tc, "[Fact]");
		output.AddLine(tc, "public async Task FullUpdate_Success()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, "// Arrange");
		output.AddLine(tc + 1, $"var {varName} = _db.{entity.Name}.Skip(RndInt(0, _db.{entity.Name}.ToList().Count)).First();");

		foreach (var prop in props)
			output.AddLine(tc + 1, $"{varName}.{prop.Name} = {GenRndPropValue(prop)};");

		output.AddLine();
		output.AddLine(tc + 1, "// Act");
		output.AddLine(tc + 1, $"await _apiClient.Update{entity.Name}({varName});");
		output.AddLine();
		output.AddLine(tc + 1, "// Assert");
		output.AddLine(tc + 1, $"var ret{entity.Name} = _db.{entity.Name}.Find({varName}.Id);");
		output.AddLine(tc + 1, $"Assert.Equal(ret{entity.Name}.Id, {varName}.Id);");
		foreach (var prop in props)
			output.AddLine(tc + 1, $"Assert.Equal(ret{entity.Name}.{prop.Name}, {varName}.{prop.Name});");
		output.AddLine(tc, "}");
	}

	private void GenerateHelperMethods(EntityModel entity, List<string> output)
	{
		var tc = 1;
		output.AddLine();
		output.AddLine(tc, "// Helper Methods");
		output.AddLine();

		// Create entity

		output.AddLine(tc, $"private {entity.Name} Create{entity.Name}()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"return new {entity.Name} {{");
		var c = 0;
		var props = entity.Properties.Where(p => !p.Nullable && !p.IsPrimaryKey).ToList();
		var cm = props.Count > 0 ? "," : string.Empty;
		output.AddLine(tc + 2, $"Id = Guid.NewGuid(){cm}");
		foreach (var prop in props) {
			cm = (c++ < (props.Count - 1)) ? "," : string.Empty;
			output.AddLine(tc + 2, $"{prop.Name} = {GenRndPropValue(prop)}{cm}");
			//if (prop.IsForeignKey) {
			//	var fkEntityName = prop.Assoc.FKEntity.Name;
			//	output.AddLine(tc + 2, $"{prop.Name} = GetRnd{prop.Assoc.PrimaryEntity.Name}Pk(){cm}");
			//} else {
			//	if (prop.PrimitiveType?.Id == PrimitiveType.String.Id) {
			//		output.AddLine(tc + 2, $"{prop.Name} = RndStr({prop.MaxLength}){cm}");
			//	} else if (prop.PrimitiveType?.Id == PrimitiveType.Int.Id) {
			//		output.AddLine(tc + 2, $"{prop.Name} = RndInt(){cm}");
			//	} else if (prop.PrimitiveType?.Id == PrimitiveType.Guid.Id) {
			//		output.AddLine(tc + 2, $"{prop.Name} = Guid.NewGuid(){cm}");
			//	} else if (prop.EnumType != null) {
			//		output.AddLine(tc + 2, $"{prop.Name} = RndEnum<{prop.EnumType.Name}>(){cm}");
			//	} else if (prop.PrimitiveType?.Id == PrimitiveType.Long.Id) {
			//		output.AddLine(tc + 2, $"{prop.Name} = RndLong(){cm}");
			//	} else if (prop.PrimitiveType?.Id == PrimitiveType.Double.Id) {
			//		output.AddLine(tc + 2, $"{prop.Name} = RndDbl(){cm}");
			//	}
			//}
		}
		output.AddLine(tc + 1, "};");
		output.AddLine(tc, "}");

		// Find random PK Id for an entity

		foreach (var fkProp in entity.Properties.Where(p => p.IsForeignKey && !p.Nullable)) {
			var pkEntityName = fkProp.Assoc.PrimaryEntity.Name;
			var varName = $"{Utils.ToCamelCase(pkEntityName)}List";
			output.AddLine();
			output.AddLine(tc, $"private Guid GetRnd{pkEntityName}Pk()");
			output.AddLine(tc, "{");
			output.AddLine(tc + 1, $"var {varName} = _db.{pkEntityName}.ToList();");
			output.AddLine(tc + 1, $"return {varName}.Skip(RndInt(1, {varName}.Count)).First().Id;");
			output.AddLine(tc, "}");
		}
		output.AddLine();
	}

	private string GenRndPropValue(PropertyModel prop)
	{
		if (prop.IsForeignKey) {
			var fkEntityName = prop.Assoc.FKEntity.Name;
			return $"GetRnd{prop.Assoc.PrimaryEntity.Name}Pk()";
		} else {
			if (prop.PrimitiveType?.Id == PrimitiveType.String.Id) {
				return $"RndStr({prop.MaxLength})";
			} else if (prop.PrimitiveType?.Id == PrimitiveType.Int.Id) {
				return $"RndInt()";
			} else if (prop.PrimitiveType?.Id == PrimitiveType.Guid.Id) {
				return $"Guid.NewGuid()";
			} else if (prop.PrimitiveType?.Id == PrimitiveType.Bool.Id) {
				return $"RndBool()";
			} else if (prop.EnumType != null) {
				return $"RndEnum<{prop.EnumType.Name}>()";
			} else if (prop.PrimitiveType?.Id == PrimitiveType.Long.Id) {
				return $"RndLong()";
			} else if (prop.PrimitiveType?.Id == PrimitiveType.Double.Id) {
				return $"RndDbl()";
			} else { 
				return $"UNEXPECTED PROP TYPE {prop.DatatypeName}";
			}
		}
	}

	private string ReplaceServiceTemplateTokens(string template, string entityName, string testsNamespace, List<string> output)
	{
		// Namespace
		template = template.Replace(Utils.FmtToken(cToken_IntTestsNs), testsNamespace);

		// Entity name
		template = template.Replace(Utils.FmtToken(cToken_EntityName), entityName);

		// Tests
		template = template.Replace(Utils.FmtToken(cToken_TestMethods), output.AsString());

		return template;
	}
}
