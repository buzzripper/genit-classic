namespace Dyvenix.Genit;

partial class MainForm
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
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		statusStrip1 = new System.Windows.Forms.StatusStrip();
		statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
		toolLblVersion = new System.Windows.Forms.ToolStripStatusLabel();
		toolLblMessage = new System.Windows.Forms.ToolStripStatusLabel();
		menuStrip1 = new System.Windows.Forms.MenuStrip();
		toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		mnuNew = new System.Windows.Forms.ToolStripMenuItem();
		mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
		mnuSave = new System.Windows.Forms.ToolStripMenuItem();
		mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
		mnuClose = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
		mnuExit = new System.Windows.Forms.ToolStripMenuItem();
		editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		openFileDlg = new System.Windows.Forms.OpenFileDialog();
		saveFileDlg = new System.Windows.Forms.SaveFileDialog();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnNew = new System.Windows.Forms.ToolStripButton();
		btnOpen = new System.Windows.Forms.ToolStripButton();
		btnSave = new System.Windows.Forms.ToolStripButton();
		toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
		btnGenerate = new System.Windows.Forms.ToolStripButton();
		btnTest1 = new System.Windows.Forms.ToolStripButton();
		btnTest2 = new System.Windows.Forms.ToolStripButton();
		splMain = new System.Windows.Forms.SplitContainer();
		treeNav = new Dyvenix.Genit.UserControls.TreeNav();
		splContent = new System.Windows.Forms.SplitContainer();
		splOutput = new System.Windows.Forms.SplitContainer();
		tbOutput = new System.Windows.Forms.ToolStrip();
		toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		btnShowOutput = new System.Windows.Forms.ToolStripButton();
		btnClearOuput = new System.Windows.Forms.ToolStripButton();
		outputCtl = new Dyvenix.Genit.UserControls.OutputCtl();
		tvImgList = new System.Windows.Forms.ImageList(components);
		statusStrip1.SuspendLayout();
		menuStrip1.SuspendLayout();
		toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splContent).BeginInit();
		splContent.Panel2.SuspendLayout();
		splContent.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splOutput).BeginInit();
		splOutput.Panel1.SuspendLayout();
		splOutput.Panel2.SuspendLayout();
		splOutput.SuspendLayout();
		tbOutput.SuspendLayout();
		SuspendLayout();
		// 
		// statusStrip1
		// 
		statusStrip1.BackColor = System.Drawing.SystemColors.Control;
		statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel, toolLblVersion, toolLblMessage });
		statusStrip1.Location = new System.Drawing.Point(0, 593);
		statusStrip1.Name = "statusStrip1";
		statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
		statusStrip1.Size = new System.Drawing.Size(1052, 22);
		statusStrip1.TabIndex = 35;
		// 
		// statusLabel
		// 
		statusLabel.Name = "statusLabel";
		statusLabel.Size = new System.Drawing.Size(0, 17);
		// 
		// toolLblVersion
		// 
		toolLblVersion.ForeColor = System.Drawing.SystemColors.ControlText;
		toolLblVersion.Name = "toolLblVersion";
		toolLblVersion.Size = new System.Drawing.Size(52, 17);
		toolLblVersion.Text = "v. 1.0.0.0";
		// 
		// toolLblMessage
		// 
		toolLblMessage.BackColor = System.Drawing.SystemColors.Control;
		toolLblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
		toolLblMessage.Name = "toolLblMessage";
		toolLblMessage.Size = new System.Drawing.Size(95, 17);
		toolLblMessage.Text = "Auto refresh: Off";
		// 
		// menuStrip1
		// 
		menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1, editToolStripMenuItem });
		menuStrip1.Location = new System.Drawing.Point(0, 0);
		menuStrip1.Name = "menuStrip1";
		menuStrip1.Size = new System.Drawing.Size(1052, 24);
		menuStrip1.TabIndex = 36;
		menuStrip1.Text = "menuStrip1";
		// 
		// toolStripMenuItem1
		// 
		toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuNew, mnuOpen, mnuSave, mnuSaveAs, mnuClose, toolStripMenuItem2, mnuExit });
		toolStripMenuItem1.Name = "toolStripMenuItem1";
		toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
		toolStripMenuItem1.Text = "&File";
		// 
		// mnuNew
		// 
		mnuNew.Name = "mnuNew";
		mnuNew.Size = new System.Drawing.Size(140, 22);
		mnuNew.Text = "&New Model";
		// 
		// mnuOpen
		// 
		mnuOpen.Name = "mnuOpen";
		mnuOpen.Size = new System.Drawing.Size(140, 22);
		mnuOpen.Text = "&Open Model";
		mnuOpen.Click += uiOpen_Click;
		// 
		// mnuSave
		// 
		mnuSave.Name = "mnuSave";
		mnuSave.Size = new System.Drawing.Size(140, 22);
		mnuSave.Text = "&Save Model";
		mnuSave.Click += uiSave_Click;
		// 
		// mnuSaveAs
		// 
		mnuSaveAs.Name = "mnuSaveAs";
		mnuSaveAs.Size = new System.Drawing.Size(140, 22);
		mnuSaveAs.Text = "Save &As...";
		// 
		// mnuClose
		// 
		mnuClose.Name = "mnuClose";
		mnuClose.Size = new System.Drawing.Size(140, 22);
		mnuClose.Text = "&Close Model";
		mnuClose.Click += uiClose_Click;
		// 
		// toolStripMenuItem2
		// 
		toolStripMenuItem2.Name = "toolStripMenuItem2";
		toolStripMenuItem2.Size = new System.Drawing.Size(137, 6);
		// 
		// mnuExit
		// 
		mnuExit.Name = "mnuExit";
		mnuExit.Size = new System.Drawing.Size(140, 22);
		mnuExit.Text = "E&xit";
		mnuExit.Click += uiExit_Click;
		// 
		// editToolStripMenuItem
		// 
		editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { generateToolStripMenuItem });
		editToolStripMenuItem.Name = "editToolStripMenuItem";
		editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
		editToolStripMenuItem.Text = "&Edit";
		// 
		// generateToolStripMenuItem
		// 
		generateToolStripMenuItem.Name = "generateToolStripMenuItem";
		generateToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
		generateToolStripMenuItem.Text = "&Generate";
		generateToolStripMenuItem.Click += uiGenerate_Click;
		// 
		// openFileDlg
		// 
		openFileDlg.DefaultExt = "*.gmdl";
		openFileDlg.Filter = "Model file (*.gmdl)|*.gmdl| All Files (*.*)|*.*";
		// 
		// saveFileDlg
		// 
		saveFileDlg.DefaultExt = "*.gmdl";
		saveFileDlg.Filter = "Model file (*.gmdl)|*.gmdl| All Files (*.*)|*.*";
		// 
		// toolStrip1
		// 
		toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnNew, btnOpen, btnSave, toolStripSeparator, btnGenerate, btnTest1, btnTest2 });
		toolStrip1.Location = new System.Drawing.Point(0, 24);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(1052, 31);
		toolStrip1.TabIndex = 37;
		toolStrip1.Text = "toolStrip1";
		// 
		// btnNew
		// 
		btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnNew.Image = (System.Drawing.Image)resources.GetObject("btnNew.Image");
		btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnNew.Name = "btnNew";
		btnNew.Size = new System.Drawing.Size(28, 28);
		btnNew.Text = "&New";
		// 
		// btnOpen
		// 
		btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnOpen.Image = (System.Drawing.Image)resources.GetObject("btnOpen.Image");
		btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnOpen.Name = "btnOpen";
		btnOpen.Size = new System.Drawing.Size(28, 28);
		btnOpen.Text = "&Open";
		btnOpen.Click += uiOpen_Click;
		// 
		// btnSave
		// 
		btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnSave.Image = (System.Drawing.Image)resources.GetObject("btnSave.Image");
		btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnSave.Name = "btnSave";
		btnSave.Size = new System.Drawing.Size(28, 28);
		btnSave.Text = "&Save";
		btnSave.Click += uiSave_Click;
		// 
		// toolStripSeparator
		// 
		toolStripSeparator.Name = "toolStripSeparator";
		toolStripSeparator.Size = new System.Drawing.Size(6, 31);
		// 
		// btnGenerate
		// 
		btnGenerate.Image = (System.Drawing.Image)resources.GetObject("btnGenerate.Image");
		btnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnGenerate.Name = "btnGenerate";
		btnGenerate.Size = new System.Drawing.Size(82, 28);
		btnGenerate.Text = "Generate";
		btnGenerate.Click += uiGenerate_Click;
		// 
		// btnTest1
		// 
		btnTest1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		btnTest1.Image = (System.Drawing.Image)resources.GetObject("btnTest1.Image");
		btnTest1.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnTest1.Name = "btnTest1";
		btnTest1.Size = new System.Drawing.Size(37, 28);
		btnTest1.Text = "Test1";
		btnTest1.Click += btnTest1_Click;
		// 
		// btnTest2
		// 
		btnTest2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		btnTest2.Image = (System.Drawing.Image)resources.GetObject("btnTest2.Image");
		btnTest2.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnTest2.Name = "btnTest2";
		btnTest2.Size = new System.Drawing.Size(37, 28);
		btnTest2.Text = "Test2";
		btnTest2.Click += btnTest2_Click;
		// 
		// splMain
		// 
		splMain.Dock = System.Windows.Forms.DockStyle.Fill;
		splMain.Location = new System.Drawing.Point(0, 55);
		splMain.Name = "splMain";
		// 
		// splMain.Panel1
		// 
		splMain.Panel1.Controls.Add(treeNav);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.Controls.Add(splContent);
		splMain.Size = new System.Drawing.Size(1052, 538);
		splMain.SplitterDistance = 190;
		splMain.SplitterWidth = 8;
		splMain.TabIndex = 38;
		// 
		// treeNav
		// 
		treeNav.Dock = System.Windows.Forms.DockStyle.Fill;
		treeNav.Location = new System.Drawing.Point(0, 0);
		treeNav.Name = "treeNav";
		treeNav.Size = new System.Drawing.Size(190, 538);
		treeNav.TabIndex = 0;
		// 
		// splContent
		// 
		splContent.Dock = System.Windows.Forms.DockStyle.Fill;
		splContent.Location = new System.Drawing.Point(0, 0);
		splContent.Name = "splContent";
		splContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splContent.Panel2
		// 
		splContent.Panel2.Controls.Add(splOutput);
		splContent.Size = new System.Drawing.Size(854, 538);
		splContent.SplitterDistance = 411;
		splContent.SplitterWidth = 8;
		splContent.TabIndex = 0;
		// 
		// splOutput
		// 
		splOutput.Dock = System.Windows.Forms.DockStyle.Fill;
		splOutput.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		splOutput.IsSplitterFixed = true;
		splOutput.Location = new System.Drawing.Point(0, 0);
		splOutput.Name = "splOutput";
		splOutput.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splOutput.Panel1
		// 
		splOutput.Panel1.Controls.Add(tbOutput);
		// 
		// splOutput.Panel2
		// 
		splOutput.Panel2.Controls.Add(outputCtl);
		splOutput.Size = new System.Drawing.Size(854, 119);
		splOutput.SplitterDistance = 25;
		splOutput.SplitterWidth = 1;
		splOutput.TabIndex = 3;
		// 
		// tbOutput
		// 
		tbOutput.BackColor = System.Drawing.SystemColors.ActiveCaption;
		tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
		tbOutput.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		tbOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel1, btnShowOutput, btnClearOuput });
		tbOutput.Location = new System.Drawing.Point(0, 0);
		tbOutput.Name = "tbOutput";
		tbOutput.Size = new System.Drawing.Size(854, 25);
		tbOutput.TabIndex = 0;
		tbOutput.Text = "Hey";
		// 
		// toolStripLabel1
		// 
		toolStripLabel1.Name = "toolStripLabel1";
		toolStripLabel1.Size = new System.Drawing.Size(45, 22);
		toolStripLabel1.Text = "Output";
		// 
		// btnShowOutput
		// 
		btnShowOutput.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		btnShowOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnShowOutput.Image = (System.Drawing.Image)resources.GetObject("btnShowOutput.Image");
		btnShowOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnShowOutput.Name = "btnShowOutput";
		btnShowOutput.Size = new System.Drawing.Size(23, 22);
		btnShowOutput.Text = "toolStripButton1";
		btnShowOutput.Click += btnShowOutput_Click;
		// 
		// btnClearOuput
		// 
		btnClearOuput.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		btnClearOuput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnClearOuput.Image = (System.Drawing.Image)resources.GetObject("btnClearOuput.Image");
		btnClearOuput.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnClearOuput.Name = "btnClearOuput";
		btnClearOuput.Size = new System.Drawing.Size(23, 22);
		btnClearOuput.Text = "toolStripButton1";
		btnClearOuput.Click += btnClearOuput_Click;
		// 
		// outputCtl
		// 
		outputCtl.Dock = System.Windows.Forms.DockStyle.Fill;
		outputCtl.Location = new System.Drawing.Point(0, 0);
		outputCtl.Name = "outputCtl";
		outputCtl.Size = new System.Drawing.Size(854, 93);
		outputCtl.TabIndex = 0;
		// 
		// tvImgList
		// 
		tvImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		tvImgList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("tvImgList.ImageStream");
		tvImgList.TransparentColor = System.Drawing.Color.Transparent;
		tvImgList.Images.SetKeyName(0, "db");
		tvImgList.Images.SetKeyName(1, "db_dis");
		tvImgList.Images.SetKeyName(2, "ent");
		tvImgList.Images.SetKeyName(3, "ent_dis");
		tvImgList.Images.SetKeyName(4, "enum");
		tvImgList.Images.SetKeyName(5, "enum_dis");
		tvImgList.Images.SetKeyName(6, "assoc");
		tvImgList.Images.SetKeyName(7, "assoc_dis");
		tvImgList.Images.SetKeyName(8, "gen");
		tvImgList.Images.SetKeyName(9, "gen_dis");
		// 
		// MainForm
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.Control;
		ClientSize = new System.Drawing.Size(1052, 615);
		Controls.Add(splMain);
		Controls.Add(toolStrip1);
		Controls.Add(statusStrip1);
		Controls.Add(menuStrip1);
		ForeColor = System.Drawing.SystemColors.ControlText;
		Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		MainMenuStrip = menuStrip1;
		Margin = new System.Windows.Forms.Padding(2);
		Name = "MainForm";
		Text = "GenIt";
		Activated += Form1_Activated;
		FormClosing += Form1_FormClosing;
		Load += Form1_Load;
		Shown += Form1_Shown;
		ResizeEnd += MainForm_ResizeEnd;
		statusStrip1.ResumeLayout(false);
		statusStrip1.PerformLayout();
		menuStrip1.ResumeLayout(false);
		menuStrip1.PerformLayout();
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		splContent.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splContent).EndInit();
		splContent.ResumeLayout(false);
		splOutput.Panel1.ResumeLayout(false);
		splOutput.Panel1.PerformLayout();
		splOutput.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splOutput).EndInit();
		splOutput.ResumeLayout(false);
		tbOutput.ResumeLayout(false);
		tbOutput.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel statusLabel;
	private System.Windows.Forms.ToolStripStatusLabel toolLblVersion;
	private System.Windows.Forms.ToolStripStatusLabel toolLblMessage;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
	private System.Windows.Forms.ToolStripMenuItem mnuOpen;
	private System.Windows.Forms.ToolStripMenuItem mnuSave;
	private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
	private System.Windows.Forms.ToolStripMenuItem mnuClose;
	private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
	private System.Windows.Forms.ToolStripMenuItem mnuExit;
	private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
	private System.Windows.Forms.ToolStripButton helpToolStripButton;
	private System.Windows.Forms.ToolStripMenuItem mnuNew;
	private System.Windows.Forms.OpenFileDialog openFileDlg;
	private System.Windows.Forms.SaveFileDialog saveFileDlg;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripButton btnNew;
	private System.Windows.Forms.ToolStripButton btnOpen;
	private System.Windows.Forms.ToolStripButton btnSave;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
	private System.Windows.Forms.ToolStripButton btnGenerate;
	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.SplitContainer splContent;
	private System.Windows.Forms.ToolStripButton btnTest1;
	private System.Windows.Forms.ToolStripButton btnTest2;
	private System.Windows.Forms.SplitContainer splOutput;
	private System.Windows.Forms.ToolStrip tbOutput;
	private System.Windows.Forms.ToolStripLabel toolStripLabel1;
	private System.Windows.Forms.ToolStripButton btnShowOutput;
	private System.Windows.Forms.ImageList tvImgList;
	private UserControls.DbContextEditCtl dbContextEditCtl;
	private UserControls.TreeNav treeNav;
	private UserControls.OutputCtl outputCtl;
	private System.Windows.Forms.ToolStripButton btnClearOuput;
}