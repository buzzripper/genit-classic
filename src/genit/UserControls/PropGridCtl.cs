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
using System.Xml.XPath;

namespace Dyvenix.Genit.UserControls;

public partial class PropGridCtl : UserControl
{
	private List<PropertyModel> _propertyModels;

	public PropGridCtl()
	{
		InitializeComponent();
	}

	private void PropGridCtl_Load(object sender, EventArgs e)
	{
		splMain_SplitterMoved(null, null);
		splDataType_SplitterMoved(null, null);
	}

	#region Properties

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public List<PropertyModel> DataSource
	{
		get { return _propertyModels; }
		set {
			_propertyModels = value;
			Initialize();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Col1Width
	{
		get { return splMain.SplitterDistance; }
		set { splMain.SplitterDistance = value; }
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Col2Width
	{
		get { return splDataType.SplitterDistance; }
		set { splDataType.SplitterDistance = value; }
	}

	#endregion

	private void Initialize()
	{
		if (this.DesignMode)
			return;

		var top = 0;
		foreach (var propMdl in _propertyModels) {
			PropGridRowCtl propGridRowCtl = new PropGridRowCtl(propMdl);
			propGridRowCtl.Top = top += 35;
			this.Controls.Add(propGridRowCtl);
		}
	}

	private void splMain_SplitterMoved(object sender, SplitterEventArgs e)
	{
		foreach (var ctl in this.Controls)
			if (ctl is PropGridRowCtl)
				((PropGridRowCtl)ctl).Col1Width = splMain.SplitterDistance;
	}

	private void splDataType_SplitterMoved(object sender, SplitterEventArgs e)
	{
		foreach (var ctl in this.Controls)
			if (ctl is PropGridRowCtl)
				((PropGridRowCtl)ctl).Col2Width = splDataType.SplitterDistance;
	}
}
