using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

public class EnumGenerator : GeneratorBase
{
	#region Fields

	private string _outputFolder;

	#endregion
		
	public EnumGenerator(EnumGenModel enumGenMdl) : base(enumGenMdl)
	{
		_outputFolder = enumGenMdl.OutputFolder;
	}

	#region Properties


	#endregion

	public void Run(ObservableCollection<EnumModel> enumMdls, string enumsNamespace)
	{
		Validate();

		if (!this._enabled)
			return;

		if (!enumMdls.All(e => e.IsExternal))
			this.GenerateEnums(enumMdls, enumsNamespace);
	}

	private void Validate()
	{
		if (!Directory.Exists(_outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {_outputFolder}");
	}

	private void GenerateEnums(ObservableCollection<EnumModel> enumMdls, string enumsNamespace)
	{
		foreach (var enumMdl in enumMdls) {
			if (enumMdl.IsExternal)
				continue;

			var usings = new List<string>();
			usings.Add("System");

			// Enum declaration
			var enumStart = new List<string>();
			enumStart.Add("");
			var ns = string.IsNullOrWhiteSpace(enumMdl.Namespace) ? enumsNamespace : enumMdl.Namespace;
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
			sb.AppendLine(string.Join(Environment.NewLine, _headerLines));
			usings.ForEach(u => sb.AppendLine($"using {u};"));
			sb.AppendLine(string.Join(Environment.NewLine, enumStart));
			sb.AppendLine(string.Join(Environment.NewLine, propOutputList));
			sb.AppendLine(string.Join(Environment.NewLine, classEnd));

			var outputFile = Path.Combine(this._outputFolder, $"{enumMdl.Name}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, sb.ToString());
		}
	}
}
