using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

public class EntityGenerator
{
	public bool InclHeader { get; set; }
	public string OutputRootFolder { get; set; }
	public bool Enabled { get; set; }
	public string Namespace { get; set; }

	public void Run(DbContextModel dbContextMdl)
	{
		Validate();

		var entities = dbContextMdl.Entities;

		if (!this.Enabled)
			return;

		if (dbContextMdl.Entities.Any(e => e.Enabled))
			this.GenerateEntities(dbContextMdl, dbContextMdl.Entities);

		if (!dbContextMdl.Enums.All(e => e.IsExternal))
			this.GenerateEnums(dbContextMdl, dbContextMdl.Enums);
	}

	private void GenerateEntities(DbContextModel dbContextMdl, List<EntityModel> entities)
	{
		foreach (var entity in entities) {
			if (!entity.Enabled)
				continue;

			var header = new List<string>();
			if (InclHeader)
				this.GenerateHeader(header);

			var usings = new List<string>();
			usings.Add("System");
			entity.AddlUsings.ForEach(u => usings.Add(u));

			// Class declaration
			var classStart = new List<string>();
			classStart.Add("");
			entity.Attributes.ForEach(a => classStart.Add($"[{a}]"));
			var ns = string.IsNullOrEmpty(entity.Namespace) ? dbContextMdl.EntitiesNamespace : entity.Namespace;
			classStart.Add($"namespace {ns};");
			classStart.Add("");
			classStart.Add($"public partial class {entity.Name}");
			classStart.Add("{");

			var propOutputList = new List<string>();

			// FK properties
			var assocs = dbContextMdl.Assocs.Where(p => p.RelatedEntity == entity).ToList();
			foreach (var assoc in assocs)
				this.GenerateFKProperty(assoc, propOutputList, usings);

			// Normal properties
			foreach (var prop in entity.Properties)
				this.GenerateProperty(prop, propOutputList, usings);

			// Navigation properties
			if (entity.Assocs.Count > 0) {
				propOutputList.AddLine();
				propOutputList.AddLine(1, $"// Navigation properties");
				foreach (var assoc in entity.Assocs)
					this.GenerateNavigationProperty(assoc, propOutputList, usings);
			}

			var classEnd = new List<string>();
			classEnd.Add("}");

			var sb = new StringBuilder();
			sb.AppendLine(string.Join(Environment.NewLine, header));
			usings.ForEach(u => sb.AppendLine($"using {u};"));
			sb.AppendLine(string.Join(Environment.NewLine, classStart));
			sb.AppendLine(string.Join(Environment.NewLine, propOutputList));
			sb.AppendLine(string.Join(Environment.NewLine, classEnd));

			var outputFile = Path.Combine(this.OutputRootFolder, $"{entity.Name}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, sb.ToString());
		}
	}

	private void GenerateFKProperty(AssocModel assoc, List<string> propOutputList, List<string> usings)
	{
		var tabCount = 1;

		string typeStr = assoc.Cardinality switch {
			CardinalityModel.OneToOne => $"{assoc.RelatedEntity.Name}",
			CardinalityModel.OneToMany => $"List<{assoc.RelatedEntity.Name}>",
			_ => throw new ApplicationException($"Error determining data type for property '{assoc.PrimaryPropertyName}': Cardinality '{assoc.Cardinality}' not supported.")
		};

		propOutputList.AddLine(tabCount, $"public List<{typeStr}> {assoc.PrimaryPropertyName} {{ get; set; }}");

		usings.AddIfNotExists(assoc.RelatedEntity.Namespace);
	}

	private void GenerateProperty(PropertyModel prop, List<string> propOutputList, List<string> usings)
	{
		var tc = 1;

		if (prop.Attributes.Any())
			foreach (var attr in prop.Attributes)
				propOutputList.AddLine(tc, $"[{attr}]");

		if (prop.EnumType != null) {
			propOutputList.AddLine(tc, $"[JsonConverter(typeof(JsonStringEnumConverter))]");
			propOutputList.AddLine(tc, $"public {prop.EnumType} {prop.Name} {{ get; set; }}");
			usings.AddIfNotExists("System.Text.Json.Serialization");

		} else {
			propOutputList.AddLine(tc, $"public {FormatTypeName(prop.PrimitiveType.ToString())} {prop.Name} {{ get; set; }}");
		}

		if (prop.AddlUsings.Any())
			foreach (var usingStr in prop.AddlUsings)
				usings.AddIfNotExists(usingStr);
	}

	private void GenerateNavigationProperty(AssocModel assoc, List<string> propOutputList, List<string> usings)
	{
		var tabCount = 1;

		string typeStr = null;

		switch (assoc.Cardinality) {
			case CardinalityModel.OneToOne:
				typeStr = $"{assoc.PrimaryEntity.Name}";
				break;

			case CardinalityModel.OneToMany:
				usings.AddIfNotExists("System.Collections.Generic");
				typeStr = $"List<{assoc.PrimaryEntity.Name}>";
				break;

			default:
				throw new ApplicationException($"Error determining data type for property '{assoc.PrimaryPropertyName}': Cardinality '{assoc.Cardinality}' not supported.");
		}

		propOutputList.AddLine(tabCount, $"public {typeStr} {assoc.PrimaryPropertyName} {{ get; set; }}");

		if (!string.IsNullOrWhiteSpace(assoc.RelatedEntity.Namespace))
			usings.AddIfNotExists(assoc.RelatedEntity.Namespace);
	}

	private void Validate()
	{
		if (!Directory.Exists(OutputRootFolder))
			throw new ApplicationException($"OutputRootFolder does not exist: {OutputRootFolder}");
	}

	private void GenerateHeader(List<string> headerLines)
	{
		headerLines.Add("//------------------------------------------------------------------------------");
		headerLines.Add("// This file was auto-generated. Any changes made to it will be lost.");
		headerLines.Add("//------------------------------------------------------------------------------");
	}

	private string FormatTypeName(string typeName)
	{
		return typeName?.Replace("Type", string.Empty);
	}

	private void GenerateEnums(DbContextModel dbContextMdl, List<EnumModel> enumMdls)
	{
		foreach (var enumMdl in enumMdls) {
			if (enumMdl.IsExternal)
				continue;

			var header = new List<string>();
			if (InclHeader)
				this.GenerateHeader(header);

			var usings = new List<string>();
			usings.Add("System");

			// Enum declaration
			var enumStart = new List<string>();
			enumStart.Add("");
			var ns = string.IsNullOrEmpty(enumMdl.Namespace) ? dbContextMdl.EntitiesNamespace : enumMdl.Namespace;
			enumStart.Add($"namespace {ns};");
			enumStart.Add("");
			if (enumMdl.IsFlags)
				enumStart.Add("[Flags]");
			enumStart.Add($"public enum {enumMdl.Name}");
			enumStart.Add("{");

			var propOutputList = new List<string>();
			foreach (var member in enumMdl.Members)
				propOutputList.AddLine(1, $"{member},");

			var classEnd = new List<string>();
			classEnd.Add("}");

			var sb = new StringBuilder();
			sb.AppendLine(string.Join(Environment.NewLine, header));
			usings.ForEach(u => sb.AppendLine($"using {u};"));
			sb.AppendLine(string.Join(Environment.NewLine, enumStart));
			sb.AppendLine(string.Join(Environment.NewLine, propOutputList));
			sb.AppendLine(string.Join(Environment.NewLine, classEnd));

			var outputFile = Path.Combine(this.OutputRootFolder, $"{enumMdl.Name}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, sb.ToString());
		}
	}
}
