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

	private readonly AssocModel _assocModel;

	#endregion

	#region Ctors / Init

	public NavPropGridRowCtl()
	{
		InitializeComponent();
	}

	public NavPropGridRowCtl(AssocModel assocMdl) : this()
	{
		_assocModel = assocMdl;
	}

	private void NavPropGridRowCtrl_Load(object sender, EventArgs e)
	{
		splMain.Height = picDelete.Height + 4;
		this.Height = splMain.Height;

		Populate();
	}

	#endregion

	#region Methods

	private void Populate()
	{
		lblPrimaryPropertyName.Text = _assocModel.PrimaryPropertyName;
		lblRelatedPropertyName.Text = _assocModel.RelatedPropertyName;
		lblCardinality.Text = _assocModel.Cardinality.ToString();
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

	#endregion

	#region UI Events

	private void picDelete_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Are you sure you want to delete this property?", "Delete Property", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			return;

		NavigationPropertyChanged?.Invoke(this, new NavPropChangedEventArgs(_assocModel, NavPropChangedAction.Deleted));
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
	public AssocModel Assoc { get; }
	public NavPropChangedAction Action { get; }

	public NavPropChangedEventArgs(AssocModel assocModel, NavPropChangedAction action)
	{
		Assoc = assocModel;
		Action = action;
	}
}

#endregion
