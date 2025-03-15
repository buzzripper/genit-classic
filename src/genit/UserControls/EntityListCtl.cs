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
		Doc.Instance.DbContexts[0].Entities.CollectionChanged += Entities_CollectionChanged;
		cmbEntities.DataSource = Doc.Instance.DbContexts[0].Entities.OrderBy(e => e.Name).ToList();
	}

	private void Entities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		cmbEntities.DataSource = Doc.Instance.DbContexts[0].Entities.OrderBy(e => e.Name).ToList();
	}

	#endregion

	#region Properties

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
