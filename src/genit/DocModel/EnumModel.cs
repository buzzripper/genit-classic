using System;
using System.Collections.Generic;

namespace Dyvenix.Genit.DocModel;

public class EnumModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool IsExternal { get; set; }
	public List<EnumItemModel> Items { get; set; }
}
