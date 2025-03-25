//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Text.Json.Serialization;

//namespace Dyvenix.Genit.Models.Services;

//public class GetListSvcMethodModel : ServiceMethodModelBase
//{
//	#region Fields

//	private PropertyModel _property;

//	#endregion

//	#region Ctors / Initialization

//	[JsonConstructor]
//	public GetListSvcMethodModel()
//	{
//	}

//	public GetListSvcMethodModel(Guid id, PropertyModel property)
//	{
//		_suspendUpdates = true;

//		Id = id;
//		Property = property;

//		_suspendUpdates = false;
//	}

//	public void InitializeOnLoad(PropertyModel property)
//	{
//		_suspendUpdates = true;

//		this.Property = property;

//		_suspendUpdates = false;
//	}

//	#endregion

//	#region Properties

//	public Guid PropertyId { get; set; }

//	#endregion

//	#region Non-serialized Properties

//	[JsonIgnore]
//	public PropertyModel Property
//	{
//		get { return _property; }
//		set {
//			PropertyId = value?.Id ?? Guid.Empty;
//			SetProperty(ref _property, value);
//		}
//	}

//	[JsonIgnore]
//	public string PropName
//	{
//		get { return this.Property?.Name; }
//	}

//	[JsonIgnore]
//	public string ArgName
//	{
//		get {
//			if (string.IsNullOrWhiteSpace(Property?.Name))
//				return string.Empty;
			
//			var firstChar = Property.Name.Substring(0, 1).ToLower();
//			if (Property.Name.Length > 1) 
//				return $"{firstChar}{Property.Name.Substring(1)}";
//			else
//				return firstChar;
//		}
//	}

//	[JsonIgnore]
//	public string ArgType
//	{
//		get {
//			if (Property == null)
//				return string.Empty;
			
//			if (Property.PrimitiveType != null)
//				return Property.PrimitiveType.CSType;
//			else if (Property.EnumType != null)
//				return Property.EnumType.Name;
//			else
//				return string.Empty;
//		}
//	}

//	[JsonIgnore]
//	public ObservableCollection<PropertyModel> ArgProperties { get; set; } = new ObservableCollection<PropertyModel>();

//	#endregion

//	#region Methods

//	public bool Validate(string entityName, List<string> errorList)
//	{
//		var errs = new List<string>();


//		errorList.AddRange(errs);
//		return (errs.Count == 0);
//	}

//	public override string ToString()
//	{
//		return this.Name;
//	}

//	#endregion
//}
