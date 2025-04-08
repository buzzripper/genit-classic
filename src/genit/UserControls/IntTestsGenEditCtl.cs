using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
	public partial class IntTestsGenEditCtl : UserControlBase
	{
		#region Fields

		private IntTestsGenModel _intTestsGenMdl;

		#endregion

		#region Ctors / Init

		public IntTestsGenEditCtl()
		{
			InitializeComponent();
		}

		public IntTestsGenEditCtl(IntTestsGenModel entityGenMdl) : this()
		{
			_intTestsGenMdl = entityGenMdl;
		}

		private void ServiceGenEditCtl_Load(object sender, EventArgs e)
		{
			Populate();
		}

		private void Populate()
		{
			_suspendUpdates = true;

			ckbInclHeader.Checked = _intTestsGenMdl.InclHeader;
			ckbEnabled.Checked = _intTestsGenMdl.Enabled;

			txtIntTestsOutputFolder.Text = _intTestsGenMdl.OutputFolder;
			txtIntTestsNamespace.Text = _intTestsGenMdl.Namespace;

			_suspendUpdates = false;
		}

		#endregion

		private void txtIntTestsOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_intTestsGenMdl.OutputFolder = txtIntTestsOutputFolder.Text;
		}

		private void txtIntTestsNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_intTestsGenMdl.Namespace = txtIntTestsNamespace.Text;
		}

		private void btnBrowseIntTestsOutFolder_Click(object sender, EventArgs e)
		{
			folderDlg.InitialDirectory = txtIntTestsOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtIntTestsOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}

		private void ckbEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_intTestsGenMdl.Enabled = ckbEnabled.Checked;
		}

		private void ckbInclHeader_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_intTestsGenMdl.InclHeader = ckbInclHeader.Checked;
		}
	}
}
