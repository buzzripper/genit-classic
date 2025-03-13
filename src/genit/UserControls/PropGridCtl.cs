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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Dyvenix.Genit.UserControls;

public partial class PropGridCtl : UserControl
{
	private ObservableCollection<PropertyModel> _propertyModels;
	private readonly List<PropGridRowCtl> _rows = new List<PropGridRowCtl>();
	private bool _suspendUpdates;

	public PropGridCtl()
	{
		InitializeComponent();
	}

	private void PropGridCtl_Load(object sender, EventArgs e)
	{
	}

	#region Properties

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableCollection<PropertyModel> DataSource
	{
		get { return _propertyModels; }
		set {
			_propertyModels = value;
			_propertyModels.CollectionChanged += OnPopertyModels_CollectionChanged;
			PopulateGrid();
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

	private void PopulateGrid()
	{
		if (this.DesignMode)
			return;

		this.SuspendLayout();
		_suspendUpdates = true;

		try {
			foreach (var row in _rows) {
				this.Controls.Remove(row);
				row.Dispose();
			}
			_rows.Clear();

			var top = 0;
			foreach (var propMdl in _propertyModels) {
				PropGridRowCtl propGridRowCtl = new PropGridRowCtl(propMdl);
				propGridRowCtl.Top = top += 35;
				propGridRowCtl.Left = 0;
				propGridRowCtl.Width = this.Width;
				propGridRowCtl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
				propGridRowCtl.PropertyModelChanged += OnPropGridRowCtl_PropertyModelChanged;

				_rows.Add(propGridRowCtl);
				this.Controls.Add(propGridRowCtl);
			}

			splMain_SplitterMoved(null, null);
			splDataType_SplitterMoved(null, null);

		} catch (Exception ex) {
			MessageBox.Show(ex.Message);

		} finally {
			_suspendUpdates = false;
			this.ResumeLayout();
		}
	}

	private void OnPropGridRowCtl_PropertyModelChanged(object sender, PropertyModelChangedEventArgs e)
	{
		if (e.Action == ModelPropertyChangedAction.Deleted) {
			_propertyModels.Remove(e.PropertyModel);
		}
	}

	private void OnPopertyModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove) {
			PopulateGrid();
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
