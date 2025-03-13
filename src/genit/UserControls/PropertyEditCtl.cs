using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class PropertyEditCtl : EntityEditCtlBase
{
	public PropertyEditCtl()
	{
		InitializeComponent();
	}

	private void PropertyEditCtl_Load(object sender, EventArgs e)
	{
		propEditCtl.Visible = false;
		propEditCtl.Dock = DockStyle.Fill;
		navPropEditCtl.Visible = false;
		navPropEditCtl.Dock = DockStyle.Fill;
	}

	public override void Initialize(EntityModel entity)
	{
		base.Initialize(entity);

		lbxProps.DataSource = _entity.Properties;
	}

	private void btnAddProp_Click(object sender, EventArgs e)
	{

	}

	private void btnDeleteProp_Click(object sender, EventArgs e)
	{

	}

	private void lbxProps_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.SuspendLayout();

		var prop = lbxProps.SelectedItem as Models.PropertyModel;
		if (prop != null) {
			propEditCtl.Initialize(prop);
			propEditCtl.Visible = true;
		} else {
			propEditCtl.Visible = false;
		}
		btnDeleteProp.Enabled = (lbxProps.SelectedIndex >= 0);

		this.ResumeLayout();
	}
}
