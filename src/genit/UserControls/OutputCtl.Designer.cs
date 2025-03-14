namespace Dyvenix.Genit.UserControls;

partial class OutputCtl
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
		grdItems = new System.Windows.Forms.DataGridView();
		colErrLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
		colMessages = new System.Windows.Forms.DataGridViewTextBoxColumn();
		((System.ComponentModel.ISupportInitialize)grdItems).BeginInit();
		SuspendLayout();
		// 
		// grdItems
		// 
		grdItems.AllowUserToAddRows = false;
		grdItems.AllowUserToResizeColumns = false;
		grdItems.AllowUserToResizeRows = false;
		grdItems.BackgroundColor = System.Drawing.SystemColors.Control;
		grdItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
		grdItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		grdItems.ColumnHeadersVisible = false;
		grdItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colErrLevel, colMessages });
		grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
		grdItems.Location = new System.Drawing.Point(0, 0);
		grdItems.MultiSelect = false;
		grdItems.Name = "grdItems";
		grdItems.ReadOnly = true;
		grdItems.RowHeadersVisible = false;
		grdItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		grdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		grdItems.ShowEditingIcon = false;
		grdItems.Size = new System.Drawing.Size(729, 257);
		grdItems.TabIndex = 3;
		grdItems.CellDoubleClick += grdItems_CellDoubleClick;
		// 
		// colErrLevel
		// 
		colErrLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		colErrLevel.FillWeight = 10F;
		colErrLevel.HeaderText = "ErrLevel";
		colErrLevel.MinimumWidth = 75;
		colErrLevel.Name = "colErrLevel";
		colErrLevel.ReadOnly = true;
		colErrLevel.Width = 75;
		// 
		// colMessages
		// 
		colMessages.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		colMessages.HeaderText = "Messages";
		colMessages.Name = "colMessages";
		colMessages.ReadOnly = true;
		// 
		// OutputCtl
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		Controls.Add(grdItems);
		Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Name = "OutputCtl";
		Size = new System.Drawing.Size(729, 257);
		((System.ComponentModel.ISupportInitialize)grdItems).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private System.Windows.Forms.DataGridView grdItems;
	private System.Windows.Forms.DataGridViewTextBoxColumn colErrLevel;
	private System.Windows.Forms.DataGridViewTextBoxColumn colMessages;
}
