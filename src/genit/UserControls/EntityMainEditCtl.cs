using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
	private const int cColFK = 10;
	private const int cColDel = 11;

	private readonly List<PrimitiveType> _primitiveTypes;
	private List<string> _datatypes;
	private bool _gridInitialized = false;

	public EntityMainEditCtl()
	{
		this.Visible = false;
		InitializeComponent();
		//grdProps.AutoGenerateColumns = false;
		_primitiveTypes = PrimitiveType.GetAll();
	}

	public override void Initialize(EntityModel entity)
	{
		base.Initialize(entity);

		_datatypes = GetDataTypes();
		InitializeDatatypeColumn();
		Globals.DbContext.Enums.CollectionChanged += Enums_CollectionChanged;

		propGridCtl.DataSource = _entity.Properties;
		sleAttrs.Items = _entity.Attributes;
		sleUsings.Items = _entity.AddlUsings;
	}

	private void EntityMainEditCtl_VisibleChanged(object sender, EventArgs e)
	{
		//if (!_gridInitialized && this.Visible) {
		//	_gridInitialized = true;
		//	InitializeGrid();
		//}
	}

	public void InitializeGrid()
	{
		//foreach (DataGridViewRow row in grdProps.Rows) {
		//	var prop = GetPropFromRow(row);
		//	if (prop == null)
		//		continue;

		//	SetRowState(row, prop);
		//}
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
		//var colDatatype = grdProps.Columns[cColDatatype] as DataGridViewComboBoxColumn;
		//if (colDatatype == null)
		//	throw new ApplicationException($"Column {cColDatatype} is not a combo box column.");

		//colDatatype.HeaderText = "Data Type";
		//colDatatype.DataPropertyName = "DatatypeName";
		//colDatatype.Name = "DatatypeColumn";
		//colDatatype.DataSource = _datatypes;
		//colDatatype.DisplayMember = "Name"; // The property to display in the combo box
		//colDatatype.ValueMember = "Id"; // The property to use as the actual value
	}

	#region Cell Updates


	private void grdProps_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (e.Control is DataGridViewComboBoxEditingControl comboBox) {
			// Detach the event handler if it was previously attached
			comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted;
			// Attach the event handler
			comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
		}
	}

	// Fired when the combo dropdown selection is made
	private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
	{
		//var cmbCell = sender as DataGridViewComboBoxEditingControl;
		//var row = grdProps.Rows[cmbCell.EditingControlRowIndex];
		//var prop = GetPropFromRow(row);
		//if (prop == null)
		//	return;

		//var selectedStr = cmbCell.SelectedItem.ToString();

		//var idx = _primitiveTypes.Select(pt => pt.CSType).ToList().IndexOf(selectedStr);
		//if (idx > -1) {
		//	prop.PrimitiveType = _primitiveTypes[idx];
		//	prop.EnumType = null;

		//	// Set states of cells
		//	SetRowState(row, prop);

		//} else {
		//	var enumModel = Globals.DbContext.Enums.FirstOrDefault(e => e.Name == selectedStr);
		//	if (enumModel != null) {
		//		prop.EnumType = enumModel;
		//		prop.PrimitiveType = null;
		//	}
		//}
	}

	//private void CellUpdated_Datatype(DataGridViewComboBoxEditingControl comboBox, DataGridViewRow row, PropertyModel prop)
	//{
	//}

	private void SetRowState(DataGridViewRow row, Models.PropertyModel prop)
	{
		SetState_Datatype(row, prop);
		SetState_MaxLength(row, prop);
		SetState_IsIdentity(row, prop);
		SetState_IsIndexed(row, prop);
		SetState_IsIndexUnique(row, prop);
		SetState_IsIndexClustered(row, prop);
	}

	private void SetState_Datatype(DataGridViewRow row, Models.PropertyModel prop)
	{
		row.Cells[cColDatatype].ReadOnly = prop.IsForeignKey;
	}

	private void SetState_MaxLength(DataGridViewRow row, Models.PropertyModel prop)
	{
		if ((prop.PrimitiveType.Id == PrimitiveType.String.Id || prop.PrimitiveType.Id == PrimitiveType.ByteArray.Id)) {
			row.Cells[cColMaxLength].ReadOnly = prop.IsForeignKey; // Read-only if FK
			row.Cells[cColMaxLength].Style.ForeColor = row.Cells[0].Style.BackColor;

		} else {
			row.Cells[cColMaxLength].Style.ForeColor = Color.Black;
			row.Cells[cColMaxLength].ReadOnly = true;
		}
	}

	private void SetState_IsIdentity(DataGridViewRow row, Models.PropertyModel prop)
	{
		if ((bool)row.Cells[cColIsPrimaryKey].Value)
			row.Cells[cColIsIdentity].ReadOnly = prop.IsForeignKey;
		else
			row.Cells[cColIsIdentity].ReadOnly = true;
	}

	private void SetState_IsIndexed(DataGridViewRow row, Models.PropertyModel prop)
	{
		var isPrimaryKey = (bool)row.Cells[cColIsPrimaryKey].Value;
		if (isPrimaryKey || prop.IsForeignKey) {
			row.Cells[cColIsIndexed].ReadOnly = true;
			row.Cells[cColIsIndexed].Value = true;
		} else {
			row.Cells[cColIsIndexed].ReadOnly = false;
		}
	}

	private void SetState_IsIndexUnique(DataGridViewRow row, Models.PropertyModel prop)
	{
		row.Cells[cColIsIndexUnique].ReadOnly = prop.IsForeignKey || (bool)row.Cells[cColIsIndexed].Value;
	}

	private void SetState_IsIndexClustered(DataGridViewRow row, Models.PropertyModel prop)
	{
		row.Cells[cColIsIndexClustered].ReadOnly = prop.IsForeignKey || (bool)row.Cells[cColIsIndexed].Value;
	}

	#endregion

	#region Helpers

	private Models.PropertyModel GetPropFromRow(DataGridViewRow row)
	{
		if (!Guid.TryParse(row.Cells[cColId].Value?.ToString(), out Guid id))
			throw new ApplicationException("Unable to parse Id");

		return _entity.Properties.FirstOrDefault(p => p.Id == id);
	}

	#endregion

	private void grdProps_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		//switch (e.ColumnIndex) {
		//	case cColFK:
		//		var fkProp = GetPropFromRow(grdProps.Rows[e.RowIndex]);
		//		break;

		//	case cColDel:
		//		var delProp = GetPropFromRow(grdProps.Rows[e.RowIndex]);
		//		//_entity.Properties.Remove(delProp);

		//		//SetRowState(grdProps.Rows[e.RowIndex], delProp);
		//		this.InitializeGrid();

		//		break;

		//	default:
		//		break;
		//}


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
