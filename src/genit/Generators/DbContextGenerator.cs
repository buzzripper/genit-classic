using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

public class DbContextGenerator
{
	#region Constants

	private const string cToken_Usings = "USINGS";
	private const string cToken_ContextNs = "CONTEXT_NS";
	private const string cToken_DbContextName = "DBCONTEXT_NAME";
	private const string cToken_Properties = "PROPERTIES";
	private const string cToken_OnModelCreating = "ON_MODEL_CREATING";

	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.DbContext;

	#endregion
		
	public void Run(DbContextGenModel genModel, DbContextModel dbContextModel)
	{
		if (!genModel.Enabled)
			return;

		// Get absolute output folder path
		var outputFolder = Path.IsPathRooted(genModel.OutputFolder) ? genModel.OutputFolder : Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Globals.CurrDocFilepath), genModel.OutputFolder));

		Validate(outputFolder, dbContextModel);

		// Addl usings
		var usings = InitializeUsings(dbContextModel);

		// Properties
		var propsList = GenerateProperties(dbContextModel.Entities);

		// OnModelCreating()
		var onModelCreatingList = GenerateOnModelCreating(dbContextModel.Entities);

		// Replace tokens in template
		var fileContents = ReplaceTemplateTokens(dbContextModel, usings, propsList, onModelCreatingList);

		// Write to file
		var outputFilepath = Path.Combine(outputFolder, $"{dbContextModel.Name}.cs");;
		if (File.Exists(outputFilepath))
			File.Delete(outputFilepath);
		File.WriteAllText(outputFilepath, fileContents);
	}

	private void Validate(string outputFolder, DbContextModel dbContextModel)
	{
		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputRootFolder does not exist: {outputFolder}");

		if (string.IsNullOrWhiteSpace(dbContextModel.ContextNamespace))
			throw new ApplicationException($"ContextNamespace not set on db context");

		if (string.IsNullOrWhiteSpace(dbContextModel.EntitiesNamespace))
			throw new ApplicationException($"EntitiesNamespace not set on db context");

		if (!dbContextModel.Entities.Any())
			throw new ApplicationException($"No entities found in DbContext.");
	}

	private List<string> InitializeUsings(DbContextModel dbContextMdl)
	{
		var usings = new List<string>();

		usings.Add("System");
		usings.Add("Microsoft.EntityFrameworkCore");
		usings.Add("System.Collections.Generic");

		dbContextMdl.AddlUsings?.ToList().ForEach(u => usings.Add(u));
		usings.Add(dbContextMdl.EntitiesNamespace);

		return usings;
	}

	private List<string> GenerateProperties(ObservableCollection<EntityModel> entities)
	{
		if (!entities.Any())
			return new List<string>();

		var propsList = new List<string>();

		var t = 1;

		foreach (var entity in entities) {
			if (!entity.Enabled)
				continue;

			propsList.AddLine(t, $"public DbSet<{entity.Name}> {entity.Name} {{ get; set; }}");
		}

		return propsList;
	}

	private List<string> GenerateOnModelCreating(ObservableCollection<EntityModel> entities)
	{
		var outList = new List<string>();

		foreach (var entity in entities) {
			if (!entity.Enabled)
				continue;
			GenerateModelBuilderEntity(entity, outList);
		}

		return outList;
	}

	private void GenerateModelBuilderEntity(EntityModel entity, List<string> outList)
	{
		if (!entity.Enabled)
			return;

		var t = 2;
		outList.AddLine(t, $"modelBuilder.Entity<{entity.Name}>(entity =>");
		outList.AddLine(t, "{");
		var tableName = string.IsNullOrWhiteSpace(entity.TableName) ? entity.Name : entity.TableName;
		if (string.IsNullOrWhiteSpace(entity.Schema))
			outList.AddLine(t + 1, $"entity.ToTable(\"{tableName}\");");
		else
			outList.AddLine(t + 1, $"entity.ToTable(\"{tableName}\", \"{entity.Schema}\");");
		outList.AddLine();

		// Primary key properties
		foreach (var prop in entity.Properties.Where(p => p.IsPrimaryKey)) {
			var sb = new StringBuilder();
			sb.Append($"entity.HasKey(e => e.{prop.Name})");

			if (prop.IsIndexClustered)
				sb.Append($".IsClustered(true)");

			sb.Append(";");
			outList.AddLine(t + 1, sb);
		}
		outList.AddLine();

		// Normal properties
		foreach (var prop in entity.Properties.Where(p => !p.IsPrimaryKey)) {
			var sb = new StringBuilder();
			sb.Append($"entity.Property(e => e.{prop.Name})");

			if (prop.Nullable)
				sb.Append($".IsRequired(false)");
			else
				sb.Append($".IsRequired(true)");

			if (prop.PrimitiveType == PrimitiveType.String && prop.MaxLength > 0) {
				sb.Append($".HasMaxLength({prop.MaxLength})");

			} else if (prop.PrimitiveType == PrimitiveType.DateTime) {
				sb.Append($".HasColumnType(\"{PrimitiveType.DateTime.SqlType}\")");
			}

			sb.Append(";");
			outList.AddLine(t + 1, sb);
		}

		// Indexes
		var indexedProps = entity.Properties.Where(p => p.IsIndexed).ToList();
		if (indexedProps.Count > 0) {
			outList.AddLine();
			outList.AddLine(t + 1, "// Indexes");
			foreach (var prop in indexedProps) {
				var sb = new StringBuilder();
				sb.Append($"entity.HasIndex(e => e.{prop.Name}, \"IX_{entity.Name}_{prop.Name}\")");
				if (prop.IsIndexUnique)
					sb.Append(".IsUnique()");
				if (prop.IsIndexClustered)
					sb.Append(".IsClustered()");
				sb.Append(";");

				outList.AddLine(t + 1, sb);
			}
		}

		outList.AddLine(t, "});");
		outList.AddLine();
	}

	private string ReplaceTemplateTokens(DbContextModel dbContextModel, List<string> usings, List<string> propsList, List<string> onModelCreatingList)
	{
		var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Generators\Templates\DbContext.cs.tmpl");
		if (!File.Exists(filepath))
			throw new ApplicationException($"Dbcontext template file not found at ''{filepath}");

		var template = File.ReadAllText(filepath);

		// Usings
		var sb = new StringBuilder();
		usings.ForEach(x => sb.AppendLine($"using {x};"));
		template = template.Replace(FmtToken(cToken_Usings), sb.ToString());

		template = template.Replace(FmtToken(cToken_ContextNs), dbContextModel.ContextNamespace);
		template = template.Replace(FmtToken(cToken_DbContextName), dbContextModel.Name);


		sb = new StringBuilder();
		propsList.ForEach(x => sb.AppendLine(x));
		template = template.Replace(FmtToken(cToken_Properties), sb.ToString());

		sb = new StringBuilder();
		onModelCreatingList.ForEach(x => sb.AppendLine(x));
		template = template.Replace(FmtToken(cToken_OnModelCreating), sb.ToString());

		return template;
	}

	#region Utility methods

	private string FmtToken(string tokenTitle)
	{
		return $"${{{{{tokenTitle}}}}}";
	}

	#endregion
}
