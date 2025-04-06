namespace Dyvenix.Genit.UserControls;

partial class GeneratorsEditCtl
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
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		txtTemplatesFolder = new System.Windows.Forms.TextBox();
		lbl1 = new System.Windows.Forms.Label();
		btnBrowseTemplatesFolder = new System.Windows.Forms.Button();
		folderDlg = new System.Windows.Forms.FolderBrowserDialog();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// toolStrip1
		// 
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel1 });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(1049, 37);
		toolStrip1.TabIndex = 13;
		toolStrip1.Text = "toolStrip1";
		// 
		// toolStripLabel1
		// 
		toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Size = new System.Drawing.Size(130, 32);
		toolStripLabel1.Text = "Generators";
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(919, 10);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(101, 29);
		ckbEnabled.TabIndex = 14;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		// 
		// txtTemplatesFolder
		// 
		txtTemplatesFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtTemplatesFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtTemplatesFolder.Location = new System.Drawing.Point(220, 95);
		txtTemplatesFolder.Name = "txtTemplatesFolder";
		txtTemplatesFolder.Size = new System.Drawing.Size(739, 31);
		txtTemplatesFolder.TabIndex = 16;
		txtTemplatesFolder.TextChanged += txtTemplatesFolder_TextChanged;
		// 
		// lbl1
		// 
		lbl1.AutoSize = true;
		lbl1.Location = new System.Drawing.Point(48, 99);
		lbl1.Name = "lbl1";
		lbl1.Size = new System.Drawing.Size(150, 25);
		lbl1.TabIndex = 15;
		lbl1.Text = "Templates Folder:";
		// 
		// btnBrowseTemplatesFolder
		// 
		btnBrowseTemplatesFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		btnBrowseTemplatesFolder.Location = new System.Drawing.Point(980, 95);
		btnBrowseTemplatesFolder.Name = "btnBrowseTemplatesFolder";
		btnBrowseTemplatesFolder.Size = new System.Drawing.Size(32, 32);
		btnBrowseTemplatesFolder.TabIndex = 17;
		btnBrowseTemplatesFolder.Text = "...";
		btnBrowseTemplatesFolder.UseVisualStyleBackColor = true;
		btnBrowseTemplatesFolder.Click += btnBrowseTemplatesFolder_Click;
		// 
		// GeneratorsEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(btnBrowseTemplatesFolder);
		Controls.Add(txtTemplatesFolder);
		Controls.Add(lbl1);
		Controls.Add(ckbEnabled);
		Controls.Add(toolStrip1);
		Name = "GeneratorsEditCtl";
		Size = new System.Drawing.Size(1049, 513);
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripLabel toolStripLabel1;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.Button btnBrowseTemplatesFolder;
	private System.Windows.Forms.TextBox txtTemplatesFolder;
	private System.Windows.Forms.Label lbl1;
	private System.Windows.Forms.FolderBrowserDialog folderDlg;
}
