using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class QueryMethodsListCtl : UserControlBase
{
	#region Constants

	private const int cIdCol = 0;
	private const int cNameCol = 1;
	private const int cInclSortingCol = 2;
	private const int cInclPagingCol = 3;
	private const int cAttrsCol = 4;
	private const int cDelCol = 5;

	#endregion

	#region Fields

	private ObservableCollection<ServiceMethodModel> _methods;

	#endregion

	#region Ctors / Init

	public QueryMethodsListCtl()
	{
		InitializeComponent();
	}

	private void GetMethodsListCtl_Load(object sender, EventArgs e)
	{
		grdQueries.AutoGenerateColumns = false;
	}

	public void SetData(ObservableCollection<ServiceMethodModel> methods, ObservableCollection<PropertyModel> properties)
	{
		_methods = methods;
		bindingSrc.DataSource = _methods;
		grdQueries.DataSource = bindingSrc;

		for (var i = 0; i < grdQueries.Rows.Count; i++) {
			var method = QueryMethodFromGridRow(i);
		}
	}

	#endregion

	#region Properties


	#endregion

	#region Add

	private void btnAdd_Click(object sender, EventArgs e)
	{
		this.Add();
	}

	private void Add()
	{
		var method = ServiceMethodModel.CreateNew(Guid.NewGuid(), "Query");
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
		if (grdQueries.SelectedCells.Count == 1) {
			var rowIdx = grdQueries.SelectedCells[0].OwningRow.Index;
			var idValStr = grdQueries.Rows[rowIdx].Cells[cIdCol].Value?.ToString();
			var method = _methods.FirstOrDefault(m => m.Id == Guid.Parse(idValStr));

			if (method != null) {
				bindingSrc.Remove(method);
			}
		}
	}

	#endregion

	#region Methods

	private void grdItems_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Shift && e.KeyCode == Keys.Insert) {
			this.Add();

		} else if (e.Shift && e.KeyCode == Keys.Delete) {
			this.Delete();
		}
	}

	#endregion

	private void grdItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		MessageBox.Show($"Error in column {e.ColumnIndex}: {e.Exception.Message}");
	}

	private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
			return;

		if (e.ColumnIndex == cAttrsCol) {
			var method = QueryMethodFromGridRow(e.RowIndex);
			this.StrListForm.Run("Attributes", method.Attributes);
			bindingSrc.ResetBindings(false);

		} else if (e.ColumnIndex == cDelCol) {
			if (MessageBox.Show("Confirm Delete", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
				var method = QueryMethodFromGridRow(e.RowIndex);
				bindingSrc.Remove(method);
			}
		}
	}

	private ServiceMethodModel QueryMethodFromGridRow(int rowIndex)
	{
		var idValStr = grdQueries.Rows[rowIndex].Cells[cIdCol].Value?.ToString();
		return _methods.FirstOrDefault(m => m.Id == Guid.Parse(idValStr));
	}

	private void grdItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex == this.grdQueries.Columns[cAttrsCol].Index || e.ColumnIndex == this.grdQueries.Columns[cDelCol].Index) && e.RowIndex > -1) {
			this.grdQueries.Cursor = Cursors.Hand;
		}
	}

	private void grdItems_SelectionChanged(object sender, EventArgs e)
	{
		_suspendUpdates = true;
		if (grdQueries.SelectedCells.Count == 1) {
			var method = QueryMethodFromGridRow(grdQueries.CurrentCell.RowIndex);
			//SetFilterPropertiesList(method);
			btnDelete.Enabled = true;
			//clbFilterProperties.Enabled = true;
			clbDtoProperties.Enabled = true;

		} else {
			//clbFilterProperties.ClearSelected();
			clbDtoProperties.ClearSelected();
			btnDelete.Enabled = false;
			//clbFilterProperties.Enabled = false;
			clbDtoProperties.Enabled = false;
		}
		_suspendUpdates = false;
	}

	private void grdItems_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		this.grdQueries.Cursor = Cursors.Default;
	}

	private void clbFilterProperties_ItemCheck(object sender, ItemCheckEventArgs e)
	{
		if (_suspendUpdates)
			return;

		//PropertyModel prop = clbFilterProperties.Items[e.Index] as PropertyModel;
		//if (e.NewValue == CheckState.Checked) {
		//	var method = QueryMethodFromGridRow(grdQueries.CurrentCell.RowIndex);
		//	method.FilterProperties.Add(prop);
		//} else {
		//	var method = QueryMethodFromGridRow(grdQueries.CurrentCell.RowIndex);
		//	method.FilterProperties.Remove(prop);
		//}
	}
}
