using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models.Services;

public class UpdateMethodModel : INotifyPropertyChanged
{
	public static UpdateMethodModel CreateNew(Guid id, string name, int displayOrder)
	{
		return new UpdateMethodModel() {
			Id = id,
			Name = name, 
			DisplayOrder = displayOrder
		};
	}

	public event PropertyChangedEventHandler PropertyChanged;

	#region Fields

	private int _displayOrder;
	private bool _suspendUpdates;

	#endregion

	#region Ctors / Initialization


	#endregion

	#region Properties

	public Guid Id { get; init; }
	public string Name { get; set; }
	public bool UseDto { get; set; }
	public ObservableCollection<UpdatePropertyModel> UpdateProperties {  get; set; } = new ObservableCollection<UpdatePropertyModel>();

	public int DisplayOrder
	{
		get => _displayOrder;
		set => SetProperty(ref _displayOrder, value);
	}

	#endregion

	#region Non-serialized Properties

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

	#region PropertyChanged

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
