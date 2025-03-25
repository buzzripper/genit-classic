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
		ckbInclSave = new System.Windows.Forms.CheckBox();
		ckbInclDelete = new System.Windows.Forms.CheckBox();
		ckbInclController = new System.Windows.Forms.CheckBox();
		ckbEnabled = new System.Windows.Forms.CheckBox();
		lkbAddlUsings = new System.Windows.Forms.LinkLabel();
		SuspendLayout();
		// 
		// ckbInclSave
		// 
		ckbInclSave.AutoSize = true;
		ckbInclSave.Location = new System.Drawing.Point(41, 50);
		ckbInclSave.Name = "ckbInclSave";
		ckbInclSave.Size = new System.Drawing.Size(157, 23);
		ckbInclSave.TabIndex = 0;
		ckbInclSave.Text = "Include Save Method";
		ckbInclSave.UseVisualStyleBackColor = true;
		// 
		// ckbInclDelete
		// 
		ckbInclDelete.AutoSize = true;
		ckbInclDelete.Location = new System.Drawing.Point(218, 50);
		ckbInclDelete.Name = "ckbInclDelete";
		ckbInclDelete.Size = new System.Drawing.Size(168, 23);
		ckbInclDelete.TabIndex = 1;
		ckbInclDelete.Text = "Include Delete Method";
		ckbInclDelete.UseVisualStyleBackColor = true;
		// 
		// ckbInclController
		// 
		ckbInclController.AutoSize = true;
		ckbInclController.Location = new System.Drawing.Point(41, 19);
		ckbInclController.Name = "ckbInclController";
		ckbInclController.Size = new System.Drawing.Size(137, 23);
		ckbInclController.TabIndex = 2;
		ckbInclController.Text = "Include Controller";
		ckbInclController.UseVisualStyleBackColor = true;
		// 
		// ckbEnabled
		// 
		ckbEnabled.AutoSize = true;
		ckbEnabled.Location = new System.Drawing.Point(218, 19);
		ckbEnabled.Name = "ckbEnabled";
		ckbEnabled.Size = new System.Drawing.Size(76, 23);
		ckbEnabled.TabIndex = 3;
		ckbEnabled.Text = "Enabled";
		ckbEnabled.UseVisualStyleBackColor = true;
		// 
		// lkbAddlUsings
		// 
		lkbAddlUsings.ActiveLinkColor = System.Drawing.Color.Azure;
		lkbAddlUsings.AutoSize = true;
		lkbAddlUsings.Cursor = System.Windows.Forms.Cursors.Hand;
		lkbAddlUsings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		lkbAddlUsings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		lkbAddlUsings.LinkColor = System.Drawing.SystemColors.MenuHighlight;
		lkbAddlUsings.Location = new System.Drawing.Point(419, 36);
		lkbAddlUsings.Name = "lkbAddlUsings";
		lkbAddlUsings.Size = new System.Drawing.Size(116, 19);
		lkbAddlUsings.TabIndex = 19;
		lkbAddlUsings.TabStop = true;
		lkbAddlUsings.Text = "Additional Usings";
		lkbAddlUsings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		lkbAddlUsings.UseMnemonic = false;
		lkbAddlUsings.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
		// 
		// SvcMethodsEditCtl
		// 
		BackColor = System.Drawing.SystemColors.ActiveBorder;
		Controls.Add(lkbAddlUsings);
		Controls.Add(ckbEnabled);
		Controls.Add(ckbInclController);
		Controls.Add(ckbInclDelete);
		Controls.Add(ckbInclSave);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "SvcMethodsEditCtl";
		Size = new System.Drawing.Size(605, 419);
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.CheckBox ckbInclSave;
	private System.Windows.Forms.CheckBox ckbInclDelete;
	private System.Windows.Forms.CheckBox ckbInclController;
	private System.Windows.Forms.CheckBox ckbEnabled;
	private System.Windows.Forms.LinkLabel lkbAddlUsings;
}
