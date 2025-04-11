using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
	public partial class UpdateMethodsEditCtl : UserControlBase
	{
		#region Constants

		private const int cIdCol = 0;
		private const int cNameCol = 1;
		private const int cUseDtoCol = 2;
		private const int cDelCol = 3;

		#endregion

		#region Fields

		private ObservableCollection<UpdateMethodModel> _updateMethods;

		#endregion

		#region Ctors / Init

		public UpdateMethodsEditCtl()
		{
			InitializeComponent();
		}

		private void ServiceMethodsEditCtl_Load(object sender, EventArgs e)
		{
			grdMethods.AutoGenerateColumns = false;
		}

		public void SetData(ObservableCollection<UpdateMethodModel> updateMethods, ObservableCollection<PropertyModel> properties, ObservableCollection<NavPropertyModel> navProperties)
		{
			_updateMethods = updateMethods;
			grdMethods.RowHeadersWidth = 40;

			bindingSrc.DataSource = _updateMethods;
			grdMethods.DataSource = bindingSrc;

			clbUpdProperties.Items.Clear();
			clbUpdProperties.Items.AddRange(navProperties.ToArray());
		}

		#endregion

		#region Add

		private void btnAdd_Click(object sender, EventArgs e)
		{
			this.Add();
		}

		private void Add()
		{
			var method = UpdateMethodModel.CreateNew(Guid.NewGuid(), "Update");
			bindingSrc.Add(method);
		}

		#endregion

		#region Delete

		private void btnDelete_Click(object sender, EventArgs e)
		{
			this.Delete();
		}

		private void Delete()
		{
			if (grdMethods.SelectedCells.Count == 1) {
				var rowIdx = grdMethods.SelectedCells[0].OwningRow.Index;
				var idValStr = grdMethods.Rows[rowIdx].Cells[cIdCol].Value?.ToString();
				var method = _updateMethods.FirstOrDefault(m => m.Id == Guid.Parse(idValStr));

				if (method != null) {
					bindingSrc.Remove(method);
				}
			}
		}

		#endregion

		#region Methods

		private void SetUpdatePropertiesList(UpdateMethodModel method)
		{
			_suspendUpdates = true;

			if (method == null) {
				for (var i = 0; i < clbUpdProperties.Items.Count; i++)
					clbUpdProperties.SetItemChecked(i, false);
				return;
			}

			for (var i = 0; i < clbUpdProperties.Items.Count; i++) {
				var updProp = clbUpdProperties.Items[i] as UpdatePropertyModel;
				clbUpdProperties.SetItemChecked(i, method.UpdateProperties.Contains(updProp));
			}

			_suspendUpdates = false;
		}

		private void grdItems_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Shift && e.KeyCode == Keys.Insert) {
				this.Add();

			} else if (e.Shift && e.KeyCode == Keys.Delete) {
				this.Delete();
			}
		}

		private UpdateMethodModel GetMethodFromGridRow(int rowIndex)
		{
			var idValStr = grdMethods.Rows[rowIndex].Cells[cIdCol].Value?.ToString();
			return _updateMethods.FirstOrDefault(m => m.Id == Guid.Parse(idValStr));
		}

		#endregion

		#region UI Events

		private void grdMethods_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show($"Error in column {e.ColumnIndex}: {e.Exception.Message}");
		}

		private void grdMethods_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
				return;

			if (e.ColumnIndex == cDelCol) {
				if (MessageBox.Show("Confirm Delete", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
					var method = GetMethodFromGridRow(e.RowIndex);
					bindingSrc.Remove(method);
				}
			}
		}

		private void grdMethods_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == this.grdMethods.Columns[cDelCol].Index && e.RowIndex > -1) {
				this.grdMethods.Cursor = Cursors.Hand;
			}
		}

		private void grdMethods_SelectionChanged(object sender, EventArgs e)
		{
			_suspendUpdates = true;

			if (grdMethods.SelectedCells.Count == 1) {
				var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);
				SetUpdatePropertiesList(method);
				clbUpdProperties.Enabled = true;
			} else {
				SetUpdatePropertiesList(null);
				clbUpdProperties.Enabled = false;
			}

			_suspendUpdates = false;
		}

		private void grdMethods_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			this.grdMethods.Cursor = Cursors.Default;
		}

		private void clbUpdProperties_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (_suspendUpdates == true)
				return;

			if (e.NewValue == CheckState.Indeterminate)
				return;

			var updProp = clbUpdProperties.Items[e.Index] as UpdatePropertyModel;
			if (updProp == null)
				return;

			var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);

			if (e.NewValue == CheckState.Checked) {
				if (!method.UpdateProperties.Contains(updProp))
					method.UpdateProperties.Add(updProp);
			} else {
				if (method.UpdateProperties.Contains(updProp))
					method.UpdateProperties.Remove(updProp);
			}
		}

		#endregion
	}
}
