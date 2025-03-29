using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models.Services;

public class ServiceMethodModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	#region Fields

	private int _displayOrder;
	private bool _inclSorting;
	private bool _inclPaging;
	private bool _useQuery;
	private ObservableCollection<string> _attributes = new ObservableCollection<string>();
	
	protected bool _suspendUpdates;

	#endregion

	#region Ctors / Initialization

	[JsonConstructor]
	public ServiceMethodModel()
	{
		this.FilterProperties.CollectionChanged += FilterProperties_OnCollectionChanged;
		this.InclNavProperties.CollectionChanged += InclNavProperties_OnCollectionChanged;
	}

	public ServiceMethodModel(Guid id) : this()
	{
		this.Id = id;
	}

	public void InitializeOnLoad(EntityModel entity)
	{
		_suspendUpdates = true;

		foreach (var prop in entity.Properties.Where(p => this.FilterPropertyIds.Contains(p.Id)))
			this.FilterProperties.Add(prop);

		foreach (var navProp in entity.NavProperties.Where(p => this.InclNavPropertyIds.Contains(p.Id)))
			this.InclNavProperties.Add(navProp);

		_suspendUpdates = false;
	}

	#endregion

	#region Properties

	public Guid Id { get; init; }
	public string Name { get; set; }
	public List<Guid> FilterPropertyIds { get; set; } = new List<Guid>();
	public List<Guid> InclNavPropertyIds { get; set; } = new List<Guid>();

	public ObservableCollection<string> Attributes
	{
		get => _attributes;
		set => SetProperty(ref _attributes, value);
	}

	public int DisplayOrder
	{
		get => _displayOrder;
		set => SetProperty(ref _displayOrder, value);
	}

	public bool InclSorting
	{
		get => _inclSorting;
		set => SetProperty(ref _inclSorting, value);
	}

	public bool InclPaging
	{
		get => _inclPaging;
		set => SetProperty(ref _inclPaging, value);
	}

	public bool UseQuery
	{
		get => _useQuery;
		set => SetProperty(ref _useQuery, value);
	}

	#endregion

	#region Non-serialized Properties

	[JsonIgnore]
	public ObservableCollection<PropertyModel> FilterProperties { get; private set; } = new ObservableCollection<PropertyModel>();

	[JsonIgnore]
	public ObservableCollection<NavPropertyModel> InclNavProperties { get; private set; } = new ObservableCollection<NavPropertyModel>();

	[JsonIgnore]
	public int AttrCount => this.Attributes.Count;

	[JsonIgnore]
	public bool IsList => this.FilterProperties.Any(fp => !fp.IsPrimaryKey && !fp.IsIndexUnique);

	#endregion

	#region Methods

	public bool Validate(string entityName, List<string> errorList)
	{
		var errs = new List<string>();

		errorList.AddRange(errs);
		return (errs.Count == 0);
	}

	public override string ToString()
	{
		return this.Name;
	}

	#endregion

	#region PropertyChanged

	private void FilterProperties_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Add) {
			FilterPropertyIds.Add(((PropertyModel)e.NewItems[0]).Id);

		} else if (e.Action == NotifyCollectionChangedAction.Remove) {
			FilterPropertyIds.Remove(((PropertyModel)e.OldItems[0]).Id);

		} else if (e.Action == NotifyCollectionChangedAction.Reset) {
			ResetPropertyIds();
		}
	}

	private void ResetPropertyIds()
	{
		FilterPropertyIds.Clear();
		foreach (var prop in FilterProperties)
			FilterPropertyIds.Add(prop.Id);
	}

	private void InclNavProperties_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Add) {
			InclNavPropertyIds.Add(((NavPropertyModel)e.NewItems[0]).Id);

		} else if (e.Action == NotifyCollectionChangedAction.Remove) {
			InclNavPropertyIds.Remove(((NavPropertyModel)e.OldItems[0]).Id);

		} else if (e.Action == NotifyCollectionChangedAction.Reset) {
			ResetNavPropertyIds();
		}
	}

	private void ResetNavPropertyIds()
	{
		InclNavPropertyIds.Clear();
		foreach (var navProp in InclNavProperties)
			InclNavPropertyIds.Add(navProp.Id);
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
		field = value;

		if (!_suspendUpdates)
			OnPropertyChanged(propertyName);

		return true;
	}

	#endregion
}
