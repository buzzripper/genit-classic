namespace Dyvenix.Genit.UserControls;

partial class DataTypeCtl
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
		cmbItems = new System.Windows.Forms.ComboBox();
		txtDatatypeName = new System.Windows.Forms.TextBox();
		textBox1 = new System.Windows.Forms.TextBox();
		SuspendLayout();
		// 
		// cmbItems
		// 
		cmbItems.Dock = System.Windows.Forms.DockStyle.Top;
		cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cmbItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		cmbItems.FormattingEnabled = true;
		cmbItems.Location = new System.Drawing.Point(0, 0);
		cmbItems.Name = "cmbItems";
		cmbItems.Size = new System.Drawing.Size(298, 23);
		cmbItems.TabIndex = 0;
		cmbItems.SelectedIndexChanged += cmbItems_SelectedIndexChanged;
		cmbItems.Layout += cmbItems_Layout;
		// 
		// txtDatatypeName
		// 
		txtDatatypeName.BackColor = System.Drawing.SystemColors.Window;
		txtDatatypeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtDatatypeName.Dock = System.Windows.Forms.DockStyle.Top;
		txtDatatypeName.ForeColor = System.Drawing.SystemColors.WindowText;
		txtDatatypeName.Location = new System.Drawing.Point(0, 23);
		txtDatatypeName.Name = "txtDatatypeName";
		txtDatatypeName.ReadOnly = true;
		txtDatatypeName.Size = new System.Drawing.Size(298, 16);
		txtDatatypeName.TabIndex = 1;
		txtDatatypeName.Visible = false;
		// 
		// textBox1
		// 
		textBox1.Location = new System.Drawing.Point(77, 58);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(100, 23);
		textBox1.TabIndex = 2;
		// 
		// DataTypeCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(textBox1);
		Controls.Add(txtDatatypeName);
		Controls.Add(cmbItems);
		Name = "DataTypeCtl";
		Size = new System.Drawing.Size(298, 107);
		Load += DataTypeCtl_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.ComboBox cmbItems;
	private System.Windows.Forms.TextBox txtDatatypeName;
	private System.Windows.Forms.TextBox textBox1;
}
