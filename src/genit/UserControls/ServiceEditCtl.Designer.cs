namespace Dyvenix.Genit.UserControls;

partial class ServiceEditCtl
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
		ckbInclSave = new System.Windows.Forms.CheckBox();
		ckbInclDelete = new System.Windows.Forms.CheckBox();
		ckbInclController = new System.Windows.Forms.CheckBox();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		lkbAddlServiceUsings = new System.Windows.Forms.LinkLabel();
		lkbServiceClassAttributes = new System.Windows.Forms.LinkLabel();
		lkbControllerClassAttributes = new System.Windows.Forms.LinkLabel();
		lkbAddlControllerUsings = new System.Windows.Forms.LinkLabel();
		getMethodsListCtl = new GetMethodsListCtl();
		queryMethodsCtl = new QueryMethodsListCtl();
		splMain = new System.Windows.Forms.SplitContainer();
		txtControllerVersion = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		ckbInclUpdate = new System.Windows.Forms.CheckBox();
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		SuspendLayout();
		// 
		// ckbInclSave
		// 
		ckbInclSave.AutoSize = true;
		ckbInclSave.Location = new System.Drawing.Point(854, 66);
		ckbInclSave.Name = "ckbInclSave";
		ckbInclSave.Size = new System.Drawing.Size(222, 32);
		ckbInclSave.TabIndex = 0;
		ckbInclSave.Text = "Include Save Method";
		ckbInclSave.UseVisualStyleBackColor = true;
		ckbInclSave.CheckedChanged += ckbInclSave_CheckedChanged;
		// 
		// ckbInclDelete
		// 
		ckbInclDelete.AutoSize = true;
		ckbInclDelete.Location = new System.Drawing.Point(854, 121);
		ckbInclDelete.Name = "ckbInclDelete";
		ckbInclDelete.Size = new System.Drawing.Size(237, 32);
		ckbInclDelete.TabIndex = 1;
		ckbInclDelete.Text = "Include Delete Method";
		ckbInclDelete.UseVisualStyleBackColor = true;
		ckbInclDelete.CheckedChanged += ckbInclDelete_CheckedChanged;
		// 
		// ckbInclController
		// 
		ckbInclController.AutoSize = true;
		ckbInclController.Location = new System.Drawing.Point(869, 167);
		ckbInclController.Name = "ckbInclController";
		ckbInclController.Size = new System.Drawing.Size(194, 32);
		ckbInclController.TabIndex = 2;
		ckbInclController.Text = "Include Controller";
		ckbInclController.UseVisualStyleBackColor = true;
		ckbInclController.CheckedChanged += ckbInclController_CheckedChanged;
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(1329, 14);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(108, 32);
		ckbEnabled.TabIndex = 3;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		// 
		// lkbAddlServiceUsings
		// 
		lkbAddlServiceUsings.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbAddlServiceUsings.AutoSize = true;
		lkbAddlServiceUsings.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbAddlServiceUsings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbAddlServiceUsings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbAddlServiceUsings.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbAddlServiceUsings.Location = new System.Drawing.Point(1132, 65);
		lkbAddlServiceUsings.Name = "lkbAddlServiceUsings";
		lkbAddlServiceUsings.Size = new System.Drawing.Size(234, 28);
		lkbAddlServiceUsings.TabIndex = 19;
		lkbAddlServiceUsings.TabStop = true;
		lkbAddlServiceUsings.Text = "Additional Service Usings";
		lkbAddlServiceUsings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbAddlServiceUsings.UseMnemonic = false;
		lkbAddlServiceUsings.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbAddlServiceUsings.LinkClicked += lkbAddlUsings_LinkClicked;
		// 
		// lkbServiceClassAttributes
		// 
		lkbServiceClassAttributes.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbServiceClassAttributes.AutoSize = true;
		lkbServiceClassAttributes.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbServiceClassAttributes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbServiceClassAttributes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbServiceClassAttributes.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbServiceClassAttributes.Location = new System.Drawing.Point(1132, 104);
		lkbServiceClassAttributes.Name = "lkbServiceClassAttributes";
		lkbServiceClassAttributes.Size = new System.Drawing.Size(214, 28);
		lkbServiceClassAttributes.TabIndex = 20;
		lkbServiceClassAttributes.TabStop = true;
		lkbServiceClassAttributes.Text = "Service Class Attributes";
		lkbServiceClassAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbServiceClassAttributes.UseMnemonic = false;
		lkbServiceClassAttributes.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbServiceClassAttributes.LinkClicked += lkbServiceClassAttributes_LinkClicked;
		// 
		// lkbControllerClassAttributes
		// 
		lkbControllerClassAttributes.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbControllerClassAttributes.AutoSize = true;
		lkbControllerClassAttributes.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbControllerClassAttributes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbControllerClassAttributes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbControllerClassAttributes.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbControllerClassAttributes.Location = new System.Drawing.Point(1132, 195);
		lkbControllerClassAttributes.Name = "lkbControllerClassAttributes";
		lkbControllerClassAttributes.Size = new System.Drawing.Size(240, 28);
		lkbControllerClassAttributes.TabIndex = 22;
		lkbControllerClassAttributes.TabStop = true;
		lkbControllerClassAttributes.Text = "Controller Class Attributes";
		lkbControllerClassAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbControllerClassAttributes.UseMnemonic = false;
		lkbControllerClassAttributes.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbControllerClassAttributes.LinkClicked += lkbControllerClassAttributes_LinkClicked;
		// 
		// lkbAddlControllerUsings
		// 
		lkbAddlControllerUsings.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbAddlControllerUsings.AutoSize = true;
		lkbAddlControllerUsings.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbAddlControllerUsings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbAddlControllerUsings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbAddlControllerUsings.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbAddlControllerUsings.Location = new System.Drawing.Point(1132, 167);
		lkbAddlControllerUsings.Name = "lkbAddlControllerUsings";
		lkbAddlControllerUsings.Size = new System.Drawing.Size(260, 28);
		lkbAddlControllerUsings.TabIndex = 21;
		lkbAddlControllerUsings.TabStop = true;
		lkbAddlControllerUsings.Text = "Additional Controller Usings";
		lkbAddlControllerUsings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbAddlControllerUsings.UseMnemonic = false;
		lkbAddlControllerUsings.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbAddlControllerUsings.LinkClicked += lkbAddlControllerUsings_LinkClicked;
		// 
		// getMethodsListCtl
		// 
		getMethodsListCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		getMethodsListCtl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		getMethodsListCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		getMethodsListCtl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		getMethodsListCtl.Location = new System.Drawing.Point(21, 27);
		getMethodsListCtl.Margin = new System.Windows.Forms.Padding(5);
		getMethodsListCtl.Name = "getMethodsListCtl";
		getMethodsListCtl.Size = new System.Drawing.Size(787, 322);
		getMethodsListCtl.TabIndex = 23;
		// 
		// queryMethodsCtl
		// 
		queryMethodsCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		queryMethodsCtl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		queryMethodsCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		queryMethodsCtl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		queryMethodsCtl.Location = new System.Drawing.Point(21, 17);
		queryMethodsCtl.Margin = new System.Windows.Forms.Padding(2);
		queryMethodsCtl.Name = "queryMethodsCtl";
		queryMethodsCtl.Size = new System.Drawing.Size(1440, 256);
		queryMethodsCtl.TabIndex = 24;
		// 
		// splMain
		// 
		splMain.Dock = System.Windows.Forms.DockStyle.Fill;
		splMain.Location = new System.Drawing.Point(0, 0);
		splMain.Name = "splMain";
		splMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splMain.Panel1
		// 
		splMain.Panel1.Controls.Add(txtControllerVersion);
		splMain.Panel1.Controls.Add(label1);
		splMain.Panel1.Controls.Add(ckbInclUpdate);
		splMain.Panel1.Controls.Add(getMethodsListCtl);
		splMain.Panel1.Controls.Add(ckbEnabled);
		splMain.Panel1.Controls.Add(lkbControllerClassAttributes);
		splMain.Panel1.Controls.Add(ckbInclSave);
		splMain.Panel1.Controls.Add(lkbAddlControllerUsings);
		splMain.Panel1.Controls.Add(ckbInclDelete);
		splMain.Panel1.Controls.Add(lkbServiceClassAttributes);
		splMain.Panel1.Controls.Add(ckbInclController);
		splMain.Panel1.Controls.Add(lkbAddlServiceUsings);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.Controls.Add(queryMethodsCtl);
		splMain.Size = new System.Drawing.Size(1475, 708);
		splMain.SplitterDistance = 368;
		splMain.SplitterWidth = 8;
		splMain.TabIndex = 25;
		// 
		// txtControllerVersion
		// 
		txtControllerVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllerVersion.Location = new System.Drawing.Point(1057, 250);
		txtControllerVersion.Name = "txtControllerVersion";
		txtControllerVersion.Size = new System.Drawing.Size(95, 34);
		txtControllerVersion.TabIndex = 26;
		txtControllerVersion.TextChanged += txtControllerVersion_TextChanged;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(878, 253);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(173, 28);
		label1.TabIndex = 25;
		label1.Text = "Controller Version:";
		// 
		// ckbInclUpdate
		// 
		ckbInclUpdate.AutoSize = true;
		ckbInclUpdate.Location = new System.Drawing.Point(854, 94);
		ckbInclUpdate.Name = "ckbInclUpdate";
		ckbInclUpdate.Size = new System.Drawing.Size(246, 32);
		ckbInclUpdate.TabIndex = 24;
		ckbInclUpdate.Text = "Include Update Method";
		ckbInclUpdate.UseVisualStyleBackColor = true;
		ckbInclUpdate.CheckedChanged += ckbInclUpdate_CheckedChanged;
		// 
		// ServiceEditCtl
		// 
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(splMain);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "ServiceEditCtl";
		Size = new System.Drawing.Size(1475, 708);
		Load += ServiceEditCtl_Load;
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel1.PerformLayout();
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.CheckBox ckbInclSave;
	private System.Windows.Forms.CheckBox ckbInclDelete;
	private System.Windows.Forms.CheckBox ckbInclController;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.LinkLabel lkbAddlServiceUsings;
	private System.Windows.Forms.LinkLabel lkbServiceClassAttributes;
	private System.Windows.Forms.LinkLabel lkbControllerClassAttributes;
	private System.Windows.Forms.LinkLabel lkbAddlControllerUsings;
	private GetMethodsListCtl getMethodsListCtl;
	private QueryMethodsListCtl queryMethodsCtl;
	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.CheckBox ckbInclUpdate;
	private System.Windows.Forms.TextBox txtControllerVersion;
	private System.Windows.Forms.Label label1;
}
