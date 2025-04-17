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
		ckbEnabled = new System.Windows.Forms.CheckBox();
		ckbInclHeader = new System.Windows.Forms.CheckBox();
		btnBrowseFolder = new System.Windows.Forms.Button();
		folderDlg = new System.Windows.Forms.FolderBrowserDialog();
		fileDlg = new System.Windows.Forms.OpenFileDialog();
		btnBrowseQueryOutFolder = new System.Windows.Forms.Button();
		txtQueryOutputFolder = new System.Windows.Forms.TextBox();
		label4 = new System.Windows.Forms.Label();
		btnBrowseCntlrOutFolder = new System.Windows.Forms.Button();
		txtControllerOutputFolder = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		btnBrowseApiClientOutFolder = new System.Windows.Forms.Button();
		txtApiClientOutputFolder = new System.Windows.Forms.TextBox();
		label8 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btnBrowseApiClientExtOutputFile = new System.Windows.Forms.Button();
		txtApiClientExtOutputFile = new System.Windows.Forms.TextBox();
		label9 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		label12 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		txtApiClientsNamespace = new System.Windows.Forms.TextBox();
		label15 = new System.Windows.Forms.Label();
		txtControllersNamespace = new System.Windows.Forms.TextBox();
		label16 = new System.Windows.Forms.Label();
		txtQueriesNamespace = new System.Windows.Forms.TextBox();
		label17 = new System.Windows.Forms.Label();
		txtServicesNamespace = new System.Windows.Forms.TextBox();
		label18 = new System.Windows.Forms.Label();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		btnBrowseServiceExtOutputFile = new System.Windows.Forms.Button();
		txtServiceExtOutputFile = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		txtDtoNamespace = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		btnBrowseDtoOutputFolder = new System.Windows.Forms.Button();
		txtDtoOutputFolder = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(71, 62);
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
		txtOutputFolder.Location = new System.Drawing.Point(176, 62);
		txtOutputFolder.Name = "txtOutputFolder";
		txtOutputFolder.Size = new System.Drawing.Size(798, 25);
		txtOutputFolder.TabIndex = 1;
		txtOutputFolder.TextChanged += txtOutputFolder_TextChanged;
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(945, 5);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(76, 23);
		ckbEnabled.TabIndex = 3;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// ckbInclHeader
		// 
		ckbInclHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbInclHeader.AutoSize = true;
		ckbInclHeader.Location = new System.Drawing.Point(767, 5);
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
		btnBrowseFolder.Location = new System.Drawing.Point(982, 62);
		btnBrowseFolder.Name = "btnBrowseFolder";
		btnBrowseFolder.Size = new System.Drawing.Size(28, 28);
		btnBrowseFolder.TabIndex = 6;
		btnBrowseFolder.Text = "...";
		btnBrowseFolder.UseVisualStyleBackColor = true;
		btnBrowseFolder.Click += btnBrowseFolder_Click;
		// 
		// fileDlg
		// 
		fileDlg.DefaultExt = "*.tmpl";
		fileDlg.Filter = "All Files (*.*)|*.*";
		// 
		// btnBrowseQueryOutFolder
		// 
		btnBrowseQueryOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseQueryOutFolder.Location = new System.Drawing.Point(982, 274);
		btnBrowseQueryOutFolder.Name = "btnBrowseQueryOutFolder";
		btnBrowseQueryOutFolder.Size = new System.Drawing.Size(28, 28);
		btnBrowseQueryOutFolder.TabIndex = 14;
		btnBrowseQueryOutFolder.Text = "...";
		btnBrowseQueryOutFolder.UseVisualStyleBackColor = true;
		btnBrowseQueryOutFolder.Click += btnBrowseQueryOutFolder_Click;
		// 
		// txtQueryOutputFolder
		// 
		txtQueryOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtQueryOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtQueryOutputFolder.Location = new System.Drawing.Point(174, 273);
		txtQueryOutputFolder.Name = "txtQueryOutputFolder";
		txtQueryOutputFolder.Size = new System.Drawing.Size(799, 25);
		txtQueryOutputFolder.TabIndex = 13;
		txtQueryOutputFolder.TextChanged += txtQueryOutputFolder_TextChanged;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(71, 274);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(99, 19);
		label4.TabIndex = 12;
		label4.Text = "Output Folder:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseCntlrOutFolder
		// 
		btnBrowseCntlrOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseCntlrOutFolder.Location = new System.Drawing.Point(982, 182);
		btnBrowseCntlrOutFolder.Name = "btnBrowseCntlrOutFolder";
		btnBrowseCntlrOutFolder.Size = new System.Drawing.Size(28, 28);
		btnBrowseCntlrOutFolder.TabIndex = 20;
		btnBrowseCntlrOutFolder.Text = "...";
		btnBrowseCntlrOutFolder.UseVisualStyleBackColor = true;
		btnBrowseCntlrOutFolder.Click += btnBrowseCntlrOutFolder_Click;
		// 
		// txtControllerOutputFolder
		// 
		txtControllerOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtControllerOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllerOutputFolder.Location = new System.Drawing.Point(175, 182);
		txtControllerOutputFolder.Name = "txtControllerOutputFolder";
		txtControllerOutputFolder.Size = new System.Drawing.Size(798, 25);
		txtControllerOutputFolder.TabIndex = 19;
		txtControllerOutputFolder.TextChanged += txtControllerOutputFolder_TextChanged;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(71, 183);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(99, 19);
		label6.TabIndex = 18;
		label6.Text = "Output Folder:";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseApiClientOutFolder
		// 
		btnBrowseApiClientOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientOutFolder.Location = new System.Drawing.Point(982, 361);
		btnBrowseApiClientOutFolder.Name = "btnBrowseApiClientOutFolder";
		btnBrowseApiClientOutFolder.Size = new System.Drawing.Size(28, 28);
		btnBrowseApiClientOutFolder.TabIndex = 26;
		btnBrowseApiClientOutFolder.Text = "...";
		btnBrowseApiClientOutFolder.UseVisualStyleBackColor = true;
		btnBrowseApiClientOutFolder.Click += btnBrowseApiClientOutFolder_Click;
		// 
		// txtApiClientOutputFolder
		// 
		txtApiClientOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientOutputFolder.Location = new System.Drawing.Point(174, 361);
		txtApiClientOutputFolder.Name = "txtApiClientOutputFolder";
		txtApiClientOutputFolder.Size = new System.Drawing.Size(799, 25);
		txtApiClientOutputFolder.TabIndex = 25;
		txtApiClientOutputFolder.TextChanged += txtApiClientOutputFolder_TextChanged;
		// 
		// label8
		// 
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(71, 362);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(99, 19);
		label8.TabIndex = 24;
		label8.Text = "Output Folder:";
		label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// pictureBox1
		// 
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(15, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(30, 27);
		pictureBox1.TabIndex = 30;
		pictureBox1.TabStop = false;
		// 
		// btnBrowseApiClientExtOutputFile
		// 
		btnBrowseApiClientExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientExtOutputFile.Location = new System.Drawing.Point(982, 423);
		btnBrowseApiClientExtOutputFile.Name = "btnBrowseApiClientExtOutputFile";
		btnBrowseApiClientExtOutputFile.Size = new System.Drawing.Size(28, 28);
		btnBrowseApiClientExtOutputFile.TabIndex = 33;
		btnBrowseApiClientExtOutputFile.Text = "...";
		btnBrowseApiClientExtOutputFile.UseVisualStyleBackColor = true;
		btnBrowseApiClientExtOutputFile.Click += btnBrowseApiClientServicesExtOutputFile_Click;
		// 
		// txtApiClientExtOutputFile
		// 
		txtApiClientExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientExtOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientExtOutputFile.Location = new System.Drawing.Point(174, 423);
		txtApiClientExtOutputFile.Name = "txtApiClientExtOutputFile";
		txtApiClientExtOutputFile.Size = new System.Drawing.Size(799, 25);
		txtApiClientExtOutputFile.TabIndex = 32;
		txtApiClientExtOutputFile.TextChanged += txtApiClientServicesExtOutputFile_TextChanged;
		// 
		// label9
		// 
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(40, 424);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(130, 19);
		label9.TabIndex = 31;
		label9.Text = "Coll Ext Output File:";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// label10
		// 
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label10.Location = new System.Drawing.Point(12, 342);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(74, 19);
		label10.TabIndex = 34;
		label10.Text = "API Client";
		// 
		// label11
		// 
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label11.Location = new System.Drawing.Point(12, 158);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(77, 19);
		label11.TabIndex = 35;
		label11.Text = "Controller";
		// 
		// label12
		// 
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label12.Location = new System.Drawing.Point(12, 248);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(88, 19);
		label12.TabIndex = 36;
		label12.Text = "Query Class";
		// 
		// label13
		// 
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label13.Location = new System.Drawing.Point(13, 35);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(59, 19);
		label13.TabIndex = 37;
		label13.Text = "Service";
		// 
		// txtApiClientsNamespace
		// 
		txtApiClientsNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientsNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientsNamespace.Location = new System.Drawing.Point(174, 392);
		txtApiClientsNamespace.Name = "txtApiClientsNamespace";
		txtApiClientsNamespace.Size = new System.Drawing.Size(799, 25);
		txtApiClientsNamespace.TabIndex = 48;
		txtApiClientsNamespace.TextChanged += txtApiClientsNamespace_TextChanged;
		// 
		// label15
		// 
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 10F);
		label15.Location = new System.Drawing.Point(19, 393);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(151, 19);
		label15.TabIndex = 47;
		label15.Text = "Api Clients Namespace:";
		label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtControllersNamespace
		// 
		txtControllersNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtControllersNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllersNamespace.Location = new System.Drawing.Point(175, 213);
		txtControllersNamespace.Name = "txtControllersNamespace";
		txtControllersNamespace.Size = new System.Drawing.Size(798, 25);
		txtControllersNamespace.TabIndex = 46;
		txtControllersNamespace.TextChanged += txtControllersNamespace_TextChanged;
		// 
		// label16
		// 
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Segoe UI", 10F);
		label16.Location = new System.Drawing.Point(17, 214);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(153, 19);
		label16.TabIndex = 45;
		label16.Text = "Controllers Namespace:";
		label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtQueriesNamespace
		// 
		txtQueriesNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtQueriesNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtQueriesNamespace.Location = new System.Drawing.Point(174, 304);
		txtQueriesNamespace.Name = "txtQueriesNamespace";
		txtQueriesNamespace.Size = new System.Drawing.Size(799, 25);
		txtQueriesNamespace.TabIndex = 44;
		txtQueriesNamespace.TextChanged += txtQueriesNamespace_TextChanged;
		// 
		// label17
		// 
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Segoe UI", 10F);
		label17.Location = new System.Drawing.Point(37, 305);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(133, 19);
		label17.TabIndex = 43;
		label17.Text = "Queries Namespace:";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtServicesNamespace
		// 
		txtServicesNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtServicesNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtServicesNamespace.Location = new System.Drawing.Point(176, 93);
		txtServicesNamespace.Name = "txtServicesNamespace";
		txtServicesNamespace.Size = new System.Drawing.Size(798, 25);
		txtServicesNamespace.TabIndex = 42;
		txtServicesNamespace.TextChanged += txtServicesNamespace_TextChanged;
		// 
		// label18
		// 
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Segoe UI", 10F);
		label18.Location = new System.Drawing.Point(36, 94);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(134, 19);
		label18.TabIndex = 41;
		label18.Text = "Services Namespace:";
		label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// toolStrip1
		// 
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel1 });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(1060, 26);
		toolStrip1.TabIndex = 49;
		toolStrip1.Text = "toolStrip1";
		// 
		// toolStripLabel1
		// 
		toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStripLabel1.Margin = new System.Windows.Forms.Padding(40, 2, 0, 3);
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Size = new System.Drawing.Size(134, 21);
		toolStripLabel1.Text = "Service Generator";
		// 
		// btnBrowseServiceExtOutputFile
		// 
		btnBrowseServiceExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseServiceExtOutputFile.Location = new System.Drawing.Point(982, 124);
		btnBrowseServiceExtOutputFile.Name = "btnBrowseServiceExtOutputFile";
		btnBrowseServiceExtOutputFile.Size = new System.Drawing.Size(28, 28);
		btnBrowseServiceExtOutputFile.TabIndex = 52;
		btnBrowseServiceExtOutputFile.Text = "...";
		btnBrowseServiceExtOutputFile.UseVisualStyleBackColor = true;
		btnBrowseServiceExtOutputFile.Click += btnBrowseServiceExtOutputFile_Click;
		// 
		// txtServiceExtOutputFile
		// 
		txtServiceExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtServiceExtOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtServiceExtOutputFile.Location = new System.Drawing.Point(176, 124);
		txtServiceExtOutputFile.Name = "txtServiceExtOutputFile";
		txtServiceExtOutputFile.Size = new System.Drawing.Size(798, 25);
		txtServiceExtOutputFile.TabIndex = 51;
		txtServiceExtOutputFile.TextChanged += txtServiceExtOutputFile_TextChanged;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(40, 123);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(130, 19);
		label2.TabIndex = 50;
		label2.Text = "Coll Ext Output File:";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtDtoNamespace
		// 
		txtDtoNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtDtoNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtDtoNamespace.Location = new System.Drawing.Point(174, 508);
		txtDtoNamespace.Name = "txtDtoNamespace";
		txtDtoNamespace.Size = new System.Drawing.Size(799, 25);
		txtDtoNamespace.TabIndex = 58;
		txtDtoNamespace.TextChanged += txtDtoNamespace_TextChanged;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 10F);
		label3.Location = new System.Drawing.Point(56, 509);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(112, 19);
		label3.TabIndex = 57;
		label3.Text = "DTO Namespace:";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label5.Location = new System.Drawing.Point(12, 458);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(43, 19);
		label5.TabIndex = 56;
		label5.Text = "DTOs";
		// 
		// btnBrowseDtoOutputFolder
		// 
		btnBrowseDtoOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseDtoOutputFolder.Location = new System.Drawing.Point(982, 477);
		btnBrowseDtoOutputFolder.Name = "btnBrowseDtoOutputFolder";
		btnBrowseDtoOutputFolder.Size = new System.Drawing.Size(28, 28);
		btnBrowseDtoOutputFolder.TabIndex = 55;
		btnBrowseDtoOutputFolder.Text = "...";
		btnBrowseDtoOutputFolder.UseVisualStyleBackColor = true;
		btnBrowseDtoOutputFolder.Click += btnBrowseDtoOutputFolder_Click;
		// 
		// txtDtoOutputFolder
		// 
		txtDtoOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtDtoOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtDtoOutputFolder.Location = new System.Drawing.Point(174, 477);
		txtDtoOutputFolder.Name = "txtDtoOutputFolder";
		txtDtoOutputFolder.Size = new System.Drawing.Size(799, 25);
		txtDtoOutputFolder.TabIndex = 54;
		txtDtoOutputFolder.TextChanged += txtDtoOutputFolder_TextChanged;
		// 
		// label7
		// 
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(71, 478);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(99, 19);
		label7.TabIndex = 53;
		label7.Text = "Output Folder:";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// ServiceGenEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(txtDtoNamespace);
		Controls.Add(label3);
		Controls.Add(label5);
		Controls.Add(btnBrowseDtoOutputFolder);
		Controls.Add(txtDtoOutputFolder);
		Controls.Add(label7);
		Controls.Add(btnBrowseServiceExtOutputFile);
		Controls.Add(txtServiceExtOutputFile);
		Controls.Add(label2);
		Controls.Add(ckbInclHeader);
		Controls.Add(ckbEnabled);
		Controls.Add(pictureBox1);
		Controls.Add(toolStrip1);
		Controls.Add(txtApiClientsNamespace);
		Controls.Add(label15);
		Controls.Add(txtControllersNamespace);
		Controls.Add(label16);
		Controls.Add(txtQueriesNamespace);
		Controls.Add(label17);
		Controls.Add(txtServicesNamespace);
		Controls.Add(label18);
		Controls.Add(label13);
		Controls.Add(label12);
		Controls.Add(label11);
		Controls.Add(label10);
		Controls.Add(btnBrowseApiClientExtOutputFile);
		Controls.Add(txtApiClientExtOutputFile);
		Controls.Add(label9);
		Controls.Add(btnBrowseApiClientOutFolder);
		Controls.Add(txtApiClientOutputFolder);
		Controls.Add(label8);
		Controls.Add(btnBrowseCntlrOutFolder);
		Controls.Add(txtControllerOutputFolder);
		Controls.Add(label6);
		Controls.Add(btnBrowseQueryOutFolder);
		Controls.Add(txtQueryOutputFolder);
		Controls.Add(label4);
		Controls.Add(btnBrowseFolder);
		Controls.Add(txtOutputFolder);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F);
		Name = "ServiceGenEditCtl";
		Size = new System.Drawing.Size(1060, 756);
		Load += ServiceGenEditCtl_Load;
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox txtOutputFolder;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.CheckBox ckbInclHeader;
	private System.Windows.Forms.Button btnBrowseFolder;
	private System.Windows.Forms.FolderBrowserDialog folderDlg;
	private System.Windows.Forms.OpenFileDialog fileDlg;
	private System.Windows.Forms.Button btnBrowseQueryOutFolder;
	private System.Windows.Forms.TextBox txtQueryOutputFolder;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Button btnBrowseCntlrOutFolder;
	private System.Windows.Forms.TextBox txtControllerOutputFolder;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.Button btnBrowseApiClientOutFolder;
	private System.Windows.Forms.TextBox txtApiClientOutputFolder;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.PictureBox pictureBox1;
	private System.Windows.Forms.Button btnBrowseApiClientExtOutputFile;
	private System.Windows.Forms.TextBox txtApiClientExtOutputFile;
	private System.Windows.Forms.Label label9;
	private System.Windows.Forms.Label label10;
	private System.Windows.Forms.Label label11;
	private System.Windows.Forms.Label label12;
	private System.Windows.Forms.Label label13;
	private System.Windows.Forms.TextBox txtApiClientsNamespace;
	private System.Windows.Forms.Label label15;
	private System.Windows.Forms.TextBox txtControllersNamespace;
	private System.Windows.Forms.Label label16;
	private System.Windows.Forms.TextBox txtQueriesNamespace;
	private System.Windows.Forms.Label label17;
	private System.Windows.Forms.TextBox txtServicesNamespace;
	private System.Windows.Forms.Label label18;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripLabel toolStripLabel1;
	private System.Windows.Forms.Button btnBrowseServiceExtOutputFile;
	private System.Windows.Forms.TextBox txtServiceExtOutputFile;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.TextBox txtDtoNamespace;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.Button btnBrowseDtoOutputFolder;
	private System.Windows.Forms.TextBox txtDtoOutputFolder;
	private System.Windows.Forms.Label label7;
}
