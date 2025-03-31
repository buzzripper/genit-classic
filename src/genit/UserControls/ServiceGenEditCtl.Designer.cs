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
		btnBrowseApiClientServicesExtOutputFile = new System.Windows.Forms.Button();
		txtApiClientServicesExtOutputFile = new System.Windows.Forms.TextBox();
		label9 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		label12 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		btnBrowseApiClientServicesExtTemplateFile = new System.Windows.Forms.Button();
		txtApiClientServicesExtTemplateFile = new System.Windows.Forms.TextBox();
		label14 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(109, 153);
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
		txtOutputFolder.Location = new System.Drawing.Point(252, 151);
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
		ckbEnabled.Location = new System.Drawing.Point(398, 747);
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
		ckbInclHeader.Location = new System.Drawing.Point(546, 747);
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
		btnBrowseFolder.Location = new System.Drawing.Point(1088, 153);
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
		btnBrowseTemplateFilepath.Location = new System.Drawing.Point(1088, 109);
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
		txtTemplateFilepath.Location = new System.Drawing.Point(252, 107);
		txtTemplateFilepath.Name = "txtTemplateFilepath";
		txtTemplateFilepath.Size = new System.Drawing.Size(827, 34);
		txtTemplateFilepath.TabIndex = 10;
		txtTemplateFilepath.TextChanged += txtTemplateFilepath_TextChanged;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(119, 108);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(130, 28);
		label3.TabIndex = 9;
		label3.Text = "Template File:";
		// 
		// fileDlg
		// 
		fileDlg.DefaultExt = "*.tmpl";
		fileDlg.Filter = "All Files (*.*)|*.*";
		// 
		// btnBrowseQueryTemplFilepath
		// 
		btnBrowseQueryTemplFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseQueryTemplFilepath.Location = new System.Drawing.Point(1087, 374);
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
		txtQueryTemplateFilepath.Location = new System.Drawing.Point(252, 374);
		txtQueryTemplateFilepath.Name = "txtQueryTemplateFilepath";
		txtQueryTemplateFilepath.Size = new System.Drawing.Size(827, 34);
		txtQueryTemplateFilepath.TabIndex = 16;
		txtQueryTemplateFilepath.TextChanged += txtQueryTemplateFilepath_TextChanged;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(119, 376);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(130, 28);
		label2.TabIndex = 15;
		label2.Text = "Template File:";
		// 
		// btnBrowseQueryOutFolder
		// 
		btnBrowseQueryOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseQueryOutFolder.Location = new System.Drawing.Point(1087, 417);
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
		txtQueryOutputFolder.Location = new System.Drawing.Point(252, 416);
		txtQueryOutputFolder.Name = "txtQueryOutputFolder";
		txtQueryOutputFolder.Size = new System.Drawing.Size(827, 34);
		txtQueryOutputFolder.TabIndex = 13;
		txtQueryOutputFolder.TextChanged += txtQueryOutputFolder_TextChanged;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(109, 417);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(140, 28);
		label4.TabIndex = 12;
		label4.Text = "Output Folder:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseCntlrTemplFilepath
		// 
		btnBrowseCntlrTemplFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseCntlrTemplFilepath.Location = new System.Drawing.Point(1088, 239);
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
		txtControllerTemplateFile.Location = new System.Drawing.Point(252, 239);
		txtControllerTemplateFile.Name = "txtControllerTemplateFile";
		txtControllerTemplateFile.Size = new System.Drawing.Size(827, 34);
		txtControllerTemplateFile.TabIndex = 22;
		txtControllerTemplateFile.TextChanged += txtControllerTemplateFile_TextChanged;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(119, 241);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(130, 28);
		label5.TabIndex = 21;
		label5.Text = "Template File:";
		// 
		// btnBrowseCntlrOutFolder
		// 
		btnBrowseCntlrOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseCntlrOutFolder.Location = new System.Drawing.Point(1088, 280);
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
		txtControllerOutputFolder.Location = new System.Drawing.Point(252, 280);
		txtControllerOutputFolder.Name = "txtControllerOutputFolder";
		txtControllerOutputFolder.Size = new System.Drawing.Size(827, 34);
		txtControllerOutputFolder.TabIndex = 19;
		txtControllerOutputFolder.TextChanged += txtControllerOutputFolder_TextChanged;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(109, 282);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(140, 28);
		label6.TabIndex = 18;
		label6.Text = "Output Folder:";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseApiClientTemplFilepath
		// 
		btnBrowseApiClientTemplFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientTemplFilepath.Location = new System.Drawing.Point(1088, 506);
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
		txtApiClientTemplateFile.Location = new System.Drawing.Point(252, 506);
		txtApiClientTemplateFile.Name = "txtApiClientTemplateFile";
		txtApiClientTemplateFile.Size = new System.Drawing.Size(827, 34);
		txtApiClientTemplateFile.TabIndex = 28;
		txtApiClientTemplateFile.TextChanged += txtApiClientTemplateFile_TextChanged;
		// 
		// label7
		// 
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(119, 512);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(130, 28);
		label7.TabIndex = 27;
		label7.Text = "Template File:";
		// 
		// btnBrowseApiClientOutFolder
		// 
		btnBrowseApiClientOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientOutFolder.Location = new System.Drawing.Point(1088, 550);
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
		txtApiClientOutputFolder.Location = new System.Drawing.Point(252, 550);
		txtApiClientOutputFolder.Name = "txtApiClientOutputFolder";
		txtApiClientOutputFolder.Size = new System.Drawing.Size(827, 34);
		txtApiClientOutputFolder.TabIndex = 25;
		txtApiClientOutputFolder.TextChanged += txtApiClientOutputFolder_TextChanged;
		// 
		// label8
		// 
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(109, 556);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(140, 28);
		label8.TabIndex = 24;
		label8.Text = "Output Folder:";
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
		// btnBrowseApiClientServicesExtOutputFile
		// 
		btnBrowseApiClientServicesExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientServicesExtOutputFile.Location = new System.Drawing.Point(1088, 650);
		btnBrowseApiClientServicesExtOutputFile.Name = "btnBrowseApiClientServicesExtOutputFile";
		btnBrowseApiClientServicesExtOutputFile.Size = new System.Drawing.Size(32, 32);
		btnBrowseApiClientServicesExtOutputFile.TabIndex = 33;
		btnBrowseApiClientServicesExtOutputFile.Text = "...";
		btnBrowseApiClientServicesExtOutputFile.UseVisualStyleBackColor = true;
		btnBrowseApiClientServicesExtOutputFile.Click += btnBrowseApiClientServicesExtOutputFile_Click;
		// 
		// txtApiClientServicesExtOutputFile
		// 
		txtApiClientServicesExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientServicesExtOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientServicesExtOutputFile.Location = new System.Drawing.Point(252, 650);
		txtApiClientServicesExtOutputFile.Name = "txtApiClientServicesExtOutputFile";
		txtApiClientServicesExtOutputFile.Size = new System.Drawing.Size(827, 34);
		txtApiClientServicesExtOutputFile.TabIndex = 32;
		txtApiClientServicesExtOutputFile.TextChanged += txtApiClientServicesExtOutputFile_TextChanged;
		// 
		// label9
		// 
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(29, 652);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(220, 28);
		label9.TabIndex = 31;
		label9.Text = "Services Ext Output File:";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// label10
		// 
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label10.Location = new System.Drawing.Point(23, 474);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(105, 28);
		label10.TabIndex = 34;
		label10.Text = "API Client";
		// 
		// label11
		// 
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label11.Location = new System.Drawing.Point(23, 204);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(107, 28);
		label11.TabIndex = 35;
		label11.Text = "Controller";
		// 
		// label12
		// 
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label12.Location = new System.Drawing.Point(23, 337);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(123, 28);
		label12.TabIndex = 36;
		label12.Text = "Query Class";
		// 
		// label13
		// 
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label13.Location = new System.Drawing.Point(23, 77);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(81, 28);
		label13.TabIndex = 37;
		label13.Text = "Service";
		// 
		// btnBrowseApiClientServicesExtTemplateFile
		// 
		btnBrowseApiClientServicesExtTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientServicesExtTemplateFile.Location = new System.Drawing.Point(1088, 606);
		btnBrowseApiClientServicesExtTemplateFile.Name = "btnBrowseApiClientServicesExtTemplateFile";
		btnBrowseApiClientServicesExtTemplateFile.Size = new System.Drawing.Size(32, 32);
		btnBrowseApiClientServicesExtTemplateFile.TabIndex = 40;
		btnBrowseApiClientServicesExtTemplateFile.Text = "...";
		btnBrowseApiClientServicesExtTemplateFile.UseVisualStyleBackColor = true;
		btnBrowseApiClientServicesExtTemplateFile.Click += btnBrowseApiClientServicesExtTemplateFile_Click;
		// 
		// txtApiClientServicesExtTemplateFile
		// 
		txtApiClientServicesExtTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientServicesExtTemplateFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientServicesExtTemplateFile.Location = new System.Drawing.Point(252, 606);
		txtApiClientServicesExtTemplateFile.Name = "txtApiClientServicesExtTemplateFile";
		txtApiClientServicesExtTemplateFile.Size = new System.Drawing.Size(827, 34);
		txtApiClientServicesExtTemplateFile.TabIndex = 39;
		txtApiClientServicesExtTemplateFile.TextChanged += txtApiClientServicesExtTemplateFile_TextChanged;
		// 
		// label14
		// 
		label14.AutoSize = true;
		label14.Location = new System.Drawing.Point(45, 608);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(204, 28);
		label14.TabIndex = 38;
		label14.Text = "Svcs Ext Template File:";
		label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// ServiceGenEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(btnBrowseApiClientServicesExtTemplateFile);
		Controls.Add(txtApiClientServicesExtTemplateFile);
		Controls.Add(label14);
		Controls.Add(label13);
		Controls.Add(label12);
		Controls.Add(label11);
		Controls.Add(label10);
		Controls.Add(btnBrowseApiClientServicesExtOutputFile);
		Controls.Add(txtApiClientServicesExtOutputFile);
		Controls.Add(label9);
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
		Size = new System.Drawing.Size(1171, 821);
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
	private System.Windows.Forms.Button btnBrowseApiClientServicesExtOutputFile;
	private System.Windows.Forms.TextBox txtApiClientServicesExtOutputFile;
	private System.Windows.Forms.Label label9;
	private System.Windows.Forms.Label label10;
	private System.Windows.Forms.Label label11;
	private System.Windows.Forms.Label label12;
	private System.Windows.Forms.Label label13;
	private System.Windows.Forms.Button btnBrowseApiClientServicesExtTemplateFile;
	private System.Windows.Forms.TextBox txtApiClientServicesExtTemplateFile;
	private System.Windows.Forms.Label label14;
}
