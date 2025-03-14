namespace Dyvenix.Genit.UserControls;

partial class SvcMethodsEditCtl
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
		textBox1 = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		SuspendLayout();
		// 
		// textBox1
		// 
		textBox1.Location = new System.Drawing.Point(324, 144);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(100, 23);
		textBox1.TabIndex = 0;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(129, 153);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(38, 15);
		label1.TabIndex = 1;
		label1.Text = "label1";
		// 
		// SvcMethodsEditCtl
		// 
		Controls.Add(label1);
		Controls.Add(textBox1);
		Name = "SvcMethodsEditCtl";
		Size = new System.Drawing.Size(605, 419);
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.Label label1;
}
