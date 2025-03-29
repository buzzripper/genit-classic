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
		ckbInclCreate = new System.Windows.Forms.CheckBox();
		ckbInclDelete = new System.Windows.Forms.CheckBox();
		ckbInclController = new System.Windows.Forms.CheckBox();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		lkbAddlServiceUsings = new System.Windows.Forms.LinkLabel();
		lkbServiceClassAttributes = new System.Windows.Forms.LinkLabel();
		lkbControllerClassAttributes = new System.Windows.Forms.LinkLabel();
		lkbAddlControllerUsings = new System.Windows.Forms.LinkLabel();
		txtControllerVersion = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		ckbInclUpdate = new System.Windows.Forms.CheckBox();
		svcMethodsEditCtl = new ServiceMethodsEditCtl();
		SuspendLayout();
		// 
		// ckbInclCreate
		// 
		ckbInclCreate.AutoSize = true;
		ckbInclCreate.Location = new System.Drawing.Point(73, 27);
		ckbInclCreate.Name = "ckbInclCreate";
		ckbInclCreate.Size = new System.Drawing.Size(237, 32);
		ckbInclCreate.TabIndex = 0;
		ckbInclCreate.Text = "Include Create Method";
		ckbInclCreate.UseVisualStyleBackColor = true;
		ckbInclCreate.CheckedChanged += ckbInclSave_CheckedChanged;
		// 
		// ckbInclDelete
		// 
		ckbInclDelete.AutoSize = true;
		ckbInclDelete.Location = new System.Drawing.Point(73, 103);
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
		ckbInclController.Location = new System.Drawing.Point(449, 27);
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
		ckbEnabled.Location = new System.Drawing.Point(972, 27);
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
		lkbAddlServiceUsings.Location = new System.Drawing.Point(76, 151);
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
		lkbServiceClassAttributes.Location = new System.Drawing.Point(85, 188);
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
		lkbControllerClassAttributes.Location = new System.Drawing.Point(449, 155);
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
		lkbAddlControllerUsings.Location = new System.Drawing.Point(448, 119);
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
		// txtControllerVersion
		// 
		txtControllerVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtControllerVersion.Location = new System.Drawing.Point(627, 65);
		txtControllerVersion.Name = "txtControllerVersion";
		txtControllerVersion.Size = new System.Drawing.Size(81, 34);
		txtControllerVersion.TabIndex = 26;
		txtControllerVersion.TextChanged += txtControllerVersion_TextChanged;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(448, 68);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(173, 28);
		label1.TabIndex = 25;
		label1.Text = "Controller Version:";
		// 
		// ckbInclUpdate
		// 
		ckbInclUpdate.AutoSize = true;
		ckbInclUpdate.Location = new System.Drawing.Point(73, 65);
		ckbInclUpdate.Name = "ckbInclUpdate";
		ckbInclUpdate.Size = new System.Drawing.Size(246, 32);
		ckbInclUpdate.TabIndex = 24;
		ckbInclUpdate.Text = "Include Update Method";
		ckbInclUpdate.UseVisualStyleBackColor = true;
		ckbInclUpdate.CheckedChanged += ckbInclUpdate_CheckedChanged;
		// 
		// svcMethodsEditCtl
		// 
		svcMethodsEditCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		svcMethodsEditCtl.Location = new System.Drawing.Point(18, 244);
		svcMethodsEditCtl.Name = "svcMethodsEditCtl";
		svcMethodsEditCtl.Size = new System.Drawing.Size(1107, 654);
		svcMethodsEditCtl.TabIndex = 27;
		// 
		// ServiceEditCtl
		// 
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(svcMethodsEditCtl);
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
		Name = "ServiceEditCtl";
		Size = new System.Drawing.Size(1144, 921);
		Load += ServiceEditCtl_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.CheckBox ckbInclCreate;
	private System.Windows.Forms.CheckBox ckbInclDelete;
	private System.Windows.Forms.CheckBox ckbInclController;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.LinkLabel lkbAddlServiceUsings;
	private System.Windows.Forms.LinkLabel lkbServiceClassAttributes;
	private System.Windows.Forms.LinkLabel lkbControllerClassAttributes;
	private System.Windows.Forms.LinkLabel lkbAddlControllerUsings;
	private System.Windows.Forms.CheckBox ckbInclUpdate;
	private System.Windows.Forms.TextBox txtControllerVersion;
	private System.Windows.Forms.Label label1;
	private ServiceMethodsEditCtl svcMethodsEditCtl;
}
