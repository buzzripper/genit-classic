using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
	public partial class EntityGenEditCtl : UserControlBase
	{
		#region Fields

		private EntityGenModel _entityGenMdl;

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
			txtEntitiesNamespace.Text = _entityGenMdl.EntitiesNamespace;
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

		private void txtEntitiesNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_entityGenMdl.EntitiesNamespace = txtEntitiesNamespace.Text;
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
			folderDlg.InitialDirectory = txtOutputFolder.Text;
			if (folderDlg.ShowDialog() == DialogResult.OK)
				txtOutputFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
		}
	}
}
