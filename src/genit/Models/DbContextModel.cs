using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dyvenix.Genit.Models;

public class DbContextModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool Enabled { get; set; }
	public string ContextNamespace { get; set; }
	public string EntitiesNamespace { get; set; }
	public ObservableCollection<string> AddlUsings { get; set; } = new ObservableCollection<string>();

	public ObservableCollection<EntityModel> Entities { get; set; } = new ObservableCollection<EntityModel>();
	public ObservableCollection<EnumModel> Enums { get; set; } = new ObservableCollection<EnumModel>();
	public List<GenModelBase> Generators = new List<GenModelBase>();

	public void InitializeOnLoad()
	{
		if (AddlUsings == null)
			AddlUsings = new ObservableCollection<string>();

		foreach (var entity in Entities) {
			entity.InitializeOnLoad(Entities, Enums);
			entity.NavPropertyAdded += Entity_NavPropertyAdded;
		}
	}

	private void Entity_NavPropertyAdded(object sender, NavPropertyAddedEventArgs e)
	{
		var newFkPropId = Guid.NewGuid();
		e.NavPropertyModel.RelatedFKPropertyId = newFkPropId;

		var fkPropMdl = new PropertyModel(newFkPropId, $"{e.EntityModel.Name}Id", e.NavPropertyModel);
		e.EntityModel.Properties.Add(fkPropMdl);
	}

	public void Validate(List<string> errorList)
	{
		foreach (var entity in Entities)
			entity.Validate(errorList);
		foreach (var enumMdl in Enums)
			enumMdl.Validate(errorList);
	}

	public override string ToString()
	{
		return this.Name;
	}
}
