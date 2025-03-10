using Dyvenix.Genit.Models;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace Dyvenix.Genit.UserControls;

public class EntityEditCtlBase : UserControlBase
{
	protected EntityModel _entity;

	public virtual void Initialize(EntityModel entity)
	{
		_entity = entity;

		//foreach(var control in Controls) {
		//	if (control is TextBox textBox) {
		//		textBox.BorderStyle = BorderStyle.None;
		//		textBox.Height += 4;
		//	}
		//}
	}
}
