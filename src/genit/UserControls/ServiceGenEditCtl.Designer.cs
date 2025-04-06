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
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(123, 104);
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
		txtOutputFolder.Location = new System.Drawing.Point(276, 101);
		txtOutputFolder.Name = "txtOutputFolder";
		txtOutputFolder.Size = new System.Drawing.Size(698, 34);
		txtOutputFolder.TabIndex = 1;
		txtOutputFolder.TextChanged += txtOutputFolder_TextChanged;
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(913, 5);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(108, 32);
		ckbEnabled.TabIndex = 3;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// ckbInclHeader
		// 
		ckbInclHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbInclHeader.AutoSize = true;
		ckbInclHeader.Location = new System.Drawing.Point(718, 5);
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
		btnBrowseFolder.Location = new System.Drawing.Point(983, 103);
		btnBrowseFolder.Name = "btnBrowseFolder";
		btnBrowseFolder.Size = new System.Drawing.Size(32, 32);
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
		btnBrowseQueryOutFolder.Location = new System.Drawing.Point(982, 425);
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
		txtQueryOutputFolder.Location = new System.Drawing.Point(276, 424);
		txtQueryOutputFolder.Name = "txtQueryOutputFolder";
		txtQueryOutputFolder.Size = new System.Drawing.Size(698, 34);
		txtQueryOutputFolder.TabIndex = 13;
		txtQueryOutputFolder.TextChanged += txtQueryOutputFolder_TextChanged;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(123, 426);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(140, 28);
		label4.TabIndex = 12;
		label4.Text = "Output Folder:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseCntlrOutFolder
		// 
		btnBrowseCntlrOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseCntlrOutFolder.Location = new System.Drawing.Point(983, 270);
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
		txtControllerOutputFolder.Location = new System.Drawing.Point(276, 270);
		txtControllerOutputFolder.Name = "txtControllerOutputFolder";
		txtControllerOutputFolder.Size = new System.Drawing.Size(698, 34);
		txtControllerOutputFolder.TabIndex = 19;
		txtControllerOutputFolder.TextChanged += txtControllerOutputFolder_TextChanged;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(123, 273);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(140, 28);
		label6.TabIndex = 18;
		label6.Text = "Output Folder:";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// btnBrowseApiClientOutFolder
		// 
		btnBrowseApiClientOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseApiClientOutFolder.Location = new System.Drawing.Point(983, 568);
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
		txtApiClientOutputFolder.Location = new System.Drawing.Point(276, 568);
		txtApiClientOutputFolder.Name = "txtApiClientOutputFolder";
		txtApiClientOutputFolder.Size = new System.Drawing.Size(698, 34);
		txtApiClientOutputFolder.TabIndex = 25;
		txtApiClientOutputFolder.TextChanged += txtApiClientOutputFolder_TextChanged;
		// 
		// label8
		// 
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(123, 575);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(140, 28);
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
		btnBrowseApiClientExtOutputFile.Location = new System.Drawing.Point(983, 664);
		btnBrowseApiClientExtOutputFile.Name = "btnBrowseApiClientExtOutputFile";
		btnBrowseApiClientExtOutputFile.Size = new System.Drawing.Size(32, 32);
		btnBrowseApiClientExtOutputFile.TabIndex = 33;
		btnBrowseApiClientExtOutputFile.Text = "...";
		btnBrowseApiClientExtOutputFile.UseVisualStyleBackColor = true;
		btnBrowseApiClientExtOutputFile.Click += btnBrowseApiClientServicesExtOutputFile_Click;
		// 
		// txtApiClientExtOutputFile
		// 
		txtApiClientExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientExtOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientExtOutputFile.Location = new System.Drawing.Point(276, 662);
		txtApiClientExtOutputFile.Name = "txtApiClientExtOutputFile";
		txtApiClientExtOutputFile.Size = new System.Drawing.Size(698, 34);
		txtApiClientExtOutputFile.TabIndex = 32;
		txtApiClientExtOutputFile.TextChanged += txtApiClientServicesExtOutputFile_TextChanged;
		// 
		// label9
		// 
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(79, 664);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(184, 28);
		label9.TabIndex = 31;
		label9.Text = "Coll Ext Output File:";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// label10
		// 
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label10.Location = new System.Drawing.Point(13, 532);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(105, 28);
		label10.TabIndex = 34;
		label10.Text = "API Client";
		// 
		// label11
		// 
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label11.Location = new System.Drawing.Point(13, 237);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(107, 28);
		label11.TabIndex = 35;
		label11.Text = "Controller";
		// 
		// label12
		// 
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label12.Location = new System.Drawing.Point(13, 383);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(123, 28);
		label12.TabIndex = 36;
		label12.Text = "Query Class";
		// 
		// label13
		// 
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label13.Location = new System.Drawing.Point(13, 71);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(81, 28);
		label13.TabIndex = 37;
		label13.Text = "Service";
		// 
		// txtApiClientsNamespace
		// 
		txtApiClientsNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtApiClientsNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtApiClientsNamespace.Location = new System.Drawing.Point(276, 615);
		txtApiClientsNamespace.Name = "txtApiClientsNamespace";
		txtApiClientsNamespace.Size = new System.Drawing.Size(698, 34);
		txtApiClientsNamespace.TabIndex = 48;
		txtApiClientsNamespace.TextChanged += txtApiClientsNamespace_TextChanged;
		// 
		// label15
		// 
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 10F);
		label15.Location = new System.Drawing.Point(48, 621);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(215, 28);
		label15.TabIndex = 47;
		label15.Text = "Api Clients Namespace:";
		label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtControllersNamespace
		// 
		txtControllersNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtControllersNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllersNamespace.Location = new System.Drawing.Point(276, 314);
		txtControllersNamespace.Name = "txtControllersNamespace";
		txtControllersNamespace.Size = new System.Drawing.Size(698, 34);
		txtControllersNamespace.TabIndex = 46;
		txtControllersNamespace.TextChanged += txtControllersNamespace_TextChanged;
		// 
		// label16
		// 
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Segoe UI", 10F);
		label16.Location = new System.Drawing.Point(45, 316);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(218, 28);
		label16.TabIndex = 45;
		label16.Text = "Controllers Namespace:";
		label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtQueriesNamespace
		// 
		txtQueriesNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtQueriesNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtQueriesNamespace.Location = new System.Drawing.Point(276, 468);
		txtQueriesNamespace.Name = "txtQueriesNamespace";
		txtQueriesNamespace.Size = new System.Drawing.Size(698, 34);
		txtQueriesNamespace.TabIndex = 44;
		txtQueriesNamespace.TextChanged += txtQueriesNamespace_TextChanged;
		// 
		// label17
		// 
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Segoe UI", 10F);
		label17.Location = new System.Drawing.Point(75, 470);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(188, 28);
		label17.TabIndex = 43;
		label17.Text = "Queries Namespace:";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtServicesNamespace
		// 
		txtServicesNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtServicesNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtServicesNamespace.Location = new System.Drawing.Point(276, 145);
		txtServicesNamespace.Name = "txtServicesNamespace";
		txtServicesNamespace.Size = new System.Drawing.Size(698, 34);
		txtServicesNamespace.TabIndex = 42;
		txtServicesNamespace.TextChanged += txtServicesNamespace_TextChanged;
		// 
		// label18
		// 
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Segoe UI", 10F);
		label18.Location = new System.Drawing.Point(71, 149);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(192, 28);
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
		toolStrip1.Size = new System.Drawing.Size(1060, 37);
		toolStrip1.TabIndex = 49;
		toolStrip1.Text = "toolStrip1";
		// 
		// toolStripLabel1
		// 
		toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStripLabel1.Margin = new System.Windows.Forms.Padding(40, 2, 0, 3);
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Size = new System.Drawing.Size(203, 32);
		toolStripLabel1.Text = "Service Generator";
		// 
		// btnBrowseServiceExtOutputFile
		// 
		btnBrowseServiceExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseServiceExtOutputFile.Location = new System.Drawing.Point(983, 193);
		btnBrowseServiceExtOutputFile.Name = "btnBrowseServiceExtOutputFile";
		btnBrowseServiceExtOutputFile.Size = new System.Drawing.Size(32, 32);
		btnBrowseServiceExtOutputFile.TabIndex = 52;
		btnBrowseServiceExtOutputFile.Text = "...";
		btnBrowseServiceExtOutputFile.UseVisualStyleBackColor = true;
		btnBrowseServiceExtOutputFile.Click += btnBrowseServiceExtOutputFile_Click;
		// 
		// txtServiceExtOutputFile
		// 
		txtServiceExtOutputFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtServiceExtOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtServiceExtOutputFile.Location = new System.Drawing.Point(276, 191);
		txtServiceExtOutputFile.Name = "txtServiceExtOutputFile";
		txtServiceExtOutputFile.Size = new System.Drawing.Size(698, 34);
		txtServiceExtOutputFile.TabIndex = 51;
		txtServiceExtOutputFile.TextChanged += txtServiceExtOutputFile_TextChanged;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(79, 193);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(184, 28);
		label2.TabIndex = 50;
		label2.Text = "Coll Ext Output File:";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// ServiceGenEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
}
