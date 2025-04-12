namespace Dyvenix.Genit.UserControls;

partial class UpdPropsEditCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdPropsEditCtl));
		grdProps = new System.Windows.Forms.DataGridView();
		colUpdPropId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colInclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		colProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colIsOptional = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		tbTitle = new System.Windows.Forms.ToolStripLabel();
		toolStripButton1 = new System.Windows.Forms.ToolStripButton();
		((System.ComponentModel.ISupportInitialize)grdProps).BeginInit();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// grdProps
		// 
		grdProps.AllowUserToAddRows = false;
		grdProps.AllowUserToDeleteRows = false;
		grdProps.AllowUserToResizeRows = false;
		grdProps.BackgroundColor = System.Drawing.Color.FromArgb(64, 64, 64);
		grdProps.BorderStyle = System.Windows.Forms.BorderStyle.None;
		grdProps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		grdProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		grdProps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colUpdPropId, colInclude, colProperty, colIsOptional });
		grdProps.Dock = System.Windows.Forms.DockStyle.Fill;
		grdProps.Location = new System.Drawing.Point(0, 31);
		grdProps.Margin = new System.Windows.Forms.Padding(2);
		grdProps.MultiSelect = false;
		grdProps.Name = "grdProps";
		grdProps.RowHeadersVisible = false;
		grdProps.RowHeadersWidth = 62;
		grdProps.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdProps.ShowEditingIcon = false;
		grdProps.Size = new System.Drawing.Size(343, 378);
		grdProps.TabIndex = 8;
		grdProps.CellValueChanged += grdProps_CellValueChanged;
		grdProps.CurrentCellDirtyStateChanged += grdProps_CurrentCellDirtyStateChanged;
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
		// colIsOptional
		// 
		colIsOptional.HeaderText = "Opt";
		colIsOptional.MinimumWidth = 60;
		colIsOptional.Name = "colIsOptional";
		colIsOptional.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		colIsOptional.Width = 60;
		// 
		// toolStrip1
		// 
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tbTitle, toolStripButton1 });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
		toolStrip1.Size = new System.Drawing.Size(343, 31);
		toolStrip1.TabIndex = 7;
		toolStrip1.Text = "toolStrip1";
		// 
		// tbTitle
		// 
		tbTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tbTitle.Name = "tbTitle";
		tbTitle.Size = new System.Drawing.Size(131, 28);
		tbTitle.Text = "Properties to Update";
		// 
		// toolStripButton1
		// 
		toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		toolStripButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
		toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		toolStripButton1.Name = "toolStripButton1";
		toolStripButton1.Size = new System.Drawing.Size(28, 28);
		toolStripButton1.Text = "toolStripButton1";
		// 
		// UpdPropsEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(grdProps);
		Controls.Add(toolStrip1);
		Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "UpdPropsEditCtl";
		Size = new System.Drawing.Size(343, 409);
		((System.ComponentModel.ISupportInitialize)grdProps).EndInit();
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.DataGridView grdProps;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripLabel tbTitle;
	private System.Windows.Forms.ToolStripButton toolStripButton1;
	private System.Windows.Forms.DataGridViewTextBoxColumn colUpdPropId;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colInclude;
	private System.Windows.Forms.DataGridViewTextBoxColumn colProperty;
	private System.Windows.Forms.DataGridViewCheckBoxColumn colIsOptional;
}
