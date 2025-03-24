namespace Dyvenix.Genit.UserControls;

partial class EntityContainerCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityContainerCtl));
		toolStrip1 = new System.Windows.Forms.ToolStrip();
		lblEntityName = new System.Windows.Forms.ToolStripLabel();
		nbMain = new System.Windows.Forms.ToolStripButton();
		nbSvcMethods = new System.Windows.Forms.ToolStripButton();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// toolStrip1
		// 
		toolStrip1.AutoSize = false;
		toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblEntityName, nbMain, nbSvcMethods });
		toolStrip1.Location = new System.Drawing.Point(0, 0);
		toolStrip1.Name = "toolStrip1";
		toolStrip1.Size = new System.Drawing.Size(832, 34);
		toolStrip1.TabIndex = 0;
		toolStrip1.Text = "toolStrip1";
		// 
		// lblEntityName
		// 
		lblEntityName.AutoSize = false;
		lblEntityName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblEntityName.Name = "lblEntityName";
		lblEntityName.Size = new System.Drawing.Size(300, 27);
		lblEntityName.Text = "Entity";
		lblEntityName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		// 
		// nbMain
		// 
		nbMain.BackColor = System.Drawing.SystemColors.Control;
		nbMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		nbMain.Image = (System.Drawing.Image)resources.GetObject("nbMain.Image");
		nbMain.ImageTransparentColor = System.Drawing.Color.Magenta;
		nbMain.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
		nbMain.Name = "nbMain";
		nbMain.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
		nbMain.Size = new System.Drawing.Size(69, 31);
		nbMain.Text = "Main";
		nbMain.Click += nbMain_Click;
		// 
		// nbSvcMethods
		// 
		nbSvcMethods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		nbSvcMethods.Image = (System.Drawing.Image)resources.GetObject("nbSvcMethods.Image");
		nbSvcMethods.ImageTransparentColor = System.Drawing.Color.Magenta;
		nbSvcMethods.Name = "nbSvcMethods";
		nbSvcMethods.Size = new System.Drawing.Size(114, 31);
		nbSvcMethods.Text = "Service Methods";
		nbSvcMethods.Click += nbSvcMethods_Click;
		// 
		// EntityContainerCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(toolStrip1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "EntityContainerCtl";
		Size = new System.Drawing.Size(832, 678);
		toolStrip1.ResumeLayout(false);
		toolStrip1.PerformLayout();
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.SplitContainer splitContainer1;
	private System.Windows.Forms.ToolStrip toolStrip1;
	private System.Windows.Forms.ToolStripLabel lblEntityName;
	private System.Windows.Forms.ToolStripButton nbMain;
	private System.Windows.Forms.ToolStripButton nbSvcMethods;
	private System.Windows.Forms.Button button1;
}
