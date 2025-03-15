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
		sleUsings = new StringListEditor();
		label5 = new System.Windows.Forms.Label();
		sleAttrs = new StringListEditor();
		label6 = new System.Windows.Forms.Label();
		propGridCtl = new PropGridCtl();
		label7 = new System.Windows.Forms.Label();
		lkbAddNewProp = new System.Windows.Forms.LinkLabel();
		splitContainer1 = new System.Windows.Forms.SplitContainer();
		navPropGridCtl = new NavPropGridCtl();
		lkbAddNewNavProp = new System.Windows.Forms.LinkLabel();
		label8 = new System.Windows.Forms.Label();
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
		label1.Location = new System.Drawing.Point(47, 25);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(48, 19);
		label1.TabIndex = 0;
		label1.Text = "Name:";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(342, 23);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(59, 19);
		label2.TabIndex = 1;
		label2.Text = "Schema:";
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(319, 53);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(82, 19);
		label3.TabIndex = 2;
		label3.Text = "Table Name:";
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(13, 54);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(82, 19);
		label4.TabIndex = 3;
		label4.Text = "Namespace:";
		// 
		// txtName
		// 
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Name", true));
		txtName.Location = new System.Drawing.Point(101, 27);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(211, 18);
		txtName.TabIndex = 0;
		txtName.TextChanged += txtName_TextChanged;
		// 
		// bindingSource
		// 
		bindingSource.DataSource = typeof(Models.EntityModel);
		// 
		// txtSchema
		// 
		txtSchema.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtSchema.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Schema", true));
		txtSchema.Location = new System.Drawing.Point(407, 25);
		txtSchema.Name = "txtSchema";
		txtSchema.Size = new System.Drawing.Size(176, 18);
		txtSchema.TabIndex = 1;
		txtSchema.TextChanged += txtSchema_TextChanged;
		// 
		// txtTableName
		// 
		txtTableName.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "TableName", true));
		txtTableName.Location = new System.Drawing.Point(407, 54);
		txtTableName.Name = "txtTableName";
		txtTableName.Size = new System.Drawing.Size(176, 18);
		txtTableName.TabIndex = 2;
		txtTableName.TextChanged += txtTableName_TextChanged;
		// 
		// txtNamespace
		// 
		txtNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Namespace", true));
		txtNamespace.Location = new System.Drawing.Point(101, 55);
		txtNamespace.Name = "txtNamespace";
		txtNamespace.Size = new System.Drawing.Size(211, 18);
		txtNamespace.TabIndex = 3;
		txtNamespace.TextChanged += txtNamespace_TextChanged;
		// 
		// ckbEnabled
		// 
		ckbEnabled.AutoSize = true;
		ckbEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "Enabled", true));
		ckbEnabled.Location = new System.Drawing.Point(603, 39);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(76, 23);
		ckbEnabled.TabIndex = 4;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		ckbEnabled.CheckedChanged += ckbEnabled_CheckedChanged;
		// 
		// sleUsings
		// 
		sleUsings.BackColor = System.Drawing.SystemColors.Control;
		sleUsings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		sleUsings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		sleUsings.Location = new System.Drawing.Point(688, 32);
		sleUsings.Name = "sleUsings";
		sleUsings.Size = new System.Drawing.Size(154, 70);
		sleUsings.TabIndex = 5;
		sleUsings.ToolbarDockStyle = System.Windows.Forms.DockStyle.Right;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(688, 10);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(116, 19);
		label5.TabIndex = 10;
		label5.Text = "Additional Usings";
		// 
		// sleAttrs
		// 
		sleAttrs.BackColor = System.Drawing.SystemColors.Control;
		sleAttrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		sleAttrs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		sleAttrs.Location = new System.Drawing.Point(871, 32);
		sleAttrs.Name = "sleAttrs";
		sleAttrs.Size = new System.Drawing.Size(170, 70);
		sleAttrs.TabIndex = 6;
		sleAttrs.ToolbarDockStyle = System.Windows.Forms.DockStyle.Right;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(873, 10);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(105, 19);
		label6.TabIndex = 12;
		label6.Text = "Class Attributes";
		// 
		// propGridCtl
		// 
		propGridCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		propGridCtl.AutoScroll = true;
		propGridCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		propGridCtl.Location = new System.Drawing.Point(2, 25);
		propGridCtl.Name = "propGridCtl";
		propGridCtl.Size = new System.Drawing.Size(755, 222);
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
		lkbAddNewProp.Location = new System.Drawing.Point(691, 3);
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
		splitContainer1.Location = new System.Drawing.Point(16, 117);
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
		splitContainer1.Size = new System.Drawing.Size(759, 447);
		splitContainer1.SplitterDistance = 248;
		splitContainer1.TabIndex = 16;
		// 
		// navPropGridCtl
		// 
		navPropGridCtl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		navPropGridCtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		navPropGridCtl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		navPropGridCtl.Location = new System.Drawing.Point(3, 35);
		navPropGridCtl.Name = "navPropGridCtl";
		navPropGridCtl.Size = new System.Drawing.Size(754, 157);
		navPropGridCtl.TabIndex = 18;
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
		lkbAddNewNavProp.Location = new System.Drawing.Point(691, 12);
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
		// EntityMainEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(splitContainer1);
		Controls.Add(label6);
		Controls.Add(sleAttrs);
		Controls.Add(label5);
		Controls.Add(sleUsings);
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
		Size = new System.Drawing.Size(792, 580);
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
	private StringListEditor sleUsings;
	private System.Windows.Forms.Label label5;
	private StringListEditor sleAttrs;
	private System.Windows.Forms.Label label6;
	private PropGridCtl propGridCtl;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.LinkLabel lkbAddNewProp;
	private System.Windows.Forms.SplitContainer splitContainer1;
	private NavPropGridCtl navPropGridCtl;
	private System.Windows.Forms.LinkLabel lkbAddNewNavProp;
	private System.Windows.Forms.Label label8;
}
