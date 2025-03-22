using System;
using System.IO;
using System.Windows.Forms;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls
{
	public partial class DbCtxGenEditCtl : UserControlBase
	{
		#region Fields

		private DbContextGenModel _dbCtxGenMdl;
		private bool _suspendUpdates;

		#endregion

		#region Ctors / Init

		public DbCtxGenEditCtl()
		{
			InitializeComponent();
		}

		public DbCtxGenEditCtl(DbContextGenModel dbCtxGenMdl) : this()
		{
			_dbCtxGenMdl = dbCtxGenMdl;
		}

		private void DbCtxGenEditCtl_Load(object sender, EventArgs e)
		{
			Populate();
		}

		private void Populate()
		{
			_suspendUpdates = true;

			txtTemplateFilepath.Text = _dbCtxGenMdl.TemplateFilepath;
			txtOutputFolder.Text = _dbCtxGenMdl.OutputFolder;
			ckbInclHeader.Checked = _dbCtxGenMdl.InclHeader;
			ckbEnabled.Checked = _dbCtxGenMdl.Enabled;

			_suspendUpdates = false;
		}

		#endregion

		private void txtOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_dbCtxGenMdl.OutputFolder = txtOutputFolder.Text;
		}

		private void txtTemplateFilepath_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_dbCtxGenMdl.TemplateFilepath = txtTemplateFilepath.Text;
		}

		private void ckbInclHeader_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_dbCtxGenMdl.InclHeader = ckbInclHeader.Checked;
		}

		private void ckbEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_dbCtxGenMdl.Enabled = ckbEnabled.Checked;
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
			if (folderDlg.ShowDialog() == DialogResult.OK) {
				txtOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
			}
		}
	}
}
