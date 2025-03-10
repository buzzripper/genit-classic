using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Dyvenix.Genit.UserControls;

public partial class StringListEditor : UserControlBase
{
	public event EventHandler<ItemAddedEventArgs> ItemAdded;
	public event EventHandler<ItemChangedEventArgs> ItemChanged;
	public event EventHandler<ItemDeletedEventArgs> ItemDeleted;

	private List<string> _items;
	private bool _populating;

	public StringListEditor()
	{
		InitializeComponent();
	}

	private void StringListEditor_Load(object sender, EventArgs e)
	{
		PositionGrid(toolStrip1.Dock);
	}

	private void StringListEditor_Layout(object sender, LayoutEventArgs e)
	{
	}

	private void PositionGrid(DockStyle dock)
	{

		switch (dock) {
			case DockStyle.Top:
				grdItems.Top = toolStrip1.Height + 1;
				grdItems.Left = 0;
				grdItems.Width = this.Width;
				grdItems.Height = this.Height - toolStrip1.Height - 2;
				break;
			case DockStyle.Right:
				grdItems.Top = 0;
				grdItems.Left = 0;
				grdItems.Width = this.Width - toolStrip1.Width - 2;
				grdItems.Height = this.Height - 2;
				break;
			case DockStyle.Left:
				grdItems.Top = 0;
				grdItems.Left = toolStrip1.Width + 1;
				grdItems.Width = this.Width - toolStrip1.Width - 2;
				grdItems.Height = this.Height - 2;
				break;
			default: // DockStyle.Bottom:
				grdItems.Top = 0;
				grdItems.Left = 0;
				grdItems.Width = this.Width;
				grdItems.Height = this.Height - toolStrip1.Height - 2;
				break;
		}

		grdItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
	}

	#region Properties

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DefaultValue(DockStyle.Top)]
	public DockStyle ToolbarDockStyle
	{
		get { return toolStrip1.Dock; }
		set {
			toolStrip1.Dock = value;
			if (value == (DockStyle.Top | DockStyle.Bottom))
				toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
			else
				toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
		}
	}

	[Browsable(false)]
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
			foreach (var item in value)
				grdItems.Rows.Add(item);

			_items = value;
			_populating = false;
		}
	}

	private void grdItems_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Shift && e.KeyCode == Keys.Insert) {
			this.Add(GetUniqueValue());

		} else if (e.Shift && e.KeyCode == Keys.Delete) {
			this.Delete();
		}
	}

	#endregion

	#region Add

	private void btnAdd_Click(object sender, EventArgs e)
	{
		this.Add(GetUniqueValue());
	}

	private void Add(string value)
	{
		_items.Add(value);
		var rowIdx = grdItems.Rows.Add(value);

		//grdItems.CurrentCell = grdItems.Rows[rowIdx].Cells[0];
		//grdItems.BeginEdit(true);
	}

	#endregion

	#region Edit

	private void grdItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		var newValue = grdItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
		_items[e.RowIndex] = newValue;
		ItemChanged?.Invoke(this, new ItemChangedEventArgs(e.RowIndex, newValue));
	}

	private void grdItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
	{
		// Get the current cell value
		string cellValue = e.FormattedValue.ToString();

		// Check if the cell value is empty
		if (string.IsNullOrWhiteSpace(cellValue)) {
			// Cancel the change and display an error message
			e.Cancel = true;
			grdItems.Rows[e.RowIndex].ErrorText = "Cell value cannot be empty";
		} else {
			// Clear the error message
			grdItems.Rows[e.RowIndex].ErrorText = string.Empty;
		}
	}

	#endregion

	#region Delete

	private void grdItems_SelectionChanged(object sender, EventArgs e)
	{
		btnDelete.Enabled = grdItems.SelectedCells.Count == 1;
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		this.Delete();
	}

	private void Delete()
	{
		if (grdItems.SelectedCells.Count == 1) {
			var rowIdx = grdItems.SelectedCells[0].OwningRow.Index;

			_items.RemoveAt(rowIdx);
			grdItems.Rows.RemoveAt(rowIdx);

			ItemDeleted?.Invoke(this, new ItemDeletedEventArgs(rowIdx));
		}
	}

	#endregion

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
}

#region EventArg Classes

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

#endregion

