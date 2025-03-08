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
		lbxProperties = new System.Windows.Forms.ListBox();
		splMain = new System.Windows.Forms.SplitContainer();
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		btnAddProperty = new System.Windows.Forms.ToolStripButton();
		btnDeleteProperty = new System.Windows.Forms.ToolStripButton();
		splPropList = new System.Windows.Forms.SplitContainer();
		txtName = new System.Windows.Forms.TextBox();
		lblName = new System.Windows.Forms.Label();
		bindingSource = new System.Windows.Forms.BindingSource(components);
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splPropList).BeginInit();
		splPropList.Panel1.SuspendLayout();
		splPropList.Panel2.SuspendLayout();
		splPropList.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
		SuspendLayout();
		// 
		// lbxProperties
		// 
		lbxProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
		lbxProperties.Dock = System.Windows.Forms.DockStyle.Fill;
		lbxProperties.FormattingEnabled = true;
		lbxProperties.Location = new System.Drawing.Point(0, 0);
		lbxProperties.Name = "lbxProperties";
		lbxProperties.Size = new System.Drawing.Size(287, 854);
		lbxProperties.TabIndex = 0;
		// 
		// splMain
		// 
		splMain.Dock = System.Windows.Forms.DockStyle.Fill;
		splMain.Location = new System.Drawing.Point(0, 0);
		splMain.Name = "splMain";
		// 
		// splMain.Panel1
		// 
		splMain.Panel1.Controls.Add(splPropList);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.Controls.Add(txtName);
		splMain.Panel2.Controls.Add(lblName);
		splMain.Size = new System.Drawing.Size(862, 883);
		splMain.SplitterDistance = 287;
		splMain.SplitterWidth = 6;
		splMain.TabIndex = 1;
		// 
		// toolStrip1
		// 
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAddProperty, btnDeleteProperty });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(287, 25);
		toolStrip1.TabIndex = 1;
		toolStrip1.Text = "toolStrip1";
		// 
		// btnAddProperty
		// 
		btnAddProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnAddProperty.Image = (System.Drawing.Image)resources.GetObject("btnAddProperty.Image");
		btnAddProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnAddProperty.Name = "btnAddProperty";
		btnAddProperty.Size = new System.Drawing.Size(23, 22);
		btnAddProperty.Text = "Add Property";
		// 
		// btnDeleteProperty
		// 
		btnDeleteProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnDeleteProperty.Enabled = false;
		btnDeleteProperty.Image = (System.Drawing.Image)resources.GetObject("btnDeleteProperty.Image");
		btnDeleteProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnDeleteProperty.Name = "btnDeleteProperty";
		btnDeleteProperty.Size = new System.Drawing.Size(23, 22);
		btnDeleteProperty.Text = "Delete Property";
		// 
		// splPropList
		// 
		splPropList.Dock = System.Windows.Forms.DockStyle.Fill;
		splPropList.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		splPropList.IsSplitterFixed = true;
		splPropList.Location = new System.Drawing.Point(0, 0);
		splPropList.Name = "splPropList";
		splPropList.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splPropList.Panel1
		// 
		splPropList.Panel1.Controls.Add(toolStrip1);
		// 
		// splPropList.Panel2
		// 
		splPropList.Panel2.Controls.Add(lbxProperties);
		splPropList.Size = new System.Drawing.Size(287, 883);
		splPropList.SplitterDistance = 25;
		splPropList.TabIndex = 2;
		// 
		// txtName
		// 
		txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Name", true));
		txtName.Location = new System.Drawing.Point(80, 27);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(468, 18);
		txtName.TabIndex = 13;
		// 
		// lblName
		// 
		lblName.AutoSize = true;
		lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
		lblName.Location = new System.Drawing.Point(17, 26);
		lblName.Name = "lblName";
		lblName.Size = new System.Drawing.Size(48, 19);
		lblName.TabIndex = 12;
		lblName.Text = "Name:";
		lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		// 
		// bindingSource
		// 
		bindingSource.DataSource = typeof(Models.PropertyModel);
		// 
		// PropertyEditCtl
		// 
		Controls.Add(splMain);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "PropertyEditCtl";
		Size = new System.Drawing.Size(862, 883);
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel2.ResumeLayout(false);
		splMain.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		splPropList.Panel1.ResumeLayout(false);
		splPropList.Panel1.PerformLayout();
		splPropList.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splPropList).EndInit();
		splPropList.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.ListBox lbxProperties;
	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripButton btnAddProperty;
	private System.Windows.Forms.ToolStripButton btnDeleteProperty;
	private System.Windows.Forms.SplitContainer splPropList;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.BindingSource bindingSource;
}
