using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public class EntityEditCtlBase : UserControlBase
{
	protected EntityModel _entity;

	public EntityEditCtlBase() : base()
	{
	}

	public EntityEditCtlBase(EntityModel entity)
	{
		_entity = entity;
	}

}
