namespace Dyvenix.Genit.UserControls;

partial class PropGridCtl
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
		splMain = new System.Windows.Forms.SplitContainer();
		label1 = new System.Windows.Forms.Label();
		splDataType = new System.Windows.Forms.SplitContainer();
		label2 = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
		splMain.Panel1.SuspendLayout();
		splMain.Panel2.SuspendLayout();
		splMain.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splDataType).BeginInit();
		splDataType.Panel1.SuspendLayout();
		splDataType.Panel2.SuspendLayout();
		splDataType.SuspendLayout();
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
		splMain.Panel1.Controls.Add(label1);
		// 
		// splMain.Panel2
		// 
		splMain.Panel2.Controls.Add(splDataType);
		splMain.Size = new System.Drawing.Size(1090, 20);
		splMain.SplitterDistance = 197;
		splMain.SplitterWidth = 3;
		splMain.TabIndex = 1;
		splMain.SplitterMoved += splMain_SplitterMoved;
		// 
		// label1
		// 
		label1.BackColor = System.Drawing.SystemColors.ScrollBar;
		label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label1.Dock = System.Windows.Forms.DockStyle.Top;
		label1.Location = new System.Drawing.Point(0, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(197, 20);
		label1.TabIndex = 0;
		label1.Text = "Name";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// splDataType
		// 
		splDataType.Dock = System.Windows.Forms.DockStyle.Fill;
		splDataType.Location = new System.Drawing.Point(0, 0);
		splDataType.Name = "splDataType";
		// 
		// splDataType.Panel1
		// 
		splDataType.Panel1.Controls.Add(label2);
		// 
		// splDataType.Panel2
		// 
		splDataType.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
		splDataType.Panel2.Controls.Add(label8);
		splDataType.Panel2.Controls.Add(label9);
		splDataType.Panel2.Controls.Add(label6);
		splDataType.Panel2.Controls.Add(label7);
		splDataType.Panel2.Controls.Add(label5);
		splDataType.Panel2.Controls.Add(label4);
		splDataType.Panel2.Controls.Add(label3);
		splDataType.Size = new System.Drawing.Size(890, 20);
		splDataType.SplitterDistance = 175;
		splDataType.SplitterWidth = 3;
		splDataType.TabIndex = 0;
		splDataType.SplitterMoved += splDataType_SplitterMoved;
		// 
		// label2
		// 
		label2.BackColor = System.Drawing.SystemColors.ScrollBar;
		label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label2.Dock = System.Windows.Forms.DockStyle.Top;
		label2.Location = new System.Drawing.Point(0, 0);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(175, 20);
		label2.TabIndex = 1;
		label2.Text = "Data Type";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// label8
		// 
		label8.BackColor = System.Drawing.SystemColors.ScrollBar;
		label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label8.Location = new System.Drawing.Point(329, 0);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(53, 20);
		label8.TabIndex = 8;
		label8.Text = "C Idx";
		label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// 
		// label9
		// 
		label9.BackColor = System.Drawing.SystemColors.ScrollBar;
		label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label9.Location = new System.Drawing.Point(277, 0);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(53, 20);
		label9.TabIndex = 7;
		label9.Text = "U Idx";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// 
		// label6
		// 
		label6.BackColor = System.Drawing.SystemColors.ScrollBar;
		label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label6.Location = new System.Drawing.Point(225, 0);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(53, 20);
		label6.TabIndex = 6;
		label6.Text = "Idx";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// 
		// label7
		// 
		label7.BackColor = System.Drawing.SystemColors.ScrollBar;
		label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label7.Location = new System.Drawing.Point(173, 0);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(53, 20);
		label7.TabIndex = 5;
		label7.Text = "Null";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// 
		// label5
		// 
		label5.BackColor = System.Drawing.SystemColors.ScrollBar;
		label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label5.Location = new System.Drawing.Point(121, 0);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(53, 20);
		label5.TabIndex = 4;
		label5.Text = "Idnt";
		label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// 
		// label4
		// 
		label4.BackColor = System.Drawing.SystemColors.ScrollBar;
		label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label4.Location = new System.Drawing.Point(69, 0);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(53, 20);
		label4.TabIndex = 3;
		label4.Text = "Pri Key";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// 
		// label3
		// 
		label3.BackColor = System.Drawing.SystemColors.ScrollBar;
		label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label3.Location = new System.Drawing.Point(2, 0);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(68, 20);
		label3.TabIndex = 2;
		label3.Text = "Max Len";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// PropGridCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		AutoScroll = true;
		Controls.Add(splMain);
		Name = "PropGridCtl";
		Size = new System.Drawing.Size(1090, 203);
		Load += PropGridCtl_Load;
		splMain.Panel1.ResumeLayout(false);
		splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splMain).EndInit();
		splMain.ResumeLayout(false);
		splDataType.Panel1.ResumeLayout(false);
		splDataType.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splDataType).EndInit();
		splDataType.ResumeLayout(false);
		ResumeLayout(false);
	}

	#endregion
	private System.Windows.Forms.SplitContainer splMain;
	private System.Windows.Forms.SplitContainer splDataType;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.Label label9;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Panel panel1;
}
