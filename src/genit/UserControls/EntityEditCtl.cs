using Dyvenix.Genit.Models;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class EntityEditCtl : UserControl
{
	private EntityModel _entity;

	public EntityEditCtl(EntityModel entity)
	{
		InitializeComponent();
		SetEntity(entity);
	}

	public void SetEntity(EntityModel entity)
	{
		bindingSource.DataSource = entity;
		_entity = entity;

		//txtName.Text = entity.Name;
		//txtNamespace.Text = entity.Namespace;
		//txtSchema.Text = entity.Schema;

		sleAttrs.Items = entity.Attributes;
		sleUsings.Items = entity.AddlUsings;

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
