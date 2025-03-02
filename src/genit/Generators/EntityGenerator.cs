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

			var propList = new List<string>();
			foreach (var prop in entity.Properties)
				this.GenerateProperty(prop, propList, usings);

			var classEnd = new List<string>();
			classEnd.Add("}");

			var sb = new StringBuilder();
			sb.AppendLine(string.Join(Environment.NewLine, header));
			usings.ForEach(u => sb.AppendLine($"using {u};"));
			sb.AppendLine(string.Join(Environment.NewLine, classStart));
			sb.AppendLine(string.Join(Environment.NewLine, propList));
			sb.AppendLine(string.Join(Environment.NewLine, classEnd));

			var outputFile = Path.Combine(this.OutputRootFolder, $"{entity.Name}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, sb.ToString());
		}
	}

	private void GenerateProperty(PropertyModel prop, List<string> propList, List<string> usings)
	{
		var tabCount = 1;

		if (prop.Attributes.Any())
			foreach (var attr in prop.Attributes)
				propList.Add($"{Tabs(tabCount)}[{attr}]");

		if (prop.EnumType != null) {
			propList.Add($"{Tabs(tabCount)}[JsonConverter(typeof(JsonStringEnumConverter))]");
			propList.Add($"{Tabs(tabCount)}public {prop.EnumType} {prop.Name} {{ get; set; }}");
			usings.AddIfNotExists("System.Text.Json.Serialization");

		} else {
			propList.Add($"{Tabs(tabCount)}public {FormatTypeName(prop.Type.ToString())} {prop.Name} {{ get; set; }}");
		}

		if (prop.AddlUsings.Any())
			foreach (var usingStr in prop.AddlUsings)
				usings.AddIfNotExists(usingStr);
	}

	private void GenerateAssocs(PropertyModel prop, List<AssocModel> assocs, List<string> usings)
	{
		var tabCount = 1;

		if (prop.Attributes.Any())
			foreach (var attr in prop.Attributes)
				propList.Add($"{Tabs(tabCount)}[{attr}]");

		if (prop.EnumType != null) {
			propList.Add($"{Tabs(tabCount)}[JsonConverter(typeof(JsonStringEnumConverter))]");
			propList.Add($"{Tabs(tabCount)}public {prop.EnumType} {prop.Name} {{ get; set; }}");
			usings.AddIfNotExists("System.Text.Json.Serialization");

		} else {
			propList.Add($"{Tabs(tabCount)}public {FormatTypeName(prop.Type.ToString())} {prop.Name} {{ get; set; }}");
		}

		if (prop.AddlUsings.Any())
			foreach (var usingStr in prop.AddlUsings)
				usings.AddIfNotExists(usingStr);
	}

	private void GenerateFile(StringBuilder sb, string fileTitle)
	{
		var outputFile = Path.Combine(this.OutputRootFolder, $"{fileTitle}.cs");
		File.WriteAllText(outputFile, sb.ToString());
	}

	private string Tabs(int count)
	{
		return new string('\t', count);
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

			var propList = new List<string>();
			foreach (var member in enumMdl.Members)
				propList.Add($"{Tabs(1)}{member},");

			var classEnd = new List<string>();
			classEnd.Add("}");

			var sb = new StringBuilder();
			sb.AppendLine(string.Join(Environment.NewLine, header));
			usings.ForEach(u => sb.AppendLine($"using {u};"));
			sb.AppendLine(string.Join(Environment.NewLine, enumStart));
			sb.AppendLine(string.Join(Environment.NewLine, propList));
			sb.AppendLine(string.Join(Environment.NewLine, classEnd));

			var outputFile = Path.Combine(this.OutputRootFolder, $"{enumMdl.Name}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, sb.ToString());
		}
	}
}
