using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class PropGridCtl : UserControl
{
	#region Fields

	private ObservableCollection<PropertyModel> _propertyModels;
	private readonly List<PropGridRowCtl> _rows = new List<PropGridRowCtl>();
	private bool _suspendUpdates;

	#endregion

	#region Ctors / Init

	public PropGridCtl()
	{
		InitializeComponent();
	}

	private void PropGridCtl_Load(object sender, EventArgs e)
	{
	}

	#endregion

	#region Properties

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableCollection<PropertyModel> DataSource
	{
		get { return _propertyModels; }
		set {
			_propertyModels = value;
			_propertyModels.CollectionChanged += OnPopertyModels_CollectionChanged;
			PopulateRows();
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

	#region Methods

	private void PopulateRows()
	{
		if (this.DesignMode)
			return;

		_suspendUpdates = true;
		SuspendLayout();

		try {
			foreach (var row in _rows) {
				this.Controls.Remove(row);
				row.Dispose();
			}
			_rows.Clear();

			var count = 0;
			foreach (var propMdl in _propertyModels.OrderBy(p => p.DisplayOrder)) {
				PropGridRowCtl propGridRowCtl = new PropGridRowCtl(propMdl);
				propGridRowCtl.Top = ++count * (propGridRowCtl.Height + 2);
				propGridRowCtl.Left = 0;
				propGridRowCtl.Width = this.Width;
				propGridRowCtl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
				propGridRowCtl.PropertyModelChanged += OnPropGridRowCtl_PropertyModelChanged;
				propGridRowCtl.RowMoved += PropGridRowCtl_RowMoved;

				_rows.Add(propGridRowCtl);
				this.Controls.Add(propGridRowCtl);
			}

			splMain_SplitterMoved(null, null);
			splDataType_SplitterMoved(null, null);

		} catch (Exception ex) {
			MessageBox.Show(ex.Message);

		} finally {
			_suspendUpdates = false;
			ResumeLayout();
		}
	}

	#endregion

	#region Events

	private void PropGridRowCtl_RowMoved(object sender, RowMovedEventArgs e)
	{
		var srcProp = _propertyModels.FirstOrDefault(p => p.Id == e.SourceId);
		var targetProp = _propertyModels.FirstOrDefault(p => p.Id == e.TargetId);

		_suspendUpdates = true;
		SuspendLayout();

		var srcOrder = srcProp.DisplayOrder;
		var targetOrder = targetProp.DisplayOrder;

		if (srcOrder < targetOrder) {
			foreach (var prop in _propertyModels.Where(p => p.DisplayOrder > srcOrder && p.DisplayOrder < targetOrder))
				prop.DisplayOrder--;
			srcProp.DisplayOrder = targetProp.DisplayOrder - 1;

		} else {
			foreach (var prop in _propertyModels.Where(p => p.DisplayOrder > targetOrder && p.DisplayOrder < srcOrder))
				prop.DisplayOrder++;
			srcProp.DisplayOrder = targetOrder;
			targetProp.DisplayOrder = targetOrder + 1;
		}

		PopulateRows();

		_suspendUpdates = false;
		ResumeLayout();
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
			PopulateRows();
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

	#endregion
}
