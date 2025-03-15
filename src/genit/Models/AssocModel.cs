//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text.Json.Serialization;

//namespace Dyvenix.Genit.Models
//{
//    public class AssocModel : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;

//        #region Fields

//        private Guid _id;
//        private Guid _primaryEntityId;
//        private string _primaryPropertyName;
//        private PrimitiveType _primaryPKType;
//        private Guid _relatedEntityId;
//        private string _relatedPropertyName;
//        private CardinalityModel _cardinality;
//        private EntityModel _primaryEntity;
//        private EntityModel _relatedEntity;

//        #endregion

//        #region Ctors

//        [JsonConstructor]
//        public AssocModel()
//        {
//        }

//        public AssocModel(Guid id, EntityModel primaryEntityMdl, string name, EntityModel relatedEntityMdl, string relatedPropertyName, CardinalityModel cardinality)
//        {
//            Id = id;
//            PrimaryEntity = primaryEntityMdl;
//            PrimaryEntityId = primaryEntityMdl.Id;
//            PrimaryPropertyName = name;
//            RelatedEntity = relatedEntityMdl;
//            RelatedEntityId = relatedEntityMdl.Id;
//            RelatedPropertyName = relatedPropertyName;
//            Cardinality = cardinality;

//            PrimaryPKType = primaryEntityMdl.Properties.FirstOrDefault(p => p.IsPrimaryKey)?.PrimitiveType;
//        }

//        public void InitializeOnLoad(EntityModel primaryEntityMdl, EntityModel relatedEntityMdl)
//        {
//            this.PrimaryEntity = primaryEntityMdl;
//            var navAssoc = primaryEntityMdl.NavAssocs.FirstOrDefault(a => a.Id == this.Id);
//			if (navAssoc == null)
//				primaryEntityMdl.NavAssocs.Add(this);
//			this.RelatedEntity = relatedEntityMdl;
//        }

//        #endregion

//        #region Properties 

//        public Guid Id
//        {
//            get => _id;
//            set => SetProperty(ref _id, value);
//        }

//        public Guid PrimaryEntityId
//        {
//            get => _primaryEntityId;
//            set => SetProperty(ref _primaryEntityId, value);
//        }

//        public string PrimaryPropertyName
//        {
//            get => _primaryPropertyName;
//            set => SetProperty(ref _primaryPropertyName, value);
//        }

//        public PrimitiveType PrimaryPKType
//        {
//            get => _primaryPKType;
//            set => SetProperty(ref _primaryPKType, value);
//        }

//        public Guid RelatedEntityId
//        {
//            get => _relatedEntityId;
//            set => SetProperty(ref _relatedEntityId, value);
//        }

//        public string RelatedPropertyName
//        {
//            get => _relatedPropertyName;
//            set => SetProperty(ref _relatedPropertyName, value);
//        }

//        public CardinalityModel Cardinality
//        {
//            get => _cardinality;
//            set => SetProperty(ref _cardinality, value);
//        }

//        [JsonIgnore]
//        public EntityModel PrimaryEntity
//        {
//            get => _primaryEntity;
//            set => SetProperty(ref _primaryEntity, value);
//        }

//        [JsonIgnore]
//        public EntityModel RelatedEntity
//        {
//            get => _relatedEntity;
//            set => SetProperty(ref _relatedEntity, value);
//        }

//        [JsonIgnore]
//        public string Name
//        {
//            get => $"{this.PrimaryEntity?.Name} - {this.RelatedEntity?.Name}";
//        }

//        #endregion

//        #region Methods

//        public void Validate(List<string> errorList)
//        {
//            if (string.IsNullOrWhiteSpace(PrimaryPropertyName))
//                errorList.Add($"Invalid AssocModel. PrimaryPropertyName not defined.");

//            if (PrimaryEntityId == Guid.Empty)
//                errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No PrimaryEntityId defined.");

//            if (this.PrimaryEntity == null)
//                errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No PrimaryEntity defined.");

//            if (string.IsNullOrWhiteSpace(RelatedPropertyName))
//                errorList.Add($"Invalid AssocModel. RelatedPropertyName not defined.");

//            if (RelatedEntityId == Guid.Empty)
//                errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No RelatedEntityId defined.");

//            if (this.RelatedEntity == null)
//                errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No RelatedEntity defined.");
//        }

//        #endregion

//        #region INotifyPropertyChanged

//        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
//        {
//            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
//            field = value;
//            OnPropertyChanged(propertyName);
//            return true;
//        }

//        #endregion
//    }
//}
