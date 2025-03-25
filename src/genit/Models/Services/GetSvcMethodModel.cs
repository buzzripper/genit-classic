using Dyvenix.Genit.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models.Services;

public class GetSvcMethodModel : ServiceMethodModelBase, INotifyPropertyChanged
{
	#region Fields

	private PropertyModel _property;
	private bool _isList;

	#endregion

	#region Ctors / Initialization

	[JsonConstructor]
	public GetSvcMethodModel()
	{
	}

	public GetSvcMethodModel(Guid id, PropertyModel property)
	{
		_suspendUpdates = true;

		Id = id;
		Property = property;

		_suspendUpdates = false;
	}

	public void InitializeOnLoad(PropertyModel property)
	{
		_suspendUpdates = true;

		this.Property = property;

		_suspendUpdates = false;
	}

	#endregion

	#region Properties

	public Guid PropertyId { get; set; }

	public bool IsList
	{
		get => _isList;
		set => SetProperty(ref _isList, value);
	}

	#endregion

	#region Non-serialized Properties

	[JsonIgnore]
	public PropertyModel Property
	{
		get { return _property; }
		set {
			PropertyId = value?.Id ?? Guid.Empty;
			SetProperty(ref _property, value);
		}
	}

	[JsonIgnore]
	public string PropName
	{
		get { return this.Property?.Name; }
	}

	[JsonIgnore]
	public string ArgName
	{
		get {
			return Utils.ToCamelCase(Property.Name);
		}
	}

	[JsonIgnore]
	public string ArgType
	{
		get {
			if (Property == null)
				return string.Empty;
			
			if (Property.PrimitiveType != null)
				return Property.PrimitiveType.CSType;
			else if (Property.EnumType != null)
				return Property.EnumType.Name;
			else
				return string.Empty;
		}
	}

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
}
