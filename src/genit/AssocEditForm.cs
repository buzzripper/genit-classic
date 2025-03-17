using Dyvenix.Genit.Models;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit
{
	public partial class AssocEditForm : Form
	{
		#region Fields

		private EntityModel _priEntity;
		private AssocModel _assoc;

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
		public string RelatedPropertyName => txtFKPropName.Text;

		#endregion

		public DialogResult Run(AssocModel assoc)
		{
			if (assoc.PrimaryEntity == null)
				throw new ArgumentException("Primary entity is required.");

			txtName.Text = assoc.NavProperty?.Name;
			cmbCardinality.SelectedItem = assoc.Cardinality;

			entityListCtl.SelectedEntity = assoc.FKEntity;
			txtFKPropName.Text = assoc?.FKProperty?.Name;

			_priEntity = assoc.PrimaryEntity;
			_assoc = assoc;

			return this.ShowDialog();
		}

		#region UI Events

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!ValidateEntries())
				return;

			//See if the FK entity has changed
			if (_assoc.FKEntity != entityListCtl.SelectedEntity) {
				// Remove the old fk property
				if (_assoc?.FKProperty != null)
					_assoc.FKEntity.Properties.Remove(_assoc.FKProperty);
				// Add the new
				_assoc.FKEntity = entityListCtl.SelectedEntity;
				_assoc.FKProperty = _assoc.FKEntity.AddForeignKey(txtFKPropName.Text, _assoc.PrimaryEntity);

			} else {
				_assoc.FKProperty.Name = txtFKPropName.Text;
			}

			_assoc.NavProperty.Name = txtName.Text;
			_assoc.Cardinality = (Cardinality)cmbCardinality.SelectedItem;

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
