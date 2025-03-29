using Dyvenix.Genit.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class NavPropGridRowCtl : UserControl
{
	public event EventHandler<NavPropChangedEventArgs> NavigationPropertyChanged;
	public event EventHandler<NavPropertyEditEventArgs> NavPropertyEdit;

	#region Fields

	private readonly EntityModel _entity;
	private readonly NavPropertyModel _navProperty;
	private bool _suspendUpdates;
	private AssocEditForm _navPropEditForm;

	#endregion

	#region Ctors / Init

	public NavPropGridRowCtl()
	{
		InitializeComponent();
	}

	public NavPropGridRowCtl(NavPropertyModel navPropMdl) : this()
	{
		_navProperty = navPropMdl;
		_navProperty.PropertyChanged += NavPropModel_PropertyChanged;
	}

	private void NavPropGridRowCtrl_Load(object sender, EventArgs e)
	{
		foreach (Cardinality cardinality in Enum.GetValues(typeof(Cardinality)))
			cmbCardinality.Items.Add(cardinality == Cardinality.None ? string.Empty : cardinality.ToString());

		splMain.Height = picDelete.Height + 4;
		this.Height = splMain.Height;

		Populate();
	}

	#endregion

	#region Methods

	private void Populate()
	{
		_suspendUpdates = true;

		lblName.Text = _navProperty.Name;
		lblCardinality.Text = _navProperty.Cardinality.ToString();
		lblFKEntity.Text = _navProperty.FKEntity.Name;

		_suspendUpdates = false;
	}

	private Cardinality GetCardinality(string cardinality)
	{
		if (string.IsNullOrEmpty(cardinality))
			return Cardinality.None;
		return (Cardinality)Enum.Parse(typeof(Cardinality), cardinality);
	}

	#endregion

	#region Properties

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Col1Width
	{
		get { return splMain.SplitterDistance; }
		set { splMain.SplitterDistance = value; }
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Col2Width
	{
		get { return splCardinality.SplitterDistance; }
		set { splCardinality.SplitterDistance = value; }
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Col3Width
	{
		get { return splRelPropName.SplitterDistance; }
		set { splRelPropName.SplitterDistance = value; }
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public AssocEditForm NavPropEditForm
	{
		get {
			if (_navPropEditForm == null)
				_navPropEditForm = new AssocEditForm();
			return _navPropEditForm;
		}
	}

	#endregion

	#region UI Events

	private void picDelete_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Are you sure you want to delete this property?", "Delete Property", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			return;

		NavigationPropertyChanged?.Invoke(this, new NavPropChangedEventArgs(_navProperty, NavPropChangedAction.Deleted));
	}

	private void picEditNavProp_Click(object sender, EventArgs e)
	{
		NavPropertyEdit?.Invoke(this, new NavPropertyEditEventArgs(_navProperty));
	}

	private void NavPropModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (!_suspendUpdates)
			Populate();
	}

	private void txtName_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_navProperty.Name = txtName.Text;
	}

	private void cmbCardinality_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_navProperty.Cardinality = GetCardinality(cmbCardinality.SelectedItem.ToString());
	}

	private void entityListCtl_ValueChanged(object sender, EntitySelectionChangedEventArgs e)
	{
		if (!_suspendUpdates)
			_navProperty.FKEntity = entityListCtl.SelectedEntity;
	}

	#endregion
}

#region Event Args

public enum NavPropChangedAction
{
	Updated,
	Deleted
}

public class NavPropChangedEventArgs : EventArgs
{
	public NavPropertyModel NavPropertyModel { get; }
	public NavPropChangedAction Action { get; }

	public NavPropChangedEventArgs(NavPropertyModel navPropertyModel, NavPropChangedAction action)
	{
		NavPropertyModel = navPropertyModel;
		Action = action;
	}
}

public class NavPropertyEditEventArgs : EventArgs
{
	public NavPropertyModel NavProperty { get; }

	public NavPropertyEditEventArgs(NavPropertyModel navProperty)
	{
		NavProperty = navProperty;
	}
}

#endregion
