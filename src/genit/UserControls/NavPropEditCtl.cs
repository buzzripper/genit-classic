using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class NavPropEditCtl : UserControlBase
{
	private AssocModel _assoc;

	public NavPropEditCtl()
	{
		InitializeComponent();
	}

	public void Initialize(AssocModel assoc)
	{
		_assoc = assoc;
		bindingSrc.DataSource = assoc;
	}
}
