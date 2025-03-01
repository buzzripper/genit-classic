using System.Drawing;
using System.Windows.Forms;

namespace Dyvenix.Genit;

partial class DetailForm
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
		if (disposing && (components != null))
		{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailForm));
		label7 = new Label();
		lblApplication = new Label();
		lblSource = new Label();
		lblException = new Label();
		picLogLevel = new PictureBox();
		button1 = new Button();
		btnUp = new Button();
		txtException = new TextBox();
		panel1 = new Panel();
		label10 = new Label();
		txtMessage = new TextBox();
		label5 = new Label();
		lblSeverity = new Label();
		label4 = new Label();
		lblTimestamp = new Label();
		label3 = new Label();
		lblRowId = new Label();
		label1 = new Label();
		picCopyMessage = new PictureBox();
		picCopyException = new PictureBox();
		((System.ComponentModel.ISupportInitialize)picLogLevel).BeginInit();
		((System.ComponentModel.ISupportInitialize)picCopyMessage).BeginInit();
		((System.ComponentModel.ISupportInitialize)picCopyException).BeginInit();
		SuspendLayout();
		// 
		// label7
		// 
		label7.ImageAlign = ContentAlignment.MiddleRight;
		label7.Location = new Point(340, 4);
		label7.Margin = new Padding(2, 0, 2, 0);
		label7.Name = "label7";
		label7.Size = new Size(74, 13);
		label7.TabIndex = 61;
		label7.Text = "Application:";
		label7.TextAlign = ContentAlignment.MiddleRight;
		// 
		// lblApplication
		// 
		lblApplication.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblApplication.AutoSize = true;
		lblApplication.ImageAlign = ContentAlignment.BottomLeft;
		lblApplication.Location = new Point(415, 4);
		lblApplication.Margin = new Padding(2, 0, 2, 0);
		lblApplication.Name = "lblApplication";
		lblApplication.Size = new Size(81, 15);
		lblApplication.TabIndex = 60;
		lblApplication.Text = "lblApplication";
		lblApplication.TextAlign = ContentAlignment.MiddleLeft;
		// 
		// lblSource
		// 
		lblSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblSource.AutoSize = true;
		lblSource.ImageAlign = ContentAlignment.BottomLeft;
		lblSource.Location = new Point(415, 19);
		lblSource.Margin = new Padding(2, 0, 2, 0);
		lblSource.Name = "lblSource";
		lblSource.Size = new Size(98, 15);
		lblSource.TabIndex = 59;
		lblSource.Text = "lblSourceContext";
		// 
		// lblException
		// 
		lblException.AutoSize = true;
		lblException.Location = new Point(15, 177);
		lblException.Margin = new Padding(2, 0, 2, 0);
		lblException.Name = "lblException";
		lblException.Size = new Size(62, 15);
		lblException.TabIndex = 57;
		lblException.Text = "Exception:";
		lblException.TextAlign = ContentAlignment.MiddleRight;
		// 
		// picLogLevel
		// 
		picLogLevel.Location = new Point(4, 3);
		picLogLevel.Margin = new Padding(2);
		picLogLevel.Name = "picLogLevel";
		picLogLevel.Size = new Size(11, 10);
		picLogLevel.TabIndex = 56;
		picLogLevel.TabStop = false;
		// 
		// button1
		// 
		button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button1.BackColor = Color.Transparent;
		button1.FlatAppearance.BorderSize = 0;
		button1.Image = (Image)resources.GetObject("button1.Image");
		button1.Location = new Point(584, 31);
		button1.Margin = new Padding(2);
		button1.Name = "button1";
		button1.Size = new Size(24, 24);
		button1.TabIndex = 48;
		button1.UseVisualStyleBackColor = false;
		button1.Click += btnDown_Click;
		// 
		// btnUp
		// 
		btnUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnUp.BackColor = Color.Transparent;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.Image = (Image)resources.GetObject("btnUp.Image");
		btnUp.Location = new Point(584, 4);
		btnUp.Margin = new Padding(2);
		btnUp.Name = "btnUp";
		btnUp.Size = new Size(24, 24);
		btnUp.TabIndex = 47;
		btnUp.UseVisualStyleBackColor = false;
		btnUp.Click += btnUp_Click;
		// 
		// txtException
		// 
		txtException.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		txtException.BackColor = SystemColors.Control;
		txtException.BorderStyle = BorderStyle.FixedSingle;
		txtException.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
		txtException.Location = new Point(15, 196);
		txtException.Margin = new Padding(2);
		txtException.Multiline = true;
		txtException.Name = "txtException";
		txtException.ScrollBars = ScrollBars.Vertical;
		txtException.Size = new Size(589, 91);
		txtException.TabIndex = 55;
		txtException.Visible = false;
		// 
		// panel1
		// 
		panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		panel1.BorderStyle = BorderStyle.Fixed3D;
		panel1.Location = new Point(6, 62);
		panel1.Margin = new Padding(2);
		panel1.Name = "panel1";
		panel1.Size = new Size(609, 4);
		panel1.TabIndex = 54;
		// 
		// label10
		// 
		label10.ImageAlign = ContentAlignment.MiddleRight;
		label10.Location = new Point(356, 19);
		label10.Margin = new Padding(2, 0, 2, 0);
		label10.Name = "label10";
		label10.Size = new Size(57, 13);
		label10.TabIndex = 49;
		label10.Text = "Source:";
		label10.TextAlign = ContentAlignment.MiddleRight;
		// 
		// txtMessage
		// 
		txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		txtMessage.BackColor = SystemColors.Control;
		txtMessage.BorderStyle = BorderStyle.FixedSingle;
		txtMessage.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
		txtMessage.Location = new Point(15, 88);
		txtMessage.Margin = new Padding(2);
		txtMessage.Multiline = true;
		txtMessage.Name = "txtMessage";
		txtMessage.ReadOnly = true;
		txtMessage.ScrollBars = ScrollBars.Vertical;
		txtMessage.Size = new Size(589, 85);
		txtMessage.TabIndex = 46;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new Point(15, 73);
		label5.Margin = new Padding(2, 0, 2, 0);
		label5.Name = "label5";
		label5.Size = new Size(56, 15);
		label5.TabIndex = 45;
		label5.Text = "Message:";
		label5.TextAlign = ContentAlignment.MiddleRight;
		// 
		// lblSeverity
		// 
		lblSeverity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblSeverity.AutoSize = true;
		lblSeverity.ImageAlign = ContentAlignment.BottomLeft;
		lblSeverity.Location = new Point(81, 33);
		lblSeverity.Margin = new Padding(2, 0, 2, 0);
		lblSeverity.Name = "lblSeverity";
		lblSeverity.Size = new Size(61, 15);
		lblSeverity.TabIndex = 44;
		lblSeverity.Text = "lblSeverity";
		// 
		// label4
		// 
		label4.ImageAlign = ContentAlignment.MiddleRight;
		label4.Location = new Point(0, 33);
		label4.Margin = new Padding(2, 0, 2, 0);
		label4.Name = "label4";
		label4.Size = new Size(80, 15);
		label4.TabIndex = 43;
		label4.Text = "Log Level:";
		label4.TextAlign = ContentAlignment.MiddleRight;
		// 
		// lblTimestamp
		// 
		lblTimestamp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTimestamp.AutoSize = true;
		lblTimestamp.ImageAlign = ContentAlignment.BottomLeft;
		lblTimestamp.Location = new Point(81, 19);
		lblTimestamp.Margin = new Padding(2, 0, 2, 0);
		lblTimestamp.Name = "lblTimestamp";
		lblTimestamp.Size = new Size(79, 15);
		lblTimestamp.TabIndex = 42;
		lblTimestamp.Text = "lblTimestamp";
		// 
		// label3
		// 
		label3.ImageAlign = ContentAlignment.MiddleRight;
		label3.Location = new Point(6, 18);
		label3.Margin = new Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Size = new Size(72, 13);
		label3.TabIndex = 41;
		label3.Text = "Timestamp:";
		label3.TextAlign = ContentAlignment.MiddleRight;
		// 
		// lblRowId
		// 
		lblRowId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblRowId.AutoSize = true;
		lblRowId.ImageAlign = ContentAlignment.BottomLeft;
		lblRowId.Location = new Point(81, 4);
		lblRowId.Margin = new Padding(2, 0, 2, 0);
		lblRowId.Name = "lblRowId";
		lblRowId.Size = new Size(53, 15);
		lblRowId.TabIndex = 40;
		lblRowId.Text = "lblRowId";
		// 
		// label1
		// 
		label1.ImageAlign = ContentAlignment.MiddleRight;
		label1.Location = new Point(26, 4);
		label1.Margin = new Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Size = new Size(51, 13);
		label1.TabIndex = 39;
		label1.Text = "Id:";
		label1.TextAlign = ContentAlignment.MiddleRight;
		// 
		// picCopyMessage
		// 
		picCopyMessage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		picCopyMessage.BackgroundImage = (Image)resources.GetObject("picCopyMessage.BackgroundImage");
		picCopyMessage.BackgroundImageLayout = ImageLayout.Center;
		picCopyMessage.Cursor = Cursors.Hand;
		picCopyMessage.Location = new Point(551, 64);
		picCopyMessage.Name = "picCopyMessage";
		picCopyMessage.Size = new Size(33, 24);
		picCopyMessage.TabIndex = 62;
		picCopyMessage.TabStop = false;
		picCopyMessage.Click += picCopyMessage_Click;
		// 
		// picCopyException
		// 
		picCopyException.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		picCopyException.BackgroundImage = (Image)resources.GetObject("picCopyException.BackgroundImage");
		picCopyException.BackgroundImageLayout = ImageLayout.Center;
		picCopyException.Cursor = Cursors.Hand;
		picCopyException.Location = new Point(551, 172);
		picCopyException.Name = "picCopyException";
		picCopyException.Size = new Size(33, 24);
		picCopyException.TabIndex = 63;
		picCopyException.TabStop = false;
		picCopyException.Click += picCopyException_Click;
		// 
		// DetailForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(619, 322);
		Controls.Add(label7);
		Controls.Add(lblApplication);
		Controls.Add(lblSource);
		Controls.Add(lblException);
		Controls.Add(picLogLevel);
		Controls.Add(button1);
		Controls.Add(btnUp);
		Controls.Add(txtException);
		Controls.Add(panel1);
		Controls.Add(label10);
		Controls.Add(txtMessage);
		Controls.Add(label5);
		Controls.Add(lblSeverity);
		Controls.Add(label4);
		Controls.Add(lblTimestamp);
		Controls.Add(label3);
		Controls.Add(lblRowId);
		Controls.Add(label1);
		Controls.Add(picCopyMessage);
		Controls.Add(picCopyException);
		Margin = new Padding(2);
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "DetailForm";
		StartPosition = FormStartPosition.CenterParent;
		Text = "DetailForm";
		Load += DetailForm_Load;
		Shown += DetailForm_Shown;
		((System.ComponentModel.ISupportInitialize)picLogLevel).EndInit();
		((System.ComponentModel.ISupportInitialize)picCopyMessage).EndInit();
		((System.ComponentModel.ISupportInitialize)picCopyException).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Label label7;
	private Label lblApplication;
	private Label lblSource;
	private Label lblException;
	private PictureBox picLogLevel;
	private Button button1;
	private Button btnUp;
	private TextBox txtException;
	private Panel panel1;
	private Label label10;
	private TextBox txtMessage;
	private Label label5;
	private Label lblSeverity;
	private Label label4;
	private Label lblTimestamp;
	private Label label3;
	private Label lblRowId;
	private Label label1;
	private PictureBox picCopyMessage;
	private PictureBox picCopyException;
}