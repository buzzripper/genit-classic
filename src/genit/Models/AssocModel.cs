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
		private Guid _primaryEntityId;
		private Guid _navPropertyId;
		private Guid _fkEntityId;
		private Guid _fkPropertyId;
		private Cardinality _cardinality;

		private bool _suspendUpdates;

		//private string _primaryPropertyName;
		//private PrimitiveType _primaryPKType;
		//private string _relatedPropertyName;
		//private EntityModel _primaryEntity;
		//private EntityModel _relatedEntity;

		#endregion

		#region Ctors

		[JsonConstructor]
		public AssocModel()
		{
		}

		//public AssocModel(Guid id, EntityModel primaryEntityMdl, string name, EntityModel relatedEntityMdl, string relatedPropertyName, CardinalityModel cardinality)
		//{
		// _suspendUpdates = true;
		//	Id = id;
		//	PrimaryEntity = primaryEntityMdl;
		//	PrimaryEntityId = primaryEntityMdl.Id;
		//	PrimaryPropertyName = name;
		//	RelatedEntity = relatedEntityMdl;
		//	RelatedEntityId = relatedEntityMdl.Id;
		//	RelatedPropertyName = relatedPropertyName;
		//	Cardinality = cardinality;

		//	PrimaryPKType = primaryEntityMdl.Properties.FirstOrDefault(p => p.IsPrimaryKey)?.PrimitiveType;
		// _suspendUpdates = false;
		//}

		public void InitializeOnLoad(EntityModel primaryEntityMdl, EntityModel relatedEntityMdl)
		{
			_suspendUpdates = true;

			PrimaryEntity = primaryEntityMdl;
			NavProperty = primaryEntityMdl.NavProperties.FirstOrDefault(np => np.Id == NavPropertyId);

			FKEntity = relatedEntityMdl;
			FKProperty = relatedEntityMdl.Properties.FirstOrDefault(p => p.Id == FKPropertyId);

			_suspendUpdates = false;
		}

		#endregion

		#region Properties 

		public Guid Id
		{
			get => _id;
			set => SetProperty(ref _id, value);
		}

		public Guid PrimaryEntityId
		{
			get => _primaryEntityId;
			set => SetProperty(ref _primaryEntityId, value);
		}

		public Guid NavPropertyId
		{
			get => _navPropertyId;
			set => SetProperty(ref _navPropertyId, value);
		}

		public Guid FKEntityId
		{
			get => _fkEntityId;
			set => SetProperty(ref _fkEntityId, value);
		}

		public Guid FKPropertyId
		{
			get => _fkPropertyId;
			set => SetProperty(ref _fkPropertyId, value);
		}

		public Cardinality Cardinality
		{ 
			get => _cardinality;
			set => SetProperty(ref _cardinality, value);
		}

		[JsonIgnore]
		public EntityModel PrimaryEntity { get; set; }

		[JsonIgnore]
		public NavPropertyModel NavProperty { get; set; }

		[JsonIgnore]
		public EntityModel FKEntity { get; set; }

		[JsonIgnore]
		public PropertyModel FKProperty { get; set; }

		//public string PrimaryPropertyName
		//{
		//    get => _primaryPropertyName;
		//    set => SetProperty(ref _primaryPropertyName, value);
		//}

		//public PrimitiveType PrimaryPKType
		//{
		//    get => _primaryPKType;
		//    set => SetProperty(ref _primaryPKType, value);
		//}

		//public string RelatedPropertyName
		//{
		//    get => _relatedPropertyName;
		//    set => SetProperty(ref _relatedPropertyName, value);
		//}

		//[JsonIgnore]
		//public string Name
		//{
		//    get => $"{this.PrimaryEntity?.Name} - {this.RelatedEntity?.Name}";
		//}

		#endregion

		#region Methods

		public void Validate(List<string> errorList)
		{
			//if (string.IsNullOrWhiteSpace(PrimaryPropertyName))
			//	errorList.Add($"Invalid AssocModel. PrimaryPropertyName not defined.");

			//if (PrimaryEntityId == Guid.Empty)
			//	errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No PrimaryEntityId defined.");

			//if (this.PrimaryEntity == null)
			//	errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No PrimaryEntity defined.");

			//if (string.IsNullOrWhiteSpace(RelatedPropertyName))
			//	errorList.Add($"Invalid AssocModel. RelatedPropertyName not defined.");

			//if (RelatedEntityId == Guid.Empty)
			//	errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No RelatedEntityId defined.");

			//if (this.RelatedEntity == null)
			//	errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No RelatedEntity defined.");
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
