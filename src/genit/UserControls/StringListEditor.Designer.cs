namespace Dyvenix.Genit.UserControls;

partial class StringListEditor
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringListEditor));
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnAdd = new System.Windows.Forms.ToolStripButton();
		btnDelete = new System.Windows.Forms.ToolStripButton();
		grdItems = new System.Windows.Forms.DataGridView();
		colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
		toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)grdItems).BeginInit();
		SuspendLayout();
		// 
		// toolStrip1
		// 
		toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnDelete });
		toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
		toolStrip1.Location = new System.Drawing.Point(408, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(24, 351);
		toolStrip1.TabIndex = 1;
		toolStrip1.Text = "toolStrip1";
		// 
		// btnAdd
		// 
		btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnAdd.Image = (System.Drawing.Image)resources.GetObject("btnAdd.Image");
		btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnAdd.Name = "btnAdd";
		btnAdd.Size = new System.Drawing.Size(21, 20);
		btnAdd.Text = "toolStripButton1";
		btnAdd.Click += btnAdd_Click;
		// 
		// btnDelete
		// 
		btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
		btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnDelete.Name = "btnDelete";
		btnDelete.Size = new System.Drawing.Size(21, 20);
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
		grdItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colValue });
		grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
		grdItems.Location = new System.Drawing.Point(0, 0);
		grdItems.MultiSelect = false;
		grdItems.Name = "grdItems";
		grdItems.RowHeadersVisible = false;
		grdItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdItems.ShowEditingIcon = false;
		grdItems.Size = new System.Drawing.Size(408, 351);
		grdItems.TabIndex = 2;
		grdItems.CellBeginEdit += grdItems_CellBeginEdit;
		grdItems.CellEndEdit += grdItems_CellEndEdit;
		grdItems.CellValidating += grdItems_CellValidating;
		grdItems.RowsAdded += grdItems_RowsAdded;
		grdItems.SelectionChanged += grdItems_SelectionChanged;
		// 
		// colValue
		// 
		colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		colValue.HeaderText = "Values";
		colValue.Name = "colValue";
		// 
		// StringListEditor
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.RosyBrown;
		Controls.Add(grdItems);
		Controls.Add(toolStrip1);
		Name = "StringListEditor";
		Size = new System.Drawing.Size(432, 351);
		Load += StringListEditor_Load;
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)grdItems).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripButton btnAdd;
	private System.Windows.Forms.ToolStripButton btnDelete;
	private System.Windows.Forms.DataGridView grdItems;
	private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
}
