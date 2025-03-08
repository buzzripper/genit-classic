using Dyvenix.Genit.Models;

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

		//txtName.Text = entity.Name;
		//txtNamespace.Text = entity.Namespace;
		//txtSchema.Text = entity.Schema;

		sleAttrs.Items = _entity.Attributes;
		sleUsings.Items = _entity.AddlUsings;

		//ckbEnabled.Checked = entity.Enabled;
		//ckbQuerySingle.Checked = entity.InclSingleQuery;
		//ckbQueryList.Checked = entity.InclListQuery;
		//ckbUseListPaging.Checked = entity.UseListPaging;	
		//ckbUseListSorting.Checked = entity.UseListSorting;
	}

	private void ckbQueryList_CheckedChanged(object sender, System.EventArgs e)
	{
		var value = ckbQueryList.Checked;
		ckbUseListPaging.Enabled = value;
		ckbUseListSorting.Enabled = value;
	}
}
