using Dyvenix.Genit.Models;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit
{
	public partial class AssocEditForm : Form
	{
		#region Fields

		#endregion

		#region Ctors / Init

		public AssocEditForm()
		{
			InitializeComponent();
			cmbCardinality.DataSource = Enum.GetValues(typeof(Cardinality));
		}

		private void AssocEditForm_Shown(object sender, EventArgs e)
		{
		}

		private void AssocEditForm_Load(object sender, EventArgs e)
		{
		}

		#endregion

		#region Properties

		public string NavPropertyName => txtName.Text;
		public EntityModel FKEntity => entityListCtl.SelectedEntity as EntityModel;
		public Cardinality Cardinality => (Cardinality)cmbCardinality.SelectedItem;
		//public string FKPropertyName => txtFKPropName.Text;

		#endregion

		public DialogResult New()
		{
			txtName.Text = string.Empty;
			cmbCardinality.SelectedItem = Cardinality.None;
			entityListCtl.SelectedEntity = null;
			//txtFKPropName.Text = string.Empty;

			return this.ShowDialog();
		}

		public DialogResult Edit(string navPropName, Cardinality cardinality, EntityModel entity)
		{
			txtName.Text = navPropName;
			cmbCardinality.SelectedItem = cardinality;
			entityListCtl.SelectedEntity = entity;

			return this.ShowDialog();
		}

		#region UI Events

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!ValidateEntries())
				return;

			this.DialogResult = DialogResult.OK;
		}

		private bool ValidateEntries()
		{
			if (string.IsNullOrWhiteSpace(txtName.Text)) {
				MessageBox.Show("Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (cmbCardinality.SelectedIndex == 0) {
				MessageBox.Show("Cardinality is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (entityListCtl.SelectedEntity == null) {
				MessageBox.Show("Please select a related entity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion
	}
}
