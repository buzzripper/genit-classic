namespace Dyvenix.Genit.UserControls;

partial class QueryMethodsListCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryMethodsListCtl));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnAdd = new System.Windows.Forms.ToolStripButton();
		btnDelete = new System.Windows.Forms.ToolStripButton();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		grdQueries = new System.Windows.Forms.DataGridView();
		colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colInclSorting = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colInclPaging = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colAttrs = new System.Windows.Forms.DataGridViewLinkColumn();
		colDelete = new System.Windows.Forms.DataGridViewImageColumn();
		bindingSrc = new System.Windows.Forms.BindingSource(components);
		splMain = new System.Windows.Forms.SplitContainer();
		splProperties = new System.Windows.Forms.SplitContainer();
		clbDtoProperties = new System.Windows.Forms.CheckedListBox();
		pnlDtoPropsHeader = new System.Windows.Forms.Panel();
		ckbAllDtoProperties = new System.Windows.Forms.CheckBox();
		label2 = new System.Windows.Forms.Label();
		filterPropsEditCtl1 = new FilterPropsEditCtl();
		toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)grdQueries).BeginInit();
		((System.ComponentModel.ISupportInitialize)bindingSrc).BeginInit();
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splProperties).BeginInit();
		splProperties.Panel1.SuspendLayout();
		splProperties.Panel2.SuspendLayout();
		splProperties.SuspendLayout();
		pnlDtoPropsHeader.SuspendLayout();
		SuspendLayout();
		// 
		// toolStrip1
		// 
		toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnDelete, toolStripLabel1 });
		toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(607, 33);
		toolStrip1.TabIndex = 1;
		toolStrip1.Text = "toolStrip1";
		// 
		// btnAdd
		// 
		btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnAdd.Image = (System.Drawing.Image)resources.GetObject("btnAdd.Image");
		btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(34, 28);
		btnAdd.Text = "toolStripButton1";
		btnAdd.Click += btnAdd_Click;
		// 
		// btnDelete
		// 
		btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
		toolStripLabel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
		toolStripLabel1.Size = new System.Drawing.Size(158, 28);
		toolStripLabel1.Text = "Query Methods";
		// 
		// grdQueries
		// 
		grdQueries.AllowUserToAddRows = false;
		grdQueries.AllowUserToResizeColumns = false;
		grdQueries.AllowUserToResizeRows = false;
		grdQueries.BackgroundColor = System.Drawing.SystemColors.Control;
		grdQueries.BorderStyle = System.Windows.Forms.BorderStyle.None;
		grdQueries.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		grdQueries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		grdQueries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colName, colInclSorting, colInclPaging, colAttrs, colDelete });
		grdQueries.Dock = System.Windows.Forms.DockStyle.Fill;
		grdQueries.Location = new System.Drawing.Point(0, 33);
		grdQueries.MultiSelect = false;
		grdQueries.Name = "grdQueries";
		grdQueries.RowHeadersVisible = false;
		grdQueries.RowHeadersWidth = 62;
		grdQueries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdQueries.ShowEditingIcon = false;
		grdQueries.Size = new System.Drawing.Size(607, 538);
		grdQueries.TabIndex = 2;
		grdQueries.CellClick += grdItems_CellClick;
		grdQueries.CellMouseEnter += grdItems_CellMouseEnter;
		grdQueries.CellMouseLeave += grdItems_CellMouseLeave;
		grdQueries.DataError += grdItems_DataError;
		grdQueries.SelectionChanged += grdItems_SelectionChanged;
		grdQueries.KeyDown += grdItems_KeyDown;
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
		colName.MinimumWidth = 100;
		colName.Name = "colName";
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
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
		colAttrs.DefaultCellStyle = dataGridViewCellStyle1;
		colAttrs.HeaderText = "Attrs";
		colAttrs.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		colAttrs.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		colAttrs.MinimumWidth = 75;
		colAttrs.Name = "colAttrs";
		colAttrs.ReadOnly = true;
		colAttrs.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colAttrs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
		// splMain
		// 
		splMain.Dock = System.Windows.Forms.DockStyle.Fill;
		splMain.Location = new System.Drawing.Point(0, 0);
		splMain.Name = "splMain";
		// 
		// splMain.Panel1
		// 
		splMain.Panel1.Controls.Add(grdQueries);
		splMain.Panel1.Controls.Add(toolStrip1);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.Controls.Add(splProperties);
		splMain.Size = new System.Drawing.Size(1453, 571);
		splMain.SplitterDistance = 607;
		splMain.SplitterWidth = 8;
		splMain.TabIndex = 3;
		// 
		// splProperties
		// 
		splProperties.Dock = System.Windows.Forms.DockStyle.Fill;
		splProperties.Location = new System.Drawing.Point(0, 0);
		splProperties.Name = "splProperties";
		// 
		// splProperties.Panel1
		// 
		splProperties.Panel1.Controls.Add(filterPropsEditCtl1);
		// 
		// splProperties.Panel2
		// 
		splProperties.Panel2.Controls.Add(clbDtoProperties);
		splProperties.Panel2.Controls.Add(pnlDtoPropsHeader);
		splProperties.Size = new System.Drawing.Size(838, 571);
		splProperties.SplitterDistance = 476;
		splProperties.SplitterWidth = 8;
		splProperties.TabIndex = 3;
		// 
		// clbDtoProperties
		// 
		clbDtoProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		clbDtoProperties.Dock = System.Windows.Forms.DockStyle.Fill;
		clbDtoProperties.FormattingEnabled = true;
		clbDtoProperties.IntegralHeight = false;
		clbDtoProperties.Location = new System.Drawing.Point(0, 42);
		clbDtoProperties.Name = "clbDtoProperties";
		clbDtoProperties.Size = new System.Drawing.Size(354, 529);
		clbDtoProperties.TabIndex = 2;
		// 
		// pnlDtoPropsHeader
		// 
		pnlDtoPropsHeader.Controls.Add(ckbAllDtoProperties);
		pnlDtoPropsHeader.Controls.Add(label2);
		pnlDtoPropsHeader.Dock = System.Windows.Forms.DockStyle.Top;
		pnlDtoPropsHeader.Location = new System.Drawing.Point(0, 0);
		pnlDtoPropsHeader.Name = "pnlDtoPropsHeader";
		pnlDtoPropsHeader.Size = new System.Drawing.Size(354, 42);
		pnlDtoPropsHeader.TabIndex = 3;
		// 
		// ckbAllDtoProperties
		// 
		ckbAllDtoProperties.AutoSize = true;
		ckbAllDtoProperties.Location = new System.Drawing.Point(178, 1);
		ckbAllDtoProperties.Name = "ckbAllDtoProperties";
		ckbAllDtoProperties.Size = new System.Drawing.Size(61, 32);
		ckbAllDtoProperties.TabIndex = 1;
		ckbAllDtoProperties.Text = "All";
		ckbAllDtoProperties.UseVisualStyleBackColor = true;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(5, 1);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(143, 28);
		label2.TabIndex = 0;
		label2.Text = "DTO Properties";
		// 
		// filterPropsEditCtl1
		// 
		filterPropsEditCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
		filterPropsEditCtl1.Location = new System.Drawing.Point(0, 0);
		filterPropsEditCtl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		filterPropsEditCtl1.Name = "filterPropsEditCtl1";
		filterPropsEditCtl1.Size = new System.Drawing.Size(476, 571);
		filterPropsEditCtl1.TabIndex = 0;
		// 
		// QueryMethodsListCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ControlDarkDark;
		BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		Controls.Add(splMain);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "QueryMethodsListCtl";
		Size = new System.Drawing.Size(1453, 571);
		Load += GetMethodsListCtl_Load;
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)grdQueries).EndInit();
		((System.ComponentModel.ISupportInitialize)bindingSrc).EndInit();
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel1.PerformLayout();
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		splProperties.Panel1.ResumeLayout(false);
		splProperties.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splProperties).EndInit();
		splProperties.ResumeLayout(false);
		pnlDtoPropsHeader.ResumeLayout(false);
		pnlDtoPropsHeader.PerformLayout();
		ResumeLayout(false);
	}

	#endregion
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripButton btnAdd;
	private System.Windows.Forms.ToolStripButton btnDelete;
	private System.Windows.Forms.DataGridView grdQueries;
	private System.Windows.Forms.BindingSource bindingSrc;
	private System.Windows.Forms.ToolStripLabel toolStripLabel1;
	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.ToolStrip toolStrip2;
	private System.Windows.Forms.ToolStripLabel toolStripLabel2;
	private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
	private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem selectDTOToolStripMenuItem;
	private System.Windows.Forms.SplitContainer splitContainer1;
	private System.Windows.Forms.SplitContainer splProperties;
	private System.Windows.Forms.Panel pnlDtoPropsHeader;
	private System.Windows.Forms.CheckBox ckbAllDtoProperties;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.CheckedListBox clbDtoProperties;
	private System.Windows.Forms.DataGridViewTextBoxColumn colId;
	private System.Windows.Forms.DataGridViewTextBoxColumn colName;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclSorting;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclPaging;
	private System.Windows.Forms.DataGridViewLinkColumn colAttrs;
	private System.Windows.Forms.DataGridViewImageColumn colDelete;
	private FilterPropsEditCtl filterPropsEditCtl1;
}
