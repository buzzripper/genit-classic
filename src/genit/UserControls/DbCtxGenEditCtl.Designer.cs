namespace Dyvenix.Genit.UserControls;

partial class DbCtxGenEditCtl
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
		label2 = new System.Windows.Forms.Label();
		txtOutputFolder = new System.Windows.Forms.TextBox();
		ckbInclHeader = new System.Windows.Forms.CheckBox();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		folderDlg = new System.Windows.Forms.FolderBrowserDialog();
		btnBrowseFolder = new System.Windows.Forms.Button();
		btnBrowseTempleFilepath = new System.Windows.Forms.Button();
		txtTemplateFilepath = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		fileDlg = new System.Windows.Forms.OpenFileDialog();
		txtContextNamespace = new System.Windows.Forms.TextBox();
		label4 = new System.Windows.Forms.Label();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(3, 2);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(248, 32);
		label1.TabIndex = 0;
		label1.Text = "Db Context Generator";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(74, 104);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(140, 28);
		label2.TabIndex = 1;
		label2.Text = "Output Folder:";
		// 
		// txtOutputFolder
		// 
		txtOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtOutputFolder.Location = new System.Drawing.Point(232, 102);
		txtOutputFolder.Name = "txtOutputFolder";
		txtOutputFolder.Size = new System.Drawing.Size(852, 34);
		txtOutputFolder.TabIndex = 2;
		txtOutputFolder.TextChanged += txtOutputFolder_TextChanged;
		// 
		// ckbInclHeader
		// 
		ckbInclHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbInclHeader.AutoSize = true;
		ckbInclHeader.Location = new System.Drawing.Point(848, 8);
		ckbInclHeader.Name = "ckbInclHeader";
		ckbInclHeader.Size = new System.Drawing.Size(169, 32);
		ckbInclHeader.TabIndex = 3;
		ckbInclHeader.Text = "Include Header";
		ckbInclHeader.UseVisualStyleBackColor = true;
		ckbInclHeader.CheckedChanged += ckbInclHeader_CheckedChanged;
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(1006, 8);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(108, 32);
		ckbEnabled.TabIndex = 4;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// btnBrowseFolder
		// 
		btnBrowseFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseFolder.Location = new System.Drawing.Point(1090, 102);
		btnBrowseFolder.Name = "btnBrowseFolder";
		btnBrowseFolder.Size = new System.Drawing.Size(24, 22);
		btnBrowseFolder.TabIndex = 5;
		btnBrowseFolder.Text = "...";
		btnBrowseFolder.UseVisualStyleBackColor = true;
		btnBrowseFolder.Click += btnBrowseFolder_Click;
		// 
		// btnBrowseTempleFilepath
		// 
		btnBrowseTempleFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseTempleFilepath.Location = new System.Drawing.Point(1092, 61);
		btnBrowseTempleFilepath.Name = "btnBrowseTempleFilepath";
		btnBrowseTempleFilepath.Size = new System.Drawing.Size(24, 22);
		btnBrowseTempleFilepath.TabIndex = 8;
		btnBrowseTempleFilepath.Text = "...";
		btnBrowseTempleFilepath.UseVisualStyleBackColor = true;
		btnBrowseTempleFilepath.Click += btnBrowseTemplateFilepath_Click;
		// 
		// txtTemplateFilepath
		// 
		txtTemplateFilepath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtTemplateFilepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtTemplateFilepath.Location = new System.Drawing.Point(234, 61);
		txtTemplateFilepath.Name = "txtTemplateFilepath";
		txtTemplateFilepath.Size = new System.Drawing.Size(852, 34);
		txtTemplateFilepath.TabIndex = 7;
		txtTemplateFilepath.TextChanged += txtTemplateFilepath_TextChanged;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(84, 62);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(130, 28);
		label3.TabIndex = 6;
		label3.Text = "Template File:";
		// 
		// fileDlg
		// 
		fileDlg.DefaultExt = "*.tmpl";
		fileDlg.Filter = "Template file (*.tmpl)|*.tmpl| All Files (*.*)|*.*";
		// 
		// txtContextNamespace
		// 
		txtContextNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtContextNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtContextNamespace.Location = new System.Drawing.Point(232, 144);
		txtContextNamespace.Name = "txtContextNamespace";
		txtContextNamespace.Size = new System.Drawing.Size(852, 34);
		txtContextNamespace.TabIndex = 14;
		txtContextNamespace.TextChanged += txtContextNamespace_TextChanged;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 10F);
		label4.Location = new System.Drawing.Point(24, 146);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(190, 28);
		label4.TabIndex = 13;
		label4.Text = "Context Namespace:";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// DbCtxGenEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(txtContextNamespace);
		Controls.Add(label4);
		Controls.Add(btnBrowseTempleFilepath);
		Controls.Add(txtTemplateFilepath);
		Controls.Add(label3);
		Controls.Add(btnBrowseFolder);
		Controls.Add(ckbEnabled);
		Controls.Add(ckbInclHeader);
		Controls.Add(txtOutputFolder);
		Controls.Add(label2);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "DbCtxGenEditCtl";
		Size = new System.Drawing.Size(1172, 315);
		Load += DbCtxGenEditCtl_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.TextBox txtOutputFolder;
	private System.Windows.Forms.CheckBox ckbInclHeader;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.FolderBrowserDialog folderDlg;
	private System.Windows.Forms.Button btnBrowseFolder;
	private System.Windows.Forms.Button btnBrowseTempleFilepath;
	private System.Windows.Forms.TextBox txtTemplateFilepath;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.OpenFileDialog fileDlg;
	private System.Windows.Forms.TextBox txtContextNamespace;
	private System.Windows.Forms.Label label4;
}
