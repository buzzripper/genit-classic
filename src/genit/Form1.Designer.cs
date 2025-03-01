namespace Dyvenix.Genit;

partial class Form1
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
		imageList1 = new System.Windows.Forms.ImageList(components);
		statusStrip1 = new System.Windows.Forms.StatusStrip();
		statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
		toolLblVersion = new System.Windows.Forms.ToolStripStatusLabel();
		toolLblMessage = new System.Windows.Forms.ToolStripStatusLabel();
		logEventImgList = new System.Windows.Forms.ImageList(components);
		timer1 = new System.Windows.Forms.Timer(components);
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		menuStrip1 = new System.Windows.Forms.MenuStrip();
		toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
		mnuSave = new System.Windows.Forms.ToolStripMenuItem();
		mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
		mnuClose = new System.Windows.Forms.ToolStripMenuItem();
		toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
		mnuExit = new System.Windows.Forms.ToolStripMenuItem();
		editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnNew = new System.Windows.Forms.ToolStripButton();
		btnOpen = new System.Windows.Forms.ToolStripButton();
		btnSave = new System.Windows.Forms.ToolStripButton();
		printToolStripButton = new System.Windows.Forms.ToolStripButton();
		toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
		cutToolStripButton = new System.Windows.Forms.ToolStripButton();
		copyToolStripButton = new System.Windows.Forms.ToolStripButton();
		pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
		toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		btnGenerate = new System.Windows.Forms.ToolStripButton();
		openFileDlg = new System.Windows.Forms.OpenFileDialog();
		saveFileDlg = new System.Windows.Forms.SaveFileDialog();
		rtbJson = new System.Windows.Forms.RichTextBox();
		statusStrip1.SuspendLayout();
		menuStrip1.SuspendLayout();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// imageList1
		// 
		imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
		imageList1.TransparentColor = System.Drawing.Color.Transparent;
		imageList1.Images.SetKeyName(0, "timer_off_32.png");
		imageList1.Images.SetKeyName(1, "timer_32.png");
		imageList1.Images.SetKeyName(2, "refresh_32.png");
		imageList1.Images.SetKeyName(3, "auto_refresh_32.png");
		imageList1.Images.SetKeyName(4, "sort_32.png");
		imageList1.Images.SetKeyName(5, "clear_filters_32.png");
		imageList1.Images.SetKeyName(6, "add_datasource.png");
		imageList1.Images.SetKeyName(7, "del_datasource_32.png");
		imageList1.Images.SetKeyName(8, "edit_datasource_32.png");
		imageList1.Images.SetKeyName(9, "left_arrow_32.png");
		imageList1.Images.SetKeyName(10, "right_arrow_32.png");
		imageList1.Images.SetKeyName(11, "Spinner.gif");
		// 
		// statusStrip1
		// 
		statusStrip1.BackColor = System.Drawing.SystemColors.Control;
		statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel, toolLblVersion, toolLblMessage });
		statusStrip1.Location = new System.Drawing.Point(0, 865);
		statusStrip1.Name = "statusStrip1";
		statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
		statusStrip1.Size = new System.Drawing.Size(1048, 22);
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
		// logEventImgList
		// 
		logEventImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		logEventImgList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("logEventImgList.ImageStream");
		logEventImgList.TransparentColor = System.Drawing.Color.Transparent;
		logEventImgList.Images.SetKeyName(0, "Verbose.png");
		logEventImgList.Images.SetKeyName(1, "Debug.png");
		logEventImgList.Images.SetKeyName(2, "Information.png");
		logEventImgList.Images.SetKeyName(3, "Warning.png");
		logEventImgList.Images.SetKeyName(4, "Error.png");
		logEventImgList.Images.SetKeyName(5, "Critical.png");
		// 
		// menuStrip1
		// 
		menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1, editToolStripMenuItem });
		menuStrip1.Location = new System.Drawing.Point(0, 0);
		menuStrip1.Name = "menuStrip1";
		menuStrip1.Size = new System.Drawing.Size(1048, 24);
		menuStrip1.TabIndex = 36;
		menuStrip1.Text = "menuStrip1";
		// 
		// toolStripMenuItem1
		// 
		toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripMenuItem, mnuOpen, mnuSave, mnuSaveAs, mnuClose, toolStripMenuItem2, mnuExit });
		toolStripMenuItem1.Name = "toolStripMenuItem1";
		toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
		toolStripMenuItem1.Text = "&File";
		// 
		// newToolStripMenuItem
		// 
		newToolStripMenuItem.Name = "newToolStripMenuItem";
		newToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
		newToolStripMenuItem.Text = "&New";
		// 
		// mnuOpen
		// 
		mnuOpen.Name = "mnuOpen";
		mnuOpen.Size = new System.Drawing.Size(140, 22);
		mnuOpen.Text = "&Open";
		mnuOpen.Click += uiOpen_Click;
		// 
		// mnuSave
		// 
		mnuSave.Name = "mnuSave";
		mnuSave.Size = new System.Drawing.Size(140, 22);
		mnuSave.Text = "&Save";
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
		// toolStrip1
		// 
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnNew, btnOpen, btnSave, printToolStripButton, toolStripSeparator, cutToolStripButton, copyToolStripButton, pasteToolStripButton, toolStripSeparator1, toolStripSeparator2, btnGenerate });
		toolStrip1.Location = new System.Drawing.Point(0, 24);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(1048, 25);
		toolStrip1.TabIndex = 37;
		toolStrip1.Text = "toolStrip1";
		// 
		// btnNew
		// 
		btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnNew.Image = (System.Drawing.Image)resources.GetObject("btnNew.Image");
		btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnNew.Name = "btnNew";
		btnNew.Size = new System.Drawing.Size(23, 22);
		btnNew.Text = "&New";
		// 
		// btnOpen
		// 
		btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnOpen.Image = (System.Drawing.Image)resources.GetObject("btnOpen.Image");
		btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnOpen.Name = "btnOpen";
		btnOpen.Size = new System.Drawing.Size(23, 22);
		btnOpen.Text = "&Open";
		btnOpen.Click += uiOpen_Click;
		// 
		// btnSave
		// 
		btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnSave.Image = (System.Drawing.Image)resources.GetObject("btnSave.Image");
		btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnSave.Name = "btnSave";
		btnSave.Size = new System.Drawing.Size(23, 22);
		btnSave.Text = "&Save";
		btnSave.Click += uiSave_Click;
		// 
		// printToolStripButton
		// 
		printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		printToolStripButton.Image = (System.Drawing.Image)resources.GetObject("printToolStripButton.Image");
		printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		printToolStripButton.Name = "printToolStripButton";
		printToolStripButton.Size = new System.Drawing.Size(23, 22);
		printToolStripButton.Text = "&Print";
		printToolStripButton.Click += printToolStripButton_Click;
		// 
		// toolStripSeparator
		// 
		toolStripSeparator.Name = "toolStripSeparator";
		toolStripSeparator.Size = new System.Drawing.Size(6, 25);
		// 
		// cutToolStripButton
		// 
		cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		cutToolStripButton.Image = (System.Drawing.Image)resources.GetObject("cutToolStripButton.Image");
		cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		cutToolStripButton.Name = "cutToolStripButton";
		cutToolStripButton.Size = new System.Drawing.Size(23, 22);
		cutToolStripButton.Text = "C&ut";
		// 
		// copyToolStripButton
		// 
		copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		copyToolStripButton.Image = (System.Drawing.Image)resources.GetObject("copyToolStripButton.Image");
		copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		copyToolStripButton.Name = "copyToolStripButton";
		copyToolStripButton.Size = new System.Drawing.Size(23, 22);
		copyToolStripButton.Text = "&Copy";
		// 
		// pasteToolStripButton
		// 
		pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		pasteToolStripButton.Image = (System.Drawing.Image)resources.GetObject("pasteToolStripButton.Image");
		pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		pasteToolStripButton.Name = "pasteToolStripButton";
		pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
		pasteToolStripButton.Text = "&Paste";
		// 
		// toolStripSeparator1
		// 
		toolStripSeparator1.Name = "toolStripSeparator1";
		toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
		// 
		// toolStripSeparator2
		// 
		toolStripSeparator2.Name = "toolStripSeparator2";
		toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
		// 
		// btnGenerate
		// 
		btnGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnGenerate.Image = (System.Drawing.Image)resources.GetObject("btnGenerate.Image");
		btnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnGenerate.Name = "btnGenerate";
		btnGenerate.Size = new System.Drawing.Size(23, 22);
		btnGenerate.Text = "toolStripButton1";
		btnGenerate.Click += uiGenerate_Click;
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
		// rtbJson
		// 
		rtbJson.AcceptsTab = true;
		rtbJson.DetectUrls = false;
		rtbJson.Dock = System.Windows.Forms.DockStyle.Fill;
		rtbJson.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		rtbJson.HideSelection = false;
		rtbJson.Location = new System.Drawing.Point(0, 49);
		rtbJson.Name = "rtbJson";
		rtbJson.Size = new System.Drawing.Size(1048, 816);
		rtbJson.TabIndex = 38;
		rtbJson.TabStop = false;
		rtbJson.Text = "";
		rtbJson.WordWrap = false;
		// 
		// Form1
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.Control;
		ClientSize = new System.Drawing.Size(1048, 887);
		Controls.Add(rtbJson);
		Controls.Add(toolStrip1);
		Controls.Add(statusStrip1);
		Controls.Add(menuStrip1);
		ForeColor = System.Drawing.SystemColors.ControlText;
		Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		MainMenuStrip = menuStrip1;
		Margin = new System.Windows.Forms.Padding(2);
		Name = "Form1";
		Text = "GenIt";
		Activated += Form1_Activated;
		FormClosing += Form1_FormClosing;
		Load += Form1_Load;
		Shown += Form1_Shown;
		Resize += Form1_Resize;
		statusStrip1.ResumeLayout(false);
		statusStrip1.PerformLayout();
		menuStrip1.ResumeLayout(false);
		menuStrip1.PerformLayout();
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel statusLabel;
	private System.Windows.Forms.ToolStripStatusLabel toolLblVersion;
	private System.Windows.Forms.ToolStripStatusLabel toolLblMessage;
	private System.Windows.Forms.Timer timer1;
	private System.Windows.Forms.ToolTip toolTip1;
	private System.Windows.Forms.ImageList imageList1;
	private System.Windows.Forms.ImageList logEventImgList;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
	private System.Windows.Forms.ToolStripMenuItem mnuOpen;
	private System.Windows.Forms.ToolStripMenuItem mnuSave;
	private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
	private System.Windows.Forms.ToolStripMenuItem mnuClose;
	private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
	private System.Windows.Forms.ToolStripMenuItem mnuExit;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
	private System.Windows.Forms.ToolStripButton btnNew;
	private System.Windows.Forms.ToolStripButton btnOpen;
	private System.Windows.Forms.ToolStripButton btnSave;
	private System.Windows.Forms.ToolStripButton printToolStripButton;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
	private System.Windows.Forms.ToolStripButton cutToolStripButton;
	private System.Windows.Forms.ToolStripButton copyToolStripButton;
	private System.Windows.Forms.ToolStripButton pasteToolStripButton;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	private System.Windows.Forms.ToolStripButton helpToolStripButton;
	private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
	private System.Windows.Forms.ToolStripButton btnGenerate;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	private System.Windows.Forms.OpenFileDialog openFileDlg;
	private System.Windows.Forms.SaveFileDialog saveFileDlg;
	private System.Windows.Forms.RichTextBox rtbJson;
}