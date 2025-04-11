using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;
public partial class SvcEditCtl : EntityEditCtlBase
{
	#region Constants

	private const string cSvcAddlUsingsLabel = "Additional Service Usings";
	private const string cSvcClassAttrsLabel = "Service Class Attributes";
	private const string cControllerAddlUsingsLabel = "Additional Controller Usings";
	private const string cControllerClassAttrsLabel = "Controller Class Attributes";

	#endregion

	#region Fields

	private ServiceModel _service;
	private List<UserControlBase> _tabControls;

	#endregion

	#region Ctors / Init

	public SvcEditCtl()
	{
	}

	public SvcEditCtl(EntityModel entity) : base(entity)
	{
		InitializeComponent();

		_service = entity.Service;
	}

	private void SvcEditCtl_Load(object sender, EventArgs e)
	{
		_tabControls = new List<UserControlBase> {
			readMethodsEditCtl,
			updMethodsEditCtl
		};

		this.PopulateControls();
		this.PositionControls();

		SelectTab(0);
	}

	private void PopulateControls()
	{
		_suspendUpdates = true;

		ckbEnabled.Checked = _service.Enabled;
		ckbInclCreate.Checked = _service.InclCreate;
		ckbInclUpdate.Checked = _service.InclUpdate;
		ckbInclDelete.Checked = _service.InclDelete;
		ckbInclController.Checked = _service.InclController;
		txtControllerVersion.Text = _service.ControllerVersion;

		SetSvcUsingsLabel();
		SetSvcAttrsLabel();
		SetControllerUsingsLabel();
		SetControllerAttrsLabel();

		readMethodsEditCtl.SetData(_service.ReadMethods, _entity.Properties, _entity.NavProperties);

		_suspendUpdates = false;
	}

	private void PositionControls()
	{
		readMethodsEditCtl.Left = tsTabs.Left;
		readMethodsEditCtl.Top = tsTabs.Top + tsTabs.Height;
		readMethodsEditCtl.Width = this.Width - (2 * tsTabs.Left);
		readMethodsEditCtl.Height = this.Height - (tsTabs.Top + tsTabs.Height);
		updMethodsEditCtl.Visible = true;

		updMethodsEditCtl.Left = readMethodsEditCtl.Left;
		updMethodsEditCtl.Top = readMethodsEditCtl.Top;
		updMethodsEditCtl.Width = readMethodsEditCtl.Width;
		updMethodsEditCtl.Height = readMethodsEditCtl.Height;
		updMethodsEditCtl.Visible = false;
	}

	#endregion

	private void lkbAddlUsings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		this.StrListForm.Run(cSvcAddlUsingsLabel, _service.AddlServiceUsings);
		SetSvcUsingsLabel();
	}

	private void SetSvcUsingsLabel()
	{
		lkbAddlServiceUsings.Text = $"{cSvcAddlUsingsLabel} ({_service.AddlServiceUsings?.Count})";
	}

	private void lkbServiceClassAttributes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		this.StrListForm.Run(cSvcClassAttrsLabel, _service.ServiceClassAttributes);
		SetSvcAttrsLabel();
	}

	private void SetSvcAttrsLabel()
	{
		lkbServiceClassAttributes.Text = $"{cSvcClassAttrsLabel} ({_service.ServiceClassAttributes?.Count})";
	}

	private void lkbAddlControllerUsings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		this.StrListForm.Run(cControllerAddlUsingsLabel, _service.AddlControllerUsings);
		SetControllerUsingsLabel();
	}

	private void SetControllerUsingsLabel()
	{
		lkbAddlControllerUsings.Text = $"{cControllerAddlUsingsLabel} ({_service.AddlControllerUsings?.Count})";
	}

	private void lkbControllerClassAttributes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		this.StrListForm.Run(cControllerClassAttrsLabel, _service.ControllerClassAttributes);
		SetControllerAttrsLabel();
	}

	private void SetControllerAttrsLabel()
	{
		lkbControllerClassAttributes.Text = $"{cControllerClassAttrsLabel} ({_service.ControllerClassAttributes?.Count})";
	}

	private void ckbInclCreate_CheckedChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_service.InclCreate = ckbInclCreate.Checked;
	}

	private void ckbInclDelete_CheckedChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_service.InclDelete = ckbInclDelete.Checked;
	}

	private void ckbInclController_CheckedChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_service.InclController = ckbInclController.Checked;
	}

	private void ckbInclUpdate_CheckedChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_service.InclUpdate = ckbInclUpdate.Checked;
	}

	private void txtControllerVersion_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_service.ControllerVersion = txtControllerVersion.Text;
	}

	private void ckbEnabled_CheckedChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_service.Enabled = ckbEnabled.Checked;
	}

	private void tabReadMethods_Click(object sender, EventArgs e)
	{
		SelectTab(0);
	}

	private void tabUpdateMethods_Click(object sender, EventArgs e)
	{
		SelectTab(1);
	}

	private void SelectTab(int idx)
	{
		this.SuspendLayout();
		try {
			for (var i = 0; i < tsTabs.Items.Count; i++) {
				var selected = (i == idx);
				var btn = tsTabs.Items[i];
				btn.BackColor = selected ? SystemColors.ActiveCaption : Color.Transparent;
				_tabControls[i].Visible = selected;
			}
		} finally {
			this.ResumeLayout();
		}
	}

}
