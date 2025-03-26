using Dyvenix.Genit.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models.Services;

public class GetSvcMethodModel : ServiceMethodModelBase, INotifyPropertyChanged
{
	#region Fields

	private PropertyModel _filterProperty;
	private bool _isList;

	#endregion

	#region Ctors / Initialization

	[JsonConstructor]
	public GetSvcMethodModel()
	{
	}

	public GetSvcMethodModel(Guid id)
	{
		Id = id;
	}

	public void InitializeOnLoad(PropertyModel property)
	{
		_suspendUpdates = true;

		this.FilterProperty = property;

		_suspendUpdates = false;
	}

	#endregion

	#region Properties

	public Guid? FilterPropertyId { get; set; }

	public bool IsList
	{
		get => _isList;
		set => SetProperty(ref _isList, value);
	}

	#endregion

	#region Non-serialized Properties

	[JsonIgnore]
	public PropertyModel FilterProperty
	{
		get { return _filterProperty; }
		set {
			FilterPropertyId = value?.Id ?? Guid.Empty;
			SetProperty(ref _filterProperty, value);
		}
	}

	[JsonIgnore]
	public string PropName
	{
		get { return this.FilterProperty?.Name; }
	}

	[JsonIgnore]
	public string ArgName
	{
		get {
			return Utils.ToCamelCase(FilterProperty?.Name);
		}
	}

	[JsonIgnore]
	public string ArgType
	{
		get {
			if (FilterProperty == null)
				return string.Empty;
			
			if (FilterProperty.PrimitiveType != null)
				return FilterProperty.PrimitiveType.CSType;
			else if (FilterProperty.EnumType != null)
				return FilterProperty.EnumType.Name;
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
