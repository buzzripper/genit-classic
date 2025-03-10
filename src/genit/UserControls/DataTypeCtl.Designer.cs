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
		cmbItems.Size = new System.Drawing.Size(221, 23);
		cmbItems.TabIndex = 0;
		cmbItems.SelectedIndexChanged += cmbItems_SelectedIndexChanged;
		cmbItems.Layout += cmbItems_Layout;
		// 
		// DataTypeCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(cmbItems);
		Name = "DataTypeCtl";
		Size = new System.Drawing.Size(221, 33);
		Load += DataTypeCtl_Load;
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.ComboBox cmbItems;
}
