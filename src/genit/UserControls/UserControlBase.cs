using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public class UserControlBase : UserControl
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		if (!this.DesignMode)
			this.BackColor = SystemColors.Control;
	}

	//protected static DialogResult ShowCenteredMessageBox(Control control, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
 //   {
	//	var ctl = control;

	//	while (ctl != null && !(ctl.Parent is MainForm))
	//		ctl = ctl.Parent;

	//	if (ctl == null)
	//		throw new ApplicationException("MainForm not found.");

	//	// Temporarily set the owner of the parent form
	//	ctl.BeginInvoke(new Action(() =>
 //       {
 //           MessageBox.Show(ctl, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
 //       }));

 //       return DialogResult.OK;
 //   }
}
