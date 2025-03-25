using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class PropertyModel : INotifyPropertyChanged
{
	#region Fields

	private bool _isPrimaryKey;
	private bool _isIdentity;
	private Guid? _assocId;
	private bool _nullable;
	private int _maxLength;
	private bool _isIndexed;
	private bool _isIndexUnique;
	private bool _isIndexClustered;
	private int _displayOrder;
	private ObservableCollection<string> _attributes = new ObservableCollection<string>();
	private ObservableCollection<string> _addlUsings = new ObservableCollection<string>();

	private EnumModel _enumType;
	private PrimitiveType _primitiveType;
	private AssocModel _assoc;

	private bool _suspendUpdates;

	#endregion

	#region Ctors / Initialization

	[JsonConstructor]
	public PropertyModel()
	{
	}

	public PropertyModel(Guid id)
	{
		Id = id;
	}

	public PropertyModel(Guid id, string name, Guid assocId, EntityModel pkEntity)
	{
		_suspendUpdates = true;

		Id = id;
		Name = name;
		ParentEntity = pkEntity;
		AssocId = assocId;

		_suspendUpdates = false;
	}

	#endregion

	#region Properties

	public Guid Id { get; init; }

	public string Name { get; set; }

	public int PrimitiveTypeId { get; set; }

	public Guid? EnumTypeId { get; set; }

	public Guid? AssocId { get; set; }

	public bool IsPrimaryKey
	{
		get => _isPrimaryKey;
		set => SetProperty(ref _isPrimaryKey, value);
	}

	public bool IsIdentity
	{
		get => _isIdentity;
		set => SetProperty(ref _isIdentity, value);
	}

	public bool Nullable
	{
		get => _nullable;
		set => SetProperty(ref _nullable, value);
	}

	public int MaxLength
	{
		get => _maxLength;
		set => SetProperty(ref _maxLength, value);
	}

	public bool IsIndexed
	{
		get => _isIndexed;
		set => SetProperty(ref _isIndexed, value);
	}

	public bool IsIndexUnique
	{
		get => _isIndexUnique;
		set => SetProperty(ref _isIndexUnique, value);
	}

	public bool IsIndexClustered
	{
		get => _isIndexClustered;
		set => SetProperty(ref _isIndexClustered, value);
	}

	public int DisplayOrder
	{
		get => _displayOrder;
		set => SetProperty(ref _displayOrder, value);
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

	#endregion

	#region Non-serialized Properties

	[JsonIgnore]
	public EntityModel ParentEntity { get; set; }

	[JsonIgnore]
	public PrimitiveType PrimitiveType
	{
		get {
			if (this.ParentEntity == null)
				return _primitiveType;
			else
				return this.ParentEntity.GetPKProperty().PrimitiveType;
		}
		set {
			PrimitiveTypeId = value?.Id ?? -1;
			SetProperty(ref _primitiveType, value);
		}
	}

	[JsonIgnore]
	public EnumModel EnumType
	{
		get => _enumType;
		set {
			EnumTypeId = value?.Id;
			SetProperty(ref _enumType, value);
		}
	}

	[JsonIgnore]
	public bool IsForeignKey
	{
		get => this.AssocId != null;
	}

	[JsonIgnore]
	public string DatatypeName
	{
		get {
			if (this.PrimitiveType != null && this.PrimitiveType != PrimitiveType.None)
				return this.PrimitiveType.CSType;
			else if (this.EnumType != null)
				return this.EnumType.Name;
			else
				return "UNKNOWN DATATYPE";
		}
	}

	#endregion

	#region Methods

	public void InitializeOnLoad(ObservableCollection<EnumModel> enums, AssocModel assoc)
	{
		if (this.PrimitiveTypeId > 0) {
			this.PrimitiveType = PrimitiveType.GetAll().First(p => p.Id == this.PrimitiveTypeId);

		} else if (this.EnumTypeId != null) {
			this.EnumType = enums.FirstOrDefault(e => e.Id == this.EnumTypeId);
		}
	}

	public bool Validate(string entityName, List<string> errorList)
	{
		var errs = new List<string>();

		if (this.PrimitiveType == null || this.PrimitiveType == PrimitiveType.None) {
			if (this.EnumType == null) {
				errs.Add($"Property {entityName}.{this.Name}: No data type defined.");
			} else {
				// It's an enum
			}
		} else {
			// It's a primitive
			if (this.PrimitiveType == PrimitiveType.String) {
				if (this.MaxLength < 0)
					errs.Add($"Property {entityName}.{this.Name}: String values must have a MaxLength >= 0 (0 == NVARCHAR(MAX))");

			} else if (this.PrimitiveType == PrimitiveType.ByteArray) {
				if (this.MaxLength <= 0)
					errs.Add($"Property {entityName}.{this.Name}: Byte array type must have a MaxLength > 0");
			}
		}

		errorList.AddRange(errs);
		return (errs.Count == 0);
	}

	public override string ToString()
	{
		return this.Name;
	}

	#endregion

	#region PropertyChanged

	public event PropertyChangedEventHandler PropertyChanged;

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
