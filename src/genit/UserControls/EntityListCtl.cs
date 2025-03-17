using System;
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

		if (this.DesignMode)
			return;

		_suspendUpdates = true;

		//cmbEntities.Items.Clear();
		//cmbEntities.Items.Add(new ListItem(null));
		//foreach (var entity in Doc.Instance?.DbContexts[0].Entities.OrderBy(e => e.Name))
		//	cmbEntities.Items.Add(new ListItem(entity));
		
		cmbEntities.DataSource = Doc.Instance.DbContexts[0].Entities.OrderBy(e => e.Name).ToList();
		Doc.Instance.DbContexts[0].Entities.CollectionChanged += Entities_CollectionChanged;

		_suspendUpdates = false;
	}

	private void Entities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		cmbEntities.DataSource = Doc.Instance.DbContexts[0].Entities.OrderBy(e => e.Name).ToList();
	}

	#endregion

	#region Properties

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public EntityModel SelectedEntity
	{
		get {
			return cmbEntities.SelectedItem as EntityModel;
		}
		set {
			if (value == null) {
				cmbEntities.SelectedIndex = -1;
				return;
			} else {
				cmbEntities.SelectedItem = value;	
			}
			//foreach (ListItem listItem in cmbEntities.Items) {
			//	if (listItem.Entity == value) {
			//		cmbEntities.SelectedItem = listItem;
			//		break;
			//	}
			//}
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

	#endregion

	private class ListItem
	{
		public string Display { get; set; }
		public EntityModel Entity { get; set; }
		
		public ListItem(EntityModel entity)
		{
			Display = entity?.Name;
			Entity = entity;
		}
		
		public override string ToString()
		{
			return Display;
		}
	}
}

public class EntitySelectionChangedEventArgs : EventArgs
{
	public EntityModel EntityModel { get; }

	public EntitySelectionChangedEventArgs(EntityModel entityModel)
	{
		EntityModel = entityModel;
	}
}
