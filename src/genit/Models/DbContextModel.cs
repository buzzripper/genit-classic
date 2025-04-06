using Dyvenix.Genit.Models.Generators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dyvenix.Genit.Models;

public class DbContextModel
{
	#region Static

	public static DbContextModel CreateNew()
	{
		var dbContext = new DbContextModel();
		dbContext.Name = "DbContext";
		dbContext.Enabled = true;
		dbContext.Generators = GeneratorsModel.CreateNew();

		return dbContext;
	}

	#endregion

	#region Ctors / Init

	public DbContextModel()
	{
	}

	#endregion

	#region Properties

	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool Enabled { get; set; }
	public ObservableCollection<string> AddlUsings { get; set; } = new ObservableCollection<string>();
	public ObservableCollection<EntityModel> Entities { get; set; } = new ObservableCollection<EntityModel>();
	public ObservableCollection<EnumModel> Enums { get; set; } = new ObservableCollection<EnumModel>();
	public ObservableCollection<AssocModel> Assocs { get; set; } = new ObservableCollection<AssocModel>();
	public GeneratorsModel Generators { get; set; } = new GeneratorsModel();

	#endregion

	#region Methods

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

	private void Entity_NavPropertyAdded(object sender, NavPropertyAddedEventArgs e)
	{
		Assocs.Add(e.NavPropertyModel.Assoc);
	}

	private void Entity_NavPropertyRemoved(object sender, NavPropertyRemovedEventArgs e)
	{
		Assocs.Remove(e.NavPropertyModel.Assoc);
	}
}
