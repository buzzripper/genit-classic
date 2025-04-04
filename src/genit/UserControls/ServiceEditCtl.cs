using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class ServiceEditCtl : EntityEditCtlBase
{
	#region Constants

	private const string cSvcAddlUsingsLabel = "Additional Service Usings";
	private const string cSvcClassAttrsLabel = "Service Class Attributes";
	private const string cControllerAddlUsingsLabel = "Additional Controller Usings";
	private const string cControllerClassAttrsLabel = "Controller Class Attributes";

	#endregion

	#region Fields

	private ServiceModel _service;

	#endregion

	#region Ctors / Init

	public ServiceEditCtl()
	{
		InitializeComponent();
	}

	public ServiceEditCtl(EntityModel entity) : base(entity)
	{
		InitializeComponent();

		_service = entity.Service;
		entity.Properties.CollectionChanged += Properties_OnCollectionChanged;
	}

	private void ServiceEditCtl_Load(object sender, EventArgs e)
	{
		this.PopulateControls();
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

		svcMethodsEditCtl.SetData(_service.Methods, _entity.Properties, _entity.NavProperties);

		_suspendUpdates = false;
	}

	#endregion

	private void Properties_OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{

	}

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

	private void ckbInclSave_CheckedChanged(object sender, EventArgs e)
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
}
