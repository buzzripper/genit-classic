namespace Dyvenix.Genit.UserControls;

partial class NavPropGridCtl
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
		splCardinality = new System.Windows.Forms.SplitContainer();
		lblCardinality = new System.Windows.Forms.Label();
		splRelPropName = new System.Windows.Forms.SplitContainer();
		lblRelatedPropertyName = new System.Windows.Forms.Label();
		lblPrimaryPropertyName = new System.Windows.Forms.Label();
		splMain = new System.Windows.Forms.SplitContainer();
		((System.ComponentModel.ISupportInitialize)splCardinality).BeginInit();
		splCardinality.Panel1.SuspendLayout();
		splCardinality.Panel2.SuspendLayout();
		splCardinality.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splRelPropName).BeginInit();
		splRelPropName.Panel1.SuspendLayout();
		splRelPropName.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		SuspendLayout();
		// 
		// splCardinality
		// 
		splCardinality.Dock = System.Windows.Forms.DockStyle.Fill;
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
		splCardinality.Size = new System.Drawing.Size(719, 30);
		splCardinality.SplitterDistance = 150;
		splCardinality.TabIndex = 0;
		splCardinality.SplitterMoved += splCardinality_SplitterMoved;
		// 
		// lblCardinality
		// 
		lblCardinality.AutoSize = true;
		lblCardinality.Location = new System.Drawing.Point(0, 0);
		lblCardinality.Name = "lblCardinality";
		lblCardinality.Size = new System.Drawing.Size(74, 19);
		lblCardinality.TabIndex = 0;
		lblCardinality.Text = "Cardinality";
		lblCardinality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// splRelPropName
		// 
		splRelPropName.Dock = System.Windows.Forms.DockStyle.Fill;
		splRelPropName.Location = new System.Drawing.Point(0, 0);
		splRelPropName.Name = "splRelPropName";
		// 
		// splRelPropName.Panel1
		// 
		splRelPropName.Panel1.Controls.Add(lblRelatedPropertyName);
		splRelPropName.Size = new System.Drawing.Size(565, 30);
		splRelPropName.SplitterDistance = 200;
		splRelPropName.TabIndex = 0;
		splRelPropName.SplitterMoved += splRelPropName_SplitterMoved;
		// 
		// lblRelatedPropertyName
		// 
		lblRelatedPropertyName.AutoSize = true;
		lblRelatedPropertyName.Location = new System.Drawing.Point(0, 0);
		lblRelatedPropertyName.Name = "lblRelatedPropertyName";
		lblRelatedPropertyName.Size = new System.Drawing.Size(151, 19);
		lblRelatedPropertyName.TabIndex = 0;
		lblRelatedPropertyName.Text = "Related Property Name";
		lblRelatedPropertyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// lblPrimaryPropertyName
		// 
		lblPrimaryPropertyName.AutoSize = true;
		lblPrimaryPropertyName.Location = new System.Drawing.Point(0, 0);
		lblPrimaryPropertyName.Name = "lblPrimaryPropertyName";
		lblPrimaryPropertyName.Size = new System.Drawing.Size(153, 19);
		lblPrimaryPropertyName.TabIndex = 0;
		lblPrimaryPropertyName.Text = "Primary Property Name";
		lblPrimaryPropertyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// splMain
		// 
		splMain.BackColor = System.Drawing.SystemColors.ScrollBar;
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
		splMain.Size = new System.Drawing.Size(948, 30);
		splMain.SplitterDistance = 225;
		splMain.TabIndex = 0;
		splMain.SplitterMoved += splMain_SplitterMoved;
		// 
		// NavPropGridCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(splMain);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "NavPropGridCtl";
		Size = new System.Drawing.Size(948, 227);
		Load += NavPropGridCtl_Load;
		splCardinality.Panel1.ResumeLayout(false);
		splCardinality.Panel1.PerformLayout();
		splCardinality.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splCardinality).EndInit();
		splCardinality.ResumeLayout(false);
		splRelPropName.Panel1.ResumeLayout(false);
		splRelPropName.Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)splRelPropName).EndInit();
		splRelPropName.ResumeLayout(false);
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel1.PerformLayout();
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.SplitContainer splCardinality;
	private System.Windows.Forms.Label lblCardinality;
	private System.Windows.Forms.SplitContainer splRelPropName;
	private System.Windows.Forms.Label lblRelatedPropertyName;
	private System.Windows.Forms.Label lblPrimaryPropertyName;
	private System.Windows.Forms.SplitContainer splMain;
}
