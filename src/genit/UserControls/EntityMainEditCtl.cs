using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dyvenix.Genit.UserControls;

public partial class EntityMainEditCtl : EntityEditCtlBase
{
	private bool _suspendUpdates;

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

		_suspendUpdates = false;
	}

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
}
