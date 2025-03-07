using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

public class EntityGenerator : IGeneratorModel
{
	private DbContextModel _dbContextMdl;

	public string Name { get { return "Entity Generator"; } }
	public bool InclHeader { get; set; }
	public string OutputRootFolder { get; set; }
	public bool Enabled { get; set; }
	public string Namespace { get; set; }

	public void Run(DbContextModel dbContextMdl)
	{
		Validate();

		_dbContextMdl = dbContextMdl;
		var entities = dbContextMdl.Entities;

		if (!this.Enabled)
			return;

		if (dbContextMdl.Entities.Any(e => e.Enabled))
			this.GenerateEntities(dbContextMdl, dbContextMdl.Entities);

		if (!dbContextMdl.Enums.All(e => e.IsExternal))
			this.GenerateEnums(dbContextMdl, dbContextMdl.Enums);
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

	private void AddEntityNamespace(EntityModel entityMdl, List<string> usings)
	{
		var ns = string.IsNullOrWhiteSpace(entityMdl.Namespace) ?
			_dbContextMdl.EntitiesNamespace :
			entityMdl.Namespace;

		if (string.IsNullOrWhiteSpace(ns))
			throw new ApplicationException($"Cannot determine namespace for entity '{entityMdl.Name}'.");

		if (string.Compare(ns, _dbContextMdl.EntitiesNamespace, true) != 0)
			usings.AddIfNotExists(ns);
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
			var ns = string.IsNullOrWhiteSpace(entity.Namespace) ? dbContextMdl.EntitiesNamespace : entity.Namespace;
			classStart.Add($"namespace {ns};");
			classStart.Add("");
			classStart.Add($"public partial class {entity.Name}");
			classStart.Add("{");

			var propOutputList = new List<string>();

			// PK
			var pkProp = entity.Properties.FirstOrDefault(p => p.IsPrimaryKey);
			this.GenerateProperty(pkProp, propOutputList, usings);
			propOutputList.AddLine();

			// FK properties
			var fkProps = entity.Properties.Where(p => p.FKAssoc != null).ToList();
			foreach (var prop in fkProps)
				this.GenerateProperty(prop, propOutputList, usings);
			if (fkProps.Count > 0)
				propOutputList.AddLine();

			// Normal properties
			foreach (var prop in entity.Properties.Where(p => p.FKAssoc == null && !p.IsPrimaryKey))
				this.GenerateProperty(prop, propOutputList, usings);

			// Navigation properties
			if (entity.NavAssocs.Count > 0) {
				propOutputList.AddLine();
				propOutputList.AddLine(1, $"// Navigation properties");
				foreach (var navProperty in entity.NavAssocs)
					this.GenerateNavigationProperty(navProperty, propOutputList, usings);
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

	private void GenerateFKProperty(AssocModel navProperty, List<string> propOutputList, List<string> usings)
	{
		var tabCount = 1;

		string typeStr = navProperty.Cardinality switch {
			CardinalityModel.OneToOne => $"{navProperty.RelatedEntity.Name}",
			CardinalityModel.OneToMany => $"List<{navProperty.RelatedEntity.Name}>",
			_ => throw new ApplicationException($"Error determining data type for property '{navProperty.PrimaryPropertyName}': Cardinality '{navProperty.Cardinality}' not supported.")
		};

		propOutputList.AddLine(tabCount, $"public {navProperty.RelatedEntity.Name} {navProperty.PrimaryPropertyName} {{ get; set; }}");

		this.AddEntityNamespace(navProperty.RelatedEntity, usings);
	}

	private void GenerateProperty(PropertyModel prop, List<string> propOutputList, List<string> usings)
	{
		var tc = 1;

		if (prop.Attributes.Any())
			foreach (var attr in prop.Attributes)
				propOutputList.AddLine(tc, $"[{attr}]");

		if ((prop.PrimitiveType ?? PrimitiveType.None) != PrimitiveType.None) {
			propOutputList.AddLine(tc, $"public {prop.PrimitiveType.CSType} {prop.Name} {{ get; set; }}");

		} else if (prop.EnumType != null) {
			propOutputList.AddLine(tc, $"[JsonConverter(typeof(JsonStringEnumConverter))]");
			propOutputList.AddLine(tc, $"public {prop.EnumType.Name} {prop.Name} {{ get; set; }}");
			usings.AddIfNotExists("System.Text.Json.Serialization");
			if (!string.IsNullOrWhiteSpace(prop.EnumType.Namespace))
				usings.AddIfNotExists(prop.EnumType.Namespace);
		}

		if (prop.AddlUsings.Any())
			foreach (var usingStr in prop.AddlUsings)
				usings.AddIfNotExists(usingStr);
	}

	private void GenerateNavigationProperty(AssocModel navProperty, List<string> propOutputList, List<string> usings)
	{
		var tabCount = 1;

		switch (navProperty.Cardinality) {
			case CardinalityModel.OneToOne:
				propOutputList.AddLine(tabCount, $"public {navProperty.RelatedEntity.Name} {navProperty.PrimaryPropertyName} {{ get; set; }}");
				break;

			case CardinalityModel.OneToMany:
				usings.AddIfNotExists("System.Collections.Generic");
				propOutputList.AddLine(tabCount, $"public virtual ICollection<{navProperty.RelatedEntity.Name}> {navProperty.PrimaryPropertyName} {{ get; set; }} = new List<{navProperty.RelatedEntity.Name}>();");
				break;

			default:
				throw new ApplicationException($"Error determining data type for property '{navProperty.PrimaryPropertyName}': Cardinality '{navProperty.Cardinality}' not supported.");
		}

		this.AddEntityNamespace(navProperty.RelatedEntity, usings);
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
			var ns = string.IsNullOrWhiteSpace(enumMdl.Namespace) ? dbContextMdl.EntitiesNamespace : enumMdl.Namespace;
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
