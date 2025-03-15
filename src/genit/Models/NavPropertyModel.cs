using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class NavPropertyModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	#region Fields

	private string _name;
	private Guid? _assocId;
	private int _displayOrder;
	private AssocModel _assoc;

	#endregion

	#region Ctors

	[JsonConstructor]
	public NavPropertyModel()
	{
	}

	public NavPropertyModel(Guid id)
	{
		this.Id = id;
	}

	public void InitializeOnLoad(AssocModel assocModel)
	{
		this.Assoc = assocModel;
	}

	#endregion

	#region Properties

	public Guid Id { get; init; }

	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	public Guid? AssocId
	{
		get => _assocId;
		set => SetProperty(ref _assocId, value);
	}

	public int DisplayOrder
	{
		get => _displayOrder;
		set => SetProperty(ref _displayOrder, value);
	}

	private ObservableCollection<string> _attributes = new ObservableCollection<string>();
	public ObservableCollection<string> Attributes
	{
		get => _attributes;
		set => SetProperty(ref _attributes, value);
	}

	// Non-serialized properties

	[JsonIgnore]
	public AssocModel Assoc { 
		get { return _assoc; }
		set{ 
			_assocId = value?.Id;
			SetProperty(ref _assoc, value);
		}
	}

	[JsonIgnore]
	public Cardinality Cardinality
	{
		get { return Assoc == null ? Models.Cardinality.None : Assoc.Cardinality; }
		set {
			if (Assoc != null)
				Assoc.Cardinality = value;
		}
	}

	[JsonIgnore]
	public EntityModel FKEntity
	{
		get { return Assoc?.FKEntity; }
		set { 
			if (Assoc != null)
				Assoc.FKEntity = value;
		}
	}

	[JsonIgnore]
	public PropertyModel FKProperty
	{
		get { return Assoc?.FKProperty; }
		set { 
			if (Assoc != null)
				Assoc.FKProperty = value;
		}
	}

	//private Cardinality _cardinality;
	//private EntityModel _relatedEntity;
	//private PropertyModel _relatedFKProperty;
	//private readonly EntityModel _entityMdl;

	//[JsonIgnore]
	//public EntityModel RelatedEntity
	//{
	//	get => _relatedEntity;
	//	set {
	//		RelatedEntityId = value.Id;
	//		_relatedEntity = value;
	//	}
	//}

	//[JsonIgnore]
	//public PropertyModel RelatedFKProperty
	//{
	//	get => _relatedFKProperty;
	//	set {
	//		RelatedFKPropertyId = _relatedEntity.Id;
	//		_relatedFKProperty = value;
	//	}
	//}

	#endregion

	#region Methods

	//public PrimitiveType GetParentPkDatatype()
	//{
	//	var pkProp = _entityMdl.Properties.FirstOrDefault(p => p.IsPrimaryKey);
	//	return pkProp?.PrimitiveType ?? PrimitiveType.None;
	//}

	public bool Validate(string entityName, List<string> errorList)
	{
		var errs = new List<string>();

		//if (string.IsNullOrWhiteSpace(this.Name))
		//	errs.Add($"NavProperty {entityName}.{this.Name}: Name is required.");

		//if (this.Cardinality == Cardinality.None)
		//	errs.Add($"NavProperty {entityName}.{this.Name}: Cardinality is required.");

		//errorList.AddRange(errs);

		return (errs.Count == 0);
	}

	#endregion

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
}
