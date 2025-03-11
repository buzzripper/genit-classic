using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class EntityMainEditCtl : EntityEditCtlBase
{
	private const int cColId = 0;
	private const int cColName = 1;
	private const int cColDatatype = 2;
	private const int cColIsPrimaryKey = 3;
	private const int cColNullable = 4;
	private const int cColIsIndexed = 5;
	private const int cColIsIndexUnique = 6;
	private const int cColIsIndexClustered = 7;

	private List<DataTypeItem> _dataTypeItems;

	public EntityMainEditCtl()
	{
		InitializeComponent();
		grdProps.AutoGenerateColumns = false;
	}

	public override void Initialize(EntityModel entity)
	{
		base.Initialize(entity);

		bindingSource.DataSource = _entity;

		sleAttrs.Items = _entity.Attributes;
		sleUsings.Items = _entity.AddlUsings;

		_dataTypeItems = GetDataTypeItems();

		InitializeDatatypeColumn();

		//grdProps.DataSource = _entity.Properties;
	}

	private List<DataTypeItem> GetDataTypeItems()
	{
		var dtItems = new List<DataTypeItem>();

		dtItems.Add(new DataTypeItem("Primitives", null, null));
		PrimitiveType.GetAll().ForEach(pt => dtItems.Add(new DataTypeItem($"     {pt.CSType}", pt, null)));

		var enumModels = Globals.DbContext.Enums.ToList();
		dtItems.Add(new DataTypeItem("Enums", null, null));
		foreach (var enumModel in enumModels)
			dtItems.Add(new DataTypeItem($"     {enumModel.Name}", null, enumModel));

		return dtItems;
	}

	private void InitializeDatatypeColumn()
	{
		var colDatatype = grdProps.Columns[cColDatatype] as DataGridViewComboBoxColumn;
		if (colDatatype == null)
			throw new ApplicationException($"Column {cColDatatype} is not a combo box column.");

		colDatatype.HeaderText = "Data Type";
		colDatatype.DataPropertyName = "PrimitiveType";
		colDatatype.Name = "DatatypeColumn";
		colDatatype.DataSource = _dataTypeItems;
		colDatatype.DisplayMember = "Name"; // The property to display in the combo box
		colDatatype.ValueMember = "Id"; // The property to use as the actual value

		//colDatatype.Items.AddRange(new List<string> { "one", "two", "three" });
	}

	private DataTypeItem ItemFromPropertyModel(PropertyModel prop)
	{
		if (prop.PrimitiveType != null)
			return _dataTypeItems.FirstOrDefault(x => x.PrimitiveType?.Id == prop.PrimitiveType.Id);
		else if (prop.EnumType != null)
			return _dataTypeItems.FirstOrDefault(i => i.EnumType != null && i.EnumType.Id == prop.EnumType.Id);
		else
			return _dataTypeItems.FirstOrDefault(i => i.Name == "Primitives");
		//}
		//{
		//	foreach (var prop in propModels) {
		//		AddGridRow(prop);
		//	}
	}

	//private void AddGridRow(PropertyModel prop)
	//{
	//	var row = new DataGridViewRow();

	//	//row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.Id });
	//	//row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.Name });

	//	//row.Cells.Add(new DataGridViewComboBoxCell {
	//	//	DataSource = PrimitiveType.GetAll(), // Set the data source for the combo box
	//	//	DisplayMember = "Name", // The property to display in the combo box
	//	//	ValueMember = "Id", // The property to use as the actual value
	//	//	//Value = prop.PrimitiveType.Id // Set the initial value
	//	//});

	//	//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.IsPrimaryKey });
	//	//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.Nullable });
	//	//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.IsIndexed });
	//	//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.IsIndexUnique });

	//	grdProps.Rows.Add(row);
	//}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{

	}

	private void grdProps_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
	{
		switch (e.ColumnIndex) {
			case cColName:
				_entity.Properties[e.RowIndex].Name = e.FormattedValue.ToString();
				break;
			case cColDatatype:

				break;
			case cColIsPrimaryKey:
				_entity.Properties[e.RowIndex].IsPrimaryKey = (bool)e.FormattedValue;
				break;
			case cColNullable:
				_entity.Properties[e.RowIndex].Nullable = (bool)e.FormattedValue;
				break;
			case cColIsIndexed:
				_entity.Properties[e.RowIndex].IsIndexed = (bool)e.FormattedValue;
				break;
			case cColIsIndexUnique:
				_entity.Properties[e.RowIndex].IsIndexUnique = (bool)e.FormattedValue;
				break;
		}
	}

	public class DataTypeItem
	{
		public Guid Id { get; private set; }
		public string Name { get; set; }
		public PrimitiveType PrimitiveType { get; set; }
		public EnumModel EnumType { get; set; }

		public DataTypeItem(string name, PrimitiveType primitiveType, EnumModel enumType)
		{
			this.Id = Guid.NewGuid();
			this.Name = name;
			this.PrimitiveType = primitiveType;
			this.EnumType = enumType;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	private void grdProps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{

	}

	private void grdProps_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (e.ColumnIndex == cColDatatype) {
			//var prop = _entity.Properties[e.RowIndex];
			//e.Value = ItemFromPropertyModel(prop);
			//e.Value = _dataTypeItems[1];
		}
	}

	private void grdProps_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{

	}
}
