using Dyvenix.Genit.Models.Services;
using Dyvenix.Genit.Models;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dyvenix.Genit.Misc;
using System.ComponentModel;

namespace Dyvenix.Genit.UserControls;

public partial class UpdPropsEditCtl : UserControlBase
{
	#region Constants

	private const int cInclCol = 1;
	private const int cIsOptCol = 3;

	#endregion

	private ObservableCollection<PropertyModel> _properties;
	private ObservableCollection<UpdatePropertyModel> _updateProps;
	private Color _highlightColor;

	public UpdPropsEditCtl()
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
			_properties = properties;

			grdProps.AutoGenerateColumns = false;
			grdProps.Rows.Clear();
			foreach (var prop in _properties) {
				if (prop.IsPrimaryKey)
					continue;
				var idx = grdProps.Rows.Add(prop.Id, false, prop.Name, false, false, null);
				grdProps.Rows[idx].Tag = prop;
			}

		} finally {
			_suspendUpdates = false;
		}
	}

	public void SetUpdateProperties(ObservableCollection<UpdatePropertyModel> updateProperties)
	{
		_suspendUpdates = true;
		try {
			ClearSelections();

			_updateProps = updateProperties;

			if (_updateProps == null || _updateProps.Count == 0) {
				ClearAllHighlights();
				return;
			}

			for (var i = 0; i < grdProps.Rows.Count; i++) {

				var row = grdProps.Rows[i];
				var grdProp = row.Tag as PropertyModel;
				var updProp = _updateProps.FirstOrDefault(fp => fp.Property == grdProp);

				if (updProp != null) {
					row.Cells[cInclCol].Value = true;
					row.Cells[cIsOptCol].Value = updProp.IsOptional;
				} else {
					row.Cells[cInclCol].Value = false;
					row.Cells[cIsOptCol].Value = false;
				}
				UpdateRowHighlight(row);
			}

		} finally {
			_suspendUpdates = false;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Readonly
	{
		get { return !grdProps.Enabled; }
		set { grdProps.Enabled = !value; }
	}

	public void Clear()
	{
		grdProps.ClearSelection();
	}

	private void ClearSelections()
	{
		for (var i = 0; i < grdProps.Rows.Count; i++) {
			var row = grdProps.Rows[i];
			row.Cells[cInclCol].Value = false;
			row.Cells[cIsOptCol].Value = false;
		}
	}

	private void grdProps_CurrentCellDirtyStateChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates)
			return;

		var col = grdProps.CurrentCell.OwningColumn;

		// If it's a checkbox column, commit the value immediately
		if (grdProps.IsCurrentCellDirty)
			grdProps.CommitEdit(DataGridViewDataErrorContexts.Commit);
	}

	private void grdProps_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
			return;

		var row = grdProps.Rows[e.RowIndex];
		bool isChecked = (bool)row.Cells[cInclCol].Value;
		//row.DefaultCellStyle.BackColor = isChecked ? _highlightColor : grdProps.DefaultCellStyle.BackColor;

		if (_suspendUpdates || grdProps.CurrentCell == null)
			return;

		var colIdx = e.ColumnIndex;

		var prop = row.Tag as PropertyModel;
		if (prop == null)
			MessageBox.Show("Error: Property not found for this row.");

		var updProp = _updateProps?.FirstOrDefault(fp => fp.Property == prop);

		// Now we know it's a checkbox column

		if (colIdx == cInclCol) {
			if (isChecked && updProp == null) {
				_updateProps.Add(UpdatePropertyModel.CreateNew(prop, false));
			} else if (!isChecked && updProp != null) {
				_updateProps.Remove(updProp);
			}
			row.Cells[cIsOptCol].ReadOnly = !isChecked;
			if (!isChecked)
				row.Cells[cIsOptCol].Value = false;

			UpdateRowHighlight(row);

		} else if (colIdx == cIsOptCol) {
			if (updProp == null)
				throw new ApplicationException("Error: no update property found.");

			updProp.IsOptional = isChecked;
		}
		grdProps.ClearSelection();

	}

	private void UpdateRowHighlight(DataGridViewRow row)
	{
		bool isChecked = Convert.ToBoolean(row.Cells[cInclCol].Value);

		row.DefaultCellStyle.BackColor = isChecked
			? _highlightColor
			: grdProps.DefaultCellStyle.BackColor;
	}

	private void ClearAllHighlights()
	{
		foreach (DataGridViewRow row in grdProps.Rows)
			row.DefaultCellStyle.BackColor = grdProps.DefaultCellStyle.BackColor;
	}
}
