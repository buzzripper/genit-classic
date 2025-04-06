using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class FilterPropsEditCtl : UserControlBase
{
	private const int cFPIdCol = 0;
	private const int cFPInclCol = 1;
	private const int cFPNameCol = 2;
	private const int cFPIsOptCol = 3;
	private const int cFPIsIntCol = 4;
	private const int cFPIntValCol = 5;

	private ObservableCollection<PropertyModel> _properties;
	private ObservableCollection<FilterPropertyModel> _filterProps;

	public FilterPropsEditCtl()
	{
		InitializeComponent();
		grdProps.RowsDefaultCellStyle.SelectionBackColor = grdProps.RowsDefaultCellStyle.BackColor;
	}

	public void SetProperties(ObservableCollection<PropertyModel> properties)
	{
		_suspendUpdates = true;
		try {
			_properties = properties;

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

			_filterProps = filterProps;

			if (filterProps == null || filterProps.Count == 0) {
				ClearSelections();
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
				}
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

	private void grdProps_CurrentCellDirtyStateChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates)
			return;

		var col = grdProps.CurrentCell.OwningColumn;

		// If it's one of the checkbox columns, we need to commit the edit
		//if (col.Index == cFPInclCol || col.Index == cFPIsIntCol || col.Index == cFPIsIntCol) {
		if (grdProps.IsCurrentCellDirty) {
			// This commits the value immediately
			grdProps.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
		//}
	}

	private void grdProps_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (_suspendUpdates || grdProps.CurrentCell == null)
			return;

		var col = grdProps.CurrentCell.OwningColumn;
		var row = grdProps.Rows[e.RowIndex];
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
				//HighlightRow(row, isChecked);

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
	}

	//private void HighlightRow(DataGridViewRow row, bool isHighlighted)
	//{
	//	if (isHighlighted) {
	//		row.DefaultCellStyle.BackColor = grdProps.DefaultCellStyle.SelectionBackColor; // or 
	//		//row.DefaultCellStyle.ForeColor = grdProps.DefaultCellStyle.SelectionBackColor;
	//	} else {
	//		// Reset to default (optional: customize your base style)
	//		row.DefaultCellStyle.BackColor = grdProps.DefaultCellStyle.BackColor;
	//		//row.DefaultCellStyle.ForeColor = grdProps.DefaultCellStyle.ForeColor;
	//	}
	//}
}
