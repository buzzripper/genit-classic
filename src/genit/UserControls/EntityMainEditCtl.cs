using Dyvenix.Genit.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class EntityMainEditCtl : EntityEditCtlBase
{
	#region Fields

	private bool _suspendUpdates;
	private AssocEditForm _navPropEditForm;

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

		sleAttrs.Items = _entity.Attributes;
		sleUsings.Items = _entity.AddlUsings;
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

		if (NavPropEditForm.Run(assoc) == DialogResult.Cancel)
			return;

		_entity.NavProperties.Add(new NavPropertyModel(Guid.NewGuid()));
	}

	#endregion
}
