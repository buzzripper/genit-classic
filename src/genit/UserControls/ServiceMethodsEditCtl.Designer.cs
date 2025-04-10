namespace Dyvenix.Genit.UserControls;

partial class ServiceMethodsEditCtl
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceMethodsEditCtl));
		splMain = new System.Windows.Forms.SplitContainer();
		grdMethods = new System.Windows.Forms.DataGridView();
		colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colInclPaging = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colUseQuery = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colInclSorting = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colAttrs = new System.Windows.Forms.DataGridViewLinkColumn();
		colDelete = new System.Windows.Forms.DataGridViewImageColumn();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnAdd = new System.Windows.Forms.ToolStripButton();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		splLists = new System.Windows.Forms.SplitContainer();
		filterPropsCtl = new FilterPropsEditCtl();
		clbNavProperties = new System.Windows.Forms.CheckedListBox();
		toolStrip2 = new System.Windows.Forms.ToolStrip();
		toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
		bindingSrc = new System.Windows.Forms.BindingSource(components);
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)grdMethods).BeginInit();
		toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splLists).BeginInit();
		splLists.Panel1.SuspendLayout();
		splLists.Panel2.SuspendLayout();
		splLists.SuspendLayout();
		toolStrip2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)bindingSrc).BeginInit();
		SuspendLayout();
		// 
		// splMain
		// 
		splMain.AllowDrop = true;
		splMain.Location = new System.Drawing.Point(12, 8);
		splMain.Margin = new System.Windows.Forms.Padding(2);
		splMain.Name = "splMain";
		// 
		// splMain.Panel1
		// 
		splMain.Panel1.AllowDrop = true;
		splMain.Panel1.Controls.Add(grdMethods);
		splMain.Panel1.Controls.Add(toolStrip1);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.Controls.Add(splLists);
		splMain.Size = new System.Drawing.Size(995, 367);
		splMain.SplitterDistance = 602;
		splMain.SplitterWidth = 6;
		splMain.TabIndex = 0;
		// 
		// grdMethods
		// 
		grdMethods.AllowUserToAddRows = false;
		grdMethods.AllowUserToResizeRows = false;
		grdMethods.BackgroundColor = System.Drawing.SystemColors.Control;
		grdMethods.BorderStyle = System.Windows.Forms.BorderStyle.None;
		grdMethods.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		grdMethods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		grdMethods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colName, colInclPaging, colUseQuery, colInclSorting, colAttrs, colDelete });
		grdMethods.Dock = System.Windows.Forms.DockStyle.Fill;
		grdMethods.Location = new System.Drawing.Point(0, 31);
		grdMethods.Margin = new System.Windows.Forms.Padding(2);
		grdMethods.MultiSelect = false;
		grdMethods.Name = "grdMethods";
		grdMethods.RowHeadersWidth = 62;
		grdMethods.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdMethods.ShowEditingIcon = false;
		grdMethods.Size = new System.Drawing.Size(602, 336);
		grdMethods.TabIndex = 3;
		grdMethods.CellClick += grdMethods_CellClick;
		grdMethods.CellContentClick += grdMethods_CellContentClick;
		grdMethods.CellMouseEnter += grdMethods_CellMouseEnter;
		grdMethods.CellMouseLeave += grdMethods_CellMouseLeave;
		grdMethods.DataError += grdMethods_DataError;
		grdMethods.SelectionChanged += grdMethods_SelectionChanged;
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
		// colInclPaging
		// 
		colInclPaging.DataPropertyName = "InclPaging";
		colInclPaging.HeaderText = "Paging";
		colInclPaging.MinimumWidth = 85;
		colInclPaging.Name = "colInclPaging";
		colInclPaging.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colInclPaging.Width = 85;
		// 
		// colUseQuery
		// 
		colUseQuery.DataPropertyName = "UseQuery";
		colUseQuery.HeaderText = "Query";
		colUseQuery.MinimumWidth = 85;
		colUseQuery.Name = "colUseQuery";
		colUseQuery.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colUseQuery.Width = 85;
		// 
		// colInclSorting
		// 
		colInclSorting.DataPropertyName = "InclSorting";
		colInclSorting.HeaderText = "Sorting";
		colInclSorting.MinimumWidth = 85;
		colInclSorting.Name = "colInclSorting";
		colInclSorting.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colInclSorting.Width = 85;
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
		colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colDelete.Width = 75;
		// 
		// toolStrip1
		// 
		toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, toolStripLabel1 });
		toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
		toolStrip1.Size = new System.Drawing.Size(602, 31);
		toolStrip1.TabIndex = 2;
		toolStrip1.Text = "toolStrip1";
		// 
		// btnAdd
		// 
		btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnAdd.Image = (System.Drawing.Image)resources.GetObject("btnAdd.Image");
		btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(28, 28);
		btnAdd.Text = "toolStripButton1";
		btnAdd.Click += btnAdd_Click;
		// 
		// toolStripLabel1
		// 
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
		toolStripLabel1.Size = new System.Drawing.Size(114, 28);
		toolStripLabel1.Text = "Methods";
		// 
		// splLists
		// 
		splLists.Dock = System.Windows.Forms.DockStyle.Fill;
		splLists.Location = new System.Drawing.Point(0, 0);
		splLists.Margin = new System.Windows.Forms.Padding(2);
		splLists.Name = "splLists";
		splLists.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splLists.Panel1
		// 
		splLists.Panel1.Controls.Add(filterPropsCtl);
		// 
		// splLists.Panel2
		// 
		splLists.Panel2.Controls.Add(clbNavProperties);
		splLists.Panel2.Controls.Add(toolStrip2);
		splLists.Size = new System.Drawing.Size(387, 367);
		splLists.SplitterDistance = 214;
		splLists.SplitterWidth = 6;
		splLists.TabIndex = 5;
		// 
		// filterPropsCtl
		// 
		filterPropsCtl.Dock = System.Windows.Forms.DockStyle.Fill;
		filterPropsCtl.Location = new System.Drawing.Point(0, 0);
		filterPropsCtl.Name = "filterPropsCtl";
		filterPropsCtl.Size = new System.Drawing.Size(387, 214);
		filterPropsCtl.TabIndex = 0;
		// 
		// clbNavProperties
		// 
		clbNavProperties.Dock = System.Windows.Forms.DockStyle.Fill;
		clbNavProperties.FormattingEnabled = true;
		clbNavProperties.Location = new System.Drawing.Point(0, 25);
		clbNavProperties.Name = "clbNavProperties";
		clbNavProperties.Size = new System.Drawing.Size(387, 122);
		clbNavProperties.TabIndex = 8;
		clbNavProperties.ItemCheck += clbNavProperties_ItemCheck;
		// 
		// toolStrip2
		// 
		toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel2 });
		toolStrip2.Location = new System.Drawing.Point(0, 0);
		toolStrip2.Name = "toolStrip2";
		toolStrip2.Size = new System.Drawing.Size(387, 25);
		toolStrip2.TabIndex = 7;
		toolStrip2.Text = "toolStrip2";
		// 
		// toolStripLabel2
		// 
		toolStripLabel2.Name = "toolStripLabel2";
		toolStripLabel2.Size = new System.Drawing.Size(163, 22);
		toolStripLabel2.Text = "Include Navigation Properties";
		// 
		// ServiceMethodsEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(splMain);
		Margin = new System.Windows.Forms.Padding(2);
		Name = "ServiceMethodsEditCtl";
		Size = new System.Drawing.Size(1130, 395);
		Load += ServiceMethodsEditCtl_Load;
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel1.PerformLayout();
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)grdMethods).EndInit();
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		splLists.Panel1.ResumeLayout(false);
		splLists.Panel2.ResumeLayout(false);
		splLists.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)splLists).EndInit();
		splLists.ResumeLayout(false);
		toolStrip2.ResumeLayout(false);
		toolStrip2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)bindingSrc).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripButton btnAdd;
	private System.Windows.Forms.ToolStripLabel toolStripLabel1;
	private System.Windows.Forms.DataGridView grdMethods;
	private System.Windows.Forms.BindingSource bindingSrc;
	private System.Windows.Forms.SplitContainer splLists;
	private System.Windows.Forms.DataGridViewTextBoxColumn colId;
	private System.Windows.Forms.DataGridViewTextBoxColumn colName;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclSorting;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclPaging;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colUseQuery;
	private System.Windows.Forms.DataGridViewLinkColumn colAttrs;
	private System.Windows.Forms.DataGridViewImageColumn colDelete;
	private FilterPropsEditCtl filterPropsCtl;
	private System.Windows.Forms.ToolStrip toolStrip2;
	private System.Windows.Forms.ToolStripLabel toolStripLabel2;
	private System.Windows.Forms.CheckedListBox clbNavProperties;
}
