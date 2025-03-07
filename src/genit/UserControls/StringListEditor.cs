using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class StringListEditor : UserControl
{
	public event EventHandler<ItemAddedEventArgs> ItemAdded;
	public event EventHandler<ItemChangedEventArgs> ItemChanged;
	public event EventHandler<ItemDeletedEventArgs> ItemDeleted;

	private bool _populating;

	public StringListEditor()
	{
		InitializeComponent();
	}

	private void StringListEditor_Load(object sender, EventArgs e)
	{
		grdItems.ColumnHeadersVisible = false;
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public List<string> Items
	{
		get {
			List<string> items = new List<string>();
			foreach (DataGridViewRow row in grdItems.Rows)
				items.Add(row.Cells[0].Value.ToString());
			return items;
		}
		set {
			_populating = true;
			grdItems.Rows.Clear();
			foreach (string item in value)
				grdItems.Rows.Add(item);
			_populating = false;
		}
	}

	private void grdItems_SelectionChanged(object sender, EventArgs e)
	{
		btnDelete.Enabled = grdItems.SelectedCells.Count == 1;
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		var itemText = GetUniqueValue();
		var rowIdx = grdItems.Rows.Add(itemText);
		grdItems.Rows[rowIdx].Cells[0].Selected = true;
	}

	private string GetUniqueValue()
	{
		var value = "New Item";
		var i = 1;
		while (grdItems.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.ToString() == value)) {
			i++;
			value = $"New Item {i}";
		}
		return value;
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		if (grdItems.SelectedCells.Count == 1) {
			var rowIdx = grdItems.SelectedCells[0].OwningRow.Index;
			grdItems.Rows.RemoveAt(rowIdx);
			ItemDeleted?.Invoke(this, new ItemDeletedEventArgs(rowIdx));
		}
	}

	private void grdItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
	}

	private void grdItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		var newValue = grdItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
		ItemChanged.Invoke(this, new ItemChangedEventArgs(e.RowIndex, newValue));
	}

	private void grdItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		if (_populating)
			return;

		var rowIdx = e.RowIndex;
		var val = grdItems.Rows[rowIdx].Cells[0].Value?.ToString();
		ItemAdded?.Invoke(this, new ItemAddedEventArgs(val));
	}

	private void grdItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
	{
		  // Get the current cell value
        string cellValue = e.FormattedValue.ToString();

        // Check if the cell value is empty
        if (string.IsNullOrWhiteSpace(cellValue))
        {
            // Cancel the change and display an error message
            e.Cancel = true;
            grdItems.Rows[e.RowIndex].ErrorText = "Cell value cannot be empty";
        }
        else
        {
            // Clear the error message
            grdItems.Rows[e.RowIndex].ErrorText = string.Empty;
        }
	}
}

public class ItemAddedEventArgs : EventArgs
{
	public string Value { get; }

	public ItemAddedEventArgs(string value)
	{
		Value = value;
	}
}

public class ItemChangedEventArgs : EventArgs
{
	public int Index { get; }
	public string Value { get; }

	public ItemChangedEventArgs(int index, string value)
	{
		Index = index;
		Value = value;
	}
}

public class ItemDeletedEventArgs : EventArgs
{
	public int Index { get; }

	public ItemDeletedEventArgs(int index)
	{
		Index = index;
	}
}


