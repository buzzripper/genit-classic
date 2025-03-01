using Dyvenix.Genit.DocModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using Syncfusion.Windows.Forms;
using System.Text.Json.Serialization;
using Dyvenix.Genit.Extensions;

namespace Dyvenix.Genit.Generators;

public class EntityGenerator
{
	//private List<string> _header = new List<string>();
	//private List<string> _usings = new List<string>();
	//private List<string> _ns = new List<string>();
	//private List<string> _classDecl = new List<string>();
	//private List<string> _properties = new List<string>();

	public bool InclHeader { get; set; }
	public string OutputRootFolder { get; set; }
	public bool Enabled { get; set; }
	public string Namespace { get; set; }

	public void Run(DbContextModel dbContextMdl)
	{
		Validate();

		var entities = dbContextMdl.Entities;

		if (!this.Enabled || !entities.Any(e => e.Enabled))
			return;

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

	//public string GenerateCSharpCode(CodeTypeDeclaration domClass, string folderPath)
	//{
	//	CodeCompileUnit compileUnit = new CodeCompileUnit();

	//	// Generate the code with the C# code provider.
	//	CSharpCodeProvider provider = new CSharpCodeProvider();

	//	// Build the output file name.
	//	string sourceFile;
	//	if (provider.FileExtension[0] == '.') {
	//		sourceFile = "HelloWorld" + provider.FileExtension;
	//	} else {
	//		sourceFile = "HelloWorld." + provider.FileExtension;
	//	}

	//	// Create a TextWriter to a StreamWriter to the output file.
	//	using (StreamWriter sw = new StreamWriter(sourceFile, false)) {
	//		IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");

	//		// Generate source code using the code provider.
	//		provider.GenerateCodeFromCompileUnit(compileunit, tw,
	//			new CodeGeneratorOptions());

	//		// Close the output file.
	//		tw.Close();
	//	}

	//	return sourceFile;
	//}
}
