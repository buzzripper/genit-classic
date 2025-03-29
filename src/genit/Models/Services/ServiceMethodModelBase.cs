//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using System.Text.Json.Serialization;

//namespace Dyvenix.Genit.Models.Services;

//public abstract class ServiceMethodModelBase : INotifyPropertyChanged
//{
//	public event PropertyChangedEventHandler PropertyChanged;

//	#region Fields

//	private int _displayOrder;
//	private bool _inclSorting;
//	private bool _inclPaging;
//	private ObservableCollection<string> _attributes = new ObservableCollection<string>();
//	protected bool _suspendUpdates;

//	#endregion

//	#region Ctors / Initialization

//	[JsonConstructor]
//	public ServiceMethodModelBase()
//	{
//	}

//	#endregion

//	#region Properties

//	public Guid Id { get; init; }
//	public string Name { get; set; }

//	public ObservableCollection<string> Attributes
//	{
//		get => _attributes;
//		set => SetProperty(ref _attributes, value);
//	}

//	public int DisplayOrder
//	{
//		get => _displayOrder;
//		set => SetProperty(ref _displayOrder, value);
//	}

//	public bool InclSorting
//	{
//		get => _inclSorting;
//		set => SetProperty(ref _inclSorting, value);
//	}

//	public bool InclPaging
//	{
//		get => _inclPaging;
//		set => SetProperty(ref _inclPaging, value);
//	}

//	#endregion

//	#region Non-serialized Properties

//	[JsonIgnore]
//	public int AttrCount => this.Attributes.Count;

//	#endregion


//	#region PropertyChanged

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
