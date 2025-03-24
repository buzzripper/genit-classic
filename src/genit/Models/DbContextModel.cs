using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dyvenix.Genit.Models;

public class DbContextModel
{
	#region Ctors / Init

	public DbContextModel()
	{
		Entities.CollectionChanged += Entities_CollectionChanged;
		Enums.CollectionChanged += Enums_CollectionChanged;
		Assocs.CollectionChanged += Assocs_CollectionChanged;
		Services.CollectionChanged += Services_CollectionChanged;
	}

	#endregion

	#region Properties

	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool Enabled { get; set; }
	public string ContextNamespace { get; set; }
	public string EntitiesNamespace { get; set; }
	public string EnumsNamespace { get; set; }
	public string ServicesNamespace { get; set; }
	public ObservableCollection<string> AddlUsings { get; set; } = new ObservableCollection<string>();
	public ObservableCollection<EntityModel> Entities { get; set; } = new ObservableCollection<EntityModel>();
	public ObservableCollection<EnumModel> Enums { get; set; } = new ObservableCollection<EnumModel>();
	public ObservableCollection<AssocModel> Assocs { get; set; } = new ObservableCollection<AssocModel>();
	public ObservableCollection<ServiceModel> Services { get; set; } = new ObservableCollection<ServiceModel>();
	public DbContextGenModel DbContextGen { get; set; }
	public EntityGenModel EntityGen { get; set; }
	public EnumGenModel EnumGen { get; set; }
	public ServiceGenModel ServiceGen { get; set; }

	#endregion

	#region Methods

	public void InitializeOnLoad()
	{
		if (AddlUsings == null)
			AddlUsings = new ObservableCollection<string>();

		foreach (var assoc in Assocs) {
			var priEntity = Entities.FirstOrDefault(e => e.Id == assoc.PrimaryEntityId);
			var fkEntity = Entities.FirstOrDefault(e => e.Id == assoc.FKEntityId);
			assoc.InitializeOnLoad(priEntity, fkEntity);
		}

		foreach (var entity in Entities) {
			entity.InitializeOnLoad(Enums, Assocs);
			entity.NavPropertyAdded += Entity_NavPropertyAdded;
			entity.NavPropertyRemoved += Entity_NavPropertyRemoved;
		}

		foreach (var service in Services) {
			service.InitializeOnLoad(Entities.FirstOrDefault(e => e.Id == service.EntityId));
		}
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

	#endregion

	private void Enums_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
	}

	private void Entities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
	}

	private void Assocs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
	}

	private void Services_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
	}

	private void Entity_NavPropertyAdded(object sender, NavPropertyAddedEventArgs e)
	{
		Assocs.Add(e.NavPropertyModel.Assoc);
	}

	private void Entity_NavPropertyRemoved(object sender, NavPropertyRemovedEventArgs e)
	{
		Assocs.Remove(e.NavPropertyModel.Assoc);
	}
}
