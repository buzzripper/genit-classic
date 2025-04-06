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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
		lbxNavProperties = new System.Windows.Forms.ListBox();
		lblInclNavProps = new System.Windows.Forms.Label();
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
		((System.ComponentModel.ISupportInitialize)bindingSrc).BeginInit();
		SuspendLayout();
		// 
		// splMain
		// 
		splMain.AllowDrop = true;
		splMain.Location = new System.Drawing.Point(17, 13);
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
		splMain.Size = new System.Drawing.Size(1421, 612);
		splMain.SplitterDistance = 861;
		splMain.SplitterWidth = 9;
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
		grdMethods.Location = new System.Drawing.Point(0, 33);
		grdMethods.MultiSelect = false;
		grdMethods.Name = "grdMethods";
		grdMethods.RowHeadersWidth = 62;
		grdMethods.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdMethods.ShowEditingIcon = false;
		grdMethods.Size = new System.Drawing.Size(861, 579);
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
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
		colAttrs.DefaultCellStyle = dataGridViewCellStyle3;
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
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.NullValue = resources.GetObject("dataGridViewCellStyle4.NullValue");
		dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
		colDelete.DefaultCellStyle = dataGridViewCellStyle4;
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
		toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
		toolStrip1.Size = new System.Drawing.Size(861, 33);
		toolStrip1.TabIndex = 2;
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
		// toolStripLabel1
		// 
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
		toolStripLabel1.Size = new System.Drawing.Size(140, 28);
		toolStripLabel1.Text = "Methods";
		// 
		// splLists
		// 
		splLists.Dock = System.Windows.Forms.DockStyle.Fill;
		splLists.Location = new System.Drawing.Point(0, 0);
		splLists.Name = "splLists";
		splLists.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splLists.Panel1
		// 
		splLists.Panel1.Controls.Add(filterPropsCtl);
		// 
		// splLists.Panel2
		// 
		splLists.Panel2.Controls.Add(lbxNavProperties);
		splLists.Panel2.Controls.Add(lblInclNavProps);
		splLists.Size = new System.Drawing.Size(551, 612);
		splLists.SplitterDistance = 358;
		splLists.SplitterWidth = 10;
		splLists.TabIndex = 5;
		// 
		// filterPropsCtl
		// 
		filterPropsCtl.Dock = System.Windows.Forms.DockStyle.Fill;
		filterPropsCtl.Location = new System.Drawing.Point(0, 0);
		filterPropsCtl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		filterPropsCtl.Name = "filterPropsCtl";
		filterPropsCtl.Size = new System.Drawing.Size(551, 358);
		filterPropsCtl.TabIndex = 0;
		// 
		// lbxNavProperties
		// 
		lbxNavProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		lbxNavProperties.FormattingEnabled = true;
		lbxNavProperties.Location = new System.Drawing.Point(32, 45);
		lbxNavProperties.Name = "lbxNavProperties";
		lbxNavProperties.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
		lbxNavProperties.Size = new System.Drawing.Size(362, 177);
		lbxNavProperties.TabIndex = 6;
		// 
		// lblInclNavProps
		// 
		lblInclNavProps.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		lblInclNavProps.Dock = System.Windows.Forms.DockStyle.Top;
		lblInclNavProps.Location = new System.Drawing.Point(0, 0);
		lblInclNavProps.Name = "lblInclNavProps";
		lblInclNavProps.Size = new System.Drawing.Size(551, 28);
		lblInclNavProps.TabIndex = 5;
		lblInclNavProps.Text = "Include Navigation Properties";
		// 
		// ServiceMethodsEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(splMain);
		Name = "ServiceMethodsEditCtl";
		Size = new System.Drawing.Size(1614, 658);
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
		((System.ComponentModel.ISupportInitialize)splLists).EndInit();
		splLists.ResumeLayout(false);
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
	private System.Windows.Forms.Label lblInclNavProps;
	private System.Windows.Forms.DataGridViewTextBoxColumn colId;
	private System.Windows.Forms.DataGridViewTextBoxColumn colName;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclSorting;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclPaging;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colUseQuery;
	private System.Windows.Forms.DataGridViewLinkColumn colAttrs;
	private System.Windows.Forms.DataGridViewImageColumn colDelete;
	private System.Windows.Forms.ListBox lbxNavProperties;
	private FilterPropsEditCtl filterPropsCtl;
}
