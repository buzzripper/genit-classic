using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyvenix.Genit.Generators;

internal abstract class ApiClientIntTestsGenBase
{
	private static readonly Random _random = new Random();

	protected void Validate(string templateFilepath, string outputFolder)
	{
		if (!File.Exists(templateFilepath))
			throw new ApplicationException($"Template file does not exist: {templateFilepath}");

		if (!Directory.Exists(outputFolder))
			throw new ApplicationException($"OutputFolder does not exist: {outputFolder}");
	}

	protected string NotExistsArg(FilterPropertyModel filterProp)
	{
		if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Guid.Id)
			return "Guid.Empty";

		else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.String.Id) {
			if (0 < filterProp.Property.MaxLength && filterProp.Property.MaxLength < 36)
				return $"Guid.NewGuid().ToString()[{filterProp.Property.MaxLength}..]";
			else
				return "Guid.NewGuid().ToString()";

		} else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Int.Id)
			return "int.MaxValue";

		else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Long.Id)
			return "long.MaxValue";

		else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Short.Id)
			return "short.MaxValue";

		else if (filterProp.Property.PrimitiveType?.Id == PrimitiveType.Short.Id)
			return "short.MaxValue";

		else
			return "null";
	}

}

#region Helper Classes

internal enum ArgType
{
	Required,
	Optional,
	Paging
}

internal enum ValType
{
	Good,
	NotSupplied,
	NotExist
}

internal class ArgDef
{
	internal ArgDef(FilterPropertyModel filterProp, ArgType argItemType)
	{
		FilterProperty = filterProp;
		ArgItemType = argItemType;
	}
	public ArgType ArgItemType { get; set; }
	public FilterPropertyModel FilterProperty { get; set; }
	public List<ArgVal> Values { get; set; } = new List<ArgVal>();
}

internal class ArgVal
{
	public ArgVal(ValType valType, string value)
	{
		ValType = valType;
		Value = value;
	}
	public ValType ValType { get; set; }
	public string Value { get; set; }

	public override string ToString()
	{
		return ValType.ToString();
	}
}

internal class ArgSet
{
	public List<ArgItem> ArgItems { get; set; } = new List<ArgItem>();

	public override string ToString()
	{
		var sb = new StringBuilder();
		foreach (var argItem in ArgItems) {
			if (sb.Length > 0)
				sb.Append(", ");
			sb.Append($"{argItem.PropName}:{argItem.ArgVal.ValType}");
		}
		return sb.ToString();
	}
}

internal class ArgItem
{
	public FilterPropertyModel FilterProperty { get; set; }
	public ArgType ArgType { get; set; }
	public ArgVal ArgVal { get; set; }

	public string PropName { get; set; }
	public string VarName { get; set; }
	public bool Nullable { get; set; }

	public override string ToString()
	{
		return PropName;
	}
}

#endregion
