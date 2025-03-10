using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
    public class UserControlBase : UserControl
    {
        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!this.DesignMode)
				this.BackColor = SystemColors.Control;
		}
	}
}
