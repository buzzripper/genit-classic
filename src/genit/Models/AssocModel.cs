using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models
{
	public class AssocModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		#region Fields

		private Guid _id;
		private Cardinality _cardinality;
		private bool _suspendUpdates;

		#endregion

		#region Ctors

		[JsonConstructor]
		public AssocModel()
		{
		}

		#endregion

		#region Properties 

		public Guid Id
		{
			get => _id;
			set => SetProperty(ref _id, value);
		}

		public Cardinality Cardinality
		{
			get => _cardinality;
			set => SetProperty(ref _cardinality, value);
		}

		public EntityModel PrimaryEntity {  get; set; }
		public NavPropertyModel NavProperty {  get; set; }
		public EntityModel FKEntity {  get; set; }
		public PropertyModel FKProperty {  get; set; }

		#endregion

		#region Methods

		public void Validate(List<string> errorList)
		{
		}

		#endregion

		#region INotifyPropertyChanged

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
}
