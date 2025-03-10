namespace Dyvenix.Genit.UserControls;

partial class NavPropEditCtl
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
		bindingSrc = new System.Windows.Forms.BindingSource(components);
		label1 = new System.Windows.Forms.Label();
		textBox1 = new System.Windows.Forms.TextBox();
		textBox2 = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)bindingSrc).BeginInit();
		SuspendLayout();
		// 
		// bindingSrc
		// 
		bindingSrc.DataSource = typeof(Models.AssocModel);
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(18, 15);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(156, 19);
		label1.TabIndex = 0;
		label1.Text = "Primary Property Name:";
		// 
		// textBox1
		// 
		textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSrc, "PrimaryPropertyName", true));
		textBox1.Location = new System.Drawing.Point(176, 16);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(374, 18);
		textBox1.TabIndex = 1;
		// 
		// textBox2
		// 
		textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSrc, "PrimaryPropertyName", true));
		textBox2.Location = new System.Drawing.Point(176, 49);
		textBox2.Name = "textBox2";
		textBox2.Size = new System.Drawing.Size(374, 18);
		textBox2.TabIndex = 3;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(20, 47);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(154, 19);
		label2.TabIndex = 2;
		label2.Text = "Related Property Name:";
		// 
		// NavPropEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(textBox2);
		Controls.Add(textBox1);
		Controls.Add(label2);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "NavPropEditCtl";
		Size = new System.Drawing.Size(569, 392);
		((System.ComponentModel.ISupportInitialize)bindingSrc).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.BindingSource bindingSrc;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.TextBox textBox2;
	private System.Windows.Forms.Label label2;
}
