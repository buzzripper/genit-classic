using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models.Services;

public class QuerySvcMethodModel : ServiceMethodModelBase
{
	#region Fields

	private List<PropertyModel> _filterProperties = new List<PropertyModel>();

	#endregion

	#region Ctors / Initialization

	[JsonConstructor]
	public QuerySvcMethodModel()
	{
	}

	public QuerySvcMethodModel(Guid id)
	{
		_suspendUpdates = true;

		Id = id;

		_suspendUpdates = false;
	}

	public void InitializeOnLoad(List<PropertyModel> filteredProperties)
	{
		_suspendUpdates = true;

		this.FilterProperties.AddRange(filteredProperties);

		_suspendUpdates = false;
	}

	#endregion

	#region Properties

	public List<Guid> FilterPropertyIds { get; set; } = new List<Guid>();

	#endregion

	#region Non-serialized Properties

	[JsonIgnore]
	public List<PropertyModel> FilterProperties
	{
		get { return _filterProperties; }
		set {
			FilterPropertyIds.AddRange(value?.Select(v => v.Id));
			SetProperty(ref _filterProperties, value);
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
