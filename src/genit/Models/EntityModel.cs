using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models
{
    public class EntityModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name;
        private string _schema;
        private string _tableName;
        private bool _enabled;
        private string _namespace;
        private ObservableCollection<string> _attributes = new ObservableCollection<string>();
        private ObservableCollection<string> _addlUsings = new ObservableCollection<string>();
        private bool _inclSingleQuery;
        private bool _inclListQuery;
        private bool _inclListInfoQuery;
        private bool _useListPaging;
        private bool _useListSorting;
        private ObservableCollection<PropertyModel> _properties = new ObservableCollection<PropertyModel>();
        private ObservableCollection<AssocModel> _navAssocs = new ObservableCollection<AssocModel>();

        [JsonConstructor]
        public EntityModel()
        {
        }

        public EntityModel(Guid id)
        {
            Id = id;
        }

        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Schema
        {
            get => _schema;
            set => SetProperty(ref _schema, value);
        }

        public string TableName
        {
            get => _tableName;
            set => SetProperty(ref _tableName, value);
        }

        public bool Enabled
        {
            get => _enabled;
            set => SetProperty(ref _enabled, value);
        }

        public string Namespace
        {
            get => _namespace;
            set => SetProperty(ref _namespace, value);
        }

        public ObservableCollection<string> Attributes
        {
            get => _attributes;
            set => SetProperty(ref _attributes, value);
        }

        public ObservableCollection<string> AddlUsings
        {
            get => _addlUsings;
            set => SetProperty(ref _addlUsings, value);
        }

        public bool InclSingleQuery
        {
            get => _inclSingleQuery;
            set => SetProperty(ref _inclSingleQuery, value);
        }

        public bool InclListQuery
        {
            get => _inclListQuery;
            set => SetProperty(ref _inclListQuery, value);
        }

        public bool InclListInfoQuery
        {
            get => _inclListInfoQuery;
            set => SetProperty(ref _inclListInfoQuery, value);
        }

        public bool UseListPaging
        {
            get => _useListPaging;
            set => SetProperty(ref _useListPaging, value);
        }

        public bool UseListSorting
        {
            get => _useListSorting;
            set => SetProperty(ref _useListSorting, value);
        }

        public ObservableCollection<PropertyModel> Properties
        {
            get => _properties;
            set => SetProperty(ref _properties, value);
        }

        public ObservableCollection<AssocModel> NavAssocs
        {
            get => _navAssocs;
            set => SetProperty(ref _navAssocs, value);
        }

        public void InitializeOnLoad(ObservableCollection<EnumModel> enums)
        {
            foreach (var property in Properties)
            {
                property.InitializeOnLoad(enums);
            }
        }

        public Guid AddForeignKey(AssocModel assoc)
        {
            var property = new PropertyModel(Guid.NewGuid(), assoc);
            Properties.Add(property);
            return property.Id;
        }

        public void Validate(List<string> errorList)
        {
            foreach (var property in Properties)
            {
                property.Validate(Name, errorList);
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
