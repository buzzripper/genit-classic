namespace Dyvenix.Genit.UserControls;

partial class PropGridRowCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropGridRowCtl));
		numMaxLength = new System.Windows.Forms.NumericUpDown();
		ckbIsPrimaryKey = new System.Windows.Forms.CheckBox();
		ckbNullable = new System.Windows.Forms.CheckBox();
		ckbIsIdentity = new System.Windows.Forms.CheckBox();
		ckbIsIndexed = new System.Windows.Forms.CheckBox();
		ckbIsIndexUnique = new System.Windows.Forms.CheckBox();
		ckbIsIndexClustered = new System.Windows.Forms.CheckBox();
		picDelete = new System.Windows.Forms.PictureBox();
		picEditAssoc = new System.Windows.Forms.PictureBox();
		splName = new System.Windows.Forms.SplitContainer();
		txtName = new System.Windows.Forms.TextBox();
		splDatatype = new System.Windows.Forms.SplitContainer();
		dtcDatatype = new DataTypeCtl();
		((System.ComponentModel.ISupportInitialize)numMaxLength).BeginInit();
		((System.ComponentModel.ISupportInitialize)picDelete).BeginInit();
		((System.ComponentModel.ISupportInitialize)picEditAssoc).BeginInit();
		((System.ComponentModel.ISupportInitialize)splName).BeginInit();
		splName.Panel1.SuspendLayout();
		splName.Panel2.SuspendLayout();
		splName.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splDatatype).BeginInit();
		splDatatype.Panel1.SuspendLayout();
		splDatatype.Panel2.SuspendLayout();
		splDatatype.SuspendLayout();
		SuspendLayout();
		// 
		// numMaxLength
		// 
		numMaxLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
		numMaxLength.Location = new System.Drawing.Point(11, 0);
		numMaxLength.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
		numMaxLength.Name = "numMaxLength";
		numMaxLength.Size = new System.Drawing.Size(55, 19);
		numMaxLength.TabIndex = 2;
		numMaxLength.ValueChanged += numMaxLength_ValueChanged;
		// 
		// ckbIsPrimaryKey
		// 
		ckbIsPrimaryKey.AutoSize = true;
		ckbIsPrimaryKey.Location = new System.Drawing.Point(88, 4);
		ckbIsPrimaryKey.Name = "ckbIsPrimaryKey";
		ckbIsPrimaryKey.Size = new System.Drawing.Size(15, 14);
		ckbIsPrimaryKey.TabIndex = 3;
		ckbIsPrimaryKey.UseVisualStyleBackColor = true;
		ckbIsPrimaryKey.CheckedChanged += ckbIsPrimaryKey_CheckedChanged;
		// 
		// ckbNullable
		// 
		ckbNullable.AutoSize = true;
		ckbNullable.Location = new System.Drawing.Point(192, 4);
		ckbNullable.Name = "ckbNullable";
		ckbNullable.Size = new System.Drawing.Size(15, 14);
		ckbNullable.TabIndex = 5;
		ckbNullable.UseVisualStyleBackColor = true;
		ckbNullable.CheckedChanged += ckbNullable_CheckedChanged;
		// 
		// ckbIsIdentity
		// 
		ckbIsIdentity.AutoSize = true;
		ckbIsIdentity.Location = new System.Drawing.Point(140, 4);
		ckbIsIdentity.Name = "ckbIsIdentity";
		ckbIsIdentity.Size = new System.Drawing.Size(15, 14);
		ckbIsIdentity.TabIndex = 4;
		ckbIsIdentity.UseVisualStyleBackColor = true;
		ckbIsIdentity.CheckedChanged += ckbIsIdentity_CheckedChanged;
		// 
		// ckbIsIndexed
		// 
		ckbIsIndexed.AutoSize = true;
		ckbIsIndexed.Location = new System.Drawing.Point(244, 4);
		ckbIsIndexed.Name = "ckbIsIndexed";
		ckbIsIndexed.Size = new System.Drawing.Size(15, 14);
		ckbIsIndexed.TabIndex = 6;
		ckbIsIndexed.UseVisualStyleBackColor = true;
		ckbIsIndexed.CheckedChanged += ckbIsIndexed_CheckedChanged;
		// 
		// ckbIsIndexUnique
		// 
		ckbIsIndexUnique.AutoSize = true;
		ckbIsIndexUnique.Location = new System.Drawing.Point(296, 4);
		ckbIsIndexUnique.Name = "ckbIsIndexUnique";
		ckbIsIndexUnique.Size = new System.Drawing.Size(15, 14);
		ckbIsIndexUnique.TabIndex = 7;
		ckbIsIndexUnique.UseVisualStyleBackColor = true;
		ckbIsIndexUnique.CheckedChanged += ckbIsIndexUnique_CheckedChanged;
		// 
		// ckbIsIndexClustered
		// 
		ckbIsIndexClustered.AutoSize = true;
		ckbIsIndexClustered.Location = new System.Drawing.Point(348, 4);
		ckbIsIndexClustered.Name = "ckbIsIndexClustered";
		ckbIsIndexClustered.Size = new System.Drawing.Size(15, 14);
		ckbIsIndexClustered.TabIndex = 8;
		ckbIsIndexClustered.UseVisualStyleBackColor = true;
		ckbIsIndexClustered.CheckedChanged += ckbIsIndexClustered_CheckedChanged;
		// 
		// picDelete
		// 
		picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
		picDelete.Image = (System.Drawing.Image)resources.GetObject("picDelete.Image");
		picDelete.Location = new System.Drawing.Point(451, 0);
		picDelete.Name = "picDelete";
		picDelete.Size = new System.Drawing.Size(25, 20);
		picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
		picDelete.TabIndex = 9;
		picDelete.TabStop = false;
		picDelete.Click += picDelete_Click;
		// 
		// picEditAssoc
		// 
		picEditAssoc.Cursor = System.Windows.Forms.Cursors.Hand;
		picEditAssoc.Image = (System.Drawing.Image)resources.GetObject("picEditAssoc.Image");
		picEditAssoc.Location = new System.Drawing.Point(399, 0);
		picEditAssoc.Name = "picEditAssoc";
		picEditAssoc.Size = new System.Drawing.Size(25, 20);
		picEditAssoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
		picEditAssoc.TabIndex = 10;
		picEditAssoc.TabStop = false;
		picEditAssoc.Click += picEditAssoc_Click;
		// 
		// splName
		// 
		splName.Dock = System.Windows.Forms.DockStyle.Top;
		splName.Location = new System.Drawing.Point(0, 0);
		splName.Name = "splName";
		// 
		// splName.Panel1
		// 
		splName.Panel1.Controls.Add(txtName);
		// 
		// splName.Panel2
		// 
		splName.Panel2.Controls.Add(splDatatype);
		splName.Size = new System.Drawing.Size(784, 28);
		splName.SplitterDistance = 140;
		splName.SplitterWidth = 3;
		splName.TabIndex = 11;
		splName.TabStop = false;
		// 
		// txtName
		// 
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtName.Dock = System.Windows.Forms.DockStyle.Fill;
		txtName.Location = new System.Drawing.Point(0, 0);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(140, 16);
		txtName.TabIndex = 0;
		txtName.TextChanged += txtName_TextChanged;
		// 
		// splDatatype
		// 
		splDatatype.Dock = System.Windows.Forms.DockStyle.Top;
		splDatatype.Location = new System.Drawing.Point(0, 0);
		splDatatype.Name = "splDatatype";
		// 
		// splDatatype.Panel1
		// 
		splDatatype.Panel1.Controls.Add(dtcDatatype);
		// 
		// splDatatype.Panel2
		// 
		splDatatype.Panel2.Controls.Add(numMaxLength);
		splDatatype.Panel2.Controls.Add(picEditAssoc);
		splDatatype.Panel2.Controls.Add(ckbIsPrimaryKey);
		splDatatype.Panel2.Controls.Add(picDelete);
		splDatatype.Panel2.Controls.Add(ckbNullable);
		splDatatype.Panel2.Controls.Add(ckbIsIndexClustered);
		splDatatype.Panel2.Controls.Add(ckbIsIndexed);
		splDatatype.Panel2.Controls.Add(ckbIsIndexUnique);
		splDatatype.Panel2.Controls.Add(ckbIsIdentity);
		splDatatype.Size = new System.Drawing.Size(641, 28);
		splDatatype.SplitterDistance = 125;
		splDatatype.SplitterWidth = 3;
		splDatatype.TabIndex = 0;
		splDatatype.TabStop = false;
		// 
		// dtcDatatype
		// 
		dtcDatatype.BackColor = System.Drawing.SystemColors.ActiveBorder;
		dtcDatatype.Dock = System.Windows.Forms.DockStyle.Fill;
		dtcDatatype.Location = new System.Drawing.Point(0, 0);
		dtcDatatype.Name = "dtcDatatype";
		dtcDatatype.Size = new System.Drawing.Size(125, 28);
		dtcDatatype.TabIndex = 0;
		// 
		// PropGridRowCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		Controls.Add(splName);
		Name = "PropGridRowCtl";
		Size = new System.Drawing.Size(784, 24);
		Load += PropGridRowCtl_Load;
		((System.ComponentModel.ISupportInitialize)numMaxLength).EndInit();
		((System.ComponentModel.ISupportInitialize)picDelete).EndInit();
		((System.ComponentModel.ISupportInitialize)picEditAssoc).EndInit();
		splName.Panel1.ResumeLayout(false);
		splName.Panel1.PerformLayout();
		splName.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splName).EndInit();
		splName.ResumeLayout(false);
		splDatatype.Panel1.ResumeLayout(false);
		splDatatype.Panel2.ResumeLayout(false);
		splDatatype.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)splDatatype).EndInit();
		splDatatype.ResumeLayout(false);
		ResumeLayout(false);
	}

	#endregion
	private System.Windows.Forms.NumericUpDown numMaxLength;
	private System.Windows.Forms.CheckBox ckbIsPrimaryKey;
	private System.Windows.Forms.CheckBox ckbNullable;
	private System.Windows.Forms.CheckBox ckbIsIdentity;
	private System.Windows.Forms.CheckBox ckbIsIndexed;
	private System.Windows.Forms.CheckBox ckbIsIndexUnique;
	private System.Windows.Forms.CheckBox ckbIsIndexClustered;
	private System.Windows.Forms.PictureBox picDelete;
	private System.Windows.Forms.PictureBox picEditAssoc;
	private System.Windows.Forms.SplitContainer splName;
	private System.Windows.Forms.SplitContainer splDatatype;
	private System.Windows.Forms.TextBox txtName;
	private DataTypeCtl dtcDatatype;
}
