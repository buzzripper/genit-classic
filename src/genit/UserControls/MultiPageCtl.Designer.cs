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
		toolStrip = new System.Windows.Forms.ToolStrip();
		tbTitle = new System.Windows.Forms.ToolStripLabel();
		toolStrip.SuspendLayout();
		SuspendLayout();
		// 
		// toolStrip
		// 
		toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
		toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tbTitle });
		toolStrip.Location = new System.Drawing.Point(0, 0);
		toolStrip.Name = "toolStrip";
		toolStrip.Size = new System.Drawing.Size(524, 25);
		toolStrip.TabIndex = 0;
		toolStrip.Text = "toolStrip1";
		// 
		// tbTitle
		// 
		tbTitle.Font = new System.Drawing.Font("Segoe UI", 14F);
		tbTitle.Name = "tbTitle";
		tbTitle.Size = new System.Drawing.Size(0, 22);
		tbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// MultiPageCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(toolStrip);
		Name = "MultiPageCtl";
		Size = new System.Drawing.Size(524, 338);
		SizeChanged += MultiButton_SizeChanged;
		toolStrip.ResumeLayout(false);
		toolStrip.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.ToolStrip toolStrip;
	private System.Windows.Forms.ToolStripLabel tbTitle;
}
