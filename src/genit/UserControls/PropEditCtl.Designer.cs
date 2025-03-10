namespace Dyvenix.Genit.UserControls;

partial class PropEditCtl
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
		textBox1 = new System.Windows.Forms.TextBox();
		bindingSrc = new System.Windows.Forms.BindingSource(components);
		ckbIsNullable = new System.Windows.Forms.CheckBox();
		ckbPrimaryKey = new System.Windows.Forms.CheckBox();
		ckbIsIdentity = new System.Windows.Forms.CheckBox();
		ckbIsIndexed = new System.Windows.Forms.CheckBox();
		ckbIsClustered = new System.Windows.Forms.CheckBox();
		dataTypeCtl1 = new DataTypeCtl();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		numMaxLength = new System.Windows.Forms.NumericUpDown();
		ckbMaxStrLength = new System.Windows.Forms.CheckBox();
		ckbIsIndexUnique = new System.Windows.Forms.CheckBox();
		((System.ComponentModel.ISupportInitialize)bindingSrc).BeginInit();
		((System.ComponentModel.ISupportInitialize)numMaxLength).BeginInit();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(59, 21);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(48, 19);
		label1.TabIndex = 0;
		label1.Text = "Name:";
		// 
		// textBox1
		// 
		textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSrc, "Name", true));
		textBox1.Location = new System.Drawing.Point(113, 22);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(592, 18);
		textBox1.TabIndex = 1;
		// 
		// bindingSrc
		// 
		bindingSrc.DataSource = typeof(Models.PropertyModel);
		// 
		// ckbIsNullable
		// 
		ckbIsNullable.AutoSize = true;
		ckbIsNullable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSrc, "Nullable", true));
		ckbIsNullable.Location = new System.Drawing.Point(113, 167);
		ckbIsNullable.Name = "ckbIsNullable";
		ckbIsNullable.Size = new System.Drawing.Size(77, 23);
		ckbIsNullable.TabIndex = 7;
		ckbIsNullable.Text = "Nullable";
		ckbIsNullable.UseVisualStyleBackColor = true;
		// 
		// ckbPrimaryKey
		// 
		ckbPrimaryKey.AutoSize = true;
		ckbPrimaryKey.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSrc, "IsPrimaryKey", true));
		ckbPrimaryKey.Location = new System.Drawing.Point(113, 140);
		ckbPrimaryKey.Name = "ckbPrimaryKey";
		ckbPrimaryKey.Size = new System.Drawing.Size(101, 23);
		ckbPrimaryKey.TabIndex = 5;
		ckbPrimaryKey.Text = "Primary Key";
		ckbPrimaryKey.UseVisualStyleBackColor = true;
		ckbPrimaryKey.CheckedChanged += ckbPrimaryKey_CheckedChanged;
		// 
		// ckbIsIdentity
		// 
		ckbIsIdentity.AutoSize = true;
		ckbIsIdentity.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSrc, "IsIdentity", true));
		ckbIsIdentity.Location = new System.Drawing.Point(234, 140);
		ckbIsIdentity.Name = "ckbIsIdentity";
		ckbIsIdentity.Size = new System.Drawing.Size(75, 23);
		ckbIsIdentity.TabIndex = 6;
		ckbIsIdentity.Text = "Identity";
		ckbIsIdentity.UseVisualStyleBackColor = true;
		// 
		// ckbIsIndexed
		// 
		ckbIsIndexed.AutoSize = true;
		ckbIsIndexed.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSrc, "IsIndexed", true));
		ckbIsIndexed.Location = new System.Drawing.Point(113, 194);
		ckbIsIndexed.Name = "ckbIsIndexed";
		ckbIsIndexed.Size = new System.Drawing.Size(76, 23);
		ckbIsIndexed.TabIndex = 8;
		ckbIsIndexed.Text = "Indexed";
		ckbIsIndexed.UseVisualStyleBackColor = true;
		ckbIsIndexed.CheckedChanged += ckbIsIndexed_CheckedChanged;
		// 
		// ckbIsClustered
		// 
		ckbIsClustered.AutoSize = true;
		ckbIsClustered.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSrc, "IsIndexClustered", true));
		ckbIsClustered.Location = new System.Drawing.Point(340, 194);
		ckbIsClustered.Name = "ckbIsClustered";
		ckbIsClustered.Size = new System.Drawing.Size(86, 23);
		ckbIsClustered.TabIndex = 9;
		ckbIsClustered.Text = "Clustered";
		ckbIsClustered.UseVisualStyleBackColor = true;
		// 
		// dataTypeCtl1
		// 
		dataTypeCtl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		dataTypeCtl1.BackColor = System.Drawing.SystemColors.ActiveBorder;
		dataTypeCtl1.Location = new System.Drawing.Point(113, 56);
		dataTypeCtl1.Name = "dataTypeCtl1";
		dataTypeCtl1.Size = new System.Drawing.Size(592, 25);
		dataTypeCtl1.TabIndex = 2;
		dataTypeCtl1.ValueChanged += dataTypeCtl1_ValueChanged;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(34, 59);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(73, 19);
		label3.TabIndex = 10;
		label3.Text = "Data Type:";
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(22, 94);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(85, 19);
		label4.TabIndex = 11;
		label4.Text = "Max Length:";
		// 
		// numMaxLength
		// 
		numMaxLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
		numMaxLength.DataBindings.Add(new System.Windows.Forms.Binding("Value", bindingSrc, "MaxLength", true));
		numMaxLength.Increment = new decimal(new int[] { 5, 0, 0, 0 });
		numMaxLength.Location = new System.Drawing.Point(113, 95);
		numMaxLength.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
		numMaxLength.Name = "numMaxLength";
		numMaxLength.Size = new System.Drawing.Size(76, 21);
		numMaxLength.TabIndex = 3;
		// 
		// ckbMaxStrLength
		// 
		ckbMaxStrLength.AutoSize = true;
		ckbMaxStrLength.Location = new System.Drawing.Point(204, 95);
		ckbMaxStrLength.Name = "ckbMaxStrLength";
		ckbMaxStrLength.Size = new System.Drawing.Size(54, 23);
		ckbMaxStrLength.TabIndex = 4;
		ckbMaxStrLength.Text = "Max";
		ckbMaxStrLength.UseVisualStyleBackColor = true;
		// 
		// ckbIsIndexUnique
		// 
		ckbIsIndexUnique.AutoSize = true;
		ckbIsIndexUnique.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSrc, "IsIndexUnique", true));
		ckbIsIndexUnique.Location = new System.Drawing.Point(234, 194);
		ckbIsIndexUnique.Name = "ckbIsIndexUnique";
		ckbIsIndexUnique.Size = new System.Drawing.Size(72, 23);
		ckbIsIndexUnique.TabIndex = 12;
		ckbIsIndexUnique.Text = "Unique";
		ckbIsIndexUnique.UseVisualStyleBackColor = true;
		// 
		// PropEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(ckbIsIndexUnique);
		Controls.Add(ckbMaxStrLength);
		Controls.Add(numMaxLength);
		Controls.Add(label4);
		Controls.Add(label3);
		Controls.Add(dataTypeCtl1);
		Controls.Add(ckbIsClustered);
		Controls.Add(ckbIsIndexed);
		Controls.Add(ckbIsIdentity);
		Controls.Add(ckbPrimaryKey);
		Controls.Add(ckbIsNullable);
		Controls.Add(textBox1);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "PropEditCtl";
		Size = new System.Drawing.Size(747, 533);
		((System.ComponentModel.ISupportInitialize)bindingSrc).EndInit();
		((System.ComponentModel.ISupportInitialize)numMaxLength).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.BindingSource bindingSrc;
	private System.Windows.Forms.CheckBox ckbIsNullable;
	private System.Windows.Forms.CheckBox ckbPrimaryKey;
	private System.Windows.Forms.CheckBox ckbIsIdentity;
	private System.Windows.Forms.CheckBox ckbIsIndexed;
	private System.Windows.Forms.CheckBox ckbIsClustered;
	private DataTypeCtl dataTypeCtl1;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.NumericUpDown numMaxLength;
	private System.Windows.Forms.CheckBox ckbMaxStrLength;
	private System.Windows.Forms.CheckBox ckbIsIndexUnique;
}
