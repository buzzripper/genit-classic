namespace Dyvenix.Genit.UserControls;

partial class MultiPageCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiPageCtl));
		toolStrip = new System.Windows.Forms.ToolStrip();
		tbTitle = new System.Windows.Forms.ToolStripLabel();
		btnCloseItem = new System.Windows.Forms.ToolStripButton();
		toolStrip.SuspendLayout();
		SuspendLayout();
		// 
		// toolStrip
		// 
		toolStrip.AutoSize = false;
		toolStrip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tbTitle, btnCloseItem });
		toolStrip.Location = new System.Drawing.Point(0, 0);
		toolStrip.Name = "toolStrip";
		toolStrip.Size = new System.Drawing.Size(524, 30);
		toolStrip.TabIndex = 1;
		toolStrip.Text = "toolStrip1";
		// 
		// tbTitle
		// 
		tbTitle.Font = new System.Drawing.Font("Segoe UI", 14F);
		tbTitle.Name = "tbTitle";
		tbTitle.Size = new System.Drawing.Size(0, 27);
		tbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// btnCloseItem
		// 
		btnCloseItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		btnCloseItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		btnCloseItem.Image = (System.Drawing.Image)resources.GetObject("btnCloseItem.Image");
		btnCloseItem.ImageTransparentColor = System.Drawing.Color.Magenta;
		btnCloseItem.Name = "btnCloseItem";
		btnCloseItem.Size = new System.Drawing.Size(23, 27);
		btnCloseItem.Text = "toolStripButton1";
		btnCloseItem.Click += btnCloseItem_Click;
		// 
		// MultiPageCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(toolStrip);
		Name = "MultiPageCtl";
		Size = new System.Drawing.Size(524, 338);
		Load += MultiPageCtl_Load;
		SizeChanged += MultiButton_SizeChanged;
		toolStrip.ResumeLayout(false);
		toolStrip.PerformLayout();
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.ToolStrip toolStrip;
	private System.Windows.Forms.ToolStripLabel tbTitle;
	private System.Windows.Forms.ToolStripButton btnCloseItem;
}
