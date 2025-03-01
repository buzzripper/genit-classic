using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dyvenix.Genit;

public partial class DetailForm : Form
{
	private const int BottomOffset = 85;
	private readonly Form1 _mainForm;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string ConnString { get; set; }

	#region Ctors / Forms Events

	public DetailForm(Form form1) : this()
	{
		_mainForm = form1 as Form1;
	}

	public DetailForm()
	{
		InitializeComponent();
	}

	private void DetailForm_Load(object sender, EventArgs e)
	{

	}

	private void DetailForm_Shown(object sender, EventArgs e)
	{

	}

	#endregion

	private void btnUp_Click(object sender, EventArgs e)
	{
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
	}


	public void ShowLog(LogEvent logEvent)
	{
	}

	private void ShowException(bool showException)
	{
		if (showException) {
			txtMessage.Height = ((this.Height - txtMessage.Top - BottomOffset) / 2);
			txtMessage.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			txtException.Top = txtMessage.Top + txtMessage.Height + 40;
			txtException.Height = this.Height - txtMessage.Top - txtMessage.Height - 110;
			txtException.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
			lblException.Top = txtMessage.Top + txtMessage.Height + 10;
			txtException.Visible = true;
			picCopyException.Top = lblException.Top - 4;
			picCopyException.Visible = true;
		} else {
			txtMessage.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
			txtMessage.Height = this.Height - txtMessage.Top - BottomOffset;
			txtException.Visible = false;
			lblException.Visible = false;
		}
	}

	private void picCopyMessage_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(txtMessage.Text);
	}

	private void picCopyException_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(txtException.Text);
	}
}
