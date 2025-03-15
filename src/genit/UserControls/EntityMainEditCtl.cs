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

	private void lkbAddNewNavProp_Click(object sender, EventArgs e)
	{
		//if (this.AssocEditForm.Run(null) == DialogResult.OK) {
		//	var assocMdl = new AssocModel(Guid.NewGuid(), _entity, this.AssocEditForm.PrimaryPropertyName, this.AssocEditForm.RelatedEntity, this.AssocEditForm.RelatedPropertyName,  this.AssocEditForm.Cardinality);
		//	_entity.NavAssocs.Add(assocMdl);
		//}
	}

	#endregion

	private void lkbAddNewNavProp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		_entity.NavProperties.Add(new NavPropertyModel(Guid.NewGuid(), _entity));
	}
}
