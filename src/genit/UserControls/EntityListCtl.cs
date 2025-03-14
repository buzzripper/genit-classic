using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class EntityListCtl : UserControl
{
	public event EventHandler<EntitySelectionChangedEventArgs> ValueChanged;

	#region Fields

	private ObservableCollection<EntityModel> _entities;
	private bool _suspendUpdates;

	#endregion

	#region Ctors / Init

	public EntityListCtl()
	{
		InitializeComponent();
	}

	private void EntityListCtl_Load(object sender, EventArgs e)
	{
		this.Height = cmbEntities.Height;
	}

	#endregion

	#region Properties

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableCollection<EntityModel> DataSource
	{
		get {
			return _entities;
		}
		set {
			_entities = value;
			PopulateDropdown();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public EntityModel SelectedItem
	{
		get {
			return cmbEntities.SelectedItem as EntityModel;
		}
		set {
			cmbEntities.SelectedItem = value;
		}
	}

	#endregion

	#region UI Events

	private void cmbEntities_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			ValueChanged?.Invoke(this, new EntitySelectionChangedEventArgs(cmbEntities.SelectedItem as EntityModel));
	}

	#endregion

	#region Methods

	private void PopulateDropdown()
	{
		_suspendUpdates = true;

		cmbEntities.Items.Clear();
		//cmbEntities.DataSource = _entities.ToList().OrderBy(e => e.Name);
		cmbEntities.DataSource = _entities.OrderBy(e => e.Name).ToList();

		_suspendUpdates = false;
	}

	#endregion
}

public class EntitySelectionChangedEventArgs : EventArgs
{
	public EntityModel EntityModel { get; }

	public EntitySelectionChangedEventArgs(EntityModel entityModel)
	{
		EntityModel = entityModel;
	}
}
