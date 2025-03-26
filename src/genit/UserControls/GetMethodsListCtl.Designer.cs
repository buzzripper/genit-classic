namespace Dyvenix.Genit.UserControls;

partial class GetMethodsListCtl
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnAdd = new System.Windows.Forms.ToolStripButton();
		btnDelete = new System.Windows.Forms.ToolStripButton();
		grdItems = new System.Windows.Forms.DataGridView();
		bindingSrc = new System.Windows.Forms.BindingSource(components);
		colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colProperty = new System.Windows.Forms.DataGridViewComboBoxColumn();
		colIsList = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colAttrs = new System.Windows.Forms.DataGridViewLinkColumn();
		colDelete = new System.Windows.Forms.DataGridViewImageColumn();
		toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)grdItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)bindingSrc).BeginInit();
		SuspendLayout();
		// 
		// toolStrip1
		// 
		toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnDelete });
		toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(656, 25);
		toolStrip1.TabIndex = 1;
		toolStrip1.Text = "toolStrip1";
		// 
		// btnAdd
		// 
		btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnAdd.Image = (System.Drawing.Image)resources.GetObject("btnAdd.Image");
		btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(23, 22);
		btnAdd.Text = "toolStripButton1";
		btnAdd.Click += btnAdd_Click;
		// 
		// btnDelete
		// 
		btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
		btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnDelete.Name = "btnDelete";
		btnDelete.Size = new System.Drawing.Size(23, 22);
		btnDelete.Text = "toolStripButton3";
		btnDelete.Click += btnDelete_Click;
		// 
		// grdItems
		// 
		grdItems.AllowUserToAddRows = false;
		grdItems.AllowUserToResizeColumns = false;
		grdItems.AllowUserToResizeRows = false;
		grdItems.BackgroundColor = System.Drawing.SystemColors.Control;
		grdItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
		grdItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		grdItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colName, colProperty, colIsList, colAttrs, colDelete });
		grdItems.Location = new System.Drawing.Point(3, 41);
		grdItems.MultiSelect = false;
		grdItems.Name = "grdItems";
		grdItems.RowHeadersVisible = false;
		grdItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdItems.ShowEditingIcon = false;
		grdItems.Size = new System.Drawing.Size(548, 203);
		grdItems.TabIndex = 2;
		grdItems.CellClick += grdItems_CellClick;
		grdItems.CellMouseEnter += grdItems_CellMouseEnter;
		grdItems.CellMouseLeave += grdItems_CellMouseLeave;
		grdItems.DataError += grdItems_DataError;
		grdItems.SelectionChanged += grdItems_SelectionChanged;
		grdItems.Click += grdItems_Click;
		grdItems.KeyDown += grdItems_KeyDown;
		// 
		// colId
		// 
		colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		colId.DataPropertyName = "Id";
		colId.HeaderText = "Id";
		colId.MinimumWidth = 40;
		colId.Name = "colId";
		colId.Visible = false;
		// 
		// colName
		// 
		colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		colName.DataPropertyName = "Name";
		colName.HeaderText = "Name";
		colName.MinimumWidth = 200;
		colName.Name = "colName";
		// 
		// colProperty
		// 
		colProperty.DataPropertyName = "FilterPropertyId";
		colProperty.HeaderText = "Property";
		colProperty.MinimumWidth = 150;
		colProperty.Name = "colProperty";
		colProperty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		colProperty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		colProperty.Width = 150;
		// 
		// colIsList
		// 
		colIsList.DataPropertyName = "IsList";
		colIsList.HeaderText = "Is List";
		colIsList.MinimumWidth = 75;
		colIsList.Name = "colIsList";
		colIsList.Width = 75;
		// 
		// colAttrs
		// 
		colAttrs.ActiveLinkColor = System.Drawing.SystemColors.MenuHighlight;
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
		colAttrs.DefaultCellStyle = dataGridViewCellStyle1;
		colAttrs.HeaderText = "";
		colAttrs.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		colAttrs.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		colAttrs.MinimumWidth = 75;
		colAttrs.Name = "colAttrs";
		colAttrs.ReadOnly = true;
		colAttrs.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colAttrs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		colAttrs.Text = "Attrs";
		colAttrs.UseColumnTextForLinkValue = true;
		colAttrs.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
		colAttrs.Width = 75;
		// 
		// colDelete
		// 
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ControlDarkDark;
		BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
	private System.Windows.Forms.DataGridViewTextBoxColumn colId;
	private System.Windows.Forms.DataGridViewTextBoxColumn colName;
	private System.Windows.Forms.DataGridViewComboBoxColumn colProperty;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colIsList;
	private System.Windows.Forms.DataGridViewLinkColumn colAttrs;
	private System.Windows.Forms.DataGridViewImageColumn colDelete;
}
