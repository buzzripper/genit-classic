namespace Dyvenix.Genit.UserControls;

partial class NavPropGridRowCtl
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavPropGridRowCtl));
		splMain = new System.Windows.Forms.SplitContainer();
		lblPrimaryPropertyName = new System.Windows.Forms.Label();
		splCardinality = new System.Windows.Forms.SplitContainer();
		lblCardinality = new System.Windows.Forms.Label();
		splRelPropName = new System.Windows.Forms.SplitContainer();
		lblRelatedPropertyName = new System.Windows.Forms.Label();
		picDelete = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splCardinality).BeginInit();
		splCardinality.Panel1.SuspendLayout();
		splCardinality.Panel2.SuspendLayout();
		splCardinality.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splRelPropName).BeginInit();
		splRelPropName.Panel1.SuspendLayout();
		splRelPropName.Panel2.SuspendLayout();
		splRelPropName.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)picDelete).BeginInit();
		SuspendLayout();
		// 
		// splMain
		// 
		splMain.Dock = System.Windows.Forms.DockStyle.Top;
		splMain.Location = new System.Drawing.Point(0, 0);
		splMain.Name = "splMain";
		// 
		// splMain.Panel1
		// 
		splMain.Panel1.Controls.Add(lblPrimaryPropertyName);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.Controls.Add(splCardinality);
		splMain.Size = new System.Drawing.Size(762, 36);
		splMain.SplitterDistance = 200;
		splMain.TabIndex = 1;
		// 
		// lblPrimaryPropertyName
		// 
		lblPrimaryPropertyName.AutoSize = true;
		lblPrimaryPropertyName.Location = new System.Drawing.Point(0, 2);
		lblPrimaryPropertyName.Name = "lblPrimaryPropertyName";
		lblPrimaryPropertyName.Size = new System.Drawing.Size(159, 19);
		lblPrimaryPropertyName.TabIndex = 0;
		lblPrimaryPropertyName.Text = "lblPrimaryPropertyName";
		lblPrimaryPropertyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// splCardinality
		// 
		splCardinality.Dock = System.Windows.Forms.DockStyle.Top;
		splCardinality.Location = new System.Drawing.Point(0, 0);
		splCardinality.Name = "splCardinality";
		// 
		// splCardinality.Panel1
		// 
		splCardinality.Panel1.Controls.Add(lblCardinality);
		// 
		// splCardinality.Panel2
		// 
		splCardinality.Panel2.Controls.Add(splRelPropName);
		splCardinality.Size = new System.Drawing.Size(558, 40);
		splCardinality.SplitterDistance = 150;
		splCardinality.TabIndex = 0;
		// 
		// lblCardinality
		// 
		lblCardinality.AutoSize = true;
		lblCardinality.Location = new System.Drawing.Point(0, 2);
		lblCardinality.Name = "lblCardinality";
		lblCardinality.Size = new System.Drawing.Size(88, 19);
		lblCardinality.TabIndex = 0;
		lblCardinality.Text = "lblCardinality";
		lblCardinality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// splRelPropName
		// 
		splRelPropName.Dock = System.Windows.Forms.DockStyle.Top;
		splRelPropName.Location = new System.Drawing.Point(0, 0);
		splRelPropName.Name = "splRelPropName";
		// 
		// splRelPropName.Panel1
		// 
		splRelPropName.Panel1.Controls.Add(lblRelatedPropertyName);
		// 
		// splRelPropName.Panel2
		// 
		splRelPropName.Panel2.Controls.Add(picDelete);
		splRelPropName.Size = new System.Drawing.Size(404, 40);
		splRelPropName.SplitterDistance = 200;
		splRelPropName.TabIndex = 0;
		// 
		// lblRelatedPropertyName
		// 
		lblRelatedPropertyName.AutoSize = true;
		lblRelatedPropertyName.Location = new System.Drawing.Point(0, 2);
		lblRelatedPropertyName.Name = "lblRelatedPropertyName";
		lblRelatedPropertyName.Size = new System.Drawing.Size(157, 19);
		lblRelatedPropertyName.TabIndex = 0;
		lblRelatedPropertyName.Text = "lblRelatedPropertyName";
		lblRelatedPropertyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// picDelete
		// 
		picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
		picDelete.Image = (System.Drawing.Image)resources.GetObject("picDelete.Image");
		picDelete.Location = new System.Drawing.Point(44, 5);
		picDelete.Name = "picDelete";
		picDelete.Size = new System.Drawing.Size(22, 25);
		picDelete.TabIndex = 1;
		picDelete.TabStop = false;
		picDelete.Click += picDelete_Click;
		// 
		// NavPropGridRowCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.Control;
		Controls.Add(splMain);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "NavPropGridRowCtl";
		Size = new System.Drawing.Size(762, 222);
		Load += NavPropGridRowCtrl_Load;
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel1.PerformLayout();
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		splCardinality.Panel1.ResumeLayout(false);
		splCardinality.Panel1.PerformLayout();
		splCardinality.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splCardinality).EndInit();
		splCardinality.ResumeLayout(false);
		splRelPropName.Panel1.ResumeLayout(false);
		splRelPropName.Panel1.PerformLayout();
		splRelPropName.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splRelPropName).EndInit();
		splRelPropName.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)picDelete).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.TextBox txtPrimaryName;
	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.Label lblPrimaryPropertyName;
	private System.Windows.Forms.SplitContainer splCardinality;
	private System.Windows.Forms.Label lblCardinality;
	private System.Windows.Forms.SplitContainer splRelPropName;
	private System.Windows.Forms.Label lblRelatedPropertyName;
	private System.Windows.Forms.PictureBox picDelete;
}
