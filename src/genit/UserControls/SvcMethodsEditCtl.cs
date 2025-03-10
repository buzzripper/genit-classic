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

namespace Dyvenix.Genit.UserControls;

public partial class SvcMethodsEditCtl :  EntityEditCtlBase
{
	//protected EntityModel _entity;

	public SvcMethodsEditCtl()
	{
		InitializeComponent();
	}

	public void Initialize(EntityModel entity)
	{
		//_entity = entity;
		base.Initialize(entity);
	}
}
