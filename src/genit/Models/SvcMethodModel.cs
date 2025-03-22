//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text.Json.Serialization;

//namespace Dyvenix.Genit.Models;

//public class SvcMethodModel : INotifyPropertyChanged
//{
//	#region Fields

//	private Guid _id; 
//	private string _name;
//	private bool _inclPaging;
//	private bool _inclSorting;
//	private int _displayOrder;
//	private ObservableCollection<string> _attributes = new ObservableCollection<string>();
//	private ObservableCollection<string> _addlUsings = new ObservableCollection<string>();

//	private PrimitiveType _returnPrimitiveType;
//	private EntityModel _returnEntityType;
//	private EnumModel _returnEnumType;
//	private ObservableCollection<PropertyModel> _argProperties = new ObservableCollection<PropertyModel>();
//	private ObservableCollection<PropertyModel> _dtoProperties = new ObservableCollection<PropertyModel>();

//	private bool _suspendUpdates;

//	#endregion

//	#region Ctors / Initialization

//	[JsonConstructor]
//	public SvcMethodModel()
//	{
//	}

//	public SvcMethodModel(Guid id)
//	{
//		Id = id;
//	}

//	public SvcMethodModel(Guid id, string name)
//	{
//		_suspendUpdates = true;

//		_id = id;
//		_name = name;

//		_suspendUpdates = false;
//	}

//	public void InitializeOnLoad(ObservableCollection<PropertyModel> properties)
//	{
//		foreach(var propId in ArgPropertyIds) {
//			var prop = properties.FirstOrDefault(p => p.Id == propId);	
//			if (prop != null) {
//				ArgProperties.Add(prop);
//		}
//	}

//	#endregion

//	#region Properties

//	public Guid Id { get; init; }

//	public string Name
//	{
//		get => _name;
//		set => SetProperty(ref _name, value);
//	}

//	public int ReturnPrimitiveTypeId { get; set; }

//	public Guid? ReturnEntityTypeId { get; set; }

//	public Guid? ReturnEnumTypeId { get; set; }

//	public bool IsListReturn { get; set; }	

//	public ObservableCollection<Guid> ArgPropertyIds { get; set; } = new ObservableCollection<Guid>();

//	public int DisplayOrder
//	{
//		get => _displayOrder;
//		set => SetProperty(ref _displayOrder, value);
//	}

//	public ObservableCollection<string> Attributes
//	{
//		get => _attributes;
//		set => SetProperty(ref _attributes, value);
//	}

//	public ObservableCollection<string> AddlUsings
//	{
//		get => _addlUsings;
//		set => SetProperty(ref _addlUsings, value);
//	}

//	#endregion

//	#region Non-serialized Properties

//	[JsonIgnore]
//	public EntityModel Entity { get; set; }

//	[JsonIgnore]
//	public ObservableCollection<PropertyModel> ArgProperties { get; set; } = new ObservableCollection<PropertyModel>();

//	[JsonIgnore]
//	public PrimitiveType ReturnPrimitiveType
//	{
//		get { return _returnPrimitiveType; }
//		set {
//			this.ReturnPrimitiveTypeId = (value != null) ? value.Id : -1;
//			SetProperty(ref _returnPrimitiveType, value);
//		}
//	}

//	[JsonIgnore]
//	public EntityModel ReturnEntityType
//	{
//		get { return _returnEntityType; }
//		set {
//			this.ReturnEntityTypeId = (value != null) ? value.Id : null;
//			SetProperty(ref _returnEntityType, value);
//		}
//	}

//	[JsonIgnore]
//	public EnumModel ReturnEnumType
//	{
//		get => _returnEnumType;
//		set {
//			ReturnEnumTypeId = (value != null) ? value.Id : null;
//			SetProperty(ref _returnEnumType, value);
//		}
//	}

//	#endregion

//	#region Methods

//	public void InitializeOnLoad(ObservableCollection<EnumModel> enums, AssocModel assoc)
//	{
//		if (this.ReturnPrimitiveTypeId > 0) {
//			this.ReturnPrimitiveType = PrimitiveType.GetAll().First(p => p.Id == this.ReturnPrimitiveTypeId);

//		} else if (this.ReturnEnumTypeId != null) {
//			this.ReturnEnumType = enums.FirstOrDefault(e => e.Id == this.ReturnEnumTypeId);
//		}
//	}

//	public bool Validate(string entityName, List<string> errorList)
//	{
//		var errs = new List<string>();

//		if ((this.ReturnPrimitiveType == null || this.ReturnPrimitiveType == PrimitiveType.None) && this.ReturnEntityType == null && this.ReturnEnumType == null) {
//			errs.Add($"Property {entityName}.{this.Name}: No data type defined.");
//		}

//		errorList.AddRange(errs);
//		return (errs.Count == 0);
//	}

//	public override string ToString()
//	{
//		return this.Name;
//	}

//	#endregion

//	#region PropertyChanged

//	public event PropertyChangedEventHandler PropertyChanged;

//	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
//	{
//		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//	}

//	protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
//	{
//		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
//		field = value;

//		if (!_suspendUpdates)
//			OnPropertyChanged(propertyName);

//		return true;
//	}

//	#endregion
//}
