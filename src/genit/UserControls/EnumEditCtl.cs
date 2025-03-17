using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls
{
	public partial class EnumEditCtl : UserControlBase
	{
		private readonly EnumModel _enumMdl;
		private bool _suspendUpdates;

		public EnumEditCtl()
		{
			InitializeComponent();
		}

		public EnumEditCtl(EnumModel enumMdl) : this()
		{
			_enumMdl = enumMdl;
			Populate();
		}

		private void Populate()
		{
			_suspendUpdates = true;

			lblName.Text = _enumMdl.Name;
			txtName.Text = _enumMdl.Name;
			slMembers.Items = _enumMdl.Members;
			txtNamespace.Text = _enumMdl.Namespace;
			ckbIsExternal.Checked = _enumMdl.IsExternal;
			ckbIsFlags.Checked = _enumMdl.IsFlags;

			_enumMdl.PropertyChanged += EnumMdl_OnPropertyChanged;
			_suspendUpdates = false;
		}

		private void EnumMdl_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			
		}

		private void txtName_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_enumMdl.Name = txtName.Text;
		}

		private void txtNamespace_TextChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_enumMdl.Namespace = txtNamespace.Text;
		}

		private void ckbIsFlags_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_enumMdl.IsFlags= ckbIsFlags.Checked;
		}

		private void ckbIsExternal_CheckedChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
				_enumMdl.IsExternal = ckbIsExternal.Checked;
		}
	}
}
