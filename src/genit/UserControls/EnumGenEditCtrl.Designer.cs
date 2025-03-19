namespace Dyvenix.Genit.UserControls;

partial class EnumGenEditCtrl
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
		txtOutputFolder = new System.Windows.Forms.TextBox();
		lblName = new System.Windows.Forms.Label();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		ckbInclHeader = new System.Windows.Forms.CheckBox();
		label2 = new System.Windows.Forms.Label();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(70, 92);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(92, 17);
		label1.TabIndex = 0;
		label1.Text = "Output Folder:";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtOutputFolder
		// 
		txtOutputFolder.Location = new System.Drawing.Point(160, 88);
		txtOutputFolder.Name = "txtOutputFolder";
		txtOutputFolder.Size = new System.Drawing.Size(371, 25);
		txtOutputFolder.TabIndex = 1;
		txtOutputFolder.TextChanged += txtOutputFolder_TextChanged;
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblName.Location = new System.Drawing.Point(1, 2);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(124, 21);
		lblName.TabIndex = 2;
		lblName.Text = "Enum Generator";
		// 
		// ckbEnabled
		// 
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(191, 168);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(74, 21);
		ckbEnabled.TabIndex = 3;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// ckbInclHeader
		// 
		ckbInclHeader.AutoSize = true;
		ckbInclHeader.Location = new System.Drawing.Point(352, 168);
		ckbInclHeader.Name = "ckbInclHeader";
		ckbInclHeader.Size = new System.Drawing.Size(115, 21);
		ckbInclHeader.TabIndex = 4;
		ckbInclHeader.Text = "Include Header";
		ckbInclHeader.UseVisualStyleBackColor = true;
		ckbInclHeader.CheckedChanged += ckbInclHeader_CheckedChanged;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(331, 361);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(43, 17);
		label2.TabIndex = 5;
		label2.Text = "label2";
		// 
		// EnumGenEditCtrl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(label2);
		Controls.Add(ckbInclHeader);
		Controls.Add(ckbEnabled);
		Controls.Add(lblName);
		Controls.Add(txtOutputFolder);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "EnumGenEditCtrl";
		Size = new System.Drawing.Size(719, 553);
		Load += DbCtxGenEditCtrl_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox txtOutputFolder;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.CheckBox ckbInclHeader;
	private System.Windows.Forms.Label label2;
}
