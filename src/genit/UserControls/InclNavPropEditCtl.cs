using Dyvenix.Genit.Models;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class InclNavPropEditCtl : UserControlBase
{
	#region Constants

	private const int cInclCol = 1;

	#endregion

	private ObservableCollection<NavPropertyModel> _navProperties;
	private ObservableCollection<NavPropertyModel> _inclNavProps;
	private Color _highlightColor;

	public InclNavPropEditCtl()
	{
		InitializeComponent();

		_highlightColor = grdNavProps.DefaultCellStyle.SelectionBackColor;

		grdNavProps.RowsDefaultCellStyle.SelectionBackColor = grdNavProps.RowsDefaultCellStyle.BackColor;
		grdNavProps.DefaultCellStyle.SelectionBackColor = grdNavProps.DefaultCellStyle.BackColor;
		grdNavProps.DefaultCellStyle.SelectionForeColor = grdNavProps.DefaultCellStyle.ForeColor;
		grdNavProps.AutoGenerateColumns = false;
	}

	public void SetNavProperties(ObservableCollection<NavPropertyModel> navProperties)
	{
		_suspendUpdates = true;

		try {
			_navProperties = navProperties;

			SuspendLayout();
			grdNavProps.Rows.Clear();
			foreach (var navProp in _navProperties) {
				var idx = grdNavProps.Rows.Add(navProp.Id, false, navProp.Name, false, false, null);
				grdNavProps.Rows[idx].Tag = navProp;
			}
			ResumeLayout();

		} finally {
			_suspendUpdates = false;
		}
	}

	public void SetInclNavProperties(ObservableCollection<NavPropertyModel> inclNavProperties)
	{
		_suspendUpdates = true;
		SuspendLayout();
		try {
			_inclNavProps = inclNavProperties;

			if (_inclNavProps == null || _inclNavProps.Count == 0) {
				ClearSelections();
				return;
			}

			for (var i = 0; i < grdNavProps.Rows.Count; i++) {
				var row = grdNavProps.Rows[i];
				var grdNavProp = row.Tag as NavPropertyModel;
				var updProp = _inclNavProps.FirstOrDefault(np => np == grdNavProp);

				if (updProp != null) {
					row.Cells[cInclCol].Value = true;
				} else {
					row.Cells[cInclCol].Value = false;
				}
			}

		} finally {
			_suspendUpdates = false;
			ResumeLayout();
		}
	}

	private void ClearSelections()
	{
		for (var i = 0; i < grdNavProps.Rows.Count; i++) {
			var row = grdNavProps.Rows[i];
			row.Cells[cInclCol].Value = false;
		}
	}

	private void grdProps_CurrentCellDirtyStateChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates)
			return;

		var col = grdNavProps.CurrentCell.OwningColumn;

		// If it's a checkbox column, commit the value immediately
		if (grdNavProps.IsCurrentCellDirty)
			grdNavProps.CommitEdit(DataGridViewDataErrorContexts.Commit);
	}

	private void grdProps_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
			return;

		var row = grdNavProps.Rows[e.RowIndex];
		bool isChecked = (bool)row.Cells[cInclCol].Value;
		row.DefaultCellStyle.BackColor = isChecked ? _highlightColor : grdNavProps.DefaultCellStyle.BackColor;

		if (_suspendUpdates || grdNavProps.CurrentCell == null)
			return;

		var colIdx = e.ColumnIndex;

		var prop = row.Tag as NavPropertyModel;
		if (prop == null)
			MessageBox.Show("Error: Property not found for this row.");

		var navProp = _inclNavProps?.FirstOrDefault(np => np == prop);

		if (isChecked && navProp == null) {
			_inclNavProps.Add(prop);

		} else if (!isChecked && navProp != null) {
			_inclNavProps.Remove(navProp);
		}
	}
}
