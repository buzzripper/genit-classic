using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace Dyvenix.Genit.UserControls;

public partial class FilterPropsEditCtl : UserControlBase
{
	#region Constants

	private const int cFPIdCol = 0;
	private const int cFPInclCol = 1;
	private const int cFPNameCol = 2;
	private const int cFPIsOptCol = 3;
	private const int cFPIsIntCol = 4;
	private const int cFPIntValCol = 5;

	#endregion

	#region Fields

	private ObservableCollection<FilterPropertyModel> _filterProps;
	private Color _highlightColor;

	#endregion

	#region Ctors / Init

	public FilterPropsEditCtl()
	{
		InitializeComponent();

		Utils.FormatDataGrid(grdProps);
		_highlightColor = grdProps.DefaultCellStyle.SelectionBackColor;

		grdProps.SelectionMode = DataGridViewSelectionMode.CellSelect;
		grdProps.DefaultCellStyle.SelectionBackColor = grdProps.DefaultCellStyle.BackColor;
		grdProps.DefaultCellStyle.SelectionForeColor = grdProps.DefaultCellStyle.ForeColor;
		grdProps.RowHeadersVisible = false;
		grdProps.MultiSelect = false;
		grdProps.ClearSelection();
	}

	public void SetProperties(ObservableCollection<PropertyModel> properties)
	{
		_suspendUpdates = true;
		try {
			grdProps.AutoGenerateColumns = false;
			grdProps.Rows.Clear();
			foreach (var prop in properties) {
				var idx = grdProps.Rows.Add(prop.Id, false, prop.Name, false, false, null);
				grdProps.Rows[idx].Tag = prop;
			}
		} finally {
			_suspendUpdates = false;
		}
	}

	public void SetFilterProperties(ObservableCollection<FilterPropertyModel> filterProps)
	{
		_suspendUpdates = true;
		try {
			ClearSelections();

			_filterProps = filterProps;
			if (filterProps == null || filterProps.Count == 0) {
				ClearAllHighlights();
				return;
			}

			for (var i = 0; i < grdProps.Rows.Count; i++) {
				var row = grdProps.Rows[i];
				var grdProp = row.Tag as PropertyModel;
				var filterProp = filterProps.FirstOrDefault(fp => fp.Property == grdProp);

				if (filterProp != null) {
					row.Cells[cFPInclCol].Value = true;
					row.Cells[cFPIsOptCol].Value = filterProp.IsOptional;
					row.Cells[cFPIsIntCol].Value = filterProp.IsInternal;
					row.Cells[cFPIntValCol].Value = filterProp.InternalValue;
				} else {
					row.Cells[cFPInclCol].Value = false;
					row.Cells[cFPIsOptCol].Value = false;
					row.Cells[cFPIsIntCol].Value = false;
					row.Cells[cFPIntValCol].Value = string.Empty;
					grdProps.ClearSelection();
				}
				UpdateRowHighlight(row);
				//grdProps.Enabled = true;
			}
		} finally {
			_suspendUpdates = false;
		}
	}

	private void ClearSelections()
	{
		for (var i = 0; i < grdProps.Rows.Count; i++) {
			var row = grdProps.Rows[i];
			row.Cells[cFPInclCol].Value = false;
			row.Cells[cFPIsOptCol].Value = false;
			row.Cells[cFPIsIntCol].Value = false;
			row.Cells[cFPIntValCol].Value = string.Empty;
		}
	}

	#endregion

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Readonly
	{
		get { return !grdProps.Enabled; }
		set { grdProps.Enabled = !value; }
	}

	private void grdProps_CurrentCellDirtyStateChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates)
			return;

		var col = grdProps.CurrentCell.OwningColumn;

		if (grdProps.IsCurrentCellDirty)
			grdProps.CommitEdit(DataGridViewDataErrorContexts.Commit);
	}

	private void grdProps_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
			return;

		try {
			var row = grdProps.Rows[e.RowIndex];
			bool isIncl = (bool)row.Cells[cFPInclCol].Value;
			//row.DefaultCellStyle.BackColor = isIncl ? _highlightColor : grdProps.DefaultCellStyle.BackColor;

			if (_suspendUpdates || grdProps.CurrentCell == null)
				return;

			var col = grdProps.CurrentCell.OwningColumn;
			var prop = row.Tag as PropertyModel;
			if (prop == null)
				MessageBox.Show("Error: Property not found for this row.");
			var filterProp = _filterProps.FirstOrDefault(fp => fp.Property == prop);

			if (col.Index == cFPIntValCol) {
				filterProp.InternalValue = row.Cells[col.Index].Value.ToString();

			} else {
				// Now we know it's a checkbox column
				bool isChecked = (bool)row.Cells[col.Index].Value;

				if (col.Index == cFPInclCol) {
					if (isChecked && filterProp == null) {
						_filterProps.Add(FilterPropertyModel.CreateNew(prop));
					} else if (!isChecked && filterProp != null) {
						_filterProps.Remove(filterProp);
					}

					row.Cells[cFPIsOptCol].ReadOnly = !isChecked;
					row.Cells[cFPIsIntCol].ReadOnly = !isChecked;
					UpdateRowHighlight(row);

					if (!isChecked) {
						row.Cells[cFPIsOptCol].Value = false;
						row.Cells[cFPIsIntCol].Value = false;
					}

				} else if (col.Index == cFPIsOptCol) {
					filterProp.IsOptional = isChecked;

				} else if (col.Index == cFPIsIntCol) {
					filterProp.IsInternal = isChecked;
				}
			}

		} catch (Exception ex) {
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateRowHighlight(DataGridViewRow row)
	{
		bool isChecked = Convert.ToBoolean(row.Cells[cFPInclCol].Value);

		row.DefaultCellStyle.BackColor = isChecked
			? _highlightColor
			: grdProps.DefaultCellStyle.BackColor;
	}

	private void ClearAllHighlights()
	{
		foreach(DataGridViewRow row in grdProps.Rows)
			row.DefaultCellStyle.BackColor = grdProps.DefaultCellStyle.BackColor;
	}
}
