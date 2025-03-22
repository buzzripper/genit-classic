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

				// Convert to relative path if possible
				if (!string.IsNullOrWhiteSpace(Globals.CurrDocFilepath)) {

					// Make sure they're on the same drive
					if (Directory.GetDirectoryRoot(Globals.CurrDocFilepath) == Directory.GetDirectoryRoot(folderDlg.SelectedPath)) {
						Uri docUri = new Uri(Globals.CurrDocFilepath);
						Uri fileUri = new Uri(folderDlg.SelectedPath);
						txtOutputFolder.Text = Uri.UnescapeDataString(docUri.MakeRelativeUri(fileUri).ToString()).Replace('/', '\\');

						// Check
						//var docFolder = Path.GetDirectoryName(Globals.CurrDocFilepath);
						//var newFolder = Path.Combine(docFolder, txtOutputFolder.Text);
						//var test = Path.GetFullPath(newFolder);
					}
				} else {
					txtOutputFolder.Text = folderDlg.SelectedPath;
				}
			}
		}
	}
}
