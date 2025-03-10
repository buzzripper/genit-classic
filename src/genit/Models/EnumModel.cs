using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class EnumModel
{
	#region Ctors

	[JsonConstructor]
	public EnumModel()
	{
	}

	public EnumModel(Guid id)
	{
		Id = id;
	}

	#endregion

	public Guid Id { get; init; }

	public string Name { get; set; }
	public bool IsExternal { get; set; }
	public bool IsFlags { get; set; }
	public string Namespace { get; set; }
	public List<string> Members { get; set; } = new List<string>();

	public void Validate(List<string> errorList)
	{
		if (string.IsNullOrWhiteSpace(Name))
			errorList.Add($"Invalid EnumModel. Name not defined.");
		if (!this.Members.Any())
			errorList.Add($"Invalid EnumModel '{this.Name}'. No members defined.");
	}

	public override string ToString()
	{
		return Name;
	}
}
