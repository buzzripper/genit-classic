namespace Dyvenix.Genit.UserControls;

partial class EnumGenEditCtl
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
		ckbEnabled = new System.Windows.Forms.CheckBox();
		ckbInclHeader = new System.Windows.Forms.CheckBox();
		btnBrowseFolder = new System.Windows.Forms.Button();
		folderDlg = new System.Windows.Forms.FolderBrowserDialog();
		fileDlg = new System.Windows.Forms.OpenFileDialog();
		txtEnumsNamespace = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(76, 97);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(140, 28);
		label1.TabIndex = 0;
		label1.Text = "Output Folder:";
		// 
		// txtOutputFolder
		// 
		txtOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtOutputFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtOutputFolder.Location = new System.Drawing.Point(222, 95);
		txtOutputFolder.Name = "txtOutputFolder";
		txtOutputFolder.Size = new System.Drawing.Size(543, 33);
		txtOutputFolder.TabIndex = 1;
		txtOutputFolder.TextChanged += txtOutputFolder_TextChanged;
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(723, 5);
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
		ckbInclHeader.Location = new System.Drawing.Point(534, 5);
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
		btnBrowseFolder.Location = new System.Drawing.Point(776, 96);
		btnBrowseFolder.Name = "btnBrowseFolder";
		btnBrowseFolder.Size = new System.Drawing.Size(32, 32);
		btnBrowseFolder.TabIndex = 7;
		btnBrowseFolder.Text = "...";
		btnBrowseFolder.UseVisualStyleBackColor = true;
		btnBrowseFolder.Click += btnBrowseFolder_Click;
		// 
		// fileDlg
		// 
		fileDlg.DefaultExt = "*.tmpl";
		fileDlg.Filter = "Template file (*.tmpl)|*.tmpl| All Files (*.*)|*.*";
		// 
		// txtEnumsNamespace
		// 
		txtEnumsNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtEnumsNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtEnumsNamespace.Location = new System.Drawing.Point(222, 145);
		txtEnumsNamespace.Name = "txtEnumsNamespace";
		txtEnumsNamespace.Size = new System.Drawing.Size(543, 34);
		txtEnumsNamespace.TabIndex = 17;
		txtEnumsNamespace.TextChanged += txtEnumsNamespace_TextChanged;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 10F);
		label5.Location = new System.Drawing.Point(37, 146);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(179, 28);
		label5.TabIndex = 16;
		label5.Text = "Enums Namespace:";
		label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// toolStrip1
		// 
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel1 });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(849, 37);
		toolStrip1.TabIndex = 18;
		toolStrip1.Text = "toolStrip1";
		// 
		// toolStripLabel1
		// 
		toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Size = new System.Drawing.Size(188, 32);
		toolStripLabel1.Text = "Enum Generator";
		// 
		// EnumGenEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(ckbInclHeader);
		Controls.Add(ckbEnabled);
		Controls.Add(toolStrip1);
		Controls.Add(txtEnumsNamespace);
		Controls.Add(label5);
		Controls.Add(btnBrowseFolder);
		Controls.Add(txtOutputFolder);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F);
		Name = "EnumGenEditCtl";
		Size = new System.Drawing.Size(849, 298);
		Load += EnumGenEditCtl_Load;
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
	private System.Windows.Forms.TextBox txtEnumsNamespace;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripLabel toolStripLabel1;
}
