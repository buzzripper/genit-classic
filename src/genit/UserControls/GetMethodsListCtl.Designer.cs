using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
    public partial class GetMethodsListCtl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetMethodsListCtl));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			toolStrip1 = new ToolStrip();
			btnAdd = new ToolStripButton();
			btnDelete = new ToolStripButton();
			toolStripLabel1 = new ToolStripLabel();
			grdItems = new DataGridView();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colIsList = new DataGridViewCheckBoxColumn();
			colInclSorting = new DataGridViewCheckBoxColumn();
			colInclPaging = new DataGridViewCheckBoxColumn();
			colAttrs = new DataGridViewLinkColumn();
			colDelete = new DataGridViewImageColumn();
			bindingSrc = new BindingSource(components);
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)grdItems).BeginInit();
			((System.ComponentModel.ISupportInitialize)bindingSrc).BeginInit();
			SuspendLayout();
			// 
			// toolStrip1
			// 
			toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdd, btnDelete, toolStripLabel1 });
			toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(656, 33);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
			// 
			// btnAdd
			// 
			btnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
			btnAdd.Image = (System.Drawing.Image)resources.GetObject("btnAdd.Image");
			btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(34, 28);
			btnAdd.Text = "toolStripButton1";
			btnAdd.Click += btnAdd_Click;
			// 
			// btnDelete
			// 
			btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
			btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
			btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new System.Drawing.Size(34, 28);
			btnDelete.Text = "toolStripButton3";
			btnDelete.Click += btnDelete_Click;
			// 
			// toolStripLabel1
			// 
			toolStripLabel1.Name = "toolStripLabel1";
			toolStripLabel1.Padding = new Padding(300, 0, 0, 0);
			toolStripLabel1.Size = new System.Drawing.Size(436, 28);
			toolStripLabel1.Text = "'Get' Methods";
			// 
			// grdItems
			// 
			grdItems.AllowUserToAddRows = false;
			grdItems.AllowUserToResizeColumns = false;
			grdItems.AllowUserToResizeRows = false;
			grdItems.BackgroundColor = System.Drawing.SystemColors.Control;
			grdItems.BorderStyle = BorderStyle.None;
			grdItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
			grdItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdItems.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colIsList, colInclSorting, colInclPaging, colAttrs, colDelete });
			grdItems.Location = new System.Drawing.Point(3, 41);
			grdItems.MultiSelect = false;
			grdItems.Name = "grdItems";
			grdItems.RowHeadersVisible = false;
			grdItems.RowHeadersWidth = 62;
			grdItems.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			grdItems.ShowEditingIcon = false;
			grdItems.Size = new System.Drawing.Size(619, 289);
			grdItems.TabIndex = 2;
			grdItems.CellClick += grdItems_CellClick;
			grdItems.CellMouseEnter += grdItems_CellMouseEnter;
			grdItems.CellMouseLeave += grdItems_CellMouseLeave;
			grdItems.DataError += grdItems_DataError;
			grdItems.SelectionChanged += grdItems_SelectionChanged;
			grdItems.KeyDown += grdItems_KeyDown;
			// 
			// colId
			// 
			colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colId.DataPropertyName = "Id";
			colId.HeaderText = "Id";
			colId.MinimumWidth = 40;
			colId.Name = "colId";
			colId.Visible = false;
			// 
			// colName
			// 
			colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colName.DataPropertyName = "Name";
			colName.HeaderText = "Name";
			colName.MinimumWidth = 200;
			colName.Name = "colName";
			// 
			// colIsList
			// 
			colIsList.DataPropertyName = "IsList";
			colIsList.HeaderText = "Is List";
			colIsList.MinimumWidth = 75;
			colIsList.Name = "colIsList";
			colIsList.Width = 75;
			// 
			// colInclSorting
			// 
			colInclSorting.DataPropertyName = "InclSorting";
			colInclSorting.HeaderText = "Sorting";
			colInclSorting.MinimumWidth = 85;
			colInclSorting.Name = "colInclSorting";
			colInclSorting.Width = 85;
			// 
			// colInclPaging
			// 
			colInclPaging.DataPropertyName = "InclPaging";
			colInclPaging.HeaderText = "Paging";
			colInclPaging.MinimumWidth = 85;
			colInclPaging.Name = "colInclPaging";
			colInclPaging.Width = 85;
			// 
			// colAttrs
			// 
			colAttrs.ActiveLinkColor = System.Drawing.SystemColors.MenuHighlight;
			colAttrs.DataPropertyName = "AttrCount";
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
			colAttrs.DefaultCellStyle = dataGridViewCellStyle1;
			colAttrs.HeaderText = "Attrs";
			colAttrs.LinkBehavior = LinkBehavior.NeverUnderline;
			colAttrs.LinkColor = System.Drawing.SystemColors.MenuHighlight;
			colAttrs.MinimumWidth = 75;
			colAttrs.Name = "colAttrs";
			colAttrs.ReadOnly = true;
			colAttrs.Resizable = DataGridViewTriState.False;
			colAttrs.SortMode = DataGridViewColumnSortMode.Automatic;
			colAttrs.Text = "";
			colAttrs.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
			colAttrs.Width = 75;
			// 
			// colDelete
			// 
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.NullValue = resources.GetObject("dataGridViewCellStyle2.NullValue");
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
			colDelete.DefaultCellStyle = dataGridViewCellStyle2;
			colDelete.HeaderText = "";
			colDelete.Image = (System.Drawing.Image)resources.GetObject("colDelete.Image");
			colDelete.MinimumWidth = 75;
			colDelete.Name = "colDelete";
			colDelete.Width = 75;
			// 
			// GetMethodsListCtl
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.ControlDarkDark;
			BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(grdItems);
			Controls.Add(toolStrip1);
			Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Name = "GetMethodsListCtl";
			Size = new System.Drawing.Size(656, 373);
			Load += GetMethodsListCtl_Load;
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)grdItems).EndInit();
			((System.ComponentModel.ISupportInitialize)bindingSrc).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.DataGridView grdItems;
        private System.Windows.Forms.BindingSource bindingSrc;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInclSorting;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInclPaging;
        private System.Windows.Forms.DataGridViewLinkColumn colAttrs;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}
