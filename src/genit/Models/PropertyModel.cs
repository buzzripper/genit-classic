using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class PropertyModel : INotifyPropertyChanged
{
	private string _name;

	#region Ctors

	[JsonConstructor]
	public PropertyModel()
	{
	}

	public PropertyModel(Guid id)
	{
		Id = id;
	}

	public PropertyModel(Guid id, AssocModel assoc)
	{
		Id = id;
		Name = assoc.RelatedPropertyName;
		PrimitiveType = assoc.PrimaryPKType;
		FKAssoc = assoc;
	}

	#endregion

	public Guid Id { get; init; }
	public string Name
	{
		get {
			if (FKAssoc != null)
				return FKAssoc.RelatedPropertyName;
			return _name;
		}
		set {
			if (FKAssoc != null)
				throw new ApplicationException($"Can't rename property, it is a FK association property.");
			SetProperty(ref _name, value);
		}
	}

	private PrimitiveType _primitiveType;
	public PrimitiveType PrimitiveType
	{
		get => _primitiveType;
		set => SetProperty(ref _primitiveType, value);
	}

	private EnumModel _enumType;
	public EnumModel EnumType
	{
		get => _enumType;
		set => SetProperty(ref _enumType, value);
	}

	private AssocModel _fkAssoc;
	public AssocModel FKAssoc
	{
		get => _fkAssoc;
		set => SetProperty(ref _fkAssoc, value);
	}

	private bool _nullable;
	public bool Nullable
	{
		get => _nullable;
		set => SetProperty(ref _nullable, value);
	}

	private bool _isPrimaryKey;
	public bool IsPrimaryKey
	{
		get => _isPrimaryKey;
		set => SetProperty(ref _isPrimaryKey, value);
	}

	private bool _isIdentity;
	public bool IsIdentity
	{
		get => _isIdentity;
		set => SetProperty(ref _isIdentity, value);
	}

	private int _maxLength;
	public int MaxLength
	{
		get => _maxLength;
		set => SetProperty(ref _maxLength, value);
	}

	private bool _isIndexed;
	public bool IsIndexed
	{
		get => _isIndexed;
		set => SetProperty(ref _isIndexed, value);
	}

	private bool _isIndexUnique;
	public bool IsIndexUnique
	{
		get => _isIndexUnique;
		set => SetProperty(ref _isIndexUnique, value);
	}

	private bool _isIndexClustered;
	public bool IsIndexClustered
	{
		get => _isIndexClustered;
		set => SetProperty(ref _isIndexClustered, value);
	}

	private bool _multiIndex1;
	public bool MultiIndex1
	{
		get => _multiIndex1;
		set => SetProperty(ref _multiIndex1, value);
	}

	private bool _multiIndex1Unique;
	public bool MultiIndex1Unique
	{
		get => _multiIndex1Unique;
		set => SetProperty(ref _multiIndex1Unique, value);
	}

	private bool _multiIndex2;
	public bool MultiIndex2
	{
		get => _multiIndex2;
		set => SetProperty(ref _multiIndex2, value);
	}

	private bool _multiIndex2Unique;
	public bool MultiIndex2Unique
	{
		get => _multiIndex2Unique;
		set => SetProperty(ref _multiIndex2Unique, value);
	}

	private bool _isSortCol;
	public bool IsSortCol
	{
		get => _isSortCol;
		set => SetProperty(ref _isSortCol, value);
	}

	private bool _isSortDesc;
	public bool IsSortDesc
	{
		get => _isSortDesc;
		set => SetProperty(ref _isSortDesc, value);
	}

	private ObservableCollection<string> _attributes = new ObservableCollection<string>();
	public ObservableCollection<string> Attributes
	{
		get => _attributes;
		set => SetProperty(ref _attributes, value);
	}

	private ObservableCollection<string> _addlUsings = new ObservableCollection<string>();
	public ObservableCollection<string> AddlUsings
	{
		get => _addlUsings;
		set => SetProperty(ref _addlUsings, value);
	}

	#region Methods

	public void Initialize(EntityModel primaryEntityMdl, EntityModel relatedEntityMdl)
	{
	}

	public bool Validate(string entityName, List<string> errorList)
	{
		var errs = new List<string>();

		if (this.PrimitiveType != PrimitiveType.None) {
			if (this.PrimitiveType == PrimitiveType.String) {
				if (this.MaxLength < 0)
					errs.Add($"Property {entityName}.{this.Name}: String values must have a MaxLength >= 0 (0 == NVARCHAR(MAX))");

			} else if (this.PrimitiveType == PrimitiveType.ByteArray) {
				if (this.MaxLength <= 0)
					errs.Add($"Property {entityName}.{this.Name}: Byte array type must have a MaxLength > 0");
			}

		} else if (this.EnumType != null) {


		} else if (this.FKAssoc != null) {


		} else {
			errs.Add($"Property {entityName}.{this.Name}: No data type defined.");
		}

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
