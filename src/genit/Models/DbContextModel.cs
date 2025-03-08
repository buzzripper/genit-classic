using Dyvenix.Genit.Generators;
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
	public List<string> AddlUsings { get; set; } = new List<string>();

	public List<EntityModel> Entities { get; set; } = new List<EntityModel>();
	public List<EnumModel> Enums { get; set; } = new List<EnumModel>();
	public List<AssocModel> Assocs { get; set; } = new List<AssocModel>();
	public List<GenModelBase> Generators = new List<GenModelBase>();

	public void InitializeOnLoad()
	{
		if (AddlUsings == null)
			AddlUsings = new List<string>();

		foreach (var navProperty in Assocs) {
			var primaryEntityMdl = Entities.FirstOrDefault(e => e.Id == navProperty.PrimaryEntityId);
			var relatedEntityMdl = Entities.FirstOrDefault(e => e.Id == navProperty.RelatedEntityId);
			navProperty.Initialize(primaryEntityMdl, relatedEntityMdl);
		}
	}

	public void AddAssoc(EntityModel primaryEntityMdl, string primaryPropertyName, EntityModel relatedEntityMdl, string relatedPropertyName, CardinalityModel cardinality)
	{
		var assoc = new AssocModel(Guid.NewGuid(), primaryEntityMdl, primaryPropertyName, relatedEntityMdl, relatedPropertyName, cardinality);
		this.Assocs.Add(assoc);

		primaryEntityMdl.NavAssocs.Add(assoc);
		relatedEntityMdl.AddForeignKey(assoc);
	}

	public void DeleteAssoc(AssocModel assoc)
	{
		this.Assocs.Remove(assoc);
		assoc.PrimaryEntity.NavAssocs.Remove(assoc);

		var fkProp = assoc.RelatedEntity.Properties.FirstOrDefault(p => p.FKAssoc == assoc);
		if (fkProp != null)
			assoc.RelatedEntity.Properties.Remove(fkProp);
	}

	public void Validate(List<string> errorList)
	{
		foreach (var entity in Entities)
			entity.Validate(errorList);
		foreach (var enumMdl in Enums)
			enumMdl.Validate(errorList);
		foreach (var assoc in Assocs)
			assoc.Validate(errorList);
	}

	public override string ToString()
	{
		return this.Name;
	}
}
