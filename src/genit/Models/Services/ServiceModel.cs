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
	#region Fields

	private EntityModel _entity;
	private bool _inclSave;
	private bool _inclDelete;
	private bool _inclController;
	private ObservableCollection<string> _addlUsings = new ObservableCollection<string>();
	private bool _enabled;
	private bool _suspendUpdates;

	#endregion

	#region Ctors / Initialization

	[JsonConstructor]
	public ServiceModel()
	{
	}

	public ServiceModel(Guid id, EntityModel entity)
	{
		_suspendUpdates = true;

		Id = id;
		this.Entity = entity;

		_suspendUpdates = false;
	}

	public void InitializeOnLoad(EntityModel entity)
	{
		this.Entity = entity;

		foreach(var getSingleMethod in GetMethods.Where(m => !m.IsList))
			getSingleMethod.InitializeOnLoad(entity.Properties.FirstOrDefault(p => p.Id == getSingleMethod.PropertyId));

		foreach(var getListMethod in GetMethods.Where(m => m.IsList))
			getListMethod.InitializeOnLoad(entity.Properties.FirstOrDefault(p => p.Id == getListMethod.PropertyId));

		foreach(var queryMethod in QueryMethods)
			queryMethod.InitializeOnLoad(entity.Properties.Where(p => queryMethod.FilterPropertyIds.Contains(p.Id)).ToList());
	}

	#endregion

	#region Properties

	public Guid Id { get; set; }

	public Guid EntityId { get; set; }

	public bool Enabled
	{
		get => _enabled;
		set => SetProperty(ref _enabled, value);
	}

	public bool InclSave
	{
		get => _inclSave;
		set => SetProperty(ref _inclSave, value);
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

	public ObservableCollection<string> AddlUsings
	{
		get => _addlUsings;
		set => SetProperty(ref _addlUsings, value);
	}

	public ObservableCollection<GetSvcMethodModel> GetMethods { get; set; } = new ObservableCollection<GetSvcMethodModel>();
	public ObservableCollection<QuerySvcMethodModel> QueryMethods { get; set; } = new ObservableCollection<QuerySvcMethodModel>();

	#endregion

	#region Non-serialized Properties

	[JsonIgnore]
	public EntityModel Entity
	{
		get { return _entity; }
		set {
			EntityId = value?.Id ?? Guid.Empty;
			SetProperty(ref _entity, value);
		}
	}

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
