using Dyvenix.Genit.Models;
using Dyvenix.Genit.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dyvenix.Genit
{
	public partial class StringListForm : Form
	{
		public StringListForm()
		{
			InitializeComponent();
		}

		private void StringListForm_Load(object sender, EventArgs e)
		{
			slEditor.Top = 0;
			slEditor.Left = 0;
			slEditor.Width = this.ClientSize.Width;
		}

		public DialogResult Run(string title, ObservableCollection<string> items)
		{
			this.Text = title;
			slEditor.Items = items;

			return this.ShowDialog();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
