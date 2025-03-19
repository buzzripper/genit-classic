using System;
using System.Windows.Forms;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls
{
	public partial class EntityGenEditCtl : UserControlBase
	{
		#region Fields

		private EntityGenModel _entityGenMdl;
		private bool _suspendUpdates;

		#endregion

		#region Ctors / Init

		public EntityGenEditCtl()
		{
			InitializeComponent();
		}

		public EntityGenEditCtl(EntityGenModel entityGenMdl) : this()
		{
			_entityGenMdl = entityGenMdl;
		}

		private void EntityGenEditCtl_Load(object sender, EventArgs e)
		{
			Populate();
		}

		private void Populate()
		{
			_suspendUpdates = true;

			txtOutputFolder.Text = _entityGenMdl.OutputFolder;
			ckbInclHeader.Checked = _entityGenMdl.InclHeader;
			ckbEnabled.Checked = _entityGenMdl.Enabled;

			_suspendUpdates = false;
		}

		#endregion

		private void txtOutputFolder_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_entityGenMdl.OutputFolder = txtOutputFolder.Text;
		}

		private void ckbEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_entityGenMdl.Enabled = ckbEnabled.Checked;
		}

		private void ckbInclHeader_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_entityGenMdl.InclHeader = ckbInclHeader.Checked;

		}

		private void btnBrowseFolder_Click(object sender, EventArgs e)
		{
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtOutputFolder.Text = folderDlg.SelectedPath;	
		}
	}
}
