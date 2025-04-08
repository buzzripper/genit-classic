namespace Dyvenix.Genit.UserControls;

partial class IntTestsGenEditCtl
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
		ckbEnabled = new System.Windows.Forms.CheckBox();
		ckbInclHeader = new System.Windows.Forms.CheckBox();
		folderDlg = new System.Windows.Forms.FolderBrowserDialog();
		fileDlg = new System.Windows.Forms.OpenFileDialog();
		btnBrowseIntTestsOutFolder = new System.Windows.Forms.Button();
		txtIntTestsOutputFolder = new System.Windows.Forms.TextBox();
		label8 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		txtIntTestsNamespace = new System.Windows.Forms.TextBox();
		label15 = new System.Windows.Forms.Label();
		tsHeader = new System.Windows.Forms.ToolStrip();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		tsHeader.SuspendLayout();
		SuspendLayout();
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(726, 5);
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
		ckbInclHeader.Location = new System.Drawing.Point(597, 5);
		ckbInclHeader.Name = "ckbInclHeader";
		ckbInclHeader.Size = new System.Drawing.Size(120, 23);
		ckbInclHeader.TabIndex = 4;
		ckbInclHeader.Text = "Include Header";
		ckbInclHeader.UseVisualStyleBackColor = true;
		ckbInclHeader.CheckedChanged += ckbInclHeader_CheckedChanged;
		// 
		// fileDlg
		// 
		fileDlg.DefaultExt = "*.tmpl";
		fileDlg.Filter = "All Files (*.*)|*.*";
		// 
		// btnBrowseIntTestsOutFolder
		// 
		btnBrowseIntTestsOutFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseIntTestsOutFolder.Location = new System.Drawing.Point(748, 114);
		btnBrowseIntTestsOutFolder.Name = "btnBrowseIntTestsOutFolder";
		btnBrowseIntTestsOutFolder.Size = new System.Drawing.Size(28, 25);
		btnBrowseIntTestsOutFolder.TabIndex = 26;
		btnBrowseIntTestsOutFolder.Text = "...";
		btnBrowseIntTestsOutFolder.UseVisualStyleBackColor = true;
		btnBrowseIntTestsOutFolder.Click += btnBrowseIntTestsOutFolder_Click;
		// 
		// txtIntTestsOutputFolder
		// 
		txtIntTestsOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtIntTestsOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtIntTestsOutputFolder.Location = new System.Drawing.Point(176, 114);
		txtIntTestsOutputFolder.Name = "txtIntTestsOutputFolder";
		txtIntTestsOutputFolder.Size = new System.Drawing.Size(566, 25);
		txtIntTestsOutputFolder.TabIndex = 25;
		txtIntTestsOutputFolder.TextChanged += txtIntTestsOutputFolder_TextChanged;
		// 
		// label8
		// 
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(71, 116);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(99, 19);
		label8.TabIndex = 24;
		label8.Text = "Output Folder:";
		label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// label10
		// 
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
		label10.Location = new System.Drawing.Point(17, 73);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(110, 19);
		label10.TabIndex = 34;
		label10.Text = "API Client Tests";
		// 
		// txtIntTestsNamespace
		// 
		txtIntTestsNamespace.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtIntTestsNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtIntTestsNamespace.Location = new System.Drawing.Point(176, 149);
		txtIntTestsNamespace.Name = "txtIntTestsNamespace";
		txtIntTestsNamespace.Size = new System.Drawing.Size(566, 25);
		txtIntTestsNamespace.TabIndex = 48;
		txtIntTestsNamespace.TextChanged += txtIntTestsNamespace_TextChanged;
		// 
		// label15
		// 
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 10F);
		label15.Location = new System.Drawing.Point(88, 150);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(82, 19);
		label15.TabIndex = 47;
		label15.Text = "Namespace:";
		label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// tsHeader
		// 
		tsHeader.ImageScalingSize = new System.Drawing.Size(24, 24);
		tsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel1 });
		tsHeader.Location = new System.Drawing.Point(0, 0);
		tsHeader.Name = "tsHeader";
		tsHeader.Size = new System.Drawing.Size(825, 26);
		tsHeader.TabIndex = 49;
		tsHeader.Text = "toolStrip1";
		// 
		// toolStripLabel1
		// 
		toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStripLabel1.Margin = new System.Windows.Forms.Padding(40, 2, 0, 3);
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Size = new System.Drawing.Size(197, 21);
		toolStripLabel1.Text = "Integration Tests Generator";
		// 
		// IntTestsGenEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(ckbInclHeader);
		Controls.Add(ckbEnabled);
		Controls.Add(tsHeader);
		Controls.Add(txtIntTestsNamespace);
		Controls.Add(label15);
		Controls.Add(label10);
		Controls.Add(btnBrowseIntTestsOutFolder);
		Controls.Add(txtIntTestsOutputFolder);
		Controls.Add(label8);
		Font = new System.Drawing.Font("Segoe UI", 10F);
		Name = "IntTestsGenEditCtl";
		Size = new System.Drawing.Size(825, 343);
		Load += ServiceGenEditCtl_Load;
		tsHeader.ResumeLayout(false);
		tsHeader.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.CheckBox ckbInclHeader;
	private System.Windows.Forms.FolderBrowserDialog folderDlg;
	private System.Windows.Forms.OpenFileDialog fileDlg;
	private System.Windows.Forms.Button btnBrowseIntTestsOutFolder;
	private System.Windows.Forms.TextBox txtIntTestsOutputFolder;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.Label label10;
	private System.Windows.Forms.TextBox txtIntTestsNamespace;
	private System.Windows.Forms.Label label15;
	private System.Windows.Forms.ToolStrip tsHeader;
	private System.Windows.Forms.ToolStripLabel toolStripLabel1;
}
