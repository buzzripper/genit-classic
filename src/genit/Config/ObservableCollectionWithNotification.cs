using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dyvenix.Genit.Config;

public class ObservableCollectionWithNotification<T> : ObservableCollection<T> where T : INotifyPropertyChanged
{
	public ObservableCollectionWithNotification() : base()
	{
		CollectionChanged += ObservableCollectionWithNotification_CollectionChanged;
	}

	public ObservableCollectionWithNotification(IEnumerable<T> collection) : base(collection)
	{
		CollectionChanged += ObservableCollectionWithNotification_CollectionChanged;
		foreach (var item in collection) {
			item.PropertyChanged += Item_PropertyChanged;
		}
	}

	private void ObservableCollectionWithNotification_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.NewItems != null) {
			foreach (T item in e.NewItems) {
				item.PropertyChanged += Item_PropertyChanged;
			}
		}

		if (e.OldItems != null) {
			foreach (T item in e.OldItems) {
				item.PropertyChanged -= Item_PropertyChanged;
			}
		}
	}

	private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		// Handle the PropertyChanged event for items within the collection
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}
}

public class Person : INotifyPropertyChanged
{
	private string _name;
	public string Name
	{
		get => _name;
		set {
			if (_name != value) {
				_name = value;
				OnPropertyChanged();
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
