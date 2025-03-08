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
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		stringListEditor1 = new StringListEditor();
		label4 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.TextBox();
		txtContextNamespace = new System.Windows.Forms.TextBox();
		txtEntitiesNamespace = new System.Windows.Forms.TextBox();
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
		lblName.Location = new System.Drawing.Point(107, 50);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(48, 19);
		lblName.TabIndex = 1;
		lblName.Text = "Name:";
		lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 10F);
		label2.Location = new System.Drawing.Point(21, 82);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(134, 19);
		label2.TabIndex = 3;
		label2.Text = "Context Namespace:";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 10F);
		label3.Location = new System.Drawing.Point(25, 113);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(130, 19);
		label3.TabIndex = 5;
		label3.Text = "Entities Namespace:";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// stringListEditor1
		// 
		stringListEditor1.BackColor = System.Drawing.Color.RosyBrown;
		stringListEditor1.Font = new System.Drawing.Font("Segoe UI", 10F);
		stringListEditor1.Location = new System.Drawing.Point(161, 154);
		stringListEditor1.Name = "stringListEditor1";
		stringListEditor1.Size = new System.Drawing.Size(329, 152);
		stringListEditor1.TabIndex = 7;
		stringListEditor1.ItemAdded += stringListEditor1_ItemAdded;
		stringListEditor1.ItemChanged += stringListEditor1_ItemChanged;
		stringListEditor1.ItemDeleted += stringListEditor1_ItemDeleted;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 10F);
		label4.Location = new System.Drawing.Point(36, 154);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(119, 19);
		label4.TabIndex = 8;
		label4.Text = "Additional Usings:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtName
		// 
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtName.Location = new System.Drawing.Point(161, 53);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(331, 18);
		txtName.TabIndex = 11;
		// 
		// txtContextNamespace
		// 
		txtContextNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtContextNamespace.Location = new System.Drawing.Point(161, 85);
		txtContextNamespace.Name = "txtContextNamespace";
		txtContextNamespace.Size = new System.Drawing.Size(331, 18);
		txtContextNamespace.TabIndex = 12;
		// 
		// txtEntitiesNamespace
		// 
		txtEntitiesNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtEntitiesNamespace.Location = new System.Drawing.Point(161, 117);
		txtEntitiesNamespace.Name = "txtEntitiesNamespace";
		txtEntitiesNamespace.Size = new System.Drawing.Size(331, 18);
		txtEntitiesNamespace.TabIndex = 13;
		// 
		// DbContextEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(txtEntitiesNamespace);
		Controls.Add(txtContextNamespace);
		Controls.Add(txtName);
		Controls.Add(label4);
		Controls.Add(stringListEditor1);
		Controls.Add(label1);
		Controls.Add(label3);
		Controls.Add(label2);
		Controls.Add(lblName);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "DbContextEditCtl";
		Size = new System.Drawing.Size(623, 388);
		Load += DbContextEditCtl_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private StringListEditor stringListEditor1;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.TextBox txtContextNamespace;
	private System.Windows.Forms.TextBox txtEntitiesNamespace;
}
