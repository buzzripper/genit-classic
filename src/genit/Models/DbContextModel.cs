using System;
using System.Collections.Generic;
using System.Linq;

namespace Dyvenix.Genit.Models;

public class DbContextModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool Enabled { get; set; }
	public string ContextNamespace { get; set; }
	public string EntitiesNamespace { get; set; }
	public List<string> AddlUsings { get; set; }

	public List<EntityModel> Entities { get; set; } = new List<EntityModel>();
	public List<EnumModel> Enums { get; set; } = new List<EnumModel>();
	public List<AssocModel> Assocs { get; set; } = new List<AssocModel>();

	public void Initialize()
	{
		foreach(var assoc in Assocs) {
			var primaryEntityMdl = Entities.FirstOrDefault(e => e.Id == assoc.PrimaryEntityId);
			var relatedEntityMdl = Entities.FirstOrDefault(e => e.Id == assoc.RelatedEntityId);
			assoc.Initialize(primaryEntityMdl, relatedEntityMdl);
		}
	}

	public void Validate(List<string> errorList)
	{
		foreach(var entity in Entities)
			entity.Validate(errorList);
		foreach(var enumMdl in Enums)
			enumMdl.Validate(errorList);
		foreach(var assoc in Assocs)
			assoc.Validate(errorList);
	}

	public AssocModel AddAssoc(EntityModel primaryEntityMdl, EntityModel relatedEntityMdl, string primaryPropertyName, string relatedPropertyName, CardinalityModel cardinality)
	{
		var assoc = new AssocModel(Guid.NewGuid(), primaryEntityMdl, relatedEntityMdl, primaryPropertyName, relatedPropertyName, cardinality);
		
		primaryEntityMdl.Assocs.Add(assoc);
		relatedEntityMdl.AddForeignKey(assoc);

		return assoc;
	}

	public override string ToString()
	{
		return this.Name;
	}
}
