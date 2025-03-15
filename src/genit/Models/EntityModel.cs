using Dyvenix.Genit.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class EntityModel : INotifyPropertyChanged
{
	#region Fields

	private Guid _id;
	private string _name;
	private string _schema;
	private string _tableName;
	private bool _enabled;
	private string _namespace;
	private ObservableCollection<string> _attributes = new ObservableCollection<string>();
	private ObservableCollection<string> _addlUsings = new ObservableCollection<string>();
	private ObservableCollection<PropertyModel> _properties = new ObservableCollection<PropertyModel>();
	private ObservableCollection<NavPropertyModel> _navProperties = new ObservableCollection<NavPropertyModel>();

	#endregion

	#region Properties

	[JsonConstructor]
	public EntityModel()
	{
	}

	public EntityModel(Guid id)
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

	public ObservableCollection<string> Attributes
	{
		get => _attributes;
		set => SetProperty(ref _attributes, value);
	}

	public ObservableCollection<string> AddlUsings
	{
		get => _addlUsings;
		set => SetProperty(ref _addlUsings, value);
	}

	public ObservableCollection<PropertyModel> Properties
	{
		get => _properties;
		set => SetProperty(ref _properties, value);
	}

	public ObservableCollection<NavPropertyModel> NavProperties
	{
		get => _navProperties;
		set {
			_navProperties.CollectionChanged += NavProperties_CollectionChanged;
			SetProperty(ref _navProperties, value);
		}
	}

	private void NavProperties_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Add) {
			var navProp = (NavPropertyModel)e.OldItems[0];
			NavPropertyAdded?.Invoke(this, new NavPropertyAddedEventArgs(this, navProp));
		}
	}

	#endregion

	#region Methods

	public void InitializeOnLoad(ObservableCollection<EnumModel> enums)
	{
		foreach (var property in Properties) {
			property.InitializeOnLoad(enums);
		}
	}

	public Guid AddForeignKey(string fkPropName, NavPropertyModel navPropertyMdl)
	{
		var property = new PropertyModel(Guid.NewGuid(), fkPropName, navPropertyMdl);
		property.DisplayOrder = Properties.Count;
		Properties.Add(property);
		return property.Id;
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

	public event PropertyChangedEventHandler PropertyChanged;
	public event EventHandler<NavPropertyAddedEventArgs> NavPropertyAdded;

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
