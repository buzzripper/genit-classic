namespace Dyvenix.Genit;

partial class StringListForm
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

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		slEditor = new Dyvenix.Genit.UserControls.StringListEditor();
		btnOk = new System.Windows.Forms.Button();
		SuspendLayout();
		// 
		// slEditor
		// 
		slEditor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		slEditor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		slEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		slEditor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		slEditor.Location = new System.Drawing.Point(0, 2);
		slEditor.Name = "slEditor";
		slEditor.Size = new System.Drawing.Size(276, 183);
		slEditor.TabIndex = 0;
		// 
		// btnOk
		// 
		btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		btnOk.BackColor = System.Drawing.SystemColors.HotTrack;
		btnOk.ForeColor = System.Drawing.SystemColors.Control;
		btnOk.Location = new System.Drawing.Point(96, 193);
		btnOk.Name = "btnOk";
		btnOk.Size = new System.Drawing.Size(75, 32);
		btnOk.TabIndex = 6;
		btnOk.Text = "OK";
		btnOk.UseVisualStyleBackColor = false;
		btnOk.Click += btnOk_Click;
		// 
		// StringListForm
		// 
		AcceptButton = btnOk;
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		ClientSize = new System.Drawing.Size(276, 235);
		ControlBox = false;
		Controls.Add(btnOk);
		Controls.Add(slEditor);
		Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		KeyPreview = true;
		MaximizeBox = false;
		MdiChildrenMinimizedAnchorBottom = false;
		MinimizeBox = false;
		Name = "StringListForm";
		StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "StringListForm";
		Load += StringListForm_Load;
		ResumeLayout(false);
	}

	#endregion

	private UserControls.StringListEditor slEditor;
	private System.Windows.Forms.Button btnOk;
}