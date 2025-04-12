namespace Dyvenix.Genit.UserControls;

partial class EntityMainEditCtl
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
		components = new System.ComponentModel.Container();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.TextBox();
		bindingSource = new System.Windows.Forms.BindingSource(components);
		txtSchema = new System.Windows.Forms.TextBox();
		txtTableName = new System.Windows.Forms.TextBox();
		txtNamespace = new System.Windows.Forms.TextBox();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		propGridCtl = new PropGridCtl();
		label7 = new System.Windows.Forms.Label();
		lkbAddNewProp = new System.Windows.Forms.LinkLabel();
		splitContainer1 = new System.Windows.Forms.SplitContainer();
		navPropGridCtl = new NavPropGridCtl();
		lkbAddNewNavProp = new System.Windows.Forms.LinkLabel();
		label8 = new System.Windows.Forms.Label();
		lkbAddlUsings = new System.Windows.Forms.LinkLabel();
		lkbClassAttributes = new System.Windows.Forms.LinkLabel();
		ckbInclRowVersion = new System.Windows.Forms.CheckBox();
		((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
		((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
		splitContainer1.Panel1.SuspendLayout();
		splitContainer1.Panel2.SuspendLayout();
		splitContainer1.SuspendLayout();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(47, 42);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(48, 19);
		label1.TabIndex = 0;
		label1.Text = "Name:";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(342, 42);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(59, 19);
		label2.TabIndex = 1;
		label2.Text = "Schema:";
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(319, 69);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(82, 19);
		label3.TabIndex = 2;
		label3.Text = "Table Name:";
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(13, 69);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(82, 19);
		label4.TabIndex = 3;
		label4.Text = "Namespace:";
		// 
		// txtName
		// 
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Name", true));
		txtName.Location = new System.Drawing.Point(101, 40);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(211, 25);
		txtName.TabIndex = 0;
		txtName.TextChanged += txtName_TextChanged;
		// 
		// bindingSource
		// 
		bindingSource.DataSource = typeof(Models.EntityModel);
		// 
		// txtSchema
		// 
		txtSchema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtSchema.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Schema", true));
		txtSchema.Location = new System.Drawing.Point(407, 38);
		txtSchema.Name = "txtSchema";
		txtSchema.Size = new System.Drawing.Size(176, 25);
		txtSchema.TabIndex = 1;
		txtSchema.TextChanged += txtSchema_TextChanged;
		// 
		// txtTableName
		// 
		txtTableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "TableName", true));
		txtTableName.Location = new System.Drawing.Point(407, 67);
		txtTableName.Name = "txtTableName";
		txtTableName.Size = new System.Drawing.Size(176, 25);
		txtTableName.TabIndex = 2;
		txtTableName.TextChanged += txtTableName_TextChanged;
		// 
		// txtNamespace
		// 
		txtNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Namespace", true));
		txtNamespace.Location = new System.Drawing.Point(101, 68);
		txtNamespace.Name = "txtNamespace";
		txtNamespace.Size = new System.Drawing.Size(211, 25);
		txtNamespace.TabIndex = 3;
		txtNamespace.TextChanged += txtNamespace_TextChanged;
		// 
		// ckbEnabled
		// 
		ckbEnabled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbEnabled.AutoSize = true;
		ckbEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "Enabled", true));
		ckbEnabled.Location = new System.Drawing.Point(792, 3);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(76, 23);
		ckbEnabled.TabIndex = 4;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// propGridCtl
		// 
		propGridCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		propGridCtl.AutoScroll = true;
		propGridCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		propGridCtl.Location = new System.Drawing.Point(2, 25);
		propGridCtl.Name = "propGridCtl";
		propGridCtl.Size = new System.Drawing.Size(837, 226);
		propGridCtl.TabIndex = 13;
		// 
		// label7
		// 
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(8, 2);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(71, 19);
		label7.TabIndex = 14;
		label7.Text = "Properties";
		// 
		// lkbAddNewProp
		// 
		lkbAddNewProp.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbAddNewProp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		lkbAddNewProp.AutoSize = true;
		lkbAddNewProp.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbAddNewProp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbAddNewProp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbAddNewProp.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbAddNewProp.Location = new System.Drawing.Point(773, 3);
		lkbAddNewProp.Name = "lkbAddNewProp";
		lkbAddNewProp.Size = new System.Drawing.Size(65, 19);
		lkbAddNewProp.TabIndex = 15;
		lkbAddNewProp.TabStop = true;
		lkbAddNewProp.Text = "Add New";
		lkbAddNewProp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbAddNewProp.UseMnemonic = false;
		lkbAddNewProp.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbAddNewProp.LinkClicked += lkbAddNewProp_LinkClicked;
		// 
		// splitContainer1
		// 
		splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		splitContainer1.Location = new System.Drawing.Point(16, 111);
		splitContainer1.Name = "splitContainer1";
		splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitContainer1.Panel1
		// 
		splitContainer1.Panel1.Controls.Add(propGridCtl);
		splitContainer1.Panel1.Controls.Add(lkbAddNewProp);
		splitContainer1.Panel1.Controls.Add(label7);
		// 
		// splitContainer1.Panel2
		// 
		splitContainer1.Panel2.Controls.Add(navPropGridCtl);
		splitContainer1.Panel2.Controls.Add(lkbAddNewNavProp);
		splitContainer1.Panel2.Controls.Add(label8);
		splitContainer1.Size = new System.Drawing.Size(841, 459);
		splitContainer1.SplitterDistance = 252;
		splitContainer1.TabIndex = 16;
		// 
		// navPropGridCtl
		// 
		navPropGridCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		navPropGridCtl.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
		navPropGridCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		navPropGridCtl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		navPropGridCtl.Location = new System.Drawing.Point(3, 35);
		navPropGridCtl.Name = "navPropGridCtl";
		navPropGridCtl.Size = new System.Drawing.Size(836, 165);
		navPropGridCtl.TabIndex = 18;
		navPropGridCtl.NavPropertyEdit += navPropGridCtl_NavPropertyEdit;
		// 
		// lkbAddNewNavProp
		// 
		lkbAddNewNavProp.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbAddNewNavProp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		lkbAddNewNavProp.AutoSize = true;
		lkbAddNewNavProp.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbAddNewNavProp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbAddNewNavProp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbAddNewNavProp.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbAddNewNavProp.Location = new System.Drawing.Point(773, 12);
		lkbAddNewNavProp.Name = "lkbAddNewNavProp";
		lkbAddNewNavProp.Size = new System.Drawing.Size(65, 19);
		lkbAddNewNavProp.TabIndex = 17;
		lkbAddNewNavProp.TabStop = true;
		lkbAddNewNavProp.Text = "Add New";
		lkbAddNewNavProp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbAddNewNavProp.UseMnemonic = false;
		lkbAddNewNavProp.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbAddNewNavProp.LinkClicked += lkbAddNewNavProp_LinkClicked;
		// 
		// label8
		// 
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(8, 13);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(141, 19);
		label8.TabIndex = 16;
		label8.Text = "Navigation Properties";
		// 
		// lkbAddlUsings
		// 
		lkbAddlUsings.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbAddlUsings.AutoSize = true;
		lkbAddlUsings.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbAddlUsings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbAddlUsings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbAddlUsings.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbAddlUsings.Location = new System.Drawing.Point(603, 41);
		lkbAddlUsings.Name = "lkbAddlUsings";
		lkbAddlUsings.Size = new System.Drawing.Size(116, 19);
		lkbAddlUsings.TabIndex = 18;
		lkbAddlUsings.TabStop = true;
		lkbAddlUsings.Text = "Additional Usings";
		lkbAddlUsings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbAddlUsings.UseMnemonic = false;
		lkbAddlUsings.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbAddlUsings.LinkClicked += lkbAddlUsings_LinkClicked;
		// 
		// lkbClassAttributes
		// 
		lkbClassAttributes.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbClassAttributes.AutoSize = true;
		lkbClassAttributes.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbClassAttributes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbClassAttributes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbClassAttributes.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbClassAttributes.Location = new System.Drawing.Point(603, 68);
		lkbClassAttributes.Name = "lkbClassAttributes";
		lkbClassAttributes.Size = new System.Drawing.Size(105, 19);
		lkbClassAttributes.TabIndex = 19;
		lkbClassAttributes.TabStop = true;
		lkbClassAttributes.Text = "Class Attributes";
		lkbClassAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbClassAttributes.UseMnemonic = false;
		lkbClassAttributes.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		lkbClassAttributes.LinkClicked += lkbClassAttributes_LinkClicked;
		// 
		// ckbInclRowVersion
		// 
		ckbInclRowVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		ckbInclRowVersion.AutoSize = true;
		ckbInclRowVersion.Location = new System.Drawing.Point(625, 3);
		ckbInclRowVersion.Name = "ckbInclRowVersion";
		ckbInclRowVersion.Size = new System.Drawing.Size(147, 23);
		ckbInclRowVersion.TabIndex = 20;
		ckbInclRowVersion.Text = "Include RowVersion";
		ckbInclRowVersion.UseVisualStyleBackColor = true;
		ckbInclRowVersion.CheckedChanged += ckbInclRowVersion_CheckedChanged;
		// 
		// EntityMainEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(ckbInclRowVersion);
		Controls.Add(lkbClassAttributes);
		Controls.Add(lkbAddlUsings);
		Controls.Add(splitContainer1);
		Controls.Add(ckbEnabled);
		Controls.Add(txtNamespace);
		Controls.Add(txtTableName);
		Controls.Add(txtSchema);
		Controls.Add(txtName);
		Controls.Add(label4);
		Controls.Add(label3);
		Controls.Add(label2);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "EntityMainEditCtl";
		Size = new System.Drawing.Size(874, 580);
		Load += EntityMainEditCtl_Load;
		((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
		splitContainer1.Panel1.ResumeLayout(false);
		splitContainer1.Panel1.PerformLayout();
		splitContainer1.Panel2.ResumeLayout(false);
		splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
		splitContainer1.ResumeLayout(false);
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.TextBox txtSchema;
	private System.Windows.Forms.TextBox txtTableName;
	private System.Windows.Forms.TextBox txtNamespace;
	private System.Windows.Forms.BindingSource bindingSource;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private PropGridCtl propGridCtl;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.LinkLabel lkbAddNewProp;
	private System.Windows.Forms.SplitContainer splitContainer1;
	private NavPropGridCtl navPropGridCtl;
	private System.Windows.Forms.LinkLabel lkbAddNewNavProp;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.LinkLabel lkbAddlUsings;
	private System.Windows.Forms.LinkLabel lkbClassAttributes;
	private System.Windows.Forms.CheckBox ckbInclRowVersion;
}
