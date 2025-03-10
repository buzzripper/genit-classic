namespace Dyvenix.Genit.UserControls;

partial class GenEditCtrl
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
		label1 = new System.Windows.Forms.Label();
		textBox1 = new System.Windows.Forms.TextBox();
		textBox2 = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(142, 113);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(34, 15);
		label1.TabIndex = 0;
		label1.Text = "Froo:";
		// 
		// textBox1
		// 
		textBox1.Location = new System.Drawing.Point(178, 111);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(322, 23);
		textBox1.TabIndex = 1;
		// 
		// textBox2
		// 
		textBox2.Location = new System.Drawing.Point(178, 140);
		textBox2.Name = "textBox2";
		textBox2.Size = new System.Drawing.Size(322, 23);
		textBox2.TabIndex = 3;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(142, 142);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(34, 15);
		label2.TabIndex = 2;
		label2.Text = "Froo:";
		// 
		// GenEditCtrl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(textBox2);
		Controls.Add(label2);
		Controls.Add(textBox1);
		Controls.Add(label1);
		Name = "GenEditCtrl";
		Size = new System.Drawing.Size(719, 488);
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.TextBox textBox2;
	private System.Windows.Forms.Label label2;
}
