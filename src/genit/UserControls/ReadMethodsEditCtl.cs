using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
	public partial class ReadMethodsEditCtl : UserControlBase
	{
		#region Constants

		private const int cIdCol = 0;
		private const int cNameCol = 1;
		private const int cInclPagingCol = 2;
		private const int cUseQueryCol = 3;
		private const int cInclSortingCol = 4;
		private const int cAttrsCol = 5;
		private const int cDelCol = 6;

		#endregion

		#region Fields

		private ObservableCollection<ReadMethodModel> _readMethods;

		#endregion

		#region Ctors / Init

		public ReadMethodsEditCtl()
		{
			InitializeComponent();
		}

		private void ServiceMethodsEditCtl_Load(object sender, EventArgs e)
		{
			PositionControls();

			Utils.FormatDataGrid(grdMethods);

			grdMethods.ClearSelection();
		}

		public void SetData(ObservableCollection<ReadMethodModel> readMethods, ObservableCollection<PropertyModel> properties, ObservableCollection<NavPropertyModel> navProperties)
		{
			_suspendUpdates = true;

			_readMethods = readMethods;

			grdMethods.DataSource = bindingSrc;
			SetBindings();

			grdMethods.AllowUserToAddRows = false;

			filterPropsCtl.SetProperties(properties);

			inclNavPropEditCtl.SetNavProperties(navProperties);

			_suspendUpdates = false;

			if (readMethods?.Count > 0) {
				grdMethods.Rows[0].Selected = true;
				grdMethods.CurrentCell = grdMethods.Rows[0].Cells[cNameCol];
			}
		}

		private void SetBindings()
		{
			SuspendLayout();

			bindingSrc.DataSource = _readMethods.OrderBy(m => m.DisplayOrder);
			bindingSrc.ResetBindings(false);

			ResumeLayout();
		}

		#endregion

		#region Add

		private void btnAdd_Click(object sender, EventArgs e)
		{
			this.Add();
		}

		private void Add()
		{
			_readMethods.Add(ReadMethodModel.CreateNew(Guid.NewGuid(), "GetSomething", _readMethods.Count));
			SetBindings();
		}

		#endregion

		#region Delete

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdMethods.CurrentRow == null)
				return;

			this.Delete(grdMethods.CurrentRow.Index);
		}

		private void Delete(int rowIdx)
		{
			if (MessageBox.Show("Confirm Delete", "Delete this item?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
				var method = GetMethodFromGridRow(rowIdx);
				_readMethods.Remove(method);
				bindingSrc.Remove(method);
			}
		}

		#endregion

		#region Methods

		private void PositionControls()
		{
			splMain.Dock = DockStyle.Fill;
			splLists.Dock = DockStyle.Fill;
		}

		private void grdItems_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Shift && e.KeyCode == Keys.Insert) {
				this.Add();

			} else if (e.Shift && e.KeyCode == Keys.Delete) {
				if (grdMethods.CurrentRow != null) 
					this.Delete(grdMethods.CurrentRow.Index);
			}
		}

		private ReadMethodModel GetMethodFromGridRow(int rowIndex)
		{
			if (rowIndex == -1)
				return null;

			var idValStr = grdMethods.Rows[rowIndex].Cells[cIdCol].Value?.ToString();
			if (idValStr == null)
				return null;

			return _readMethods.FirstOrDefault(m => m.Id == Guid.Parse(idValStr));
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
				Delete(e.RowIndex);
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
			if (grdMethods.CurrentRow == null) {
				btnUp.Enabled = false;
				btnDown.Enabled = false;
				filterPropsCtl.SetFilterProperties(null);
				filterPropsCtl.Readonly = true;
				inclNavPropEditCtl.SetInclNavProperties(null);
				inclNavPropEditCtl.Readonly = true;
				return;
			}

			var rowIdx = grdMethods.CurrentRow.Index;

			var method = GetMethodFromGridRow(rowIdx);
			filterPropsCtl.SetFilterProperties(method?.FilterProperties);
			filterPropsCtl.Readonly = false;
			inclNavPropEditCtl.SetInclNavProperties(method?.InclNavProperties);
			inclNavPropEditCtl.Readonly = false;

			btnUp.Enabled = rowIdx > 0;
			btnDown.Enabled = rowIdx < (grdMethods.RowCount - 1);
		}

		private void grdMethods_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			this.grdMethods.Cursor = Cursors.Default;
		}

		private void grdMethods_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == cUseQueryCol) {
				bool isQuery = !(bool)grdMethods.Rows[e.RowIndex].Cells[cUseQueryCol].Value;
				grdMethods.Rows[e.RowIndex].Cells[cInclSortingCol].ReadOnly = !isQuery;
				grdMethods.Rows[e.RowIndex].Cells[cUseQueryCol].Value = isQuery;
				if (isQuery == false)
					grdMethods.Rows[e.RowIndex].Cells[cInclSortingCol].Value = false;
			}
		}

		// Reordering

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
			var srcMethod = _readMethods.First(m => m.DisplayOrder == srcIdx);
			var targetMethod = _readMethods.First(m => m.DisplayOrder == targetIdx);

			srcMethod.DisplayOrder = targetIdx;
			targetMethod.DisplayOrder = srcIdx;

			SetBindings();

			grdMethods.Rows[srcIdx].Selected = false;
			grdMethods.Rows[targetIdx].Selected = true;
			grdMethods.CurrentCell = grdMethods.Rows[targetIdx].Cells[cNameCol];
			grdMethods_SelectionChanged(null, null);
		}
	}

	#endregion
}
