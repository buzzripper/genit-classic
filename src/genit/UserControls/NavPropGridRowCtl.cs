using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.XPath;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class NavPropGridRowCtl : UserControl
{
	public event EventHandler<NavPropChangedEventArgs> NavigationPropertyChanged;

	#region Fields

	private readonly NavPropertyModel _navPropertyModel;
	private bool _suspendUpdates;

	#endregion

	#region Ctors / Init

	public NavPropGridRowCtl()
	{
		InitializeComponent();
	}

	public NavPropGridRowCtl(NavPropertyModel navPropMdl) : this()
	{
		_navPropertyModel = navPropMdl;
		_navPropertyModel.PropertyChanged += NavPropModel_PropertyChanged;
	}

	private void NavPropGridRowCtrl_Load(object sender, EventArgs e)
	{
		cmbCardinality.DataSource = Enum.GetValues(typeof(CardinalityModel));
		splMain.Height = picDelete.Height + 4;
		this.Height = splMain.Height;

		Populate();
	}

	#endregion

	#region Methods

	private void Populate()
	{
		txtName.Text = _navPropertyModel.Name;
		cmbCardinality.SelectedItem = _navPropertyModel.Datatype;
		entityListCtl.SelectedItem = _navPropertyModel.Datatype;
		//lblRelatedPropertyName.Text = _navPropertyModel.RelatedPropertyName;
		//lblCardinality.Text = _navPropertyModel.Cardinality.ToString();
	}

	#endregion

	private void NavPropModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (_suspendUpdates)
			return;
	}

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

	#endregion

	#region UI Events

	private void picDelete_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Are you sure you want to delete this property?", "Delete Property", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			return;

		NavigationPropertyChanged?.Invoke(this, new NavPropChangedEventArgs(_navPropertyModel, NavPropChangedAction.Deleted));
	}

	#endregion

	private void txtName_TextChanged(object sender, EventArgs e)
	{
		_navPropertyModel.Name = txtName.Text;
	}

	private void cmbCardinality_SelectedIndexChanged(object sender, EventArgs e)
	{
		_navPropertyModel.Cardinality = (CardinalityModel)cmbCardinality.SelectedItem;
	}

	private void entityListCtl_ValueChanged(object sender, EntitySelectionChangedEventArgs e)
	{
		_navPropertyModel.Datatype = entityListCtl.SelectedItem;
	}
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

#endregion
