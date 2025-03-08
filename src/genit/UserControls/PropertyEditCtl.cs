using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class PropertyEditCtl: EntityEditCtlBase
{
	public PropertyEditCtl()
    {
        InitializeComponent();
	}

	public override void Initialize(EntityModel entity)
	{
		base.Initialize(entity);

		//txtName.Text = entity.Name;
		//txtNamespace.Text = entity.Namespace;
		//txtSchema.Text = entity.Schema;
		//sleAttrs.Items = entity.Attributes;
		//sleUsings.Items = entity.AddlUsings;
		//ckbEnabled.Checked = entity.Enabled;
		//ckbQuerySingle.Checked = entity.InclSingleQuery;
		//ckbQueryList.Checked = entity.InclListQuery;
		//ckbUseListPaging.Checked = entity.UseListPaging;	
		//ckbUseListSorting.Checked = entity.UseListSorting;
	}
}
