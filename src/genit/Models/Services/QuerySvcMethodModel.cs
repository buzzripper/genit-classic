//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Collections.Specialized;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text.Json.Serialization;

//namespace Dyvenix.Genit.Models.Services;

//public class QuerySvcMethodModel : ServiceMethodModelBase
//{
//	#region Fields

//	private ObservableCollection<PropertyModel> _filterProperties = new ObservableCollection<PropertyModel>();

//	#endregion

//	#region Ctors / Initialization

//	[JsonConstructor]
//	public QuerySvcMethodModel()
//	{
//		this.FilterProperties.CollectionChanged += FilterProperties_OnCollectionChanged;
//	}

//	public QuerySvcMethodModel(Guid id) : this()
//	{
//		_suspendUpdates = true;
//		Id = id;
//		_suspendUpdates = false;
//	}

//	public void InitializeOnLoad(List<PropertyModel> filterProperties)
//	{
//		_suspendUpdates = true;

//		this.FilterProperties.Clear();
//		filterProperties.ForEach(fp => this.FilterProperties.Add(fp));

//		_suspendUpdates = false;
//	}

//	#endregion

//	private void FilterProperties_OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
//	{
//		if (e.Action == NotifyCollectionChangedAction.Add) {
//			FilterPropertyIds.Add(((PropertyModel)e.NewItems[0]).Id);

//		} else if (e.Action == NotifyCollectionChangedAction.Remove) {
//			FilterPropertyIds.Remove(((PropertyModel)e.OldItems[0]).Id);

//		} else if (e.Action == NotifyCollectionChangedAction.Reset) {
//			ResetPropertyIds();
//		}
//	}

//	private void ResetPropertyIds()
//	{
//		FilterPropertyIds.Clear();
//		foreach (var prop in FilterProperties)
//			FilterPropertyIds.Add(prop.Id);
//	}

//	#region Properties

//	public List<Guid> FilterPropertyIds { get; set; } = new List<Guid>();

//	#endregion

//	#region Non-serialized Properties

//	[JsonIgnore]
//	public ObservableCollection<PropertyModel> FilterProperties { get; private set; } = new ObservableCollection<PropertyModel>();

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
