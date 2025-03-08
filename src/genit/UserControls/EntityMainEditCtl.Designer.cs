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
		lblName = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.TextBox();
		bindingSource = new System.Windows.Forms.BindingSource(components);
		txtNamespace = new System.Windows.Forms.TextBox();
		label8 = new System.Windows.Forms.Label();
		txtSchema = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		sleUsings = new StringListEditor();
		label4 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		sleAttrs = new StringListEditor();
		txtTableName = new System.Windows.Forms.TextBox();
		lbl7 = new System.Windows.Forms.Label();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		label2 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		ckbQuerySingle = new System.Windows.Forms.CheckBox();
		ckbQueryList = new System.Windows.Forms.CheckBox();
		ckbUseListPaging = new System.Windows.Forms.CheckBox();
		ckbUseListSorting = new System.Windows.Forms.CheckBox();
		checkBox1 = new System.Windows.Forms.CheckBox();
		((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
		SuspendLayout();
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Location = new System.Drawing.Point(98, 55);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(48, 19);
		lblName.TabIndex = 1;
		lblName.Text = "Name:";
		lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtName
		// 
		txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Name", true));
		txtName.Location = new System.Drawing.Point(146, 53);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(318, 25);
		txtName.TabIndex = 2;
		// 
		// bindingSource
		// 
		bindingSource.DataSource = typeof(Models.EntityModel);
		// 
		// txtNamespace
		// 
		txtNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Namespace", true));
		txtNamespace.Location = new System.Drawing.Point(146, 161);
		txtNamespace.Name = "txtNamespace";
		txtNamespace.Size = new System.Drawing.Size(318, 25);
		txtNamespace.TabIndex = 4;
		// 
		// label8
		// 
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(64, 164);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(82, 19);
		label8.TabIndex = 3;
		label8.Text = "Namespace:";
		label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// txtSchema
		// 
		txtSchema.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Schema", true));
		txtSchema.Location = new System.Drawing.Point(146, 89);
		txtSchema.Name = "txtSchema";
		txtSchema.Size = new System.Drawing.Size(318, 25);
		txtSchema.TabIndex = 6;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(87, 91);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(59, 19);
		label3.TabIndex = 5;
		label3.Text = "Schema:";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// sleUsings
		// 
		sleUsings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		sleUsings.BackColor = System.Drawing.Color.RosyBrown;
		sleUsings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		sleUsings.Font = new System.Drawing.Font("Segoe UI", 10F);
		sleUsings.Location = new System.Drawing.Point(480, 51);
		sleUsings.Name = "sleUsings";
		sleUsings.Size = new System.Drawing.Size(322, 111);
		sleUsings.TabIndex = 7;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(480, 29);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(116, 19);
		label4.TabIndex = 8;
		label4.Text = "Additional Usings";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(480, 185);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(105, 19);
		label1.TabIndex = 10;
		label1.Text = "Class Attributes";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// sleAttrs
		// 
		sleAttrs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		sleAttrs.BackColor = System.Drawing.Color.RosyBrown;
		sleAttrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		sleAttrs.Font = new System.Drawing.Font("Segoe UI", 10F);
		sleAttrs.Location = new System.Drawing.Point(480, 206);
		sleAttrs.Name = "sleAttrs";
		sleAttrs.Size = new System.Drawing.Size(322, 111);
		sleAttrs.TabIndex = 9;
		// 
		// txtTableName
		// 
		txtTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "TableName", true));
		txtTableName.Location = new System.Drawing.Point(146, 125);
		txtTableName.Name = "txtTableName";
		txtTableName.Size = new System.Drawing.Size(318, 25);
		txtTableName.TabIndex = 12;
		// 
		// lbl7
		// 
		lbl7.AutoSize = true;
		lbl7.Location = new System.Drawing.Point(64, 128);
		lbl7.Name = "lbl7";
		lbl7.Size = new System.Drawing.Size(82, 19);
		lbl7.TabIndex = 11;
		lbl7.Text = "Table Name:";
		lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// ckbEnabled
		// 
		ckbEnabled.AutoSize = true;
		ckbEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		ckbEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "Enabled", true));
		ckbEnabled.Location = new System.Drawing.Point(385, 197);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(79, 23);
		ckbEnabled.TabIndex = 13;
		ckbEnabled.Text = "Enabled:";
		ckbEnabled.UseVisualStyleBackColor = true;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(31, 40);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(40, 19);
		label2.TabIndex = 14;
		label2.Text = "Main";
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(31, 218);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(110, 19);
		label5.TabIndex = 15;
		label5.Text = "Service Methods";
		// 
		// ckbQuerySingle
		// 
		ckbQuerySingle.AutoSize = true;
		ckbQuerySingle.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "InclSingleQuery", true));
		ckbQuerySingle.Location = new System.Drawing.Point(78, 252);
		ckbQuerySingle.Name = "ckbQuerySingle";
		ckbQuerySingle.Size = new System.Drawing.Size(116, 23);
		ckbQuerySingle.TabIndex = 16;
		ckbQuerySingle.Text = "Query - Single";
		ckbQuerySingle.UseVisualStyleBackColor = true;
		// 
		// ckbQueryList
		// 
		ckbQueryList.AutoSize = true;
		ckbQueryList.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "InclListQuery", true));
		ckbQueryList.Location = new System.Drawing.Point(77, 312);
		ckbQueryList.Name = "ckbQueryList";
		ckbQueryList.Size = new System.Drawing.Size(101, 23);
		ckbQueryList.TabIndex = 17;
		ckbQueryList.Text = "Query - List";
		ckbQueryList.UseVisualStyleBackColor = true;
		ckbQueryList.CheckedChanged += ckbQueryList_CheckedChanged;
		// 
		// ckbUseListPaging
		// 
		ckbUseListPaging.AutoSize = true;
		ckbUseListPaging.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "UseListPaging", true));
		ckbUseListPaging.Enabled = false;
		ckbUseListPaging.Location = new System.Drawing.Point(196, 312);
		ckbUseListPaging.Name = "ckbUseListPaging";
		ckbUseListPaging.Size = new System.Drawing.Size(97, 23);
		ckbUseListPaging.TabIndex = 18;
		ckbUseListPaging.Text = "Use Paging";
		ckbUseListPaging.UseVisualStyleBackColor = true;
		// 
		// ckbUseListSorting
		// 
		ckbUseListSorting.AutoSize = true;
		ckbUseListSorting.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "UseListSorting", true));
		ckbUseListSorting.Enabled = false;
		ckbUseListSorting.Location = new System.Drawing.Point(301, 312);
		ckbUseListSorting.Name = "ckbUseListSorting";
		ckbUseListSorting.Size = new System.Drawing.Size(99, 23);
		ckbUseListSorting.TabIndex = 19;
		ckbUseListSorting.Text = "Use Sorting";
		ckbUseListSorting.UseVisualStyleBackColor = true;
		// 
		// checkBox1
		// 
		checkBox1.AutoSize = true;
		checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "InclListQuery", true));
		checkBox1.Location = new System.Drawing.Point(77, 282);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(101, 23);
		checkBox1.TabIndex = 20;
		checkBox1.Text = "Query - List";
		checkBox1.UseVisualStyleBackColor = true;
		// 
		// EntityMainEditCtl
		// 
		Controls.Add(checkBox1);
		Controls.Add(ckbUseListSorting);
		Controls.Add(ckbUseListPaging);
		Controls.Add(ckbQueryList);
		Controls.Add(ckbQuerySingle);
		Controls.Add(label5);
		Controls.Add(label2);
		Controls.Add(ckbEnabled);
		Controls.Add(txtTableName);
		Controls.Add(label1);
		Controls.Add(sleAttrs);
		Controls.Add(label4);
		Controls.Add(sleUsings);
		Controls.Add(txtSchema);
		Controls.Add(txtNamespace);
		Controls.Add(txtName);
		Controls.Add(lbl7);
		Controls.Add(label3);
		Controls.Add(label8);
		Controls.Add(lblName);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "EntityMainEditCtl";
		Size = new System.Drawing.Size(865, 640);
		((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.TextBox txtNamespace;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.TextBox txtSchema;
	private System.Windows.Forms.Label label3;
	private StringListEditor sleUsings;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label1;
	private StringListEditor sleAttrs;
	private System.Windows.Forms.TextBox txtTableName;
	private System.Windows.Forms.Label lbl7;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.CheckBox ckbQuerySingle;
	private System.Windows.Forms.CheckBox ckbQueryList;
	private System.Windows.Forms.CheckBox ckbUseListPaging;
	private System.Windows.Forms.CheckBox ckbUseListSorting;
	private System.Windows.Forms.BindingSource bindingSource;
	private System.Windows.Forms.CheckBox checkBox1;
}
