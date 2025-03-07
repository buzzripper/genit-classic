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
		txtName = new System.Windows.Forms.TextBox();
		txtContextNamespace = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		txtEntitiesNamespace = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		stringListEditor1 = new StringListEditor();
		label4 = new System.Windows.Forms.Label();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(83, 21);
		label1.TabIndex = 0;
		label1.Text = "DbContext";
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Location = new System.Drawing.Point(98, 60);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(42, 15);
		lblName.TabIndex = 1;
		lblName.Text = "Name:";
		lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtName
		// 
		txtName.Location = new System.Drawing.Point(146, 57);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(318, 23);
		txtName.TabIndex = 2;
		// 
		// txtContextNamespace
		// 
		txtContextNamespace.Location = new System.Drawing.Point(146, 86);
		txtContextNamespace.Name = "txtContextNamespace";
		txtContextNamespace.Size = new System.Drawing.Size(318, 23);
		txtContextNamespace.TabIndex = 4;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(23, 89);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(117, 15);
		label2.TabIndex = 3;
		label2.Text = "Context Namespace:";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtEntitiesNamespace
		// 
		txtEntitiesNamespace.Location = new System.Drawing.Point(146, 115);
		txtEntitiesNamespace.Name = "txtEntitiesNamespace";
		txtEntitiesNamespace.Size = new System.Drawing.Size(318, 23);
		txtEntitiesNamespace.TabIndex = 6;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(23, 118);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(113, 15);
		label3.TabIndex = 5;
		label3.Text = "Entities Namespace:";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// stringListEditor1
		// 
		stringListEditor1.BackColor = System.Drawing.Color.RosyBrown;
		stringListEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		stringListEditor1.Location = new System.Drawing.Point(146, 168);
		stringListEditor1.Name = "stringListEditor1";
		stringListEditor1.Size = new System.Drawing.Size(318, 153);
		stringListEditor1.TabIndex = 7;
		stringListEditor1.ItemAdded += stringListEditor1_ItemAdded;
		stringListEditor1.ItemChanged += stringListEditor1_ItemChanged;
		stringListEditor1.ItemDeleted += stringListEditor1_ItemDeleted;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(146, 150);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(180, 15);
		label4.TabIndex = 8;
		label4.Text = "Additional Context Namespaces:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// DbContextEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(label4);
		Controls.Add(stringListEditor1);
		Controls.Add(txtEntitiesNamespace);
		Controls.Add(label3);
		Controls.Add(txtContextNamespace);
		Controls.Add(label2);
		Controls.Add(txtName);
		Controls.Add(lblName);
		Controls.Add(label1);
		Name = "DbContextEditCtl";
		Size = new System.Drawing.Size(492, 342);
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.TextBox txtContextNamespace;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.TextBox txtEntitiesNamespace;
	private System.Windows.Forms.Label label3;
	private StringListEditor stringListEditor1;
	private System.Windows.Forms.Label label4;
}
