using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models.Services;

public class ServiceModel : INotifyPropertyChanged
{
	#region Static

	public static ServiceModel CreateNew(Guid id, EntityModel entity)
	{
		return new ServiceModel() {
			Id = id,
			Entity = entity,
			InclCreate = true,
			InclUpdate = true,
			InclDelete = true,
			ControllerVersion = "1.0",
			Enabled = true
		};
	}

	#endregion

	#region Fields

	private bool _inclCreate;
	private bool _inclUpdate;
	private bool _inclDelete;
	private bool _inclController;
	private string _controllerVersion;
	private ObservableCollection<string> _addlServiceUsings = new ObservableCollection<string>();
	private ObservableCollection<string> _serviceAttributes = new ObservableCollection<string>();
	private ObservableCollection<string> _addlControllerUsings = new ObservableCollection<string>();
	private ObservableCollection<string> _controllerAttributes = new ObservableCollection<string>();
	private bool _enabled;
	private bool _suspendUpdates;

	#endregion

	#region Ctors / Initialization

	#endregion

	#region Properties

	public Guid Id { get; set; }

	public bool Enabled
	{
		get => _enabled;
		set => SetProperty(ref _enabled, value);
	}

	public bool InclCreate
	{
		get => _inclCreate;
		set => SetProperty(ref _inclCreate, value);
	}

	public bool InclUpdate
	{
		get => _inclUpdate;
		set => SetProperty(ref _inclUpdate, value);
	}

	public bool InclDelete
	{
		get => _inclDelete;
		set => SetProperty(ref _inclDelete, value);
	}

	public bool InclController
	{
		get => _inclController;
		set => SetProperty(ref _inclController, value);
	}

	public string ControllerVersion
	{
		get => _controllerVersion;
		set => SetProperty(ref _controllerVersion, value);
	}

	public ObservableCollection<string> AddlServiceUsings
	{
		get => _addlServiceUsings;
		set => SetProperty(ref _addlServiceUsings, value);
	}

	public ObservableCollection<string> ServiceClassAttributes
	{
		get => _serviceAttributes;
		set => SetProperty(ref _serviceAttributes, value);
	}

	public ObservableCollection<string> AddlControllerUsings
	{
		get => _addlControllerUsings;
		set => SetProperty(ref _addlControllerUsings, value);
	}

	public ObservableCollection<string> ControllerClassAttributes
	{
		get => _controllerAttributes;
		set => SetProperty(ref _controllerAttributes, value);
	}

	public ObservableCollection<ReadMethodModel> ReadMethods { get; set; } = new ObservableCollection<ReadMethodModel>();
	public ObservableCollection<UpdateMethodModel> UpdateMethods { get; set; } = new ObservableCollection<UpdateMethodModel>();

	#endregion

	#region Non-serialized Properties

	[JsonIgnore]
	public EntityModel Entity { get; private set; }

	[JsonIgnore]
	public string EntityName => Entity?.Name;

	#endregion

	#region Methods

	public bool Validate(string entityName, List<string> errorList)
	{
		var errs = new List<string>();


		errorList.AddRange(errs);
		return errs.Count == 0;
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
