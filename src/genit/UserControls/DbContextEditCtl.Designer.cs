namespace Dyvenix.Genit.UserControls;

partial class DbContextEditCtl
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
		lblName = new System.Windows.Forms.Label();
		stringListEditor1 = new StringListEditor();
		label4 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.TextBox();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
		lblName.Location = new System.Drawing.Point(140, 77);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(68, 28);
		lblName.TabIndex = 1;
		lblName.Text = "Name:";
		lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// stringListEditor1
		// 
		stringListEditor1.BackColor = System.Drawing.SystemColors.Control;
		stringListEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		stringListEditor1.Font = new System.Drawing.Font("Segoe UI", 10F);
		stringListEditor1.Location = new System.Drawing.Point(214, 115);
		stringListEditor1.Margin = new System.Windows.Forms.Padding(2);
		stringListEditor1.Name = "stringListEditor1";
		stringListEditor1.Size = new System.Drawing.Size(503, 152);
		stringListEditor1.TabIndex = 7;
		stringListEditor1.ToolbarDockStyle = System.Windows.Forms.DockStyle.Right;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 10F);
		label4.Location = new System.Drawing.Point(38, 115);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(171, 28);
		label4.TabIndex = 8;
		label4.Text = "Additional Usings:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtName
		// 
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtName.Location = new System.Drawing.Point(214, 75);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(503, 34);
		txtName.TabIndex = 11;
		txtName.TextChanged += txtName_TextChanged;
		// 
		// toolStrip1
		// 
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel1 });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(837, 37);
		toolStrip1.TabIndex = 12;
		toolStrip1.Text = "toolStrip1";
		// 
		// toolStripLabel1
		// 
		toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Size = new System.Drawing.Size(128, 32);
		toolStripLabel1.Text = "DbContext";
		// 
		// DbContextEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(toolStrip1);
		Controls.Add(txtName);
		Controls.Add(label4);
		Controls.Add(stringListEditor1);
		Controls.Add(lblName);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "DbContextEditCtl";
		Size = new System.Drawing.Size(837, 316);
		Load += DbContextEditCtl_Load;
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private System.Windows.Forms.Label lblName;
	private StringListEditor stringListEditor1;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripLabel toolStripLabel1;
}
