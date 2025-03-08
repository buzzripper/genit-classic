using Dyvenix.Genit.Models;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public class EntityEditCtlBase : Control
{
	protected EntityModel _entity;

	public virtual void Initialize(EntityModel entity)
	{
		_entity = entity;
	}
}
