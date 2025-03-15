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
	#region Fields

	private readonly EntityModel _entityMdl;

	#endregion

	#region Ctors

	[JsonConstructor]
	public NavPropertyModel()
	{
	}

	public NavPropertyModel(Guid id, EntityModel entityMdl)
	{
		Id = id;
		_entityMdl = entityMdl;
	}

	#endregion

	#region Properties

	public Guid Id { get; init; }

	private string _name;
	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	private Cardinality _cardinality;
	public Cardinality Cardinality
	{
		get => _cardinality;
		set => SetProperty(ref _cardinality, value);
	}

	public Guid RelatedEntityId { get; set; }

	public Guid RelatedFKPropertyId { get; set; }

	private int _displayOrder;
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

	private EntityModel _relatedEntity;
	[JsonIgnore]
	public EntityModel RelatedEntity
	{
		get => _relatedEntity;
		set {
			RelatedEntityId = value.Id;
			SetProperty(ref _relatedEntity, value);
		}
	}

	private PropertyModel _relatedFKProperty;
	[JsonIgnore]
	public PropertyModel RelatedFKProperty
	{
		get => _relatedFKProperty;
		set => SetProperty(ref _relatedFKProperty, value);
	}

	#endregion

	#region Methods

	public void InitializeOnLoad(ObservableCollection<EntityModel> entities)
	{
		this.RelatedEntity = entities.FirstOrDefault(e => e.Id == RelatedEntityId);
		this.RelatedFKProperty = this.RelatedEntity.Properties.FirstOrDefault(p => p.Id == RelatedFKPropertyId);
	}

	public PrimitiveType GetParentPkDatatype()
	{
		var pkProp = _entityMdl.Properties.FirstOrDefault(p => p.IsPrimaryKey);
		return pkProp?.PrimitiveType ?? PrimitiveType.None;
	}

	public bool Validate(string entityName, List<string> errorList)
	{
		var errs = new List<string>();

		if (string.IsNullOrWhiteSpace(this.Name))
			errs.Add($"NavProperty {entityName}.{this.Name}: Name is required.");

		if (this.Cardinality == Cardinality.None)
			errs.Add($"NavProperty {entityName}.{this.Name}: Cardinality is required.");

		errorList.AddRange(errs);
		return (errs.Count == 0);
	}

	#endregion

	public event PropertyChangedEventHandler PropertyChanged;

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
