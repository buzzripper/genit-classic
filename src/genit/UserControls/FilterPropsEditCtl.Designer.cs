namespace Dyvenix.Genit.UserControls;

partial class FilterPropsEditCtl
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
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		tbTitle = new System.Windows.Forms.ToolStripLabel();
		grdProps = new System.Windows.Forms.DataGridView();
		colFilterPropId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colInclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colIsOptional = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colIsInternal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colIntVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
		toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)grdProps).BeginInit();
		SuspendLayout();
		// 
		// toolStrip1
		// 
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tbTitle });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
		toolStrip1.Size = new System.Drawing.Size(412, 25);
		toolStrip1.TabIndex = 0;
		toolStrip1.Text = "toolStrip1";
		// 
		// tbTitle
		// 
		tbTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tbTitle.Name = "tbTitle";
		tbTitle.Size = new System.Drawing.Size(100, 22);
		tbTitle.Text = "Filter Properties";
		// 
		// grdProps
		// 
		grdProps.AllowUserToAddRows = false;
		grdProps.AllowUserToResizeRows = false;
		grdProps.BackgroundColor = System.Drawing.SystemColors.Control;
		grdProps.BorderStyle = System.Windows.Forms.BorderStyle.None;
		grdProps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		grdProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		grdProps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colFilterPropId, colInclude, colProperty, colIsOptional, colIsInternal, colIntVal });
		grdProps.Dock = System.Windows.Forms.DockStyle.Fill;
		grdProps.Location = new System.Drawing.Point(0, 25);
		grdProps.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		grdProps.MultiSelect = false;
		grdProps.Name = "grdProps";
		grdProps.RowHeadersVisible = false;
		grdProps.RowHeadersWidth = 62;
		grdProps.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdProps.ShowEditingIcon = false;
		grdProps.Size = new System.Drawing.Size(412, 237);
		grdProps.TabIndex = 6;
		grdProps.CellValueChanged += grdProps_CellValueChanged;
		grdProps.CurrentCellDirtyStateChanged += grdProps_CurrentCellDirtyStateChanged;
		// 
		// colFilterPropId
		// 
		colFilterPropId.HeaderText = "Id";
		colFilterPropId.MinimumWidth = 40;
		colFilterPropId.Name = "colFilterPropId";
		colFilterPropId.Visible = false;
		colFilterPropId.Width = 150;
		// 
		// colInclude
		// 
		colInclude.HeaderText = "";
		colInclude.MinimumWidth = 40;
		colInclude.Name = "colInclude";
		colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colInclude.Width = 40;
		// 
		// colProperty
		// 
		colProperty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		colProperty.HeaderText = "Property";
		colProperty.MinimumWidth = 100;
		colProperty.Name = "colProperty";
		colProperty.ReadOnly = true;
		colProperty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		// 
		// colIsOptional
		// 
		colIsOptional.HeaderText = "Opt";
		colIsOptional.MinimumWidth = 50;
		colIsOptional.Name = "colIsOptional";
		colIsOptional.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colIsOptional.Width = 50;
		// 
		// colIsInternal
		// 
		colIsInternal.HeaderText = "Int";
		colIsInternal.MinimumWidth = 50;
		colIsInternal.Name = "colIsInternal";
		colIsInternal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colIsInternal.Width = 50;
		// 
		// colIntVal
		// 
		colIntVal.HeaderText = "Value";
		colIntVal.MinimumWidth = 8;
		colIntVal.Name = "colIntVal";
		colIntVal.Width = 150;
		// 
		// FilterPropsEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(grdProps);
		Controls.Add(toolStrip1);
		Name = "FilterPropsEditCtl";
		Size = new System.Drawing.Size(412, 262);
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)grdProps).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripLabel tbTitle;
	private System.Windows.Forms.DataGridView grdProps;
	private System.Windows.Forms.DataGridViewTextBoxColumn colFilterPropId;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclude;
	private System.Windows.Forms.DataGridViewTextBoxColumn colProperty;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colIsOptional;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colIsInternal;
	private System.Windows.Forms.DataGridViewTextBoxColumn colIntVal;
}
