using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

public class DbContextGenerator
{
	private DbContextModel _dbMdl;
	private List<string> _usings;

	public bool InclHeader { get; set; }
	public string OutputRootFolder { get; set; }
	public bool Enabled { get; set; }
	//public string Namespace { get; set; }

	public void Run(DbContextModel dbContextModel)
	{
		if (!this.Enabled)
			return;

		Validate(dbContextModel);

		// Header
		var headerLines = GenerateHeader();

		// Usings
		var _usings = InitUsings(_dbMdl);

		var classDeclLines = GenerateClassDeclaration();

		//if (_dbMdl.Entities.Any(e => e.Enabled))
		//	this.GenerateEntities(_dbMdl.Entities);

		//if (!_dbMdl.Enums.All(e => e.IsExternal))
		//	this.GenerateEnums(_dbMdl, _dbMdl.Enums);

		var sb = new StringBuilder();
		headerLines.ForEach(x => sb.AppendLine(x));
		_usings.ForEach(u => sb.AppendLine($"using {u};"));
		classDeclLines.ForEach(u => sb.AppendLine($"using {u};"));
		sb.AppendLine(string.Join(Environment.NewLine, classStart));
		sb.AppendLine(string.Join(Environment.NewLine, propOutputList));
		sb.AppendLine(string.Join(Environment.NewLine, classEnd));

		var outputFile = Path.Combine(this.OutputRootFolder, $"{entity.Name}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, sb.ToString());

	}

	private List<string> GenerateHeader()
	{
		var headerLines = new List<string>();
		headerLines.Add("//------------------------------------------------------------------------------");
		headerLines.Add("// This file was auto-generated. Any changes made to it will be lost.");
		headerLines.Add("//------------------------------------------------------------------------------");
		return headerLines;
	}

	private void Validate(DbContextModel dbContextModel)
	{
		if (!Directory.Exists(OutputRootFolder))
			throw new ApplicationException($"OutputRootFolder does not exist: {OutputRootFolder}");
		if (!Directory.Exists(dbContextModel.ContextNamespace))
			throw new ApplicationException($"ContextNamespace not set on db context");
		if (!Directory.Exists(dbContextModel.EntitiesNamespace))
			throw new ApplicationException($"EntitiesNamespace not set on db context");
	}

	private List<string> InitUsings(DbContextModel _dbMdl)
	{
		var _usings = new List<string>();

		// Add default _usings
		_usings.Add("System");
		_usings.Add("System.Data");
		_usings.Add("System.Linq");
		_usings.Add("System.Linq.Expressions");
		_usings.Add("System.Data.Common");
		_usings.Add("System.Collections.Generic");
		_usings.Add("Microsoft.EntityFrameworkCore");
		_usings.Add("Microsoft.EntityFrameworkCore.Infrastructure");
		_usings.Add("Microsoft.EntityFrameworkCore.Internal");
		_usings.Add("Microsoft.EntityFrameworkCore.Metadata");

		// Context namespace
		if (!string.IsNullOrWhiteSpace(_dbMdl.ContextNamespace))
			_usings.Add(_dbMdl.ContextNamespace);
		if (!string.IsNullOrWhiteSpace(_dbMdl.ContextNamespace))
			_usings.Add(_dbMdl.ContextNamespace);

		// Add additional _usings
		_dbMdl.AddlContextUsings.ForEach(u => _usings.Add(u));

		_usings.AddLine();

		return _usings;
	}

	private List<string> GenerateClassDeclaration()
	{
		var classDecl = new List<string>();

		classDecl.Add($"namespace {_dbMdl.ContextNamespace};");
		classDecl.Add("{");
		classDecl.AddLine(1, $"public partial class {_dbMdl.Name} : DbContext");
		classDecl.AddLine(1, "{");
		classDecl.AddLine(2, $"public {_dbMdl.Name}() :");
		classDecl.AddLine(3, "base()");
		classDecl.AddLine(2, "{");
		classDecl.AddLine(3, "OnCreated();");
		classDecl.AddLine(2, "}");
		classDecl.AddLine();

		classDecl.AddLine(2, $"public {_dbMdl.Name}(DbContextOptions<{_dbMdl.Name}> options) :");
		classDecl.AddLine(3, "base()");
		classDecl.AddLine(2, "{");
		classDecl.AddLine(3, "OnCreated();");
		classDecl.AddLine(2, "}");
		classDecl.AddLine();

		return classDecl;
	}

	//private void GenerateEntities(List<EntityModel> entities)
	//{
	//	foreach (var entity in entities) {
	//		if (!entity.Enabled)
	//			continue;

	//		var header = new List<string>();
	//		if (InclHeader)
	//			this.GenerateHeader(header);

	//		var _usings = new List<string>();
	//		_usings.Add("System");
	//		entity.AddlUsings.ForEach(u => _usings.Add(u));

	//		// Class declaration
	//		var classStart = new List<string>();
	//		classStart.Add("");
	//		entity.Attributes.ForEach(a => classStart.Add($"[{a}]"));
	//		var ns = string.IsNullOrEmpty(entity.Namespace) ? _dbMdl.EntitiesNamespace : entity.Namespace;
	//		classStart.Add($"namespace {ns};");
	//		classStart.Add("");
	//		classStart.Add($"public partial class {entity.Name}");
	//		classStart.Add("{");

	//		var propOutputList = new List<string>();

	//		// FK properties
	//		var assocs = _dbMdl.Assocs.Where(p => p.RelatedEntity == entity).ToList();
	//		foreach (var assoc in assocs)
	//			this.GenerateFKProperty(assoc, propOutputList, _usings);

	//		// Normal properties
	//		foreach (var prop in entity.Properties)
	//			this.GenerateProperty(prop, propOutputList, _usings);

	//		// Navigation properties
	//		if (entity.Assocs.Count > 0) {
	//			propOutputList.AddLine();
	//			propOutputList.AddLine(1, $"// Navigation properties");
	//			foreach (var assoc in entity.Assocs)
	//				this.GenerateNavigationProperty(assoc, propOutputList, _usings);
	//		}

	//		var classEnd = new List<string>();
	//		classEnd.Add("}");

	//		var sb = new StringBuilder();
	//		sb.AppendLine(string.Join(Environment.NewLine, header));
	//		_usings.ForEach(u => sb.AppendLine($"using {u};"));
	//		sb.AppendLine(string.Join(Environment.NewLine, classStart));
	//		sb.AppendLine(string.Join(Environment.NewLine, propOutputList));
	//		sb.AppendLine(string.Join(Environment.NewLine, classEnd));

	//		var outputFile = Path.Combine(this.OutputRootFolder, $"{entity.Name}.cs");
	//		if (File.Exists(outputFile))
	//			File.Delete(outputFile);
	//		File.WriteAllText(outputFile, sb.ToString());
	//	}
	//}

	//private void GenerateFKProperty(AssocModel assoc, List<string> propOutputList)
	//{
	//	var tabCount = 1;

	//	string typeStr = assoc.Cardinality switch {
	//		CardinalityModel.OneToOne => $"{assoc.RelatedEntity.Name}",
	//		CardinalityModel.OneToMany => $"List<{assoc.RelatedEntity.Name}>",
	//		_ => throw new ApplicationException($"Error determining data type for property '{assoc.PrimaryPropertyName}': Cardinality '{assoc.Cardinality}' not supported.")
	//	};

	//	propOutputList.AddLine(tabCount, $"public List<{typeStr}> {assoc.PrimaryPropertyName} {{ get; set; }}");

	//	_usings.AddIfNotExists(assoc.RelatedEntity.Namespace);
	//}

	//private void GenerateProperty(PropertyModel prop, List<string> propOutputList)
	//{
	//	var tc = 1;

	//	if (prop.Attributes.Any())
	//		foreach (var attr in prop.Attributes)
	//			propOutputList.AddLine(tc, $"[{attr}]");

	//	if (prop.EnumType != null) {
	//		propOutputList.AddLine(tc, $"[JsonConverter(typeof(JsonStringEnumConverter))]");
	//		propOutputList.AddLine(tc, $"public {prop.EnumType} {prop.Name} {{ get; set; }}");
	//		_usings.AddIfNotExists("System.Text.Json.Serialization");

	//	} else {
	//		propOutputList.AddLine(tc, $"public {FormatTypeName(prop.PrimitiveType.ToString())} {prop.Name} {{ get; set; }}");
	//	}

	//	if (prop.AddlUsings.Any())
	//		foreach (var usingStr in prop.AddlUsings)
	//			_usings.AddIfNotExists(usingStr);
	//}

	//private void GenerateNavigationProperty(AssocModel assoc, List<string> propOutputList)
	//{
	//	var tabCount = 1;

	//	string typeStr = null;

	//	switch (assoc.Cardinality) {
	//		case CardinalityModel.OneToOne:
	//			typeStr = $"{assoc.PrimaryEntity.Name}";
	//			break;

	//		case CardinalityModel.OneToMany:
	//			_usings.AddIfNotExists("System.Collections.Generic");
	//			typeStr = $"List<{assoc.PrimaryEntity.Name}>";
	//			break;

	//		default:
	//			throw new ApplicationException($"Error determining data type for property '{assoc.PrimaryPropertyName}': Cardinality '{assoc.Cardinality}' not supported.");
	//	}

	//	propOutputList.AddLine(tabCount, $"public {typeStr} {assoc.PrimaryPropertyName} {{ get; set; }}");

	//	if (!string.IsNullOrWhiteSpace(assoc.RelatedEntity.Namespace))
	//		_usings.AddIfNotExists(assoc.RelatedEntity.Namespace);
	//}


	//private void GenerateHeader(List<string> headerLines)
	//{
	//	headerLines.Add("//------------------------------------------------------------------------------");
	//	headerLines.Add("// This file was auto-generated. Any changes made to it will be lost.");
	//	headerLines.Add("//------------------------------------------------------------------------------");
	//}

	//private string FormatTypeName(string typeName)
	//{
	//	return typeName?.Replace("Type", string.Empty);
	//}

	//private void GenerateEnums(DbContextModel _dbMdl, List<EnumModel> enumMdls)
	//{
	//	foreach (var enumMdl in enumMdls) {
	//		if (enumMdl.IsExternal)
	//			continue;

	//		var header = new List<string>();
	//		if (InclHeader)
	//			this.GenerateHeader(header);

	//		var _usings = new List<string>();
	//		_usings.Add("System");

	//		// Enum declaration
	//		var enumStart = new List<string>();
	//		enumStart.Add("");
	//		var ns = string.IsNullOrEmpty(enumMdl.Namespace) ? _dbMdl.EntitiesNamespace : enumMdl.Namespace;
	//		enumStart.Add($"namespace {ns};");
	//		enumStart.Add("");
	//		if (enumMdl.IsFlags)
	//			enumStart.Add("[Flags]");
	//		enumStart.Add($"public enum {enumMdl.Name}");
	//		enumStart.Add("{");

	//		var propOutputList = new List<string>();
	//		foreach (var member in enumMdl.Members)
	//			propOutputList.AddLine(1, member);

	//		var classEnd = new List<string>();

	//		var sb = new StringBuilder();
	//		sb.AppendLine(string.Join(Environment.NewLine, header));
	//		_usings.ForEach(u => sb.AppendLine($"using {u};"));
	//		sb.AppendLine(string.Join(Environment.NewLine, enumStart));
	//		sb.AppendLine(string.Join(Environment.NewLine, propOutputList));
	//		sb.AppendLine(string.Join(Environment.NewLine, classEnd));

	//		var outputFile = Path.Combine(this.OutputRootFolder, $"{enumMdl.Name}.cs");
	//		if (File.Exists(outputFile))
	//			File.Delete(outputFile);
	//		File.WriteAllText(outputFile, sb.ToString());
	//	}
	//}
}
