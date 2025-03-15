namespace Dyvenix.Genit.UserControls;

partial class NavPropGridRowCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavPropGridRowCtl));
		splMain = new System.Windows.Forms.SplitContainer();
		txtName = new System.Windows.Forms.TextBox();
		splCardinality = new System.Windows.Forms.SplitContainer();
		cmbCardinality = new System.Windows.Forms.ComboBox();
		splRelPropName = new System.Windows.Forms.SplitContainer();
		entityListCtl = new EntityListCtl();
		picDelete = new System.Windows.Forms.PictureBox();
		picEditNavProp = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splCardinality).BeginInit();
		splCardinality.Panel1.SuspendLayout();
		splCardinality.Panel2.SuspendLayout();
		splCardinality.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splRelPropName).BeginInit();
		splRelPropName.Panel1.SuspendLayout();
		splRelPropName.Panel2.SuspendLayout();
		splRelPropName.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)picDelete).BeginInit();
		((System.ComponentModel.ISupportInitialize)picEditNavProp).BeginInit();
		SuspendLayout();
		// 
		// splMain
		// 
		splMain.Dock = System.Windows.Forms.DockStyle.Top;
		splMain.Location = new System.Drawing.Point(0, 0);
		splMain.Name = "splMain";
		// 
		// splMain.Panel1
		// 
		splMain.Panel1.Controls.Add(txtName);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.Controls.Add(splCardinality);
		splMain.Size = new System.Drawing.Size(1408, 41);
		splMain.SplitterDistance = 369;
		splMain.TabIndex = 1;
		// 
		// txtName
		// 
		txtName.Dock = System.Windows.Forms.DockStyle.Top;
		txtName.Location = new System.Drawing.Point(0, 0);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(369, 25);
		txtName.TabIndex = 0;
		txtName.TextChanged += txtName_TextChanged;
		// 
		// splCardinality
		// 
		splCardinality.Dock = System.Windows.Forms.DockStyle.Fill;
		splCardinality.Location = new System.Drawing.Point(0, 0);
		splCardinality.Name = "splCardinality";
		// 
		// splCardinality.Panel1
		// 
		splCardinality.Panel1.Controls.Add(cmbCardinality);
		// 
		// splCardinality.Panel2
		// 
		splCardinality.Panel2.Controls.Add(splRelPropName);
		splCardinality.Size = new System.Drawing.Size(1035, 41);
		splCardinality.SplitterDistance = 278;
		splCardinality.TabIndex = 0;
		// 
		// cmbCardinality
		// 
		cmbCardinality.Dock = System.Windows.Forms.DockStyle.Top;
		cmbCardinality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cmbCardinality.FormattingEnabled = true;
		cmbCardinality.Location = new System.Drawing.Point(0, 0);
		cmbCardinality.Name = "cmbCardinality";
		cmbCardinality.Size = new System.Drawing.Size(278, 25);
		cmbCardinality.TabIndex = 0;
		cmbCardinality.SelectedIndexChanged += cmbCardinality_SelectedIndexChanged;
		// 
		// splRelPropName
		// 
		splRelPropName.Dock = System.Windows.Forms.DockStyle.Fill;
		splRelPropName.Location = new System.Drawing.Point(0, 0);
		splRelPropName.Name = "splRelPropName";
		// 
		// splRelPropName.Panel1
		// 
		splRelPropName.Panel1.Controls.Add(entityListCtl);
		// 
		// splRelPropName.Panel2
		// 
		splRelPropName.Panel2.Controls.Add(picEditNavProp);
		splRelPropName.Panel2.Controls.Add(picDelete);
		splRelPropName.Size = new System.Drawing.Size(753, 41);
		splRelPropName.SplitterDistance = 240;
		splRelPropName.TabIndex = 0;
		// 
		// entityListCtl
		// 
		entityListCtl.Dock = System.Windows.Forms.DockStyle.Top;
		entityListCtl.Location = new System.Drawing.Point(0, 0);
		entityListCtl.Name = "entityListCtl";
		entityListCtl.Size = new System.Drawing.Size(240, 23);
		entityListCtl.TabIndex = 0;
		entityListCtl.ValueChanged += entityListCtl_ValueChanged;
		// 
		// picDelete
		// 
		picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
		picDelete.Image = (System.Drawing.Image)resources.GetObject("picDelete.Image");
		picDelete.Location = new System.Drawing.Point(58, 0);
		picDelete.Name = "picDelete";
		picDelete.Size = new System.Drawing.Size(22, 25);
		picDelete.TabIndex = 1;
		picDelete.TabStop = false;
		picDelete.Click += picDelete_Click;
		// 
		// picEditNavProp
		// 
		picEditNavProp.Cursor = System.Windows.Forms.Cursors.Hand;
		picEditNavProp.Image = (System.Drawing.Image)resources.GetObject("picEditNavProp.Image");
		picEditNavProp.Location = new System.Drawing.Point(15, 0);
		picEditNavProp.Name = "picEditNavProp";
		picEditNavProp.Size = new System.Drawing.Size(22, 25);
		picEditNavProp.TabIndex = 2;
		picEditNavProp.TabStop = false;
		picEditNavProp.Click += picEditNavProp_Click;
		// 
		// NavPropGridRowCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.Control;
		Controls.Add(splMain);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "NavPropGridRowCtl";
		Size = new System.Drawing.Size(1408, 261);
		Load += NavPropGridRowCtrl_Load;
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel1.PerformLayout();
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		splCardinality.Panel1.ResumeLayout(false);
		splCardinality.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splCardinality).EndInit();
		splCardinality.ResumeLayout(false);
		splRelPropName.Panel1.ResumeLayout(false);
		splRelPropName.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splRelPropName).EndInit();
		splRelPropName.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)picDelete).EndInit();
		((System.ComponentModel.ISupportInitialize)picEditNavProp).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.TextBox txtPrimaryName;
	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.SplitContainer splCardinality;
	private System.Windows.Forms.SplitContainer splRelPropName;
	private System.Windows.Forms.PictureBox picDelete;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.ComboBox cmbCardinality;
	private EntityListCtl entityListCtl;
	private System.Windows.Forms.PictureBox picEditNavProp;
}
