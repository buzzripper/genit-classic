using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class DbContextModel
{
	#region Ctors / Init

	public DbContextModel()
	{
		Entities.CollectionChanged += Entities_CollectionChanged;
		Enums.CollectionChanged += Enums_CollectionChanged;
		Assocs.CollectionChanged += Assocs_CollectionChanged;
	}

	#endregion

	#region Properties

	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool Enabled { get; set; }
	public string ContextNamespace { get; set; }
	public string EntitiesNamespace { get; set; }
	public ObservableCollection<string> AddlUsings { get; set; } = new ObservableCollection<string>();
	public ObservableCollection<EntityModel> Entities { get; set; } = new ObservableCollection<EntityModel>();
	public ObservableCollection<EnumModel> Enums { get; set; } = new ObservableCollection<EnumModel>();
	public ObservableCollection<AssocModel> Assocs { get; set; } = new ObservableCollection<AssocModel>();
	public List<GenModelBase> Generators { get; private set; } = new List<GenModelBase>();

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

	private void Entity_NavPropertyAdded(object sender, NavPropertyAddedEventArgs e)
	{
		Assocs.Add(e.NavPropertyModel.Assoc);
	}

	private void Entity_NavPropertyRemoved(object sender, NavPropertyRemovedEventArgs e)
	{
		Assocs.Remove(e.NavPropertyModel.Assoc);
	}
}
