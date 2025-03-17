using Dyvenix.Genit.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class EntityMainEditCtl : EntityEditCtlBase
{
	private const string cAddUsingsLabel = "Additional Usings";
	private const string cClassAttrsLabel = "Class Attributes";

	#region Fields

	private bool _suspendUpdates;
	private AssocEditForm _navPropEditForm;
	private StringListForm _slForm;

	#endregion

	#region Ctors / Init

	public EntityMainEditCtl() : base()
	{
		InitializeComponent();
	}

	public EntityMainEditCtl(EntityModel entity) : base(entity)
	{
		InitializeComponent();
	}

	private void EntityMainEditCtl_Load(object sender, EventArgs e)
	{
		this.PopulateControls();
	}

	private void PopulateControls()
	{
		_suspendUpdates = true;

		txtName.Text = _entity.Name;
		txtSchema.Text = _entity.Schema;
		txtTableName.Text = _entity.TableName;
		txtNamespace.Text = _entity.Namespace;
		ckbEnabled.Checked = _entity.Enabled;

		SetUsingsLabel();
		SetAttrsLabel();

		propGridCtl.DataSource = _entity.Properties;
		navPropGridCtl.DataSource = _entity.NavProperties;

		_suspendUpdates = false;
	}

	#endregion

	#region Properties

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public AssocEditForm NavPropEditForm
	{
		get {
			if (_navPropEditForm == null)
				_navPropEditForm = new AssocEditForm();
			return _navPropEditForm;
		}
	}

	private StringListForm StrListForm
	{
		get {
			if (_slForm == null)
				_slForm = new StringListForm();
			return _slForm;
		}
	}

	#endregion

	#region Methods

	private void SetUsingsLabel()
	{
		lkbAddlUsings.Text = $"{cAddUsingsLabel} ({_entity.AddlUsings?.Count})";
	}

	private void SetAttrsLabel()
	{
		lkbClassAttributes.Text = $"{cClassAttrsLabel} ({_entity.Attributes?.Count})";
	}

	#endregion

	#region UI Events

	private void txtName_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.Name = txtName.Text;
	}

	private void txtNamespace_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.Namespace = txtNamespace.Text;
	}

	private void txtSchema_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.Schema = txtSchema.Text;
	}

	private void txtTableName_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.TableName = txtTableName.Text;
	}

	private void ckbEnabled_CheckedChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.Enabled = ckbEnabled.Checked;
	}

	private void lkbAddNewProp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		_entity.Properties.Add(new PropertyModel(Guid.NewGuid()));
	}

	private void lkbAddNewNavProp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		var assoc = new AssocModel();
		assoc.Id = Guid.NewGuid();
		assoc.PrimaryEntity = _entity;

		var navProperty = new NavPropertyModel(Guid.NewGuid(), assoc);
		navProperty.Name = NavPropEditForm.NavPropertyName;
		assoc.NavProperty = navProperty;

		if (NavPropEditForm.Run(assoc) == DialogResult.Cancel)
			return;

		_entity.NavProperties.Add(navProperty);
	}

	private void lkbAddlUsings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		this.StrListForm.Run("Additional Usings", _entity.AddlUsings);
		SetUsingsLabel();
	}

	private void lkbClassAttributes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		this.StrListForm.Run("Additional Usings", _entity.Attributes);
		SetAttrsLabel();
	}

	#endregion
}

