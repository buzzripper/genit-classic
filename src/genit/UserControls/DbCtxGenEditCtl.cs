using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
	public partial class DbCtxGenEditCtl : UserControlBase
	{
		#region Fields

		private DbContextGenModel _dbCtxGenMdl;

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

			txtOutputFolder.Text = _dbCtxGenMdl.OutputFolder;
			txtContextNamespace.Text = _dbCtxGenMdl.ContextNamespace;
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

		private void txtContextNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_dbCtxGenMdl.ContextNamespace = txtContextNamespace.Text;
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

		private void btnBrowseFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK) {
				txtOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
			}
		}
	}
}
