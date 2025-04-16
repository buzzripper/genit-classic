using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

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
		Utils.FormatDataGrid(grdMethods);

		Utils.FormatDataGrid(grdMethods);

		grdMethods.ClearSelection();
	}

	public void SetData(ObservableCollection<UpdateMethodModel> updateMethods, ObservableCollection<PropertyModel> properties)
	{
		_suspendUpdates = true;

		_updateMethods = updateMethods;

		grdMethods.DataSource = bindingSrc;
		SetBindings();

		updPropsEditCtl.SetProperties(properties);

		_suspendUpdates = false;

		if (updateMethods?.Count > 0) {
			grdMethods.Rows[0].Selected = true;
			grdMethods.CurrentCell = grdMethods.Rows[0].Cells[cNameCol];
		}
	}

	#endregion

	#region Add

	private void btnAdd_Click(object sender, EventArgs e)
	{
		this.Add();
	}

	private void Add()
	{
		var idx = grdMethods.Rows.Count;
		var method = UpdateMethodModel.CreateNew(Guid.NewGuid(), "Update", idx);

		SuspendLayout();
		_updateMethods.Add(method);
		bindingSrc.DataSource = _updateMethods.OrderBy(m => m.DisplayOrder);
		grdMethods.ResetBindings();
		ResumeLayout();
	}

	#endregion

	#region Delete

	private void Delete()
	{
		var rowIdx = grdMethods.SelectedCells[0].OwningRow.Index;
		if (rowIdx > -1) {
			if (MessageBox.Show("Confirm Delete", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
				var method = GetMethodFromGridRow(rowIdx);
				_updateMethods.Remove(method);
				bindingSrc.Remove(method);
				//bindingSrc.ResetBindings(false);
			}
		}
	}

	#endregion

	#region Methods

	private UpdateMethodModel GetMethodFromGridRow(int? rowIndex)
	{
		if (!rowIndex.HasValue)
			return null;

		var idValStr = grdMethods.Rows[rowIndex.Value].Cells[cIdCol].Value?.ToString();
		if (idValStr == null)
			return null;

		return _updateMethods.FirstOrDefault(m => m.Id == Guid.Parse(idValStr));
	}

	#endregion

	#region UI Events

	private void grdItems_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Shift && e.KeyCode == Keys.Insert) {
			this.Add();

		} else if (e.Shift && e.KeyCode == Keys.Delete) {
			this.Delete();
		}
	}

	private void grdMethods_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		MessageBox.Show($"Error in column {e.ColumnIndex}: {e.Exception.Message}");
	}

	private void grdMethods_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
			return;

		if (e.ColumnIndex == cDelCol)
			this.Delete();
	}

	private void grdMethods_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == this.grdMethods.Columns[cDelCol].Index && e.RowIndex > -1)
			this.grdMethods.Cursor = Cursors.Hand;
	}

	private void grdMethods_SelectionChanged(object sender, EventArgs e)
	{
		if (grdMethods.CurrentRow == null) {
			btnUp.Enabled = false;
			btnDown.Enabled = false;
			updPropsEditCtl.SetUpdateProperties(null);
			updPropsEditCtl.Readonly = true;
			updPropsEditCtl.Clear();
			return;
		}

		var rowIdx = grdMethods.CurrentRow.Index;

		var method = GetMethodFromGridRow(rowIdx);
		updPropsEditCtl.SetUpdateProperties(method?.UpdateProperties);
		updPropsEditCtl.Readonly = false;

		btnUp.Enabled = rowIdx > 0;
		btnDown.Enabled = rowIdx < (grdMethods.RowCount - 1);
	}

	private void grdMethods_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		this.grdMethods.Cursor = Cursors.Default;
	}

	#endregion

	private void btnUp_Click(object sender, EventArgs e)
	{
		var rowIdx = grdMethods.CurrentRow.Index;
		SwapOrder(rowIdx, rowIdx - 1);
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		var rowIdx = grdMethods.CurrentRow.Index;
		SwapOrder(rowIdx, rowIdx + 1);
	}

	private void SwapOrder(int srcIdx, int targetIdx)
	{
		var srcMethod = _updateMethods.First(m => m.DisplayOrder == srcIdx);
		var targetMethod = _updateMethods.First(m => m.DisplayOrder == targetIdx);

		srcMethod.DisplayOrder = targetIdx;
		targetMethod.DisplayOrder = srcIdx;

		SetBindings();

		grdMethods.Rows[srcIdx].Selected = false;
		grdMethods.Rows[targetIdx].Selected = true;
		grdMethods.CurrentCell = grdMethods.Rows[targetIdx].Cells[cNameCol];
		grdMethods_SelectionChanged(null, null);
	}

	private void SetBindings()
	{
		SuspendLayout();

		bindingSrc.DataSource = _updateMethods.OrderBy(m => m.DisplayOrder);
		bindingSrc.ResetBindings(false);

		ResumeLayout();
	}
}
