using Dyvenix.Genit.Models;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class EntityMainEditCtl : EntityEditCtlBase
{
	public EntityMainEditCtl()
	{
		InitializeComponent();
	}

	public override void Initialize(EntityModel entity)
	{
		base.Initialize(entity);

		bindingSource.DataSource = _entity;

		sleAttrs.Items = _entity.Attributes;
		sleUsings.Items = _entity.AddlUsings;
	}

	private void EntityMainEditCtl2_Load(object sender, EventArgs e)
	{

	}
}
