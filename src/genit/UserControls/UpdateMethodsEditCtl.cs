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
		grdMethods.AutoGenerateColumns = false;
		grdMethods.RowHeadersWidth = 40;
		grdMethods.AllowUserToAddRows = false;
		grdMethods.AllowDrop = true;
		grdMethods.MouseDown += grdMethods_MouseDown;
		grdMethods.DragOver += grdMethods_DragOver;
		grdMethods.DragDrop += grdMethods_DragDrop;
		grdMethods.DefaultCellStyle.SelectionBackColor = grdMethods.DefaultCellStyle.BackColor;
		grdMethods.DefaultCellStyle.SelectionForeColor = grdMethods.DefaultCellStyle.ForeColor;
		grdMethods.MultiSelect = false;
	}

	public void SetData(ObservableCollection<UpdateMethodModel> updateMethods, ObservableCollection<PropertyModel> properties)
	{
		_suspendUpdates = true;

		_updateMethods = updateMethods;

		bindingSrc.DataSource = _updateMethods.OrderBy(m => m.DisplayOrder).ToList();
		grdMethods.DataSource = bindingSrc;

		updPropsEditCtl.SetProperties(properties);

		_suspendUpdates = false;
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
			//for (var i = 0; i < updPropsEditCtl.Items.Count; i++)
			//	updPropsEditCtl.SetItemChecked(i, false);
			updPropsEditCtl.SetUpdateProperties(null);
			return;
		}

		//for (var i = 0; i < updPropsEditCtl.Items.Count; i++) {
		//	var updProp = updPropsEditCtl.Items[i] as UpdatePropertyModel;
		//	updPropsEditCtl.SetItemChecked(i, method.UpdateProperties.Contains(updProp));
		//}

		_suspendUpdates = false;
	}

	private UpdateMethodModel GetMethodFromGridRow(int rowIndex)
	{
		var idValStr = grdMethods.Rows[rowIndex].Cells[cIdCol].Value?.ToString();
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

		if (e.ColumnIndex == cDelCol) {
			if (MessageBox.Show("Confirm Delete", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
				var method = GetMethodFromGridRow(e.RowIndex);
				bindingSrc.Remove(method);
			}
		}
	}

	private void grdMethods_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == this.grdMethods.Columns[cDelCol].Index && e.RowIndex > -1)
			this.grdMethods.Cursor = Cursors.Hand;
	}

	private void grdMethods_SelectionChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates)
			return;

		//if (grdMethods.SelectedCells.Count == 1) {
			var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);
			updPropsEditCtl.SetUpdateProperties(method.UpdateProperties);

		//} else {
			//updPropsEditCtl.SetUpdateProperties(null);
		//}

		_suspendUpdates = false;
	}

	private void grdMethods_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		this.grdMethods.Cursor = Cursors.Default;
	}

	#endregion

	#region Drag/Drop

	private void grdMethods_MouseDown(object sender, MouseEventArgs e)
	{
		var hitTest = grdMethods.HitTest(e.X, e.Y);
		if (hitTest.ColumnIndex == -1 && hitTest.RowIndex > -1) {
			grdMethods.DoDragDrop(hitTest.RowIndex, DragDropEffects.Move);
		}
	}

	private void grdMethods_DragOver(object sender, DragEventArgs e)
	{
		e.Effect = DragDropEffects.Move;
	}

	private void grdMethods_DragDrop(object sender, DragEventArgs e)
	{
		Point clientPoint = grdMethods.PointToClient(new Point(e.X, e.Y));
		var destRowIdx = grdMethods.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
		if (!e.Data.GetDataPresent(typeof(int)))
			return;
		var srcRowIdx = (int)e.Data.GetData(typeof(int));

		if (e.Effect == DragDropEffects.Move && destRowIdx > -1 && destRowIdx != srcRowIdx) {
			var srcMethod = _updateMethods.FirstOrDefault(m => m.DisplayOrder == srcRowIdx);
			if (srcRowIdx < destRowIdx) {
				foreach (var readMethod in _updateMethods.ToList().Where(m => m.DisplayOrder > srcRowIdx && m.DisplayOrder <= destRowIdx))
					readMethod.DisplayOrder--;
				srcMethod.DisplayOrder = destRowIdx;
			} else {
				foreach (var readMethod in _updateMethods.ToList().Where(m => m.DisplayOrder >= destRowIdx && m.DisplayOrder < srcRowIdx))
					readMethod.DisplayOrder++;
				srcMethod.DisplayOrder = destRowIdx;
			}

			SuspendLayout();
			bindingSrc.DataSource = _updateMethods.OrderBy(m => m.DisplayOrder);
			grdMethods.ResetBindings();
			ResumeLayout();
		}
	}

	#endregion
}
