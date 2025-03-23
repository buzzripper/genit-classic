namespace Dyvenix.Genit.UserControls;

partial class EnumEditCtl
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
		txtName = new System.Windows.Forms.TextBox();
		lblName = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		slMembers = new StringListEditor();
		txtNamespace = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		ckbIsFlags = new System.Windows.Forms.CheckBox();
		ckbIsExternal = new System.Windows.Forms.CheckBox();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(46, 52);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(46, 17);
		label1.TabIndex = 0;
		label1.Text = "Name:";
		// 
		// txtName
		// 
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtName.Location = new System.Drawing.Point(115, 52);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(256, 25);
		txtName.TabIndex = 3;
		txtName.TextChanged += txtName_TextChanged;
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblName.Location = new System.Drawing.Point(0, 1);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(52, 21);
		lblName.TabIndex = 4;
		lblName.Text = "label2";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(37, 96);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(67, 17);
		label2.TabIndex = 5;
		label2.Text = "Members:";
		// 
		// slMembers
		// 
		slMembers.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		slMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		slMembers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		slMembers.Location = new System.Drawing.Point(115, 96);
		slMembers.Name = "slMembers";
		slMembers.Size = new System.Drawing.Size(256, 203);
		slMembers.TabIndex = 6;
		// 
		// txtNamespace
		// 
		txtNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtNamespace.Location = new System.Drawing.Point(115, 327);
		txtNamespace.Name = "txtNamespace";
		txtNamespace.Size = new System.Drawing.Size(256, 25);
		txtNamespace.TabIndex = 8;
		txtNamespace.TextChanged += txtNamespace_TextChanged;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(29, 327);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(80, 17);
		label3.TabIndex = 7;
		label3.Text = "Namespace:";
		// 
		// ckbIsFlags
		// 
		ckbIsFlags.AutoSize = true;
		ckbIsFlags.Location = new System.Drawing.Point(115, 381);
		ckbIsFlags.Name = "ckbIsFlags";
		ckbIsFlags.Size = new System.Drawing.Size(57, 21);
		ckbIsFlags.TabIndex = 9;
		ckbIsFlags.Text = "Flags";
		ckbIsFlags.UseVisualStyleBackColor = true;
		ckbIsFlags.CheckedChanged += ckbIsFlags_CheckedChanged;
		// 
		// ckbIsExternal
		// 
		ckbIsExternal.AutoSize = true;
		ckbIsExternal.Location = new System.Drawing.Point(205, 381);
		ckbIsExternal.Name = "ckbIsExternal";
		ckbIsExternal.Size = new System.Drawing.Size(73, 21);
		ckbIsExternal.TabIndex = 10;
		ckbIsExternal.Text = "External";
		ckbIsExternal.UseVisualStyleBackColor = true;
		ckbIsExternal.CheckedChanged += ckbIsExternal_CheckedChanged;
		// 
		// ckbEnabled
		// 
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(298, 381);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(73, 21);
		ckbEnabled.TabIndex = 11;
		ckbEnabled.Text = "External";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// EnumEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(ckbEnabled);
		Controls.Add(ckbIsExternal);
		Controls.Add(ckbIsFlags);
		Controls.Add(txtNamespace);
		Controls.Add(label3);
		Controls.Add(slMembers);
		Controls.Add(label2);
		Controls.Add(lblName);
		Controls.Add(txtName);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "EnumEditCtl";
		Size = new System.Drawing.Size(468, 493);
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.Label label2;
	private StringListEditor slMembers;
	private System.Windows.Forms.TextBox txtNamespace;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.CheckBox ckbIsFlags;
	private System.Windows.Forms.CheckBox ckbIsExternal;
	private System.Windows.Forms.CheckBox ckbEnabled;
}
