namespace Dyvenix.Genit;

partial class AssocEditForm
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
		label1 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.TextBox();
		txtFKPropName = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		cmbCardinality = new System.Windows.Forms.ComboBox();
		btnOk = new System.Windows.Forms.Button();
		btnCancel = new System.Windows.Forms.Button();
		entityListCtl = new Dyvenix.Genit.UserControls.EntityListCtl();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(96, 28);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(48, 19);
		label1.TabIndex = 0;
		label1.Text = "Name:";
		// 
		// txtName
		// 
		txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtName.Location = new System.Drawing.Point(151, 25);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(252, 25);
		txtName.TabIndex = 0;
		// 
		// txtFKPropName
		// 
		txtFKPropName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txtFKPropName.Location = new System.Drawing.Point(151, 131);
		txtFKPropName.Name = "txtFKPropName";
		txtFKPropName.Size = new System.Drawing.Size(252, 25);
		txtFKPropName.TabIndex = 3;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(20, 134);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(124, 19);
		label2.TabIndex = 2;
		label2.Text = "FK Property Name:";
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(48, 97);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(96, 19);
		label3.TabIndex = 4;
		label3.Text = "Related Entity:";
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(67, 62);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(77, 19);
		label4.TabIndex = 6;
		label4.Text = "Cardinality:";
		// 
		// cmbCardinality
		// 
		cmbCardinality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cmbCardinality.FormattingEnabled = true;
		cmbCardinality.Location = new System.Drawing.Point(151, 59);
		cmbCardinality.Name = "cmbCardinality";
		cmbCardinality.Size = new System.Drawing.Size(144, 25);
		cmbCardinality.TabIndex = 1;
		// 
		// btnOk
		// 
		btnOk.BackColor = System.Drawing.SystemColors.HotTrack;
		btnOk.ForeColor = System.Drawing.SystemColors.Control;
		btnOk.Location = new System.Drawing.Point(126, 176);
		btnOk.Name = "btnOk";
		btnOk.Size = new System.Drawing.Size(75, 32);
		btnOk.TabIndex = 4;
		btnOk.Text = "OK";
		btnOk.UseVisualStyleBackColor = false;
		btnOk.Click += btnOk_Click;
		// 
		// btnCancel
		// 
		btnCancel.BackColor = System.Drawing.SystemColors.HotTrack;
		btnCancel.ForeColor = System.Drawing.SystemColors.Control;
		btnCancel.Location = new System.Drawing.Point(216, 176);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(75, 32);
		btnCancel.TabIndex = 5;
		btnCancel.Text = "Cancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		// 
		// entityListCtl
		// 
		entityListCtl.Location = new System.Drawing.Point(151, 94);
		entityListCtl.Name = "entityListCtl";
		entityListCtl.Size = new System.Drawing.Size(252, 23);
		entityListCtl.TabIndex = 2;
		// 
		// AssocEditForm
		// 
		AcceptButton = btnOk;
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		CancelButton = btnCancel;
		ClientSize = new System.Drawing.Size(415, 220);
		ControlBox = false;
		Controls.Add(entityListCtl);
		Controls.Add(btnCancel);
		Controls.Add(btnOk);
		Controls.Add(cmbCardinality);
		Controls.Add(label4);
		Controls.Add(label3);
		Controls.Add(txtFKPropName);
		Controls.Add(label2);
		Controls.Add(txtName);
		Controls.Add(label1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "AssocEditForm";
		StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Association";
		Load += AssocEditForm_Load;
		Shown += AssocEditForm_Shown;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.TextBox txtFKPropName;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.ComboBox cmbCardinality;
	private System.Windows.Forms.Button btnOk;
	private System.Windows.Forms.Button btnCancel;
	private UserControls.EntityListCtl entityListCtl;
}