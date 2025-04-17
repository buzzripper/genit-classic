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

			txtOutputFolder.Text = _serviceGenMdl.OutputFolder;
			txtQueryOutputFolder.Text = _serviceGenMdl.QueryOutputFolder;
			txtControllerOutputFolder.Text = _serviceGenMdl.ControllerOutputFolder;
			txtApiClientOutputFolder.Text = _serviceGenMdl.ApiClientOutputFolder;
			txtApiClientExtOutputFile.Text = _serviceGenMdl.ApiClientExtOutputFilepath;
			txtServicesNamespace.Text = _serviceGenMdl.ServicesNamespace;
			txtQueriesNamespace.Text = _serviceGenMdl.QueriesNamespace;
			txtControllersNamespace.Text = _serviceGenMdl.ControllersNamespace;
			txtApiClientsNamespace.Text = _serviceGenMdl.ApiClientsNamespace;
			txtDtoNamespace.Text = _serviceGenMdl.DtoNamespace;
			txtDtoOutputFolder.Text = _serviceGenMdl.DtoOutputFolder;

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

		private void txtQueryOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.QueryOutputFolder = txtQueryOutputFolder.Text;
		}

		private void txtControllerOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ControllerOutputFolder = txtControllerOutputFolder.Text;
		}

		private void txtApiClientOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ApiClientOutputFolder = txtApiClientOutputFolder.Text;
		}

		private void txtApiClientServicesExtOutputFile_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ApiClientExtOutputFilepath = txtApiClientExtOutputFile.Text;
		}

		private void txtServicesNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ServicesNamespace = txtServicesNamespace.Text;
		}

		private void txtServiceExtOutputFile_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.ServicesExtOutputFilepath = txtServiceExtOutputFile.Text;
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

		private void txtDtoOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.DtoOutputFolder = txtDtoOutputFolder.Text;
		}

		private void txtDtoNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_serviceGenMdl.DtoNamespace = txtDtoNamespace.Text;
		}

		private void btnBrowseFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void btnBrowseQueryOutFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtQueryOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtQueryOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void btnBrowseCntlrOutFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtControllerOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtControllerOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void btnBrowseApiClientOutFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtApiClientOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtApiClientOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void btnBrowseApiClientServicesExtOutputFile_Click(object sender, EventArgs e)
		{
			fileDlg.InitialDirectory = txtApiClientExtOutputFile.Text;
			if (fileDlg.ShowDialog() == DialogResult.OK)
				txtApiClientExtOutputFile.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, fileDlg.FileName);
		}

		private void btnBrowseServiceExtOutputFile_Click(object sender, EventArgs e)
		{
			fileDlg.InitialDirectory = txtServiceExtOutputFile.Text;
			if (fileDlg.ShowDialog() == DialogResult.OK)
				txtServiceExtOutputFile.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, fileDlg.FileName);
		}

		private void btnBrowseDtoOutputFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtDtoOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtDtoOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
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
