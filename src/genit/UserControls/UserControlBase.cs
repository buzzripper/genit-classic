using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public class UserControlBase : UserControl
{
	private StringListForm _slForm;

	protected bool _suspendUpdates;

	public UserControlBase()
	{
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		if (!this.DesignMode)
			this.BackColor = SystemColors.Control;
	}

	#region Properties

	protected StringListForm StrListForm
	{
		get {
			if (_slForm == null)
				_slForm = new StringListForm();
			return _slForm;
		}
	}

	#endregion
}
