using Dyvenix.Genit.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class PropGridRowCtl : UserControl
{
	public event EventHandler<PropertyModelChangedEventArgs> PropertyModelChanged;
	public event EventHandler<RowMovedEventArgs> RowMoved;

	private readonly PropertyModel _propertyMdl;
	private bool _suspendUpdates;

	#region Ctors / Init

	public PropGridRowCtl()
	{
		InitializeComponent();
		this.Height = txtName.Height + 8;
	}

	public PropGridRowCtl(PropertyModel propertyMdl) : this()
	{
		_propertyMdl = propertyMdl;
	}

	private void PropGridRowCtl_Load(object sender, EventArgs e)
	{
		PopulateControls();
		picDrag.AllowDrop = true;
	}

	private void PopulateControls()
	{
		this.SuspendLayout();
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
		this.ResumeLayout();
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


	private void txtName_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_propertyMdl.Name = txtName.Text;
	}

	private void dtcDatatype_ValueChanged(object sender, DataTypeChangedEventArgs e)
	{
		if (!_suspendUpdates) {
			_propertyMdl.PrimitiveType = e.PrimitiveType;
			_propertyMdl.EnumType = e.EnumType;
			SetState();
		}
	}

	private void numMaxLength_ValueChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_propertyMdl.MaxLength = Convert.ToInt32(numMaxLength.Value);
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

	private void picDelete_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Are you sure you want to delete this property?", "Delete Property", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			return;

		PropertyModelChanged?.Invoke(this, new PropertyModelChangedEventArgs(ModelPropertyChangedAction.Deleted, _propertyMdl.Id, _propertyMdl));
	}

	private void picEditAssoc_Click(object sender, EventArgs e)
	{

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
		if (_propertyMdl.PrimitiveType?.Id == PrimitiveType.String.Id || _propertyMdl.PrimitiveType?.Id == PrimitiveType.ByteArray.Id) {
			numMaxLength.Visible = true;
		} else {
			numMaxLength.Visible = false;
		}

		numMaxLength.Enabled = !_propertyMdl.IsForeignKey;
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

	#region Rearrange Rows

	private void picDrag_MouseDown(object sender, MouseEventArgs e)
	{
		picDrag.DoDragDrop(_propertyMdl.Id.ToString(), DragDropEffects.Move);
	}

	private void picDrag_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Text)) {
			var picDrag = (PictureBox)sender;
			picDrag.BackColor = Color.DarkGray;
		}
		e.Effect = DragDropEffects.Move; // Show copy cursor
	}

	private void picDrag_DragLeave(object sender, EventArgs e)
	{
		var picDrag = sender as PictureBox;
		if (picDrag != null)
			picDrag.BackColor = SystemColors.Control;
	}

	private void picDrag_DragDrop(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Text)) {
			var srcIdStr = e.Data.GetData(DataFormats.Text) as string;
			if (srcIdStr != null)
				RowMoved?.Invoke(this, new RowMovedEventArgs(new Guid(srcIdStr), _propertyMdl.Id));

			var picDrag = sender as PictureBox;
			if (picDrag != null)
				picDrag.BackColor = SystemColors.Control;
		}
	}

	#endregion
}

#region Event Arg Classes

public enum ModelPropertyChangedAction
{
	Added,
	Deleted,
	Updated
}

public class PropertyModelChangedEventArgs : EventArgs
{
	public ModelPropertyChangedAction Action { get; }
	public Guid PropertyId { get; }
	public PropertyModel PropertyModel { get; }

	public PropertyModelChangedEventArgs(ModelPropertyChangedAction action, Guid propertyId, PropertyModel propMdl)
	{
		Action = action;
		PropertyId = propertyId;
		PropertyModel = propMdl;
	}
}

public class RowMovedEventArgs : EventArgs
{
	public Guid SourceId { get; }
	public Guid TargetId { get; }

	public RowMovedEventArgs(Guid sourceId, Guid targetId)
	{
		SourceId = sourceId;
		TargetId = targetId;
	}
}

#endregion

