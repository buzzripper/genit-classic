namespace Dyvenix.Genit.UserControls;

partial class TreeNav
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeNav));
		tvImgList = new System.Windows.Forms.ImageList(components);
		treeView1 = new System.Windows.Forms.TreeView();
		ctxMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
		mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
		mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
		ctxMenuStrip.SuspendLayout();
		SuspendLayout();
		// 
		// tvImgList
		// 
		tvImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		tvImgList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("tvImgList.ImageStream");
		tvImgList.TransparentColor = System.Drawing.Color.Transparent;
		tvImgList.Images.SetKeyName(0, "db");
		tvImgList.Images.SetKeyName(1, "ent");
		tvImgList.Images.SetKeyName(2, "prop");
		tvImgList.Images.SetKeyName(3, "enum");
		tvImgList.Images.SetKeyName(4, "assoc");
		tvImgList.Images.SetKeyName(5, "gens");
		tvImgList.Images.SetKeyName(6, "gen");
		tvImgList.Images.SetKeyName(7, "svcs");
		// 
		// treeView1
		// 
		treeView1.ContextMenuStrip = ctxMenuStrip;
		treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
		treeView1.ImageIndex = 0;
		treeView1.ImageList = tvImgList;
		treeView1.Location = new System.Drawing.Point(0, 0);
		treeView1.Name = "treeView1";
		treeView1.SelectedImageIndex = 0;
		treeView1.Size = new System.Drawing.Size(123, 391);
		treeView1.TabIndex = 0;
		treeView1.AfterSelect += treeView1_AfterSelect;
		// 
		// ctxMenuStrip
		// 
		ctxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuAdd, mnuDelete });
		ctxMenuStrip.Name = "ctxMenuStrip";
		ctxMenuStrip.Size = new System.Drawing.Size(117, 48);
		ctxMenuStrip.Opening += ctxMenuStrip_Opening;
		// 
		// mnuAdd
		// 
		mnuAdd.Name = "mnuAdd";
		mnuAdd.Size = new System.Drawing.Size(116, 22);
		mnuAdd.Text = "Add...";
		mnuAdd.Click += mnuAdd_Click;
		// 
		// mnuDelete
		// 
		mnuDelete.Name = "mnuDelete";
		mnuDelete.Size = new System.Drawing.Size(116, 22);
		mnuDelete.Text = "Delete...";
		mnuDelete.Click += mnuDelete_Click;
		// 
		// TreeNav
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(treeView1);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "TreeNav";
		Size = new System.Drawing.Size(123, 391);
		ctxMenuStrip.ResumeLayout(false);
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.ImageList tvImgList;
	private System.Windows.Forms.TreeView treeView1;
	private System.Windows.Forms.ContextMenuStrip ctxMenuStrip;
	private System.Windows.Forms.ToolStripMenuItem mnuAdd;
	private System.Windows.Forms.ToolStripMenuItem mnuDelete;
}
