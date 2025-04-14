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
			output.AddLine(1, "#region Single Methods");
			GenerateCreateTests(entity, intTestsGenModel, output);
			output.AddLine();
			GenerateHelperMethods(entity, output);
			output.AddLine(1, "#endregion");
		}


		if (output.Count == 0)
			return;

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

	private void GenerateHelperMethods(EntityModel entity, List<string> output)
	{
		var tc = 1;
		output.AddLine(tc, "// Helper Methods");
		output.AddLine();
		output.AddLine(tc, $"private {entity.Name} Create{entity.Name}()");
		output.AddLine(tc, "{");
		output.AddLine(tc + 1, $"return new {entity.Name} {{");
		var c = 0;
		var props = entity.Properties.Where(p => !p.Nullable && !p.IsPrimaryKey).ToList();
		foreach (var prop in props) {
			var cm = (c++ < (props.Count - 1)) ? "," : string.Empty;
			if (prop.IsForeignKey) {
				var fkEntityName = prop.Assoc.FKEntity.Name;
				output.AddLine(tc + 2, $"{prop.Name} = GetRnd{prop.Assoc.FKEntity.Name}Pk(){cm}");
			} else {
				if (prop.PrimitiveType?.Id == PrimitiveType.String.Id) {
					output.AddLine(tc + 2, $"{prop.Name} = RndStr({prop.MaxLength}){cm}");
				} else if (prop.PrimitiveType?.Id == PrimitiveType.Int.Id) {
					output.AddLine(tc + 2, $"{prop.Name} = RndInt(){cm}");
				} else if (prop.PrimitiveType?.Id == PrimitiveType.Guid.Id) {
					output.AddLine(tc + 2, $"{prop.Name} = Guid.NewGuid(){cm}");
				} else if (prop.EnumType != null) {
					output.AddLine(tc + 2, $"{prop.Name} = RndEnum<{prop.EnumType.Name}>(){cm}");
				} else if (prop.PrimitiveType?.Id == PrimitiveType.Long.Id) {
					output.AddLine(tc + 2, $"{prop.Name} = RndLong(){cm}");
				} else if (prop.PrimitiveType?.Id == PrimitiveType.Double.Id) {
					output.AddLine(tc + 2, $"{prop.Name} = RndDbl(){cm}");
				}
			}
		}
		output.AddLine(tc + 1, "};");
		output.AddLine(tc, "}");

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
