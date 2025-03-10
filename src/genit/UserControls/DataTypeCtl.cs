using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Misc;
using System.ComponentModel;

namespace Dyvenix.Genit.UserControls;

public partial class DataTypeCtl : UserControlBase
{
	public event EventHandler<DataTypeChangedEventArgs> ValueChanged;

	private bool _suspendUpdates;

	public DataTypeCtl()
	{
		InitializeComponent();
	}

	private void DataTypeCtl_Load(object sender, EventArgs e)
	{
	}

	private void cmbItems_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
	{
		this.Height = cmbItems.Height;
	}

	#region Properties

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PrimitiveType PrimitiveType { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public EnumModel EnumModel { get; private set; }

	#endregion

	public void SetDataTypes(PrimitiveType primitiveType, EnumModel enumMdl)
	{
		//_suspendUpdates = true;

		this.PrimitiveType = primitiveType;
		this.EnumModel = enumMdl;
		Globals.DbContext.Enums.CollectionChanged += Enums_CollectionChanged;

		FillComboList(Globals.DbContext.Enums.ToList());

		if (primitiveType != null)
			Select(primitiveType);
		else if (enumMdl != null)
			Select(enumMdl);
		else
			SelectNone();
	}

	private void Enums_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		var enumModels = e.NewItems?.Cast<EnumModel>();
		FillComboList(enumModels);
	}

	private void FillComboList(IEnumerable<EnumModel> enumModels)
	{
		cmbItems.SuspendLayout();
		cmbItems.Items.Clear();

		cmbItems.Items.Add(new DataTypeItem("Primitives", null, null));
		PrimitiveType.GetAll().ForEach(pt => cmbItems.Items.Add(new DataTypeItem($"     {pt.CSType}", pt, null)));
		cmbItems.Items.Add(new DataTypeItem("Enums", null, null));
		foreach (var enumModel in enumModels)
			cmbItems.Items.Add(new DataTypeItem($"     {enumModel.Name}", null, enumModel));

		cmbItems.ResumeLayout();
	}

	public void Select(PrimitiveType primitiveType)
	{
		if (primitiveType == null)
			cmbItems.SelectedIndex = -1;
		else
			cmbItems.SelectedItem = cmbItems.Items.Cast<DataTypeItem>().FirstOrDefault(i => i.PrimitiveType == primitiveType);

		this.SetValues(primitiveType, null);
	}

	public void Select(EnumModel enumModel)
	{
		if (enumModel == null)
			cmbItems.SelectedIndex = -1;
		else
			cmbItems.SelectedItem = cmbItems.Items.Cast<DataTypeItem>().FirstOrDefault(i => i.EnumType == enumModel);

		this.SetValues(null, enumModel);
	}

	public void SelectNone()
	{
		cmbItems.SelectedIndex = -1;
		this.SetValues(null, null);
	}

	private void SetValues(PrimitiveType primitiveType, EnumModel enumType)
	{
		this.PrimitiveType = primitiveType;
		this.EnumModel = enumType;

		if (!_suspendUpdates)
			ValueChanged?.Invoke(this, new DataTypeChangedEventArgs(primitiveType, enumType));
	}

	private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		var selectedDataTypeItem = cmbItems.SelectedItem as DataTypeItem;
		if (selectedDataTypeItem == null)
			return;

		if (selectedDataTypeItem.PrimitiveType != null) {
			SetValues(selectedDataTypeItem.PrimitiveType, null);

		} else if (selectedDataTypeItem.EnumType != null) {
			SetValues(null, selectedDataTypeItem.EnumType);

		} else {
			SetValues(null, null);
			// If one of the heading items, then select the first item in the list
			cmbItems.SelectedIndex = 1;
		}
	}

	private class DataTypeItem
	{
		public string Name { get; set; }
		public PrimitiveType PrimitiveType { get; set; }
		public EnumModel EnumType { get; set; }

		public DataTypeItem(string name, PrimitiveType primitiveType, EnumModel enumType)
		{
			this.Name = name;
			this.PrimitiveType = primitiveType;
			this.EnumType = enumType;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}

public class DataTypeChangedEventArgs : EventArgs
{
	public PrimitiveType PrimitiveType { get; }
	public EnumModel EnumType { get; }

	public DataTypeChangedEventArgs(PrimitiveType primitiveType, EnumModel enumType)
	{
		PrimitiveType = primitiveType;
		EnumType = enumType;
	}
}
