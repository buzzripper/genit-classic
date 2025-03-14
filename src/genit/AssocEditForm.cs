using Dyvenix.Genit.Models;
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

		#endregion

		#region Ctors / Init

		public AssocEditForm()
		{
			InitializeComponent();
		}

		private void AssocEditForm_Load(object sender, EventArgs e)
		{
			cmbCardinality.DataSource = Enum.GetValues(typeof(CardinalityModel));
		}

		#endregion

		#region Properties

		public string PrimaryPropertyName => txtPriPropertyName.Text;
		public EntityModel RelatedEntity => entityListCtl.SelectedItem as EntityModel;
		public CardinalityModel Cardinality => (CardinalityModel)cmbCardinality.SelectedItem;
		public string RelatedPropertyName => txtRelPropName.Text;

		#endregion

		public DialogResult Run(ObservableCollection<EntityModel> allEntities)
		{
			entityListCtl.DataSource = allEntities;

			return this.ShowDialog();
		}

		#region UI Events

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion
	}
}
