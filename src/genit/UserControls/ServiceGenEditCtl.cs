using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
	public partial class ServiceGenEditCtl : UserControlBase
	{
		#region Fields

		private ServiceGenModel _serviceGenMdl;

		#endregion

		#region Ctors / Init

		public ServiceGenEditCtl()
		{
			InitializeComponent();
		}

		public ServiceGenEditCtl(ServiceGenModel entityGenMdl) : this()
		{
			_serviceGenMdl = entityGenMdl;
		}

		private void ServiceGenEditCtl_Load(object sender, EventArgs e)
		{
			Populate();
		}

		private void Populate()
		{
			_suspendUpdates = true;

			txtTemplateFilepath.Text = _serviceGenMdl.TemplateFilepath;
			txtOutputFolder.Text = _serviceGenMdl.OutputFolder;
			txtQueryTemplateFilepath.Text = _serviceGenMdl.QueryTemplateFilepath;
			txtQueryOutputFolder.Text = _serviceGenMdl.QueryOutputFolder;
			txtControllerTemplateFile.Text = _serviceGenMdl.ControllerTemplateFilepath;
			txtControllerOutputFolder.Text = _serviceGenMdl.ControllerOutputFolder;
			txtApiClientOutputFolder.Text = _serviceGenMdl.ApiClientOutputFolder;
			txtApiClientTemplateFile.Text = _serviceGenMdl.ApiClientTemplateFilepath;
			txtApiClientServicesExtOutputFile.Text = _serviceGenMdl.ApiClientServicesExtOutputFilepath;
			txtApiClientServicesExtTemplateFile.Text = _serviceGenMdl.ApiClientServicesExtTemplateFilepath;
			txtServicesNamespace.Text = _serviceGenMdl.ServicesNamespace;
			txtQueriesNamespace.Text = _serviceGenMdl.QueriesNamespace;
			txtControllersNamespace.Text = _serviceGenMdl.ControllersNamespace;
			txtApiClientsNamespace.Text = _serviceGenMdl.ApiClientsNamespace;
			ckbInclHeader.Checked = _serviceGenMdl.InclHeader;
			ckbEnabled.Checked = _serviceGenMdl.Enabled;

			_suspendUpdates = false;
		}

		#endregion

		private void txtOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.OutputFolder = txtOutputFolder.Text;
		}

		private void txtTemplateFilepath_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.TemplateFilepath = txtTemplateFilepath.Text;
		}

		private void txtQueryTemplateFilepath_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.QueryTemplateFilepath = txtQueryTemplateFilepath.Text;
		}

		private void txtQueryOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.QueryOutputFolder = txtQueryOutputFolder.Text;
		}

		private void txtControllerTemplateFile_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ControllerTemplateFilepath = txtControllerTemplateFile.Text;
		}

		private void txtControllerOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ControllerOutputFolder = txtControllerOutputFolder.Text;
		}

		private void txtApiClientTemplateFile_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ApiClientTemplateFilepath = txtApiClientTemplateFile.Text;
		}

		private void txtApiClientOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ApiClientOutputFolder = txtApiClientOutputFolder.Text;
		}

		private void txtApiClientServicesExtTemplateFile_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ApiClientServicesExtTemplateFilepath = txtApiClientServicesExtTemplateFile.Text;
		}

		private void txtApiClientServicesExtOutputFile_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ApiClientServicesExtOutputFilepath = txtApiClientServicesExtOutputFile.Text;
		}

		private void txtServicesNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ServicesNamespace = txtServicesNamespace.Text;
		}

		private void txtQueriesNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.QueriesNamespace = txtQueriesNamespace.Text;
		}

		private void txtControllersNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ControllersNamespace = txtControllersNamespace.Text;
		}

		private void txtApiClientsNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ApiClientsNamespace = txtApiClientsNamespace.Text;
		}

		private void btnBrowseTemplateFilepath_Click(object sender, EventArgs e)
		{
			fileDlg.InitialDirectory = txtTemplateFilepath.Text;
			if (fileDlg.ShowDialog() == DialogResult.OK)
				txtTemplateFilepath.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, fileDlg.FileName);
		}

		private void btnBrowseFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void btnBrowseQueryTemplFilepath_Click(object sender, EventArgs e)
		{
			fileDlg.InitialDirectory = txtQueryTemplateFilepath.Text;
			if (fileDlg.ShowDialog() == DialogResult.OK)
				txtQueryTemplateFilepath.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, fileDlg.FileName);
		}

		private void btnBrowseQueryOutFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtQueryOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtQueryOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void btnBrowseCntlrTemplFilepath_Click(object sender, EventArgs e)
		{
			fileDlg.InitialDirectory = txtControllerTemplateFile.Text;
			if (fileDlg.ShowDialog() == DialogResult.OK)
				txtControllerTemplateFile.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, fileDlg.FileName);
		}

		private void btnBrowseCntlrOutFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtControllerOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtControllerOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void btnBrowseApiClientTemplFilepath_Click(object sender, EventArgs e)
		{
			fileDlg.InitialDirectory = txtApiClientTemplateFile.Text;
			if (fileDlg.ShowDialog() == DialogResult.OK)
				txtApiClientTemplateFile.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, fileDlg.FileName);
		}

		private void btnBrowseApiClientOutFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtApiClientOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtApiClientOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void btnBrowseApiClientServicesExtTemplateFile_Click(object sender, EventArgs e)
		{
			fileDlg.InitialDirectory = txtApiClientServicesExtTemplateFile.Text;
			if (fileDlg.ShowDialog() == DialogResult.OK)
				txtApiClientServicesExtTemplateFile.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, fileDlg.FileName);
		}

		private void btnBrowseApiClientServicesExtOutputFile_Click(object sender, EventArgs e)
		{
			fileDlg.InitialDirectory = txtApiClientServicesExtOutputFile.Text;
			if (fileDlg.ShowDialog() == DialogResult.OK)
				txtApiClientServicesExtOutputFile.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, fileDlg.FileName);
		}

		private void ckbEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.Enabled = ckbEnabled.Checked;
		}

		private void ckbInclHeader_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.InclHeader = ckbInclHeader.Checked;
		}

	}
}
