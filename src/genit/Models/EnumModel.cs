using System;
using System.Collections.Generic;

namespace Dyvenix.Genit.Models;

public class EnumModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool IsExternal { get; set; }
	public bool IsFlags { get; set; }
	public string Namespace { get; set; }
	public List<string> Members { get; set; } = new List<string>();
}
