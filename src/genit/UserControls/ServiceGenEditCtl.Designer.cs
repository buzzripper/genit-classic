namespace Dyvenix.Genit.UserControls;

partial class ServiceGenEditCtl
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
		btnBrowseFolder = new System.Windows.Forms.Button();
		folderDlg = new System.Windows.Forms.FolderBrowserDialog();
		btnBrowseTemplateFilepath = new System.Windows.Forms.Button();
		txtTemplateFilepath = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		fileDlg = new System.Windows.Forms.OpenFileDialog();
		btnBrowseQueryTemplFilepath = new System.Windows.Forms.Button();
		txtQueryTemplateFilepath = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		btnBrowseQueryOutFolder = new System.Windows.Forms.Button();
		txtQueryOutputFolder = new System.Windows.Forms.TextBox();
		label4 = new System.Windows.Forms.Label();
		btnBrowseCntlrTemplFilepath = new System.Windows.Forms.Button();
		txtControllerTemplateFile = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		btnBrowseCntlrOutFolder = new System.Windows.Forms.Button();
		txtControllerOutputFolder = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(81, 92);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(99, 19);
		label1.TabIndex = 0;
		label1.Text = "Output Folder:";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtOutputFolder
		// 
		txtOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtOutputFolder.Location = new System.Drawing.Point(181, 90);
		txtOutputFolder.Name = "txtOutputFolder";
		txtOutputFolder.Size = new System.Drawing.Size(463, 25);
		txtOutputFolder.TabIndex = 1;
		txtOutputFolder.TextChanged += txtOutputFolder_TextChanged;
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblName.Location = new System.Drawing.Point(1, 2);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(123, 21);
		lblName.TabIndex = 2;
		lblName.Text = "Entity Generator";
		// 
		// ckbEnabled
		// 
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(243, 320);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(76, 23);
		ckbEnabled.TabIndex = 3;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// ckbInclHeader
		// 
		ckbInclHeader.AutoSize = true;
		ckbInclHeader.Location = new System.Drawing.Point(391, 320);
		ckbInclHeader.Name = "ckbInclHeader";
		ckbInclHeader.Size = new System.Drawing.Size(120, 23);
		ckbInclHeader.TabIndex = 4;
		ckbInclHeader.Text = "Include Header";
		ckbInclHeader.UseVisualStyleBackColor = true;
		ckbInclHeader.CheckedChanged += ckbInclHeader_CheckedChanged;
		// 
		// btnBrowseFolder
		// 
		btnBrowseFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseFolder.Location = new System.Drawing.Point(649, 90);
		btnBrowseFolder.Name = "btnBrowseFolder";
		btnBrowseFolder.Size = new System.Drawing.Size(24, 22);
		btnBrowseFolder.TabIndex = 6;
		btnBrowseFolder.Text = "...";
		btnBrowseFolder.UseVisualStyleBackColor = true;
		btnBrowseFolder.Click += btnBrowseFolder_Click;
		// 
		// btnBrowseTemplateFilepath
		// 
		btnBrowseTemplateFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseTemplateFilepath.Location = new System.Drawing.Point(649, 59);
		btnBrowseTemplateFilepath.Name = "btnBrowseTemplateFilepath";
		btnBrowseTemplateFilepath.Size = new System.Drawing.Size(24, 22);
		btnBrowseTemplateFilepath.TabIndex = 11;
		btnBrowseTemplateFilepath.Text = "...";
		btnBrowseTemplateFilepath.UseVisualStyleBackColor = true;
		btnBrowseTemplateFilepath.Click += btnBrowseTemplateFilepath_Click;
		// 
		// txtTemplateFilepath
		// 
		txtTemplateFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtTemplateFilepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtTemplateFilepath.Location = new System.Drawing.Point(181, 59);
		txtTemplateFilepath.Name = "txtTemplateFilepath";
		txtTemplateFilepath.Size = new System.Drawing.Size(462, 25);
		txtTemplateFilepath.TabIndex = 10;
		txtTemplateFilepath.TextChanged += txtTemplateFilepath_TextChanged;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(89, 60);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(91, 19);
		label3.TabIndex = 9;
		label3.Text = "Template File:";
		// 
		// fileDlg
		// 
		fileDlg.DefaultExt = "*.tmpl";
		fileDlg.Filter = "Template file (*.tmpl)|*.tmpl| All Files (*.*)|*.*";
		// 
		// btnBrowseQueryTemplFilepath
		// 
		btnBrowseQueryTemplFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseQueryTemplFilepath.Location = new System.Drawing.Point(650, 136);
		btnBrowseQueryTemplFilepath.Name = "btnBrowseQueryTemplFilepath";
		btnBrowseQueryTemplFilepath.Size = new System.Drawing.Size(24, 22);
		btnBrowseQueryTemplFilepath.TabIndex = 17;
		btnBrowseQueryTemplFilepath.Text = "...";
		btnBrowseQueryTemplFilepath.UseVisualStyleBackColor = true;
		btnBrowseQueryTemplFilepath.Click += btnBrowseQueryTemplFilepath_Click;
		// 
		// txtQueryTemplateFilepath
		// 
		txtQueryTemplateFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtQueryTemplateFilepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtQueryTemplateFilepath.Location = new System.Drawing.Point(182, 136);
		txtQueryTemplateFilepath.Name = "txtQueryTemplateFilepath";
		txtQueryTemplateFilepath.Size = new System.Drawing.Size(462, 25);
		txtQueryTemplateFilepath.TabIndex = 16;
		txtQueryTemplateFilepath.TextChanged += txtQueryTemplateFilepath_TextChanged;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(47, 138);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(133, 19);
		label2.TabIndex = 15;
		label2.Text = "Query Template File:";
		// 
		// btnBrowseQueryOutFolder
		// 
		btnBrowseQueryOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseQueryOutFolder.Location = new System.Drawing.Point(650, 167);
		btnBrowseQueryOutFolder.Name = "btnBrowseQueryOutFolder";
		btnBrowseQueryOutFolder.Size = new System.Drawing.Size(24, 22);
		btnBrowseQueryOutFolder.TabIndex = 14;
		btnBrowseQueryOutFolder.Text = "...";
		btnBrowseQueryOutFolder.UseVisualStyleBackColor = true;
		btnBrowseQueryOutFolder.Click += btnBrowseQueryOutFolder_Click;
		// 
		// txtQueryOutputFolder
		// 
		txtQueryOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtQueryOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtQueryOutputFolder.Location = new System.Drawing.Point(182, 167);
		txtQueryOutputFolder.Name = "txtQueryOutputFolder";
		txtQueryOutputFolder.Size = new System.Drawing.Size(463, 25);
		txtQueryOutputFolder.TabIndex = 13;
		txtQueryOutputFolder.TextChanged += txtQueryOutputFolder_TextChanged;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(39, 168);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(141, 19);
		label4.TabIndex = 12;
		label4.Text = "Query Output Folder:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseCntlrTemplFilepath
		// 
		btnBrowseCntlrTemplFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseCntlrTemplFilepath.Location = new System.Drawing.Point(649, 215);
		btnBrowseCntlrTemplFilepath.Name = "btnBrowseCntlrTemplFilepath";
		btnBrowseCntlrTemplFilepath.Size = new System.Drawing.Size(24, 22);
		btnBrowseCntlrTemplFilepath.TabIndex = 23;
		btnBrowseCntlrTemplFilepath.Text = "...";
		btnBrowseCntlrTemplFilepath.UseVisualStyleBackColor = true;
		btnBrowseCntlrTemplFilepath.Click += btnBrowseCntlrTemplFilepath_Click;
		// 
		// txtControllerTemplateFile
		// 
		txtControllerTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtControllerTemplateFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllerTemplateFile.Location = new System.Drawing.Point(181, 215);
		txtControllerTemplateFile.Name = "txtControllerTemplateFile";
		txtControllerTemplateFile.Size = new System.Drawing.Size(462, 25);
		txtControllerTemplateFile.TabIndex = 22;
		txtControllerTemplateFile.TextChanged += txtControllerTemplateFile_TextChanged;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(24, 217);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(156, 19);
		label5.TabIndex = 21;
		label5.Text = "Controller Template File:";
		// 
		// btnBrowseCntlrOutFolder
		// 
		btnBrowseCntlrOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseCntlrOutFolder.Location = new System.Drawing.Point(649, 246);
		btnBrowseCntlrOutFolder.Name = "btnBrowseCntlrOutFolder";
		btnBrowseCntlrOutFolder.Size = new System.Drawing.Size(24, 22);
		btnBrowseCntlrOutFolder.TabIndex = 20;
		btnBrowseCntlrOutFolder.Text = "...";
		btnBrowseCntlrOutFolder.UseVisualStyleBackColor = true;
		btnBrowseCntlrOutFolder.Click += btnBrowseCntlrOutFolder_Click;
		// 
		// txtControllerOutputFolder
		// 
		txtControllerOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtControllerOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllerOutputFolder.Location = new System.Drawing.Point(181, 246);
		txtControllerOutputFolder.Name = "txtControllerOutputFolder";
		txtControllerOutputFolder.Size = new System.Drawing.Size(463, 25);
		txtControllerOutputFolder.TabIndex = 19;
		txtControllerOutputFolder.TextChanged += txtControllerOutputFolder_TextChanged;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(16, 248);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(164, 19);
		label6.TabIndex = 18;
		label6.Text = "Controller Output Folder:";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// ServiceGenEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(btnBrowseCntlrTemplFilepath);
		Controls.Add(txtControllerTemplateFile);
		Controls.Add(label5);
		Controls.Add(btnBrowseCntlrOutFolder);
		Controls.Add(txtControllerOutputFolder);
		Controls.Add(label6);
		Controls.Add(btnBrowseQueryTemplFilepath);
		Controls.Add(txtQueryTemplateFilepath);
		Controls.Add(label2);
		Controls.Add(btnBrowseQueryOutFolder);
		Controls.Add(txtQueryOutputFolder);
		Controls.Add(label4);
		Controls.Add(btnBrowseTemplateFilepath);
		Controls.Add(txtTemplateFilepath);
		Controls.Add(label3);
		Controls.Add(btnBrowseFolder);
		Controls.Add(ckbInclHeader);
		Controls.Add(ckbEnabled);
		Controls.Add(lblName);
		Controls.Add(txtOutputFolder);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F);
		Name = "ServiceGenEditCtl";
		Size = new System.Drawing.Size(727, 414);
		Load += ServiceGenEditCtl_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox txtOutputFolder;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.CheckBox ckbInclHeader;
	private System.Windows.Forms.Button btnBrowseFolder;
	private System.Windows.Forms.FolderBrowserDialog folderDlg;
	private System.Windows.Forms.Button btnBrowseTemplateFilepath;
	private System.Windows.Forms.TextBox txtTemplateFilepath;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.OpenFileDialog fileDlg;
	private System.Windows.Forms.Button btnBrowseQueryTemplFilepath;
	private System.Windows.Forms.TextBox txtQueryTemplateFilepath;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Button btnBrowseQueryOutFolder;
	private System.Windows.Forms.TextBox txtQueryOutputFolder;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Button btnBrowseCntlrTemplFilepath;
	private System.Windows.Forms.TextBox txtControllerTemplateFile;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.Button btnBrowseCntlrOutFolder;
	private System.Windows.Forms.TextBox txtControllerOutputFolder;
	private System.Windows.Forms.Label label6;
}
