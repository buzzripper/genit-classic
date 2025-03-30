using Dyvenix.Genit.Extensions;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dyvenix.Genit.Generators;

internal class ServiceQueryGenerator
{
	private const string cToken_CurrTimestamp = "CURR_TIMESTAMP";
	private const string cToken_AddlUsings = "ADDL_USINGS";

	private const string cToken_QueriesNs = "QUERIES_NS";
	private const string cToken_QueryClassName = "QUERY_CLASS_NAME";
	private const string cToken_QueryIntfDecl = "QUERY_INTF_DECL";
	private const string cToken_FilterProps = "FILTER_PROPERTIES";
	private const string cToken_QueryInclSorting = "QRY_INCL_SORTING";
	private const string cToken_QueryInclPaging = "QRY_INCL_PAGING";

	internal void GenerateQueryClass(ServiceModel service, ServiceGenModel serviceGen, string template, string outputFolder, string queriesNamespace)
	{
		foreach (var queryMethod in service.Methods.Where(m => m.UseQuery)) {
			var className = $"{queryMethod.Name}Query";
			string interfaceDecl = null;

			// Addl usings
			var addlUsings = new List<string>();
			if (queryMethod.InclSorting)
				addlUsings.Add("Dyvenix.Core.Queries");

			// Sorting
			var sortingSb = new StringBuilder();
			if (queryMethod.InclSorting) {
				interfaceDecl = ": ISortingQuery";
				sortingSb.AppendLine("\tpublic string SortBy { get; set; }");
				sortingSb.AppendLine("\tpublic bool SortDesc { get; set; }");
			}

			// Paging
			var pagingSb = new StringBuilder();
			if (queryMethod.InclPaging) {
				pagingSb.AppendLine("\tpublic int PageSize { get; set; }");
				pagingSb.AppendLine("\tpublic int PageOffset { get; set; }");
				pagingSb.AppendLine("\tpublic bool RecalcRowCount { get; set; }");
				pagingSb.AppendLine("\tpublic bool GetRowCountOnly { get; set; }");
			}

			// Filter properties
			var propsOutput = new List<string>();
			foreach (var filterProp in queryMethod.FilterProperties) {
				var nullStr = filterProp.DatatypeName != "string" ? "?" : null;
				propsOutput.AddLine(1, $"public {filterProp.DatatypeName}{nullStr} {filterProp.Name} {{ get; set; }}");
			}

			// Replace tokens in template
			var fileContents = ReplaceQueryTemplateTokens(template, className, interfaceDecl, addlUsings, queriesNamespace, sortingSb.ToString(), pagingSb.ToString(), propsOutput);

			var outputFile = Path.Combine(outputFolder, $"{className}.cs");
			if (File.Exists(outputFile))
				File.Delete(outputFile);
			File.WriteAllText(outputFile, fileContents);
		}
	}

	internal string ReplaceQueryTemplateTokens(string template, string className, string interfaceDecl, List<string> addlUsings, string queriesNamespace, string sorting, string paging, List<string> propsOutput)
	{
		// Header
		var fileContents = template.Replace(Utils.FmtToken(cToken_CurrTimestamp), DateTime.Now.ToString("g"));

		// Addl Usings
		var sb = new StringBuilder();
		addlUsings.ForEach(x => {
			if (sb.Length > 0)
				sb.AppendLine();
			sb.Append($"using {x};");
		});
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_AddlUsings), sb.ToString());

		// Namespace
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueriesNs), queriesNamespace);

		// Class name
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueryClassName), className);

		// Interface
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueryIntfDecl), interfaceDecl);

		// Sorting
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueryInclSorting), sorting);

		// Paging
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_QueryInclPaging), paging);

		// Filter properties
		sb = new StringBuilder();
		propsOutput.ForEach(x => sb.AppendLine(x));
		fileContents = fileContents.Replace(Utils.FmtToken(cToken_FilterProps), sb.ToString());

		return fileContents;
	}
}
