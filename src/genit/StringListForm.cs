using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

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
