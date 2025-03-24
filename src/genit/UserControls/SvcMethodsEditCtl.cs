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
using System.DirectoryServices.ActiveDirectory;
using System.Xml.Linq;

namespace Dyvenix.Genit.UserControls;

public partial class SvcMethodsEditCtl : EntityEditCtlBase
{
	#region Fields

	private bool _suspendUpdates;
	private AssocEditForm _navPropEditForm;
	private StringListForm _slForm;

	#endregion

	#region Ctors / Init

	//public SvcMethodsEditCtl()
	//{
	//	InitializeComponent();
	//}

	public SvcMethodsEditCtl(EntityModel entity) : base()
	{
		InitializeComponent();
	}

	//public SvcMethodsEditCtl(SvcMethodsModel entity) : base(entity)
	//{
	//	InitializeComponent();
	//}

	private void EntityMainEditCtl_Load(object sender, EventArgs e)
	{
		this.PopulateControls();
	}

	private void PopulateControls()
	{
		_suspendUpdates = true;


		_suspendUpdates = false;
	}

	#endregion
}
