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
		label1 = new System.Windows.Forms.Label();
		lblName = new System.Windows.Forms.Label();
		stringListEditor1 = new StringListEditor();
		label4 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.TextBox();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(0, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(83, 21);
		label1.TabIndex = 0;
		label1.Text = "DbContext";
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
		lblName.Location = new System.Drawing.Point(107, 54);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(48, 19);
		lblName.TabIndex = 1;
		lblName.Text = "Name:";
		lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// stringListEditor1
		// 
		stringListEditor1.BackColor = System.Drawing.SystemColors.Control;
		stringListEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		stringListEditor1.Font = new System.Drawing.Font("Segoe UI", 10F);
		stringListEditor1.Location = new System.Drawing.Point(161, 93);
		stringListEditor1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		stringListEditor1.Name = "stringListEditor1";
		stringListEditor1.Size = new System.Drawing.Size(331, 152);
		stringListEditor1.TabIndex = 7;
		stringListEditor1.ToolbarDockStyle = System.Windows.Forms.DockStyle.Right;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 10F);
		label4.Location = new System.Drawing.Point(40, 94);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(119, 19);
		label4.TabIndex = 8;
		label4.Text = "Additional Usings:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtName
		// 
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtName.Location = new System.Drawing.Point(161, 53);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(331, 25);
		txtName.TabIndex = 11;
		txtName.TextChanged += txtName_TextChanged;
		// 
		// DbContextEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(txtName);
		Controls.Add(label4);
		Controls.Add(stringListEditor1);
		Controls.Add(label1);
		Controls.Add(lblName);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "DbContextEditCtl";
		Size = new System.Drawing.Size(623, 294);
		Load += DbContextEditCtl_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label lblName;
	private StringListEditor stringListEditor1;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.TextBox txtName;
}
