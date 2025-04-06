using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
	public partial class ServiceMethodsEditCtl : UserControlBase
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

			filterPropsCtl.SetProperties(properties);

			lbxNavProperties.Items.Clear();
			lbxNavProperties.Items.AddRange(navProperties.ToArray());
		}

		#endregion

		#region Add

		private void btnAdd_Click(object sender, EventArgs e)
		{
			this.Add();
		}

		private void Add()
		{
			var method = ServiceMethodModel.CreateNew(Guid.NewGuid(), "Query");
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

			//lblFilterProperties.Height = toolStrip1.Height;

			lblInclNavProps.Height = toolStrip1.Height;
			lbxNavProperties.Left = 0;
			lbxNavProperties.Top = lblInclNavProps.Height + 1;
			lbxNavProperties.Width = splLists.Panel2.Width;
			lbxNavProperties.Height = splLists.Panel2.Height - toolStrip1.Height;
			lbxNavProperties.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
		}

		

		private void SetInclNavPropertiesList(ServiceMethodModel method)
		{
			_suspendUpdates = true;

			lbxNavProperties.SelectedItems.Clear();
			for (var i = 0; i < lbxNavProperties.Items.Count; i++) {
				var navProp = (NavPropertyModel)lbxNavProperties.Items[i];
				if (method.InclNavProperties.Contains(navProp))
					lbxNavProperties.SelectedItems.Add(navProp);
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
				filterPropsCtl.SetFilterProperties(method.FilterProperties);
				SetInclNavPropertiesList(method);
				lbxNavProperties.Enabled = true;

			} else {
				filterPropsCtl.SetFilterProperties(null);
			}

			_suspendUpdates = false;
		}

		
		private void grdMethods_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			this.grdMethods.Cursor = Cursors.Default;
		}

		private void lbxNavProperties_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_suspendUpdates)
				return;

			var method = GetMethodFromGridRow(grdMethods.CurrentCell.RowIndex);

			foreach (var item in lbxNavProperties.Items) {
				NavPropertyModel navProp = item as NavPropertyModel;
				var isSelected = lbxNavProperties.SelectedItems.Contains(navProp);
				var isFilterProp = method.InclNavProperties.Contains(navProp);

				if (isSelected) {
					if (!isFilterProp) {
						method.InclNavProperties.Add(navProp);
						break;
					}
				} else {
					// not selected
					if (isFilterProp) {
						method.InclNavProperties.Remove(navProp);
						break;
					}
				}
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

		#endregion
	}
}
