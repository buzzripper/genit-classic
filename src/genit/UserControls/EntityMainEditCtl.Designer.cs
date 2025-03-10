namespace Dyvenix.Genit.UserControls;

partial class EntityMainEditCtl
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
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		textBox1 = new System.Windows.Forms.TextBox();
		bindingSource = new System.Windows.Forms.BindingSource(components);
		textBox2 = new System.Windows.Forms.TextBox();
		textBox3 = new System.Windows.Forms.TextBox();
		textBox4 = new System.Windows.Forms.TextBox();
		checkBox1 = new System.Windows.Forms.CheckBox();
		sleUsings = new StringListEditor();
		label5 = new System.Windows.Forms.Label();
		sleAttrs = new StringListEditor();
		label6 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(75, 25);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(48, 19);
		label1.TabIndex = 0;
		label1.Text = "Name:";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(64, 62);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(59, 19);
		label2.TabIndex = 1;
		label2.Text = "Schema:";
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(41, 99);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(82, 19);
		label3.TabIndex = 2;
		label3.Text = "Table Name:";
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(41, 136);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(82, 19);
		label4.TabIndex = 3;
		label4.Text = "Namespace:";
		// 
		// textBox1
		// 
		textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Name", true));
		textBox1.Location = new System.Drawing.Point(129, 27);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(366, 18);
		textBox1.TabIndex = 0;
		// 
		// bindingSource
		// 
		bindingSource.DataSource = typeof(Models.EntityModel);
		// 
		// textBox2
		// 
		textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Schema", true));
		textBox2.Location = new System.Drawing.Point(129, 64);
		textBox2.Name = "textBox2";
		textBox2.Size = new System.Drawing.Size(366, 18);
		textBox2.TabIndex = 1;
		// 
		// textBox3
		// 
		textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
		textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "TableName", true));
		textBox3.Location = new System.Drawing.Point(129, 101);
		textBox3.Name = "textBox3";
		textBox3.Size = new System.Drawing.Size(366, 18);
		textBox3.TabIndex = 2;
		// 
		// textBox4
		// 
		textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
		textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "Namespace", true));
		textBox4.Location = new System.Drawing.Point(129, 138);
		textBox4.Name = "textBox4";
		textBox4.Size = new System.Drawing.Size(366, 18);
		textBox4.TabIndex = 3;
		// 
		// checkBox1
		// 
		checkBox1.AutoSize = true;
		checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "Enabled", true));
		checkBox1.Location = new System.Drawing.Point(254, 173);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(76, 23);
		checkBox1.TabIndex = 4;
		checkBox1.Text = "Enabled";
		checkBox1.UseVisualStyleBackColor = true;
		// 
		// sleUsings
		// 
		sleUsings.BackColor = System.Drawing.SystemColors.Control;
		sleUsings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		sleUsings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		sleUsings.Location = new System.Drawing.Point(129, 234);
		sleUsings.Name = "sleUsings";
		sleUsings.Size = new System.Drawing.Size(366, 92);
		sleUsings.TabIndex = 5;
		sleUsings.ToolbarDockStyle = System.Windows.Forms.DockStyle.Right;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(129, 212);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(116, 19);
		label5.TabIndex = 10;
		label5.Text = "Additional Usings";
		// 
		// sleAttrs
		// 
		sleAttrs.BackColor = System.Drawing.SystemColors.Control;
		sleAttrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		sleAttrs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		sleAttrs.Location = new System.Drawing.Point(129, 366);
		sleAttrs.Name = "sleAttrs";
		sleAttrs.Size = new System.Drawing.Size(366, 82);
		sleAttrs.TabIndex = 6;
		sleAttrs.ToolbarDockStyle = System.Windows.Forms.DockStyle.Right;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(131, 344);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(105, 19);
		label6.TabIndex = 12;
		label6.Text = "Class Attributes";
		// 
		// EntityMainEditCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(label6);
		Controls.Add(sleAttrs);
		Controls.Add(label5);
		Controls.Add(sleUsings);
		Controls.Add(checkBox1);
		Controls.Add(textBox4);
		Controls.Add(textBox3);
		Controls.Add(textBox2);
		Controls.Add(textBox1);
		Controls.Add(label4);
		Controls.Add(label3);
		Controls.Add(label2);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "EntityMainEditCtl";
		Size = new System.Drawing.Size(560, 477);
		((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.TextBox textBox2;
	private System.Windows.Forms.TextBox textBox3;
	private System.Windows.Forms.TextBox textBox4;
	private System.Windows.Forms.BindingSource bindingSource;
	private System.Windows.Forms.CheckBox checkBox1;
	private StringListEditor sleUsings;
	private System.Windows.Forms.Label label5;
	private StringListEditor sleAttrs;
	private System.Windows.Forms.Label label6;
}
