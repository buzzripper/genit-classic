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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceGenEditCtl));
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
		btnBrowseApiClientTemplFilepath = new System.Windows.Forms.Button();
		txtApiClientTemplateFile = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		btnBrowseApiClientOutFolder = new System.Windows.Forms.Button();
		txtApiClientOutputFolder = new System.Windows.Forms.TextBox();
		label8 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(81, 105);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(140, 28);
		label1.TabIndex = 0;
		label1.Text = "Output Folder:";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtOutputFolder
		// 
		txtOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtOutputFolder.Location = new System.Drawing.Point(251, 103);
		txtOutputFolder.Name = "txtOutputFolder";
		txtOutputFolder.Size = new System.Drawing.Size(827, 34);
		txtOutputFolder.TabIndex = 1;
		txtOutputFolder.TextChanged += txtOutputFolder_TextChanged;
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblName.Location = new System.Drawing.Point(42, 10);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(203, 32);
		lblName.TabIndex = 2;
		lblName.Text = "Service Generator";
		// 
		// ckbEnabled
		// 
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(433, 463);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(108, 32);
		ckbEnabled.TabIndex = 3;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// ckbInclHeader
		// 
		ckbInclHeader.AutoSize = true;
		ckbInclHeader.Location = new System.Drawing.Point(581, 463);
		ckbInclHeader.Name = "ckbInclHeader";
		ckbInclHeader.Size = new System.Drawing.Size(169, 32);
		ckbInclHeader.TabIndex = 4;
		ckbInclHeader.Text = "Include Header";
		ckbInclHeader.UseVisualStyleBackColor = true;
		ckbInclHeader.CheckedChanged += ckbInclHeader_CheckedChanged;
		// 
		// btnBrowseFolder
		// 
		btnBrowseFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseFolder.Location = new System.Drawing.Point(1087, 105);
		btnBrowseFolder.Name = "btnBrowseFolder";
		btnBrowseFolder.Size = new System.Drawing.Size(32, 32);
		btnBrowseFolder.TabIndex = 6;
		btnBrowseFolder.Text = "...";
		btnBrowseFolder.UseVisualStyleBackColor = true;
		btnBrowseFolder.Click += btnBrowseFolder_Click;
		// 
		// btnBrowseTemplateFilepath
		// 
		btnBrowseTemplateFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseTemplateFilepath.Location = new System.Drawing.Point(1087, 61);
		btnBrowseTemplateFilepath.Name = "btnBrowseTemplateFilepath";
		btnBrowseTemplateFilepath.Size = new System.Drawing.Size(32, 32);
		btnBrowseTemplateFilepath.TabIndex = 11;
		btnBrowseTemplateFilepath.Text = "...";
		btnBrowseTemplateFilepath.UseVisualStyleBackColor = true;
		btnBrowseTemplateFilepath.Click += btnBrowseTemplateFilepath_Click;
		// 
		// txtTemplateFilepath
		// 
		txtTemplateFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtTemplateFilepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtTemplateFilepath.Location = new System.Drawing.Point(251, 59);
		txtTemplateFilepath.Name = "txtTemplateFilepath";
		txtTemplateFilepath.Size = new System.Drawing.Size(827, 34);
		txtTemplateFilepath.TabIndex = 10;
		txtTemplateFilepath.TextChanged += txtTemplateFilepath_TextChanged;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(89, 60);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(130, 28);
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
		btnBrowseQueryTemplFilepath.Location = new System.Drawing.Point(1087, 155);
		btnBrowseQueryTemplFilepath.Name = "btnBrowseQueryTemplFilepath";
		btnBrowseQueryTemplFilepath.Size = new System.Drawing.Size(32, 32);
		btnBrowseQueryTemplFilepath.TabIndex = 17;
		btnBrowseQueryTemplFilepath.Text = "...";
		btnBrowseQueryTemplFilepath.UseVisualStyleBackColor = true;
		btnBrowseQueryTemplFilepath.Click += btnBrowseQueryTemplFilepath_Click;
		// 
		// txtQueryTemplateFilepath
		// 
		txtQueryTemplateFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtQueryTemplateFilepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtQueryTemplateFilepath.Location = new System.Drawing.Point(252, 155);
		txtQueryTemplateFilepath.Name = "txtQueryTemplateFilepath";
		txtQueryTemplateFilepath.Size = new System.Drawing.Size(827, 34);
		txtQueryTemplateFilepath.TabIndex = 16;
		txtQueryTemplateFilepath.TextChanged += txtQueryTemplateFilepath_TextChanged;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(47, 157);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(188, 28);
		label2.TabIndex = 15;
		label2.Text = "Query Template File:";
		// 
		// btnBrowseQueryOutFolder
		// 
		btnBrowseQueryOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseQueryOutFolder.Location = new System.Drawing.Point(1087, 198);
		btnBrowseQueryOutFolder.Name = "btnBrowseQueryOutFolder";
		btnBrowseQueryOutFolder.Size = new System.Drawing.Size(32, 32);
		btnBrowseQueryOutFolder.TabIndex = 14;
		btnBrowseQueryOutFolder.Text = "...";
		btnBrowseQueryOutFolder.UseVisualStyleBackColor = true;
		btnBrowseQueryOutFolder.Click += btnBrowseQueryOutFolder_Click;
		// 
		// txtQueryOutputFolder
		// 
		txtQueryOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtQueryOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtQueryOutputFolder.Location = new System.Drawing.Point(252, 197);
		txtQueryOutputFolder.Name = "txtQueryOutputFolder";
		txtQueryOutputFolder.Size = new System.Drawing.Size(827, 34);
		txtQueryOutputFolder.TabIndex = 13;
		txtQueryOutputFolder.TextChanged += txtQueryOutputFolder_TextChanged;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(39, 198);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(198, 28);
		label4.TabIndex = 12;
		label4.Text = "Query Output Folder:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseCntlrTemplFilepath
		// 
		btnBrowseCntlrTemplFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseCntlrTemplFilepath.Location = new System.Drawing.Point(1087, 250);
		btnBrowseCntlrTemplFilepath.Name = "btnBrowseCntlrTemplFilepath";
		btnBrowseCntlrTemplFilepath.Size = new System.Drawing.Size(32, 32);
		btnBrowseCntlrTemplFilepath.TabIndex = 23;
		btnBrowseCntlrTemplFilepath.Text = "...";
		btnBrowseCntlrTemplFilepath.UseVisualStyleBackColor = true;
		btnBrowseCntlrTemplFilepath.Click += btnBrowseCntlrTemplFilepath_Click;
		// 
		// txtControllerTemplateFile
		// 
		txtControllerTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtControllerTemplateFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllerTemplateFile.Location = new System.Drawing.Point(251, 250);
		txtControllerTemplateFile.Name = "txtControllerTemplateFile";
		txtControllerTemplateFile.Size = new System.Drawing.Size(827, 34);
		txtControllerTemplateFile.TabIndex = 22;
		txtControllerTemplateFile.TextChanged += txtControllerTemplateFile_TextChanged;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(24, 252);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(223, 28);
		label5.TabIndex = 21;
		label5.Text = "Controller Template File:";
		// 
		// btnBrowseCntlrOutFolder
		// 
		btnBrowseCntlrOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseCntlrOutFolder.Location = new System.Drawing.Point(1087, 291);
		btnBrowseCntlrOutFolder.Name = "btnBrowseCntlrOutFolder";
		btnBrowseCntlrOutFolder.Size = new System.Drawing.Size(32, 32);
		btnBrowseCntlrOutFolder.TabIndex = 20;
		btnBrowseCntlrOutFolder.Text = "...";
		btnBrowseCntlrOutFolder.UseVisualStyleBackColor = true;
		btnBrowseCntlrOutFolder.Click += btnBrowseCntlrOutFolder_Click;
		// 
		// txtControllerOutputFolder
		// 
		txtControllerOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtControllerOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllerOutputFolder.Location = new System.Drawing.Point(251, 291);
		txtControllerOutputFolder.Name = "txtControllerOutputFolder";
		txtControllerOutputFolder.Size = new System.Drawing.Size(827, 34);
		txtControllerOutputFolder.TabIndex = 19;
		txtControllerOutputFolder.TextChanged += txtControllerOutputFolder_TextChanged;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(16, 293);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(233, 28);
		label6.TabIndex = 18;
		label6.Text = "Controller Output Folder:";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseApiClientTemplFilepath
		// 
		btnBrowseApiClientTemplFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientTemplFilepath.Location = new System.Drawing.Point(1087, 344);
		btnBrowseApiClientTemplFilepath.Name = "btnBrowseApiClientTemplFilepath";
		btnBrowseApiClientTemplFilepath.Size = new System.Drawing.Size(32, 32);
		btnBrowseApiClientTemplFilepath.TabIndex = 29;
		btnBrowseApiClientTemplFilepath.Text = "...";
		btnBrowseApiClientTemplFilepath.UseVisualStyleBackColor = true;
		btnBrowseApiClientTemplFilepath.Click += btnBrowseApiClientTemplFilepath_Click;
		// 
		// txtApiClientTemplateFile
		// 
		txtApiClientTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientTemplateFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientTemplateFile.Location = new System.Drawing.Point(251, 344);
		txtApiClientTemplateFile.Name = "txtApiClientTemplateFile";
		txtApiClientTemplateFile.Size = new System.Drawing.Size(827, 34);
		txtApiClientTemplateFile.TabIndex = 28;
		txtApiClientTemplateFile.TextChanged += txtApiClientTemplateFile_TextChanged;
		// 
		// label7
		// 
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(24, 346);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(220, 28);
		label7.TabIndex = 27;
		label7.Text = "Api Client Template File:";
		// 
		// btnBrowseApiClientOutFolder
		// 
		btnBrowseApiClientOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientOutFolder.Location = new System.Drawing.Point(1087, 388);
		btnBrowseApiClientOutFolder.Name = "btnBrowseApiClientOutFolder";
		btnBrowseApiClientOutFolder.Size = new System.Drawing.Size(32, 32);
		btnBrowseApiClientOutFolder.TabIndex = 26;
		btnBrowseApiClientOutFolder.Text = "...";
		btnBrowseApiClientOutFolder.UseVisualStyleBackColor = true;
		btnBrowseApiClientOutFolder.Click += btnBrowseApiClientOutFolder_Click;
		// 
		// txtApiClientOutputFolder
		// 
		txtApiClientOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientOutputFolder.Location = new System.Drawing.Point(251, 388);
		txtApiClientOutputFolder.Name = "txtApiClientOutputFolder";
		txtApiClientOutputFolder.Size = new System.Drawing.Size(827, 34);
		txtApiClientOutputFolder.TabIndex = 25;
		txtApiClientOutputFolder.TextChanged += txtApiClientOutputFolder_TextChanged;
		// 
		// label8
		// 
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(15, 391);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(230, 28);
		label8.TabIndex = 24;
		label8.Text = "Api Client Output Folder:";
		label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// pictureBox1
		// 
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(14, 15);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(30, 27);
		pictureBox1.TabIndex = 30;
		pictureBox1.TabStop = false;
		// 
		// ServiceGenEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(pictureBox1);
		Controls.Add(btnBrowseApiClientTemplFilepath);
		Controls.Add(txtApiClientTemplateFile);
		Controls.Add(label7);
		Controls.Add(btnBrowseApiClientOutFolder);
		Controls.Add(txtApiClientOutputFolder);
		Controls.Add(label8);
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
		Size = new System.Drawing.Size(1171, 528);
		Load += ServiceGenEditCtl_Load;
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
	private System.Windows.Forms.Button btnBrowseApiClientTemplFilepath;
	private System.Windows.Forms.TextBox txtApiClientTemplateFile;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.Button btnBrowseApiClientOutFolder;
	private System.Windows.Forms.TextBox txtApiClientOutputFolder;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.PictureBox pictureBox1;
}
