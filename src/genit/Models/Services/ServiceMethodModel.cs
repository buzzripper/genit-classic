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
	private ObservableCollection<PropertyModel> _filterProperties = new ObservableCollection<PropertyModel>();
	private ObservableCollection<NavPropertyModel> _inclNavProperties = new ObservableCollection<NavPropertyModel>();
	
	protected bool _suspendUpdates;

	#endregion

	#region Ctors / Initialization

	[JsonConstructor]
	public ServiceMethodModel()
	{
	}

	public ServiceMethodModel(Guid id) : this()
	{
		this.Id = id;
	}

	#endregion

	#region Properties

	public Guid Id { get; init; }
	public string Name { get; set; }

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

	public ObservableCollection<PropertyModel> FilterProperties
	{
		get => _filterProperties;
		set => SetProperty(ref _filterProperties, value);
	}

	public ObservableCollection<NavPropertyModel> InclNavProperties
	{
		get => _inclNavProperties;
		set => SetProperty(ref _inclNavProperties, value);
	}

	#endregion

	#region Non-serialized Properties

	[JsonIgnore]
	public int AttrCount => this.Attributes.Count;

	[JsonIgnore]
	public bool IsList => !this.FilterProperties.Any() || this.FilterProperties.Any(fp => !fp.IsPrimaryKey && !fp.IsIndexUnique);

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
