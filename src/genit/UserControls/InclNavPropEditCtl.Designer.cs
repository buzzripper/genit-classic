namespace Dyvenix.Genit.UserControls;

partial class InclNavPropEditCtl
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
		grdNavProps = new System.Windows.Forms.DataGridView();
		colUpdPropId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colInclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		tbTitle = new System.Windows.Forms.ToolStripLabel();
		((System.ComponentModel.ISupportInitialize)grdNavProps).BeginInit();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// grdNavProps
		// 
		grdNavProps.AllowUserToAddRows = false;
		grdNavProps.AllowUserToDeleteRows = false;
		grdNavProps.AllowUserToResizeRows = false;
		grdNavProps.BackgroundColor = System.Drawing.SystemColors.Control;
		grdNavProps.BorderStyle = System.Windows.Forms.BorderStyle.None;
		grdNavProps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		grdNavProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		grdNavProps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colUpdPropId, colInclude, colProperty });
		grdNavProps.Dock = System.Windows.Forms.DockStyle.Fill;
		grdNavProps.Location = new System.Drawing.Point(0, 25);
		grdNavProps.Margin = new System.Windows.Forms.Padding(2);
		grdNavProps.MultiSelect = false;
		grdNavProps.Name = "grdNavProps";
		grdNavProps.RowHeadersVisible = false;
		grdNavProps.RowHeadersWidth = 62;
		grdNavProps.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdNavProps.ShowEditingIcon = false;
		grdNavProps.Size = new System.Drawing.Size(326, 429);
		grdNavProps.TabIndex = 10;
		grdNavProps.CellValueChanged += grdProps_CellValueChanged;
		grdNavProps.CurrentCellDirtyStateChanged += grdProps_CurrentCellDirtyStateChanged;
		// 
		// colUpdPropId
		// 
		colUpdPropId.HeaderText = "Id";
		colUpdPropId.MinimumWidth = 40;
		colUpdPropId.Name = "colUpdPropId";
		colUpdPropId.Visible = false;
		colUpdPropId.Width = 150;
		// 
		// colInclude
		// 
		colInclude.HeaderText = "";
		colInclude.MinimumWidth = 50;
		colInclude.Name = "colInclude";
		colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colInclude.Width = 50;
		// 
		// colProperty
		// 
		colProperty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		colProperty.HeaderText = "Name";
		colProperty.MinimumWidth = 100;
		colProperty.Name = "colProperty";
		colProperty.ReadOnly = true;
		colProperty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		// 
		// toolStrip1
		// 
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tbTitle });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
		toolStrip1.Size = new System.Drawing.Size(326, 25);
		toolStrip1.TabIndex = 9;
		toolStrip1.Text = "toolStrip1";
		// 
		// tbTitle
		// 
		tbTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tbTitle.Name = "tbTitle";
		tbTitle.Size = new System.Drawing.Size(196, 22);
		tbTitle.Text = "Navigation Properties to Include";
		// 
		// InclNavPropEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(grdNavProps);
		Controls.Add(toolStrip1);
		Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "InclNavPropEditCtl";
		Size = new System.Drawing.Size(326, 454);
		((System.ComponentModel.ISupportInitialize)grdNavProps).EndInit();
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.DataGridView grdNavProps;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripLabel tbTitle;
	private System.Windows.Forms.DataGridViewTextBoxColumn colUpdPropId;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclude;
	private System.Windows.Forms.DataGridViewTextBoxColumn colProperty;
}
