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

namespace Dyvenix.Genit
{
	public partial class AssocEditForm : Form
	{
		#region Fields

		private AssocModel _assoc;

		#endregion

		#region Ctors / Init

		public AssocEditForm()
		{
			InitializeComponent();
		}

		private void AssocEditForm_Load(object sender, EventArgs e)
		{
			cmbCardinality.DataSource = Enum.GetValues(typeof(Cardinality));
		}

		#endregion

		#region Properties

		public string NavPropertyName => txtName.Text;
		public EntityModel FKEntity => entityListCtl.SelectedEntity as EntityModel;
		public Cardinality Cardinality => (Cardinality)cmbCardinality.SelectedItem;
		public string RelatedPropertyName => txtRelPropName.Text;

		#endregion

		public DialogResult Run(AssocModel assoc)
		{
			txtName.Text = assoc.NavProperty?.Name;
			cmbCardinality.SelectedItem = assoc.Cardinality;

			entityListCtl.SelectedEntity = assoc.FKEntity;
			txtRelPropName.Text = assoc?.FKProperty?.Name;

			_assoc = assoc;

			return this.ShowDialog();
		}

		#region UI Events

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!Validate())
				return;

			// See the rel entity has changed
			if (_assoc.FKEntity != entityListCtl.SelectedEntity) {
				// Remove the old fk property
				if (_assoc?.FKProperty != null)
					_assoc.FKEntity.Properties.Remove(_assoc.FKProperty);
				// Add the new
				_assoc.FKEntity = entityListCtl.SelectedEntity;
				_assoc.FKProperty = _assoc.FKEntity.AddForeignKey(txtRelPropName.Text, _assoc.PrimaryEntity);
			}

			this.DialogResult = DialogResult.OK;
		}

		private bool Validate()
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
