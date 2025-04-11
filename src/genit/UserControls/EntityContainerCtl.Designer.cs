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
		nbEntity = new System.Windows.Forms.ToolStripButton();
		nbService = new System.Windows.Forms.ToolStripButton();
		toolStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// toolStrip1
		// 
		toolStrip1.AutoSize = false;
		toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblEntityName, nbEntity, nbService });
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
		// nbEntity
		// 
		nbEntity.BackColor = System.Drawing.SystemColors.Control;
		nbEntity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		nbEntity.Image = (System.Drawing.Image)resources.GetObject("nbEntity.Image");
		nbEntity.ImageTransparentColor = System.Drawing.Color.Magenta;
		nbEntity.Margin = new System.Windows.Forms.Padding(0);
		nbEntity.Name = "nbEntity";
		nbEntity.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
		nbEntity.Size = new System.Drawing.Size(68, 34);
		nbEntity.Text = "Entity";
		nbEntity.Click += nbEntity_Click;
		// 
		// nbService
		// 
		nbService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		nbService.Image = (System.Drawing.Image)resources.GetObject("nbService.Image");
		nbService.ImageTransparentColor = System.Drawing.Color.Magenta;
		nbService.Name = "nbService";
		nbService.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
		nbService.Size = new System.Drawing.Size(75, 31);
		nbService.Text = "Service";
		nbService.Click += nbService_Click;
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
	private System.Windows.Forms.ToolStripButton nbEntity;
	private System.Windows.Forms.ToolStripButton nbService;
	private System.Windows.Forms.Button button1;
}
