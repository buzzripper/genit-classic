using System;
using System.Windows.Forms;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls
{
	public partial class EnumGenEditCtrl : UserControlBase
	{
		#region Fields

		private DbContextGenModel _entityGenMdl;
		private bool _suspendUpdates;

		#endregion

		#region Ctors / Init

		public EnumGenEditCtrl()
		{
			InitializeComponent();
		}

		public EnumGenEditCtrl(DbContextGenModel dbCtxGenMdl) : this()
		{
			InitializeComponent();
			_entityGenMdl = dbCtxGenMdl;
		}

		private void DbCtxGenEditCtrl_Load(object sender, EventArgs e)
		{
			Populate();
		}

		private void Populate()
		{
			_suspendUpdates = true;

			txtOutputFolder.Text = _entityGenMdl.OutputFolder;
			ckbInclHeader.Checked = _entityGenMdl.InclHeader;

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
	}
}
