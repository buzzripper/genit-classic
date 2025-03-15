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

	private EntityModel _datatype;
	[JsonIgnore]
	public EntityModel Datatype
	{
		get => _datatype;
		set {
			DatatypeId = value.Id;
			SetProperty(ref _datatype, value);
		}
	}

	private Guid DatatypeId { get; set; }

	private Guid _relatedFKPropertyId;
	public Guid RelatedFKPropertyId
	{
		get => _relatedFKPropertyId;
		set => SetProperty(ref _relatedFKPropertyId, value);
	}

	private string _relatedFKPropertyName;
	public string RelatedFKPropertyName
	{
		get => _relatedFKPropertyName;
		set => SetProperty(ref _relatedFKPropertyName, value);
	}

	private CardinalityModel _cardinality;
	public CardinalityModel Cardinality
	{
		get => _cardinality;
		set => SetProperty(ref _cardinality, value);
	}

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

	#endregion

	#region Methods

	public PrimitiveType GetParentPkDatatype()
	{
		var pkProp = _entityMdl.Properties.FirstOrDefault(p => p.IsPrimaryKey);
		return pkProp?.PrimitiveType ?? PrimitiveType.None;
	}

	public bool Validate(string entityName, List<string> errorList)
	{
		var errs = new List<string>();

		//if (this.PrimitiveType != PrimitiveType.None) {
		//	if (this.PrimitiveType == PrimitiveType.String) {
		//		if (this.MaxLength < 0)
		//			errs.Add($"Property {entityName}.{this.Name}: String values must have a MaxLength >= 0 (0 == NVARCHAR(MAX))");

		//	} else if (this.PrimitiveType == PrimitiveType.ByteArray) {
		//		if (this.MaxLength <= 0)
		//			errs.Add($"Property {entityName}.{this.Name}: Byte array type must have a MaxLength > 0");
		//	}

		//} else if (this.EnumType != null) {


		//} else if (this.FKAssoc != null) {


		//} else {
		//	errs.Add($"Property {entityName}.{this.Name}: No data type defined.");
		//}

		errorList.AddRange(errs);
		return (errs.Count == 0);
	}

	#endregion

	public override string ToString()
	{
		return this.Name;
	}

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
