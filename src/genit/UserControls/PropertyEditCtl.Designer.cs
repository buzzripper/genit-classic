namespace Dyvenix.Genit.UserControls;

partial class PropertyEditCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyEditCtl));
		splMain = new System.Windows.Forms.SplitContainer();
		splProps = new System.Windows.Forms.SplitContainer();
		lbxProps = new System.Windows.Forms.ListBox();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnAddProp = new System.Windows.Forms.ToolStripButton();
		btnDeleteProp = new System.Windows.Forms.ToolStripButton();
		lblProps = new System.Windows.Forms.ToolStripButton();
		listBox1 = new System.Windows.Forms.ListBox();
		toolStrip2 = new System.Windows.Forms.ToolStrip();
		toolStripButton1 = new System.Windows.Forms.ToolStripButton();
		toolStripButton2 = new System.Windows.Forms.ToolStripButton();
		lblNavProps = new System.Windows.Forms.ToolStripButton();
		navPropEditCtl = new NavPropEditCtl();
		propEditCtl = new PropEditCtl();
		propsBindingSrc = new System.Windows.Forms.BindingSource(components);
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splProps).BeginInit();
		splProps.Panel1.SuspendLayout();
		splProps.Panel2.SuspendLayout();
		splProps.SuspendLayout();
		toolStrip1.SuspendLayout();
		toolStrip2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)propsBindingSrc).BeginInit();
		SuspendLayout();
		// 
		// splMain
		// 
		splMain.Dock = System.Windows.Forms.DockStyle.Fill;
		splMain.Location = new System.Drawing.Point(0, 0);
		splMain.Name = "splMain";
		// 
		// splMain.Panel1
		// 
		splMain.Panel1.Controls.Add(splProps);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
		splMain.Panel2.Controls.Add(navPropEditCtl);
		splMain.Panel2.Controls.Add(propEditCtl);
		splMain.Size = new System.Drawing.Size(862, 883);
		splMain.SplitterDistance = 287;
		splMain.SplitterWidth = 6;
		splMain.TabIndex = 1;
		// 
		// splProps
		// 
		splProps.Dock = System.Windows.Forms.DockStyle.Fill;
		splProps.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		splProps.Location = new System.Drawing.Point(0, 0);
		splProps.Name = "splProps";
		splProps.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splProps.Panel1
		// 
		splProps.Panel1.Controls.Add(lbxProps);
		splProps.Panel1.Controls.Add(toolStrip1);
		// 
		// splProps.Panel2
		// 
		splProps.Panel2.Controls.Add(listBox1);
		splProps.Panel2.Controls.Add(toolStrip2);
		splProps.Size = new System.Drawing.Size(287, 883);
		splProps.SplitterDistance = 350;
		splProps.TabIndex = 2;
		// 
		// lbxProps
		// 
		lbxProps.BorderStyle = System.Windows.Forms.BorderStyle.None;
		lbxProps.Dock = System.Windows.Forms.DockStyle.Fill;
		lbxProps.FormattingEnabled = true;
		lbxProps.Location = new System.Drawing.Point(0, 25);
		lbxProps.Name = "lbxProps";
		lbxProps.Size = new System.Drawing.Size(287, 325);
		lbxProps.TabIndex = 1;
		lbxProps.SelectedIndexChanged += lbxProps_SelectedIndexChanged;
		// 
		// toolStrip1
		// 
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAddProp, btnDeleteProp, lblProps });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(287, 25);
		toolStrip1.TabIndex = 0;
		toolStrip1.Text = "toolStrip1";
		// 
		// btnAddProp
		// 
		btnAddProp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		btnAddProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnAddProp.Image = (System.Drawing.Image)resources.GetObject("btnAddProp.Image");
		btnAddProp.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnAddProp.Name = "btnAddProp";
		btnAddProp.Size = new System.Drawing.Size(23, 22);
		btnAddProp.Text = "toolStripButton1";
		btnAddProp.ToolTipText = "Add";
		btnAddProp.Click += btnAddProp_Click;
		// 
		// btnDeleteProp
		// 
		btnDeleteProp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		btnDeleteProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnDeleteProp.Image = (System.Drawing.Image)resources.GetObject("btnDeleteProp.Image");
		btnDeleteProp.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnDeleteProp.Name = "btnDeleteProp";
		btnDeleteProp.Size = new System.Drawing.Size(23, 22);
		btnDeleteProp.Text = "toolStripButton1";
		btnDeleteProp.ToolTipText = "Delete";
		btnDeleteProp.Click += btnDeleteProp_Click;
		// 
		// lblProps
		// 
		lblProps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		lblProps.Image = (System.Drawing.Image)resources.GetObject("lblProps.Image");
		lblProps.ImageTransparentColor = System.Drawing.Color.Magenta;
		lblProps.Name = "lblProps";
		lblProps.Size = new System.Drawing.Size(64, 22);
		lblProps.Text = "Properties";
		// 
		// listBox1
		// 
		listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		listBox1.FormattingEnabled = true;
		listBox1.Location = new System.Drawing.Point(0, 25);
		listBox1.Name = "listBox1";
		listBox1.Size = new System.Drawing.Size(287, 504);
		listBox1.TabIndex = 3;
		// 
		// toolStrip2
		// 
		toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButton1, toolStripButton2, lblNavProps });
		toolStrip2.Location = new System.Drawing.Point(0, 0);
		toolStrip2.Name = "toolStrip2";
		toolStrip2.Size = new System.Drawing.Size(287, 25);
		toolStrip2.TabIndex = 2;
		toolStrip2.Text = "toolStrip2";
		// 
		// toolStripButton1
		// 
		toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		toolStripButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
		toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		toolStripButton1.Name = "toolStripButton1";
		toolStripButton1.Size = new System.Drawing.Size(23, 22);
		toolStripButton1.Text = "toolStripButton1";
		toolStripButton1.ToolTipText = "Add";
		// 
		// toolStripButton2
		// 
		toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		toolStripButton2.Image = (System.Drawing.Image)resources.GetObject("toolStripButton2.Image");
		toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
		toolStripButton2.Name = "toolStripButton2";
		toolStripButton2.Size = new System.Drawing.Size(23, 22);
		toolStripButton2.Text = "toolStripButton1";
		toolStripButton2.ToolTipText = "Delete";
		// 
		// lblNavProps
		// 
		lblNavProps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		lblNavProps.Image = (System.Drawing.Image)resources.GetObject("lblNavProps.Image");
		lblNavProps.ImageTransparentColor = System.Drawing.Color.Magenta;
		lblNavProps.Name = "lblNavProps";
		lblNavProps.Size = new System.Drawing.Size(125, 22);
		lblNavProps.Text = "Navigation Properties";
		// 
		// navPropEditCtl
		// 
		navPropEditCtl.BackColor = System.Drawing.SystemColors.ActiveBorder;
		navPropEditCtl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		navPropEditCtl.Location = new System.Drawing.Point(30, 382);
		navPropEditCtl.Name = "navPropEditCtl";
		navPropEditCtl.Size = new System.Drawing.Size(392, 274);
		navPropEditCtl.TabIndex = 1;
		// 
		// propEditCtl
		// 
		propEditCtl.BackColor = System.Drawing.SystemColors.ActiveBorder;
		propEditCtl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		propEditCtl.Location = new System.Drawing.Point(42, 41);
		propEditCtl.Name = "propEditCtl";
		propEditCtl.Size = new System.Drawing.Size(411, 335);
		propEditCtl.TabIndex = 0;
		// 
		// propsBindingSrc
		// 
		propsBindingSrc.DataSource = typeof(Models.PropertyModel);
		// 
		// PropertyEditCtl
		// 
		Controls.Add(splMain);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "PropertyEditCtl";
		Size = new System.Drawing.Size(862, 883);
		Load += PropertyEditCtl_Load;
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		splProps.Panel1.ResumeLayout(false);
		splProps.Panel1.PerformLayout();
		splProps.Panel2.ResumeLayout(false);
		splProps.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)splProps).EndInit();
		splProps.ResumeLayout(false);
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		toolStrip2.ResumeLayout(false);
		toolStrip2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)propsBindingSrc).EndInit();
		ResumeLayout(false);
	}

	#endregion
	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.SplitContainer splProps;
	private System.Windows.Forms.BindingSource propsBindingSrc;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripButton btnAddProp;
	private System.Windows.Forms.ToolStripButton btnDeleteProp;
	private System.Windows.Forms.ListBox lbxProps;
	private System.Windows.Forms.ToolStripButton lblProps;
	private System.Windows.Forms.ListBox listBox1;
	private System.Windows.Forms.ToolStrip toolStrip2;
	private System.Windows.Forms.ToolStripButton toolStripButton1;
	private System.Windows.Forms.ToolStripButton toolStripButton2;
	private System.Windows.Forms.ToolStripButton lblNavProps;
	private PropEditCtl propEditCtl;
	private NavPropEditCtl navPropEditCtl;
}
