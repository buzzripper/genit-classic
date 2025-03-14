namespace Dyvenix.Genit.UserControls;

partial class EntityListCtl
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
		cmbEntities = new System.Windows.Forms.ComboBox();
		SuspendLayout();
		// 
		// cmbEntities
		// 
		cmbEntities.Dock = System.Windows.Forms.DockStyle.Top;
		cmbEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cmbEntities.FormattingEnabled = true;
		cmbEntities.Location = new System.Drawing.Point(0, 0);
		cmbEntities.Name = "cmbEntities";
		cmbEntities.Size = new System.Drawing.Size(515, 23);
		cmbEntities.TabIndex = 0;
		cmbEntities.SelectedIndexChanged += cmbEntities_SelectedIndexChanged;
		// 
		// EntityListCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(cmbEntities);
		Name = "EntityListCtl";
		Size = new System.Drawing.Size(515, 31);
		Load += EntityListCtl_Load;
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.ComboBox cmbEntities;
}
