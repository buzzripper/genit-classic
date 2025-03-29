using Dyvenix.Genit.Models;
using System;
using System.ComponentModel;

namespace Dyvenix.Genit.UserControls
{
	public partial class EnumEditCtl : UserControlBase
	{
		#region Fields

		#endregion

		#region Ctors / Init

		public EnumEditCtl()
		{
			InitializeComponent();
		}

		public EnumEditCtl(EnumModel enumMdl) : this()
		{
			EnumModel = enumMdl;
			Populate();
		}

		private void Populate()
		{
			_suspendUpdates = true;

			lblName.Text = EnumModel.Name;
			txtName.Text = EnumModel.Name;
			slMembers.Items = EnumModel.Members;
			txtNamespace.Text = EnumModel.Namespace;
			ckbIsExternal.Checked = EnumModel.IsExternal;
			ckbIsFlags.Checked = EnumModel.IsFlags;
			ckbEnabled.Checked = EnumModel.Enabled;

			EnumModel.PropertyChanged += EnumMdl_OnPropertyChanged;
			_suspendUpdates = false;
		}

		#endregion

		#region Properties

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public EnumModel EnumModel { get; private set; }

		#endregion

		private void EnumMdl_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{

		}

		private void txtName_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				EnumModel.Name = txtName.Text;
		}

		private void txtNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				EnumModel.Namespace = txtNamespace.Text;
		}

		private void ckbIsFlags_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				EnumModel.IsFlags = ckbIsFlags.Checked;
		}

		private void ckbIsExternal_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				EnumModel.IsExternal = ckbIsExternal.Checked;
		}

		private void ckbEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				EnumModel.Enabled = ckbEnabled.Checked;
		}
	}
}
