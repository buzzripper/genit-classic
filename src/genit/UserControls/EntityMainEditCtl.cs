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
	private const int cColMaxLength = 3;
	private const int cColIsPrimaryKey = 4;
	private const int cColIsIdentity = 5;
	private const int cColNullable = 6;
	private const int cColIsIndexed = 7;
	private const int cColIsIndexUnique = 8;
	private const int cColIsIndexClustered = 9;

	private readonly List<PrimitiveType> _primitiveTypes;
	private List<string> _datatypes;

	public EntityMainEditCtl()
	{
		InitializeComponent();
		grdProps.AutoGenerateColumns = false;
		_primitiveTypes = PrimitiveType.GetAll();
	}

	public override void Initialize(EntityModel entity)
	{
		base.Initialize(entity);

		_datatypes = GetDataTypes();
		InitializeDatatypeColumn();
		Globals.DbContext.Enums.CollectionChanged += Enums_CollectionChanged;

		grdProps.DataSource = _entity.Properties;
		sleAttrs.Items = _entity.Attributes;
		sleUsings.Items = _entity.AddlUsings;
	}

	#region Data Events

	private void Enums_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		// Refresh the datatypes list when the Enums collection changes
		_datatypes = GetDataTypes();
	}

	#endregion

	#region DataTypeItems

	private List<string> GetDataTypes()
	{
		var datatypes = new List<string>();

		_primitiveTypes.ForEach(pt => datatypes.Add(pt.CSType));
		Globals.DbContext.Enums.ToList().ForEach(e => datatypes.Add(e.Name));

		return datatypes;
	}

	#endregion

	private void InitializeDatatypeColumn()
	{
		var colDatatype = grdProps.Columns[cColDatatype] as DataGridViewComboBoxColumn;
		if (colDatatype == null)
			throw new ApplicationException($"Column {cColDatatype} is not a combo box column.");

		colDatatype.HeaderText = "Data Type";
		colDatatype.DataPropertyName = "DatatypeName";
		//colDatatype.Name = "DatatypeColumn";
		colDatatype.DataSource = _datatypes;
		//colDatatype.DisplayMember = "Name"; // The property to display in the combo box
		//colDatatype.ValueMember = "Id"; // The property to use as the actual value
	}

	private void grdProps_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (e.Control is DataGridViewComboBoxEditingControl comboBox) {
			// Detach the event handler if it was previously attached
			comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted;
			// Attach the event handler
			comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
		}
	}

	private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
	{
		if (!(sender is DataGridViewComboBoxEditingControl comboBox))
			return;

		var datatypeStr = comboBox.SelectedItem.ToString();
		var id = GetIdFromCell(grdProps.SelectedCells[0].OwningRow.Cells[cColId]);

		UpdateDatatypeValue(id, datatypeStr);
	}

	private Guid GetIdFromCell(DataGridViewCell cell)
	{
		if (!Guid.TryParse(cell.Value?.ToString(), out Guid id))
			throw new ApplicationException("Unable to parse Id");
		return id;
	}

	private void grdProps_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		//if (e.ColumnIndex == cColDatatype) {
		//	var idStr = grdProps.Rows[e.RowIndex].Cells[cColId].Value?.ToString();
		//	if (!Guid.TryParse(idStr?.ToString(), out Guid id))
		//		return;

		//	var cmbCell = grdProps.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
		//	var x = cmbCell.Value;
		//	var datatypeStr = grdProps.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

		//	UpdateDatatypeValue(id, datatypeStr);
		//}
	}

	private void UpdateDatatypeValue(Guid propId, string selectedStr)
	{
		var prop = _entity.Properties.FirstOrDefault(p => p.Id == propId);
		if (prop == null)
			return;

		var idx = _primitiveTypes.Select(pt => pt.CSType).ToList().IndexOf(selectedStr);
		if (idx > -1) {
			prop.PrimitiveType = _primitiveTypes[idx];
			prop.EnumType = null;

		} else {
			var enumModel = Globals.DbContext.Enums.FirstOrDefault(e => e.Name == selectedStr);
			if (enumModel != null) {
				prop.EnumType = enumModel;
				prop.PrimitiveType = null;
			}
		}
	}
}


//private List<DataTypeItem> GetDataTypeItems()
//{
//	var dtItems = new List<DataTypeItem>();

//	dtItems.Add(new DataTypeItem("Primitives", null, null));
//	PrimitiveType.GetAll().ForEach(pt => dtItems.Add(new DataTypeItem($"     {pt.CSType}", pt, null)));

//	var enumModels = Globals.DbContext.Enums.ToList();
//	dtItems.Add(new DataTypeItem("Enums", null, null));
//	foreach (var enumModel in enumModels)
//		dtItems.Add(new DataTypeItem($"     {enumModel.Name}", null, enumModel));

//	return dtItems;
//}

//public class DataTypeItem
//{
//	public Guid Id { get; private set; }
//	public string Name { get; set; }
//	public PrimitiveType PrimitiveType { get; set; }
//	public EnumModel EnumType { get; set; }

//	public DataTypeItem(string name, PrimitiveType primitiveType, EnumModel enumType)
//	{
//		this.Id = Guid.NewGuid();
//		this.Name = name;
//		this.PrimitiveType = primitiveType;
//		this.EnumType = enumType;
//	}

//	public override string ToString()
//	{
//		return Name;
//	}
//}

//private DataTypeItem ItemFromPropertyModel(PropertyModel prop)
//{
//	if (prop.PrimitiveType != null)
//		return _dataTypeItems.FirstOrDefault(x => x.PrimitiveType?.Id == prop.PrimitiveType.Id);
//	else if (prop.EnumType != null)
//		return _dataTypeItems.FirstOrDefault(i => i.EnumType != null && i.EnumType.Id == prop.EnumType.Id);
//	else
//		return _dataTypeItems.FirstOrDefault(i => i.Name == "Primitives");
//	//}
//	//{
//}

//private void PopulateGrid(List<PropertyModel> props)
//{
//	foreach (var prop in props) {
//		AddGridRow(prop);
//	}
//}

//private void AddGridRow(PropertyModel prop)
//{
//var row = new DataGridViewRow();

//row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.Id });
//row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.Name });

//row.Cells.Add(new DataGridViewComboBoxCell());
////	DataSource = PrimitiveType.GetAll(), // Set the data source for the combo box
////	DisplayMember = "Name", // The property to display in the combo box
////	ValueMember = "Id", // The property to use as the actual value
////	//Value = prop.PrimitiveType.Id // Set the initial value
////});

//row.Cells.Add(new DataGridViewTextBoxCell { Value = prop.MaxLength });
//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.IsPrimaryKey });
//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.IsIdentity });
//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.Nullable });
//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.IsIndexed });
//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.IsIndexUnique });
//row.Cells.Add(new DataGridViewCheckBoxCell { Value = prop.IsIndexClustered });

//grdProps.Rows.Add(row);
//}
