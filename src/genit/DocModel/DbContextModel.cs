using System;
using System.Collections.Generic;

namespace Dyvenix.Genit.DocModel;

public class DbContextModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool Enabled { get; set; }
	public string OutputFolder { get; set; }
	public string ContextNamespace { get; set; }
	public string EntitiesNamespace { get; set; }
	public List<string> AddlContextUsings { get; set; }

	public List<EntityModel> Entities { get; set; } = new List<EntityModel>();
	public List<Enum> Enums { get; set; } = new List<Enum>();
}
