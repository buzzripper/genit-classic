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
	private const string cToken_EntityNs = "ENTITY_NS";
	private const string cToken_Usings = "USINGS";
	private const string cToken_ContextNs = "CONTEXT_NS";
	private const string cToken_DbContextName = "DBCONTEXT_NAME";
	private const string cToken_Properties = "PROPERTIES";
	private const string cToken_OnModelCreating = "ON_MODEL_CREATING";

	public bool InclHeader { get; set; }
	public string OutputFolder { get; set; }
	public bool Enabled { get; set; }

	public void Run(DbContextModel dbContextModel)
	{
		if (!this.Enabled)
			return;

		Validate(dbContextModel);

		// Addl usings
		var usings = InitializeUsings(dbContextModel);

		// Properties
		var propsList = this.GenerateProperties(dbContextModel.Entities);

		// OnModelCreating()
		var onModelCreatingList = this.GenerateOnModelCreating(dbContextModel.Entities, dbContextModel.Assocs);

		// Replace tokens in template
		var fileContents = this.ReplaceTemplateTokens(dbContextModel, usings, propsList, onModelCreatingList);

		var outputFile = Path.Combine(this.OutputFolder, $"{dbContextModel.Name}.cs");
		if (File.Exists(outputFile))
			File.Delete(outputFile);
		File.WriteAllText(outputFile, fileContents);
	}

	private void Validate(DbContextModel dbContextModel)
	{
		if (!Directory.Exists(OutputFolder))
			throw new ApplicationException($"OutputRootFolder does not exist: {OutputFolder}");

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

		dbContextMdl.AddlUsings?.ForEach(u => usings.Add(u));
		usings.Add(dbContextMdl.EntitiesNamespace);

		return usings;
	}

	private List<string> GenerateProperties(List<EntityModel> entities)
	{
		if (!entities.Any())
			return new List<string>();

		var propsList = new List<string>();

		var t = 1;

		propsList.AddLine(t, "// Properties");

		foreach (var entity in entities) {
			if (!entity.Enabled)
				continue;

			propsList.AddLine(t, $"public DbSet<{entity.Name}> {entity.Name} {{ get; set; }}");
		}

		propsList.AddLine();

		return propsList;
	}

	private List<string> GenerateOnModelCreating(List<EntityModel> entities, List<AssocModel> assocs)
	{
		var outList = new List<string>();

		foreach (var entity in entities) {
			if (!entity.Enabled)
				continue;
			this.GenerateModelBuilderEntity(entity, assocs, outList);
		}

		return outList;
	}

	private void GenerateModelBuilderEntity(EntityModel entity, List<AssocModel> assocs, List<string> outList)
	{
		if (!entity.Enabled)
			return;

		var t = 2;
		outList.AddLine(t, $"modelBuilder.Entity<{entity.Name}>(entity =>");
		outList.AddLine(t, "{");
		var tableName = string.IsNullOrWhiteSpace(entity.TableName) ? entity.Name : entity.TableName;
		outList.AddLine(t + 1, $"entity.ToTable(\"{tableName}\");");
		outList.AddLine();

		// Properties
		//foreach (var prop in entity.Properties.Where(p => p.FKAssoc == null)) {
		foreach (var prop in entity.Properties) {
			var sb = new StringBuilder();
			sb.Append($"entity.Property(e => e.{prop.Name})");

			if (prop.IsPrimaryKey) {
				var valGen = prop.IsIdentity ? "ValueGeneratedOnAdd" : "ValueGeneratedNever";
				sb.Append($".{valGen}()");
			}

			if (!prop.Nullable)
				sb.Append($".IsRequired()");

			if (prop.PrimitiveType == PrimitiveType.String && prop.MaxLength > 0) {
				sb.Append($".HasMaxLength({prop.MaxLength})");

			} else if (prop.PrimitiveType == PrimitiveType.DateTime) {
				sb.Append($".HasColumnType(\"{PrimitiveType.DateTime.SqlType}\")");
			}

			sb.Append(";");
			outList.AddLine(t + 1, sb.ToString());
		}

		// Indexes
		var indexedProps = entity.Properties.Where(p => p.IsIndexed).ToList();
		if (indexedProps.Count > 0) {
			outList.AddLine();
			outList.AddLine(t+1, "// Indexes");
			foreach (var prop in indexedProps) {
				var sb = new StringBuilder();
				sb.Append($"entity.HasIndex(e => e.{prop.Name}, \"IX_{entity.Name}_{prop.Name}\")");
				if (prop.IsIndexUnique)
					sb.Append(".IsUnique()");
				if (prop.IsIndexClustered)
					sb.Append(".IsClustered()");
				sb.Append(";");

				outList.AddLine(t + 1, sb.ToString());
			}
		}
		
		outList.AddLine(t, "});");
		outList.AddLine();
	}

	//private string MapSqlServerType(PrimitiveType primitiveType)
	//{
	//	return primitiveType switch {
	//		PrimitiveType.stringType => "nvarchar",
	//		PrimitiveType.Int32 => "int",
	//		PrimitiveType.Bool => "bit",
	//		PrimitiveType.Guid => "uniqueidentifier",
	//		PrimitiveType.DateTime => "datetime",
	//		PrimitiveType.TimeSpanType => "time",
	//		PrimitiveType.shortType => "smallint",
	//		PrimitiveType.Int64 => "bigint",
	//		PrimitiveType.Double => "float",
	//		PrimitiveType.DecimalType => "decimal",
	//		PrimitiveType.DateTimeOffsetType => "datetimeoffset",
	//		PrimitiveType.ByteArrayType => "varbinary",
	//		PrimitiveType.TimeType => "time",
	//		_ => throw new ApplicationException($"Error determining data type '{primitiveType}'")
	//	};
	//}

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


	#region Utility methods

	private string FormatTypeName(string typeName)
	{
		return typeName?.Replace("Type", string.Empty);
	}

	private string FmtToken(string tokenTitle)
	{
		return $"${{{{{tokenTitle}}}}}";
	}

	#endregion
}
