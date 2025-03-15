using Dyvenix.Genit.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class EntityModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	public event EventHandler<NavPropertyAddedEventArgs> NavPropertyAdded;

	#region Fields

	private Guid _id;
	private string _name;
	private string _schema;
	private string _tableName;
	private bool _enabled;
	private string _namespace;
	

	#endregion

	#region Properties

	[JsonConstructor]
	public EntityModel()
	{
		Properties.CollectionChanged += Properties_CollectionChanged;
		NavProperties.CollectionChanged += NavProperties_CollectionChanged;
	}

	public EntityModel(Guid id) : this()
	{
		Id = id;
	}

	public Guid Id
	{
		get => _id;
		set => SetProperty(ref _id, value);
	}

	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	public string Schema
	{
		get => _schema;
		set => SetProperty(ref _schema, value);
	}

	public string TableName
	{
		get => _tableName;
		set => SetProperty(ref _tableName, value);
	}

	public bool Enabled
	{
		get => _enabled;
		set => SetProperty(ref _enabled, value);
	}

	public string Namespace
	{
		get => _namespace;
		set => SetProperty(ref _namespace, value);
	}

	public ObservableCollection<PropertyModel> Properties { get; private set; } = new ObservableCollection<PropertyModel>();

	public ObservableCollection<NavPropertyModel> NavProperties { get; private set; } = new ObservableCollection<NavPropertyModel>();

	public ObservableCollection<string> Attributes { get; private set; } = new ObservableCollection<string>();

	public ObservableCollection<string> AddlUsings { get; private set; } = new ObservableCollection<string>();

	private void Properties_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
	}

	private void NavProperties_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Add) {
			var navProp = e.NewItems?[0] as NavPropertyModel;
			if (navProp != null)
				NavPropertyAdded?.Invoke(this, new NavPropertyAddedEventArgs(this, navProp));
		}
	}

	#endregion

	#region Methods

	public void InitializeOnLoad(ObservableCollection<EnumModel> enums)
	{
		foreach (var property in Properties)
			property.InitializeOnLoad(enums);
	}

	public PropertyModel AddForeignKey(string fkPropName, EntityModel pkEntity)
	{
		var property = new PropertyModel(Guid.NewGuid(), fkPropName, pkEntity);
		property.DisplayOrder = Properties.Count;
		Properties.Add(property);
		return property;
	}

	public PropertyModel GetPKProperty()
	{
		return Properties.FirstOrDefault(p => p.IsPrimaryKey);
	}	

	public void Validate(List<string> errorList)
	{
		foreach (var property in Properties) {
			property.Validate(Name, errorList);
		}
	}

	public override string ToString()
	{
		return Name;
	}

	#endregion

	#region IPropertyNotifyEvent

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	#endregion
}

public class NavPropertyAddedEventArgs : EventArgs
{
	public EntityModel EntityModel { get; private set; }
	public NavPropertyModel NavPropertyModel { get; private set; }

	public NavPropertyAddedEventArgs(EntityModel entityModel, NavPropertyModel navPropertyMdl)
	{
		EntityModel = entityModel;
		NavPropertyModel = navPropertyMdl;
	}
}
