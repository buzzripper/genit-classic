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
		((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
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
		propGridCtl.Location = new System.Drawing.Point(12, 120);
		propGridCtl.Name = "propGridCtl";
		propGridCtl.Size = new System.Drawing.Size(1035, 423);
		propGridCtl.TabIndex = 13;
		// 
		// EntityMainEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(propGridCtl);
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
		Size = new System.Drawing.Size(1058, 552);
		Load += EntityMainEditCtl_Load;
		((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
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
}
