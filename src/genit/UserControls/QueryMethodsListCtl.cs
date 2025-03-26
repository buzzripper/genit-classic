using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class QueryMethodsListCtl : UserControlBase
{
	#region Constants

	private const int cIdCol = 0;
	private const int cNameCol = 1;
	private const int cAttrsCol = 2;
	private const int cDelCol = 3;

	#endregion

	#region Fields

	private ObservableCollection<QuerySvcMethodModel> _methods;

	#endregion

	#region Ctors / Init

	public QueryMethodsListCtl()
	{
		InitializeComponent();
	}

	private void GetMethodsListCtl_Load(object sender, EventArgs e)
	{
		PositionControls();
		grdQueries.AutoGenerateColumns = false;
	}

	public void SetData(ObservableCollection<QuerySvcMethodModel> methods, ObservableCollection<PropertyModel> properties)
	{
		_methods = methods;
		bindingSrc.DataSource = _methods;
		grdQueries.DataSource = bindingSrc;

		for (var i = 0; i < grdQueries.Rows.Count; i++) {
			var method = QueryMethodFromGridRow(i);
			//grdQueries.Rows[i].Cells[cAttrsCol].Value = $"[]  ({method.Attributes.Count})";
			//grdQueries.Rows[i].Cells[cAttrsCol].Value = "FOO";
		}

		clbFilterProperties.Items.Clear();
		clbFilterProperties.Items.AddRange(properties.Where(p => !p.IsPrimaryKey && !p.IsIndexUnique).ToArray());
		clbDtoProperties.Items.Clear();
		clbDtoProperties.Items.AddRange(properties.ToArray());
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
		var method = new QuerySvcMethodModel(Guid.NewGuid()) {
			Name = "Query"
		};

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

	private void PositionControls()
	{
		pnlFilterPropsHeader.Height = toolStrip1.Height;
		pnlDtoPropsHeader.Height = toolStrip1.Height;

		clbFilterProperties.Top = pnlFilterPropsHeader.Height + 1;
		clbFilterProperties.Left = 0;
		clbFilterProperties.Width = splProperties.Panel1.Width;
		clbFilterProperties.Height = splProperties.Panel1.Height - pnlFilterPropsHeader.Height - 2;
		clbFilterProperties.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
	}

	private void SetFilterPropertiesList(QuerySvcMethodModel query)
	{
		_suspendUpdates = true;

		for (var i = 0; i < clbFilterProperties.Items.Count; i++) {
			var prop = (PropertyModel)clbFilterProperties.Items[i];
			clbFilterProperties.SetItemChecked(i, query.FilterProperties.Contains(prop));
		}

		_suspendUpdates = false;
	}

	private void SetDtoPropsAll(bool value)
	{
		clbDtoProperties.Enabled = value;

	}

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
		if (e.ColumnIndex == 2) {
			var method = QueryMethodFromGridRow(e.RowIndex);
			this.StrListForm.Run("Attributes", method.Attributes);

		} else if (e.ColumnIndex == 3) {
			if (MessageBox.Show("Confirm Delete", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
				var method = QueryMethodFromGridRow(e.RowIndex);
				bindingSrc.Remove(method);
			}
		}
	}

	private QuerySvcMethodModel QueryMethodFromGridRow(int rowIndex)
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
			SetFilterPropertiesList(method);
			btnDelete.Enabled = true;
			clbFilterProperties.Enabled = true;
			clbDtoProperties.Enabled = true;

		} else {
			clbFilterProperties.ClearSelected();
			clbDtoProperties.ClearSelected();
			btnDelete.Enabled = false;
			clbFilterProperties.Enabled = false;
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

		PropertyModel prop = clbFilterProperties.Items[e.Index] as PropertyModel;
		if (e.NewValue == CheckState.Checked) {
			var method = QueryMethodFromGridRow(grdQueries.CurrentCell.RowIndex);
			method.FilterProperties.Add(prop);
		} else {
			var method = QueryMethodFromGridRow(grdQueries.CurrentCell.RowIndex);
			method.FilterProperties.Remove(prop);
		}
	}
}
