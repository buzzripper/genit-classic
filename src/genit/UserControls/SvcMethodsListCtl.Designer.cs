namespace Dyvenix.Genit.UserControls;

partial class SvcMethodsListCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SvcMethodsListCtl));
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnAdd = new System.Windows.Forms.ToolStripButton();
		btnDelete = new System.Windows.Forms.ToolStripButton();
		grdItems = new System.Windows.Forms.DataGridView();
		bindingSource = new System.Windows.Forms.BindingSource(components);
		colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colProperty = new System.Windows.Forms.DataGridViewComboBoxColumn();
		toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)grdItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
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
		toolStrip1.Size = new System.Drawing.Size(370, 25);
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
		grdItems.ColumnHeadersVisible = false;
		grdItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colName, colProperty });
		grdItems.Location = new System.Drawing.Point(16, 41);
		grdItems.MultiSelect = false;
		grdItems.Name = "grdItems";
		grdItems.RowHeadersVisible = false;
		grdItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdItems.ShowEditingIcon = false;
		grdItems.Size = new System.Drawing.Size(310, 98);
		grdItems.TabIndex = 2;
		grdItems.CellEndEdit += grdItems_CellEndEdit;
		grdItems.CellValidating += grdItems_CellValidating;
		grdItems.SelectionChanged += grdItems_SelectionChanged;
		grdItems.KeyDown += grdItems_KeyDown;
		// 
		// colId
		// 
		colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		colId.HeaderText = "Id";
		colId.Name = "colId";
		colId.Visible = false;
		// 
		// colName
		// 
		colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		colName.HeaderText = "Name";
		colName.MinimumWidth = 200;
		colName.Name = "colName";
		// 
		// colProperty
		// 
		colProperty.HeaderText = "Property";
		colProperty.Name = "colProperty";
		colProperty.Width = 250;
		// 
		// SvcMethodsListCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ControlDarkDark;
		BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		Controls.Add(grdItems);
		Controls.Add(toolStrip1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "SvcMethodsListCtl";
		Size = new System.Drawing.Size(370, 193);
		Load += StringListEditor_Load;
		Layout += StringListEditor_Layout;
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)grdItems).EndInit();
		((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripButton btnAdd;
	private System.Windows.Forms.ToolStripButton btnDelete;
	private System.Windows.Forms.DataGridView grdItems;
	private System.Windows.Forms.BindingSource bindingSource;
	private System.Windows.Forms.DataGridViewTextBoxColumn colId;
	private System.Windows.Forms.DataGridViewTextBoxColumn colName;
	private System.Windows.Forms.DataGridViewComboBoxColumn colProperty;
}
