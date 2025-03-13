using System;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class PropEditCtl : UserControlBase
{
	public PropEditCtl()
	{
		InitializeComponent();
	}

	public void Initialize(Models.PropertyModel property)
	{
		bindingSrc.DataSource = property;
		dataTypeCtl1.SetDataTypes(property.PrimitiveType, property.EnumType);
	}

	private void ckbPrimaryKey_CheckedChanged(object sender, EventArgs e)
	{
		ckbIsIdentity.Enabled = ckbPrimaryKey.Checked;
		ckbIsNullable.Enabled = !ckbPrimaryKey.Checked;
		if (ckbPrimaryKey.Checked)
			ckbIsNullable.Checked = false;

		if (ckbPrimaryKey.Checked && dataTypeCtl1.PrimitiveType == PrimitiveType.Int) {
			ckbIsIdentity.Enabled = true;
		} else {
			ckbIsIdentity.Enabled = false;
			ckbIsIdentity.Checked = false;
		}
	}

	private void ckbIsIndexed_CheckedChanged(object sender, EventArgs e)
	{
		ckbIsClustered.Enabled = ckbIsIndexed.Checked;

		if (ckbIsIndexed.Checked) {
			ckbIsIndexUnique.Enabled = true;
			ckbIsClustered.Enabled = true;

		} else {
			ckbIsIndexUnique.Enabled = false;
			ckbIsIndexUnique.Checked = false;
			ckbIsClustered.Enabled = false;
			ckbIsClustered.Checked = false;
		}
	}

	private void dataTypeCtl1_ValueChanged(object sender, DataTypeChangedEventArgs e)
	{
		if (e.PrimitiveType != null) {
			if (e.PrimitiveType == PrimitiveType.String) {
				numMaxLength.Enabled = true;
				ckbMaxStrLength.Enabled = true;

			} else if (e.PrimitiveType == PrimitiveType.ByteArray) {
				numMaxLength.Enabled = true;
				ckbMaxStrLength.Enabled = false;

			} else {
				numMaxLength.Enabled = false;
				ckbMaxStrLength.Enabled = false;
			}

			ckbIsIdentity.Enabled = (e.PrimitiveType == PrimitiveType.Int && ckbPrimaryKey.Enabled);

		} else if (e.EnumType != null) {
			numMaxLength.Enabled = false;
			ckbMaxStrLength.Enabled = false;

		} else {
			numMaxLength.Enabled = false;
			ckbMaxStrLength.Enabled = false;
		}
	}
}
