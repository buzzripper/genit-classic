using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;
public partial class ServiceMethodsEditCtl : UserControlBase
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

	public ServiceMethodsEditCtl()
	{
		InitializeComponent();
	}


	private void ServiceMethodsEditCtl_Load(object sender, EventArgs e)
	{
		PositionControls();
		grdMethods.AutoGenerateColumns = false;
	}

	public void SetData(ObservableCollection<ServiceMethodModel> methods, ObservableCollection<PropertyModel> properties, ObservableCollection<NavPropertyModel> navProperties)
	{
		_methods = methods;
		bindingSrc.DataSource = _methods;
		grdMethods.DataSource = bindingSrc;

		clbFilterProperties.Items.Clear();
		clbFilterProperties.Items.AddRange(properties.ToArray());

		clbNavProperties.Items.Clear();
		clbNavProperties.Items.AddRange(navProperties.ToArray());
	}

	#endregion

	#region Add

	private void btnAdd_Click(object sender, EventArgs e)
	{
		this.Add();
	}

	private void Add()
	{
		var method = new ServiceMethodModel(Guid.NewGuid()) {
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
		if (grdMethods.SelectedCells.Count == 1) {
			var rowIdx = grdMethods.SelectedCells[0].OwningRow.Index;
			var idValStr = grdMethods.Rows[rowIdx].Cells[cIdCol].Value?.ToString();
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
		splMain.Dock = DockStyle.Fill;
		splLists.Dock = DockStyle.Fill;

		lblFilterProperties.Height = toolStrip1.Height;
		clbFilterProperties.Left = 0;
		clbFilterProperties.Top = lblFilterProperties.Height + 1;
		clbFilterProperties.Width = splLists.Panel1.Width;
		clbFilterProperties.Height = splLists.Panel1.Height - toolStrip1.Height;
		clbFilterProperties.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

		lblInclNavProps.Height = toolStrip1.Height;
		clbNavProperties.Left = 0;
		clbNavProperties.Top = lblInclNavProps.Height + 1;
		clbNavProperties.Width = splLists.Panel2.Width;
		clbNavProperties.Height = splLists.Panel2.Height - toolStrip1.Height;
		clbNavProperties.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
	}

	private void SetFilterPropertiesList(ServiceMethodModel method)
	{
		_suspendUpdates = true;

		for (var i = 0; i < clbFilterProperties.Items.Count; i++) {
			var prop = (PropertyModel)clbFilterProperties.Items[i];
			clbFilterProperties.SetItemChecked(i, method.FilterProperties.Contains(prop));
		}

		_suspendUpdates = false;
	}

	private void SetInclNavPropertiesList(ServiceMethodModel method)
	{
		_suspendUpdates = true;

		for (var i = 0; i < clbNavProperties.Items.Count; i++) {
			var navProp = (NavPropertyModel)clbNavProperties.Items[i];
			clbNavProperties.SetItemChecked(i, method.InclNavProperties.Contains(navProp));
		}

		_suspendUpdates = false;
	}

	private void grdItems_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Shift && e.KeyCode == Keys.Insert) {
			this.Add();

		} else if (e.Shift && e.KeyCode == Keys.Delete) {
			this.Delete();
		}
	}

	private ServiceMethodModel GetMethodFromGridRow(int rowIndex)
	{
		var idValStr = grdMethods.Rows[rowIndex].Cells[cIdCol].Value?.ToString();
		return _methods.FirstOrDefault(m => m.Id == Guid.Parse(idValStr));
	}

	#endregion

	#region UI Events

	private void grdMethods_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		MessageBox.Show($"Error in column {e.ColumnIndex}: {e.Exception.Message}");
	}

	private void grdMethods_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
			return;

		if (e.ColumnIndex == cAttrsCol) {
			var method = GetMethodFromGridRow(e.RowIndex);
			this.StrListForm.Run("Attributes", method.Attributes);
			bindingSrc.ResetBindings(false);

		} else if (e.ColumnIndex == cDelCol) {
			if (MessageBox.Show("Confirm Delete", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
				var method = GetMethodFromGridRow(e.RowIndex);
				bindingSrc.Remove(method);
			}
		}
	}

	private void grdMethods_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex == this.grdMethods.Columns[cAttrsCol].Index || e.ColumnIndex == this.grdMethods.Columns[cDelCol].Index) && e.RowIndex > -1) {
			this.grdMethods.Cursor = Cursors.Hand;
		}
	}

	private void grdMethods_SelectionChanged(object sender, EventArgs e)
	{
		_suspendUpdates = true;
		if (grdMethods.SelectedCells.Count == 1) {
			var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);
			SetFilterPropertiesList(method);
			clbFilterProperties.Enabled = true;
			SetInclNavPropertiesList(method);
			clbNavProperties.Enabled = true;

		} else {
			clbFilterProperties.ClearSelected();
			clbFilterProperties.Enabled = false;
		}
		_suspendUpdates = false;
	}

	private void grdMethods_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		this.grdMethods.Cursor = Cursors.Default;
	}

	private void clbFilterProperties_ItemCheck(object sender, ItemCheckEventArgs e)
	{
		if (_suspendUpdates)
			return;

		PropertyModel prop = clbFilterProperties.Items[e.Index] as PropertyModel;
		if (e.NewValue == CheckState.Checked) {
			var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);
			method.FilterProperties.Add(prop);
		} else {
			var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);
			method.FilterProperties.Remove(prop);
		}
	}

	private void clbNavProperties_ItemCheck(object sender, ItemCheckEventArgs e)
	{
		if (_suspendUpdates)
			return;

		NavPropertyModel navProp = clbNavProperties.Items[e.Index] as NavPropertyModel;
		var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);

		if (e.NewValue == CheckState.Checked)
			method.InclNavProperties.Add(navProp);
		else
			method.InclNavProperties.Remove(navProp);
	}

	#endregion
}
