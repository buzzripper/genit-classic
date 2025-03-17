using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models
{
    public class EnumModel : INotifyPropertyChanged
    {
        private string _name;
        private bool _isExternal;
        private bool _isFlags;
        private string _namespace;
        private ObservableCollection<string> _members = new();

        public event PropertyChangedEventHandler PropertyChanged;

        #region Ctors

        [JsonConstructor]
        public EnumModel()
        {
        }

        public EnumModel(Guid id)
        {
            Id = id;
        }

        #endregion

        public Guid Id { get; init; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public bool IsExternal
        {
            get => _isExternal;
            set => SetProperty(ref _isExternal, value);
        }

        public bool IsFlags
        {
            get => _isFlags;
            set => SetProperty(ref _isFlags, value);
        }

        public string Namespace
        {
            get => _namespace;
            set => SetProperty(ref _namespace, value);
        }

        public ObservableCollection<string> Members
        {
            get => _members;
            set => SetProperty(ref _members, value);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void Validate(List<string> errorList)
        {
            if (string.IsNullOrWhiteSpace(Name))
                errorList.Add("Invalid EnumModel. Name not defined.");
            if (!Members.Any())
                errorList.Add($"Invalid EnumModel '{Name}'. No members defined.");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
