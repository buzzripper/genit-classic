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
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace Dyvenix.Genit.UserControls;

public partial class PropGridRowCtl : UserControl
{
	private readonly PropertyModel _propertyMdl;
	private bool _suspendUpdates;

	#region Ctors / Init

	public PropGridRowCtl()
	{
		InitializeComponent();
		this.Height = 35;
	}

	public PropGridRowCtl(PropertyModel propertyMdl) : this()
	{
		_propertyMdl = propertyMdl;
	}

	private void PropGridRowCtl_Load(object sender, EventArgs e)
	{
		PopulateControls();
	}

	private void PopulateControls()
	{
		_suspendUpdates = true;

		txtName.Text = _propertyMdl.Name;
		dtcDatatype.SetDataTypes(_propertyMdl.PrimitiveType, _propertyMdl.EnumType);
		numMaxLength.Value = _propertyMdl.MaxLength;
		ckbIsPrimaryKey.Checked = _propertyMdl.IsPrimaryKey;
		ckbIsIdentity.Checked = _propertyMdl.IsIdentity;
		ckbNullable.Checked = _propertyMdl.Nullable;
		ckbIsIndexed.Checked = _propertyMdl.IsIndexed;
		ckbIsIndexUnique.Checked = _propertyMdl.IsIndexUnique;
		ckbIsIndexClustered.Checked = _propertyMdl.IsIndexClustered;

		SetState();

		_suspendUpdates = false;
	}

	#endregion

	#region Properties

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Col1Width
	{
		get { return splName.SplitterDistance; }
		set { splName.SplitterDistance = value; }
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Col2Width
	{
		get { return splDatatype.SplitterDistance; }
		set { splDatatype.SplitterDistance = value; }
	}

	#endregion

	#region UI Events

	private void ckbAll_CheckedChanged(object sender, EventArgs e)
	{
		SetState();
	}

	private void dtcDatatype_ValueChanged(object sender, DataTypeChangedEventArgs e)
	{
		if (!_suspendUpdates) {
			_propertyMdl.PrimitiveType = e.PrimitiveType;
			_propertyMdl.EnumType = e.EnumType;
			SetState();
		}
	}

	private void ckbIsPrimaryKey_CheckedChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates) return;
		_propertyMdl.IsPrimaryKey = ckbIsPrimaryKey.Checked;
		SetState();
	}

	private void ckbIsIdentity_CheckedChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates) return;
		_propertyMdl.IsIdentity = ckbIsIdentity.Checked;
		SetState();
	}

	private void ckbNullable_CheckedChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates) return;
		_propertyMdl.Nullable = ckbNullable.Checked;
		SetState();
	}

	private void ckbIsIndexed_CheckedChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates) return;
		_propertyMdl.IsIndexed = ckbIsIndexed.Checked;
		SetState();
	}

	private void ckbIsIndexUnique_CheckedChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates) return;
		_propertyMdl.IsIndexUnique = ckbIsIndexUnique.Checked;
		SetState();
	}

	private void ckbIsIndexClustered_CheckedChanged(object sender, EventArgs e)
	{
		if (_suspendUpdates) return;
		_propertyMdl.IsIndexClustered = ckbIsIndexClustered.Checked;
		SetState();
	}

	#endregion

	#region State Management

	private void SetState()
	{
		SetState_Name();
		SetState_Datatype();
		SetState_MaxLength();
		SetState_IsPrimaryKey();
		SetState_IsIdentity();
		SetState_Nullable();
		SetState_IsIndexed();
		SetState_IsIndexUnique();
		SetState_IsIndexClustered();
	}

	private void SetState_Name()
	{
		txtName.Enabled = !_propertyMdl.IsForeignKey;
	}

	private void SetState_Datatype()
	{
		dtcDatatype.Enabled = !_propertyMdl.IsForeignKey;
	}

	private void SetState_MaxLength()
	{
		if (_propertyMdl.PrimitiveType.Id == PrimitiveType.String.Id || _propertyMdl.PrimitiveType.Id == PrimitiveType.ByteArray.Id) {
			//numMaxLength.ReadOnly = false;
			numMaxLength.Visible = true;
			//numMaxLength.ForeColor = SystemColors.Control;
		} else {
			numMaxLength.Visible = false;
			//numMaxLength.ReadOnly = true;
			//numMaxLength.ForeColor = Color.Black;
		}

		// Override readonly if it's a foreign key
		//if (_propertyMdl.IsForeignKey)
			//numMaxLength.ReadOnly = true;
	}

	private void SetState_IsPrimaryKey()
	{
		ckbIsPrimaryKey.Enabled = !_propertyMdl.IsForeignKey;
	}

	private void SetState_IsIdentity()
	{
		if (!ckbIsPrimaryKey.Checked)
			ckbIsIdentity.Checked = false;

		ckbIsIdentity.Enabled = ckbIsPrimaryKey.Checked;

		if (_propertyMdl.IsForeignKey)
			ckbIsIdentity.Enabled = !_propertyMdl.IsForeignKey;
	}

	private void SetState_Nullable()
	{
		if (ckbIsPrimaryKey.Checked) {
			ckbNullable.Checked = false;
			ckbNullable.Enabled = false;
		} else {
			ckbNullable.Enabled = true;
		}

		if (_propertyMdl.IsForeignKey)
			ckbNullable.Enabled = false;
	}

	private void SetState_IsIndexed()
	{
		if (ckbIsPrimaryKey.Checked) {
			ckbIsIndexed.Checked = true;
			ckbIsIndexed.Enabled = false;
		} else {
			ckbIsIndexed.Enabled = true;
		}

		if (_propertyMdl.IsForeignKey)
			ckbIsIndexed.Enabled = false;
	}

	private void SetState_IsIndexUnique()
	{
		if (ckbIsPrimaryKey.Checked) {
			ckbIsIndexUnique.Checked = true;
			ckbIsIndexUnique.Enabled = ckbIsIndexed.Checked;
		} else if (ckbIsIndexed.Checked) {
			ckbIsIndexUnique.Enabled = true;
		} else {
			ckbIsIndexUnique.Checked = false;
		}

		if (_propertyMdl.IsForeignKey)
			ckbIsIndexed.Enabled = false;
	}

	private void SetState_IsIndexClustered()
	{
		ckbIsIndexClustered.Enabled = ckbIsIndexed.Checked;

		if (!ckbIsIndexed.Checked) 
			ckbIsIndexClustered.Checked = false;

		if (_propertyMdl.IsForeignKey)
			ckbIsIndexClustered.Enabled = false;
	}

	#endregion
}
