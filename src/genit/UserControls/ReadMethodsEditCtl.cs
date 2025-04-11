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
		//private int _dragDropSrcIdx;
		//private int _dragDropDestIdx;

		#endregion

		#region Ctors / Init

		public ReadMethodsEditCtl()
		{
			InitializeComponent();
		}

		private void ServiceMethodsEditCtl_Load(object sender, EventArgs e)
		{
			PositionControls();
			grdMethods.AutoGenerateColumns = false;

			grdMethods.RowHeadersWidth = 40;
			grdMethods.AllowDrop = true;
			grdMethods.MouseDown += grdMethods_MouseDown;
			grdMethods.DragOver += grdMethods_DragOver;
			grdMethods.DragDrop += grdMethods_DragDrop;
			grdMethods.DefaultCellStyle.SelectionBackColor = grdMethods.DefaultCellStyle.BackColor;
			grdMethods.DefaultCellStyle.SelectionForeColor = grdMethods.DefaultCellStyle.ForeColor;
		}

		public void SetData(ObservableCollection<ReadMethodModel> readMethods, ObservableCollection<PropertyModel> properties, ObservableCollection<NavPropertyModel> navProperties)
		{
			_readMethods = readMethods;

			bindingSrc.DataSource = _readMethods.OrderBy(m => m.DisplayOrder);
			grdMethods.DataSource = bindingSrc;

			filterPropsCtl.SetProperties(properties);

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
			var method = ReadMethodModel.CreateNew(Guid.NewGuid(), "Query");
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
				var method = _readMethods.FirstOrDefault(m => m.Id == Guid.Parse(idValStr));

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
		}

		private void SetInclNavPropertiesList(ReadMethodModel method)
		{
			_suspendUpdates = true;

			for (var i = 0; i < clbNavProperties.Items.Count; i++) {
				if (method == null) {
					clbNavProperties.SetItemChecked(i, false);
					continue;
				}
				var navProp = clbNavProperties.Items[i] as NavPropertyModel;
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

		private ReadMethodModel GetMethodFromGridRow(int rowIndex)
		{
			var idValStr = grdMethods.Rows[rowIndex].Cells[cIdCol].Value?.ToString();
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
				filterPropsCtl.SetFilterProperties(method.FilterProperties);
				SetInclNavPropertiesList(method);
				clbNavProperties.Enabled = true;
			} else {
				filterPropsCtl.SetFilterProperties(null);
				SetInclNavPropertiesList(null);
			}
			_suspendUpdates = false;
		}

		private void grdMethods_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			this.grdMethods.Cursor = Cursors.Default;
		}

		private void clbNavProperties_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (_suspendUpdates == true)
				return;

			if (e.NewValue == CheckState.Indeterminate)
				return;

			var navProp = clbNavProperties.Items[e.Index] as NavPropertyModel;
			if (navProp == null)
				return;

			var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);

			if (e.NewValue == CheckState.Checked) {
				if (!method.InclNavProperties.Contains(navProp))
					method.InclNavProperties.Add(navProp);
			} else {
				if (method.InclNavProperties.Contains(navProp))
					method.InclNavProperties.Remove(navProp);
			}
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
				var srcMethod = _readMethods.FirstOrDefault(m => m.DisplayOrder == srcRowIdx);
				if (srcRowIdx < destRowIdx) {
					foreach (var readMethod in _readMethods.ToList().Where(m => m.DisplayOrder > srcRowIdx && m.DisplayOrder <= destRowIdx))
						readMethod.DisplayOrder--;
					srcMethod.DisplayOrder = destRowIdx;
				} else {
					foreach (var readMethod in _readMethods.ToList().Where(m => m.DisplayOrder >= destRowIdx && m.DisplayOrder < srcRowIdx))
						readMethod.DisplayOrder++;
					srcMethod.DisplayOrder = destRowIdx;
				}

				SuspendLayout();
				bindingSrc.DataSource = _readMethods.OrderBy(m => m.DisplayOrder);
				grdMethods.ResetBindings();
				ResumeLayout();
			}
		}

		#endregion
	}
}
