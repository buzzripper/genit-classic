using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dyvenix.Genit.Generators;

public class EntityGenerator : GeneratorBase
{
	#region Fields

	private string _outputFolder;

	#endregion
		
	public EntityGenerator(EntityGenModel entityMdl) : base(entityMdl)
	{
		_outputFolder = entityMdl.OutputFolder;
	}

	#region Properties


	#endregion

	public void Run(ObservableCollection<EntityModel> entities, string entitiesNamespace)
	{
		if (!this._enabled)
			return;

		Validate();

		if (entities.Any(e => e.Enabled))
			this.GenerateEntities(entities, entitiesNamespace);
	}

	private void Validate()
	{
		if (!Directory.Exists(_outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {_outputFolder}");
	}

	private void GenerateEntities(ObservableCollection<EntityModel> entities, string entitiesNamespace)
	{
		foreach (var entity in entities) {
			if (!entity.Enabled)
				continue;

			var usings = new List<string>();
			usings.Add("System");
			entity.AddlUsings.ToList().ForEach(u => usings.Add(u));

			// Class declaration
			var classStart = new List<string>();
			classStart.Add("");
			entity.Attributes.ToList().ForEach(a => classStart.Add($"[{a}]"));
			var ns = string.IsNullOrWhiteSpace(entity.Namespace) ? entitiesNamespace : entity.Namespace;
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
			//var fkProps = entity.Properties.Where(p => p.FKAssoc != null).ToList();
			//foreach (var prop in fkProps)
			//	this.GenerateProperty(prop, propOutputList, usings);
			//if (fkProps.Count > 0)
			//	propOutputList.AddLine();

			//// Normal properties
			//foreach (var prop in entity.Properties.Where(p => p.FKAssoc == null && !p.IsPrimaryKey))
			//	this.GenerateProperty(prop, propOutputList, usings);

			//// Navigation properties
			//if (entity.NavAssocs.Count > 0) {
			//	propOutputList.AddLine();
			//	propOutputList.AddLine(1, $"// Navigation properties");
			//	foreach (var navProperty in entity.NavAssocs)
			//		this.GenerateNavigationProperty(navProperty, propOutputList, usings);
			//}

			var classEnd = new List<string>();
			classEnd.Add("}");

			var sb = new StringBuilder();
			sb.AppendLine(string.Join(Environment.NewLine, _headerLines));
			usings.ForEach(u => sb.AppendLine($"using {u};"));
			sb.AppendLine(string.Join(Environment.NewLine, classStart));
			sb.AppendLine(string.Join(Environment.NewLine, propOutputList));
			sb.AppendLine(string.Join(Environment.NewLine, classEnd));

			var outputFile = Path.Combine(this._outputFolder, $"{entity.Name}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, sb.ToString());
		}
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

	//private void GenerateNavigationProperty(AssocModel navProperty, List<string> propOutputList, List<string> usings)
	//{
	//	var tabCount = 1;

	//	switch (navProperty.Cardinality) {
	//		case CardinalityModel.OneToOne:
	//			propOutputList.AddLine(tabCount, $"public {navProperty.RelatedEntity.Name} {navProperty.PrimaryPropertyName} {{ get; set; }}");
	//			break;

	//		case CardinalityModel.OneToMany:
	//			usings.AddIfNotExists("System.Collections.Generic");
	//			propOutputList.AddLine(tabCount, $"public virtual ICollection<{navProperty.RelatedEntity.Name}> {navProperty.PrimaryPropertyName} {{ get; set; }} = new List<{navProperty.RelatedEntity.Name}>();");
	//			break;

	//		default:
	//			throw new ApplicationException($"Error determining data type for property '{navProperty.PrimaryPropertyName}': Cardinality '{navProperty.Cardinality}' not supported.");
	//	}

	//	this.AddEntityNamespace(navProperty.RelatedEntity, usings);
	//}
}
