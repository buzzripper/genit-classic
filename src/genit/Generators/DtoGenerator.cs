using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

public class DtoGenerator
{
	#region Constants

	private const string cTemplateFilename = "DTO.tmpl";

	private const string cToken_AddlUsings = "ADDL_USINGS";
	private const string cToken_DtoNs = "DTO_NS";
	private const string cToken_DtoName = "DTO_NAME";
	private const string cToken_Members = "MEMBERS";

	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.DTO;

	#endregion

	public void Run(ServiceGenModel svcGenModel, ObservableCollection<EntityModel> entities, string entitiesNamespace, string templatesFolderpath)
	{
		if (!svcGenModel.Enabled)
			return;

		// Load template

		var templateFilepath = Path.Combine(templatesFolderpath, cTemplateFilename);
		var outputRootFolder = Utils.ResolveRelativePath(Globals.CurrDocFilepath, svcGenModel.DtoOutputFolder);
		Validate(templateFilepath, outputRootFolder);
		var serviceTemplate = File.ReadAllText(templateFilepath);

		// Loop thru all update methods and generate DTOs

		foreach (var entity in entities.Where(e => e.Service.Enabled)) {
			foreach (var updateMethod in entity.Service.UpdateMethods) {
				var outputFolder = Path.Combine(outputRootFolder, $"{entity.Name}Req");
				if (!Directory.Exists(outputFolder))
					Directory.CreateDirectory(outputFolder);
				GenerateDto(updateMethod, svcGenModel, entity, $"{serviceTemplate}", entitiesNamespace, outputFolder);
			}
		}
	}

	private void Validate(string templateFilepath, string outputFolder)
	{
		if (!File.Exists(templateFilepath))
			throw new ApplicationException($"Template file does not exist: {templateFilepath}");

		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {outputFolder}");
	}

	private void GenerateDto(UpdateMethodModel updMethod, ServiceGenModel serviceGen, EntityModel entity, string template, string entitiesNamespace, string outputFolder)
	{
		var dtoName = $"{updMethod.Name}Req";
		var t = "\t";
		var sb = new StringBuilder();

		var addlUsings = string.Empty;
		if (updMethod.UpdateProperties.Any(x => x.Property.PrimitiveType == null))
			addlUsings = $"using {entitiesNamespace};{Environment.NewLine}";

		sb.AppendLine($"{t}public Guid Id {{ get; set; }}");
		if (entity.InclRowVersion)
			sb.AppendLine($"{t}public byte[] RowVersion {{ get; set; }}");

		// Required properties first
		foreach (var updProp in updMethod.UpdateProperties.Where(x => !x.IsOptional))
			sb.AppendLine($"{t}public {updProp.Property.DatatypeName} {updProp.Property.Name} {{ get; set; }}");

		// Optional properties last
		foreach (var updProp in updMethod.UpdateProperties.Where(x => x.IsOptional))
			sb.AppendLine($"{t}public {updProp.Property.DatatypeName} {updProp.Property.Name} {{ get; set; }}");

		var output = template.Replace(Utils.FmtToken(cToken_AddlUsings), addlUsings);
		output = output.Replace(Utils.FmtToken(cToken_DtoNs), serviceGen.DtoNamespace);
		output = output.Replace(Utils.FmtToken(cToken_DtoName), dtoName);
		output = output.Replace(Utils.FmtToken(cToken_Members), sb.ToString());

		var outputFile = Path.Combine(outputFolder, $"{dtoName}.g.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, output);
	}
}