namespace Dyvenix.Genit.UserControls;

partial class SvcEditCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SvcEditCtl));
		txtControllerVersion = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		ckbInclCreate = new System.Windows.Forms.CheckBox();
		ckbInclUpdate = new System.Windows.Forms.CheckBox();
		lkbAddlServiceUsings = new System.Windows.Forms.LinkLabel();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		ckbInclController = new System.Windows.Forms.CheckBox();
		lkbControllerClassAttributes = new System.Windows.Forms.LinkLabel();
		lkbServiceClassAttributes = new System.Windows.Forms.LinkLabel();
		ckbInclDelete = new System.Windows.Forms.CheckBox();
		lkbAddlControllerUsings = new System.Windows.Forms.LinkLabel();
		readMethodsEditCtl = new ReadMethodsEditCtl();
		tsTabs = new System.Windows.Forms.ToolStrip();
		tabReadMethods = new System.Windows.Forms.ToolStripButton();
		tabUpdateMethods = new System.Windows.Forms.ToolStripButton();
		updMethodsEditCtl = new UpdateMethodsEditCtl();
		tsTabs.SuspendLayout();
		SuspendLayout();
		// 
		// txtControllerVersion
		// 
		txtControllerVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllerVersion.Location = new System.Drawing.Point(355, 31);
		txtControllerVersion.Name = "txtControllerVersion";
		txtControllerVersion.Size = new System.Drawing.Size(42, 25);
		txtControllerVersion.TabIndex = 37;
		txtControllerVersion.TextChanged += txtControllerVersion_TextChanged;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(230, 33);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(122, 19);
		label1.TabIndex = 36;
		label1.Text = "Controller Version:";
		// 
		// ckbInclCreate
		// 
		ckbInclCreate.AutoSize = true;
		ckbInclCreate.Location = new System.Drawing.Point(20, 6);
		ckbInclCreate.Name = "ckbInclCreate";
		ckbInclCreate.Size = new System.Drawing.Size(169, 23);
		ckbInclCreate.TabIndex = 27;
		ckbInclCreate.Text = "Include Create Method";
		ckbInclCreate.UseVisualStyleBackColor = true;
		ckbInclCreate.CheckedChanged += ckbInclCreate_CheckedChanged;
		// 
		// ckbInclUpdate
		// 
		ckbInclUpdate.AutoSize = true;
		ckbInclUpdate.Location = new System.Drawing.Point(20, 29);
		ckbInclUpdate.Name = "ckbInclUpdate";
		ckbInclUpdate.Size = new System.Drawing.Size(174, 23);
		ckbInclUpdate.TabIndex = 35;
		ckbInclUpdate.Text = "Include Update Method";
		ckbInclUpdate.UseVisualStyleBackColor = true;
		ckbInclUpdate.CheckedChanged += ckbInclUpdate_CheckedChanged;
		// 
		// lkbAddlServiceUsings
		// 
		lkbAddlServiceUsings.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbAddlServiceUsings.AutoSize = true;
		lkbAddlServiceUsings.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbAddlServiceUsings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbAddlServiceUsings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbAddlServiceUsings.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbAddlServiceUsings.Location = new System.Drawing.Point(423, 6);
		lkbAddlServiceUsings.Name = "lkbAddlServiceUsings";
		lkbAddlServiceUsings.Size = new System.Drawing.Size(162, 19);
		lkbAddlServiceUsings.TabIndex = 31;
		lkbAddlServiceUsings.TabStop = true;
		lkbAddlServiceUsings.Text = "Additional Service Usings";
		lkbAddlServiceUsings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbAddlServiceUsings.UseMnemonic = false;
		lkbAddlServiceUsings.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbAddlServiceUsings.LinkClicked += lkbAddlUsings_LinkClicked;
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(772, 9);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(76, 23);
		ckbEnabled.TabIndex = 30;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckStateChanged += ckbEnabled_CheckedChanged;
		// 
		// ckbInclController
		// 
		ckbInclController.AutoSize = true;
		ckbInclController.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		ckbInclController.Location = new System.Drawing.Point(230, 6);
		ckbInclController.Name = "ckbInclController";
		ckbInclController.Size = new System.Drawing.Size(137, 23);
		ckbInclController.TabIndex = 29;
		ckbInclController.Text = "Include Controller";
		ckbInclController.UseVisualStyleBackColor = true;
		ckbInclController.CheckedChanged += ckbInclController_CheckedChanged;
		// 
		// lkbControllerClassAttributes
		// 
		lkbControllerClassAttributes.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbControllerClassAttributes.AutoSize = true;
		lkbControllerClassAttributes.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbControllerClassAttributes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbControllerClassAttributes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbControllerClassAttributes.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbControllerClassAttributes.Location = new System.Drawing.Point(423, 63);
		lkbControllerClassAttributes.Name = "lkbControllerClassAttributes";
		lkbControllerClassAttributes.Size = new System.Drawing.Size(170, 19);
		lkbControllerClassAttributes.TabIndex = 34;
		lkbControllerClassAttributes.TabStop = true;
		lkbControllerClassAttributes.Text = "Controller Class Attributes";
		lkbControllerClassAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbControllerClassAttributes.UseMnemonic = false;
		lkbControllerClassAttributes.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbControllerClassAttributes.LinkClicked += lkbControllerClassAttributes_LinkClicked;
		// 
		// lkbServiceClassAttributes
		// 
		lkbServiceClassAttributes.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbServiceClassAttributes.AutoSize = true;
		lkbServiceClassAttributes.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbServiceClassAttributes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbServiceClassAttributes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbServiceClassAttributes.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbServiceClassAttributes.Location = new System.Drawing.Point(423, 25);
		lkbServiceClassAttributes.Name = "lkbServiceClassAttributes";
		lkbServiceClassAttributes.Size = new System.Drawing.Size(151, 19);
		lkbServiceClassAttributes.TabIndex = 32;
		lkbServiceClassAttributes.TabStop = true;
		lkbServiceClassAttributes.Text = "Service Class Attributes";
		lkbServiceClassAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbServiceClassAttributes.UseMnemonic = false;
		lkbServiceClassAttributes.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbServiceClassAttributes.LinkClicked += lkbServiceClassAttributes_LinkClicked;
		// 
		// ckbInclDelete
		// 
		ckbInclDelete.AutoSize = true;
		ckbInclDelete.Location = new System.Drawing.Point(20, 51);
		ckbInclDelete.Name = "ckbInclDelete";
		ckbInclDelete.Size = new System.Drawing.Size(168, 23);
		ckbInclDelete.TabIndex = 28;
		ckbInclDelete.Text = "Include Delete Method";
		ckbInclDelete.UseVisualStyleBackColor = true;
		ckbInclDelete.CheckedChanged += ckbInclDelete_CheckedChanged;
		// 
		// lkbAddlControllerUsings
		// 
		lkbAddlControllerUsings.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbAddlControllerUsings.AutoSize = true;
		lkbAddlControllerUsings.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbAddlControllerUsings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbAddlControllerUsings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbAddlControllerUsings.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbAddlControllerUsings.Location = new System.Drawing.Point(423, 44);
		lkbAddlControllerUsings.Name = "lkbAddlControllerUsings";
		lkbAddlControllerUsings.Size = new System.Drawing.Size(181, 19);
		lkbAddlControllerUsings.TabIndex = 33;
		lkbAddlControllerUsings.TabStop = true;
		lkbAddlControllerUsings.Text = "Additional Controller Usings";
		lkbAddlControllerUsings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbAddlControllerUsings.UseMnemonic = false;
		lkbAddlControllerUsings.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbAddlControllerUsings.LinkClicked += lkbAddlControllerUsings_LinkClicked;
		// 
		// readMethodsEditCtl
		// 
		readMethodsEditCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		readMethodsEditCtl.Location = new System.Drawing.Point(11, 125);
		readMethodsEditCtl.Margin = new System.Windows.Forms.Padding(2);
		readMethodsEditCtl.Name = "readMethodsEditCtl";
		readMethodsEditCtl.Size = new System.Drawing.Size(838, 210);
		readMethodsEditCtl.TabIndex = 39;
		// 
		// tsTabs
		// 
		tsTabs.Dock = System.Windows.Forms.DockStyle.None;
		tsTabs.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		tsTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tabReadMethods, tabUpdateMethods });
		tsTabs.Location = new System.Drawing.Point(11, 91);
		tsTabs.Name = "tsTabs";
		tsTabs.Size = new System.Drawing.Size(199, 32);
		tsTabs.TabIndex = 40;
		tsTabs.Text = "toolStrip1";
		// 
		// tabReadMethods
		// 
		tabReadMethods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		tabReadMethods.Image = (System.Drawing.Image)resources.GetObject("tabReadMethods.Image");
		tabReadMethods.ImageTransparentColor = System.Drawing.Color.Magenta;
		tabReadMethods.Name = "tabReadMethods";
		tabReadMethods.Padding = new System.Windows.Forms.Padding(5);
		tabReadMethods.Size = new System.Drawing.Size(97, 29);
		tabReadMethods.Text = "Read Methods";
		tabReadMethods.Click += tabReadMethods_Click;
		// 
		// tabUpdateMethods
		// 
		tabUpdateMethods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		tabUpdateMethods.Image = (System.Drawing.Image)resources.GetObject("tabUpdateMethods.Image");
		tabUpdateMethods.ImageTransparentColor = System.Drawing.Color.Magenta;
		tabUpdateMethods.Name = "tabUpdateMethods";
		tabUpdateMethods.Size = new System.Drawing.Size(99, 29);
		tabUpdateMethods.Text = "Update Methods";
		tabUpdateMethods.Click += tabUpdateMethods_Click;
		// 
		// updMethodsEditCtl
		// 
		updMethodsEditCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		updMethodsEditCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		updMethodsEditCtl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		updMethodsEditCtl.Location = new System.Drawing.Point(11, 350);
		updMethodsEditCtl.Margin = new System.Windows.Forms.Padding(2);
		updMethodsEditCtl.Name = "updMethodsEditCtl";
		updMethodsEditCtl.Size = new System.Drawing.Size(846, 223);
		updMethodsEditCtl.TabIndex = 38;
		// 
		// SvcEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(readMethodsEditCtl);
		Controls.Add(tsTabs);
		Controls.Add(updMethodsEditCtl);
		Controls.Add(txtControllerVersion);
		Controls.Add(label1);
		Controls.Add(ckbInclCreate);
		Controls.Add(ckbInclUpdate);
		Controls.Add(lkbAddlServiceUsings);
		Controls.Add(ckbEnabled);
		Controls.Add(ckbInclController);
		Controls.Add(lkbControllerClassAttributes);
		Controls.Add(lkbServiceClassAttributes);
		Controls.Add(ckbInclDelete);
		Controls.Add(lkbAddlControllerUsings);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "SvcEditCtl";
		Size = new System.Drawing.Size(871, 644);
		Load += SvcEditCtl_Load;
		tsTabs.ResumeLayout(false);
		tsTabs.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.TextBox txtControllerVersion;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.CheckBox ckbInclCreate;
	private System.Windows.Forms.CheckBox ckbInclUpdate;
	private System.Windows.Forms.LinkLabel lkbAddlServiceUsings;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.CheckBox ckbInclController;
	private System.Windows.Forms.LinkLabel lkbControllerClassAttributes;
	private System.Windows.Forms.LinkLabel lkbServiceClassAttributes;
	private System.Windows.Forms.CheckBox ckbInclDelete;
	private System.Windows.Forms.LinkLabel lkbAddlControllerUsings;
	private ReadMethodsEditCtl readMethodsEditCtl;
	private System.Windows.Forms.ToolStrip tsTabs;
	private System.Windows.Forms.ToolStripButton tabReadMethods;
	private System.Windows.Forms.ToolStripButton tabUpdateMethods;
	private UpdateMethodsEditCtl updMethodsEditCtl;
}
