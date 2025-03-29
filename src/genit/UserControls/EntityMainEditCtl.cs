using Dyvenix.Genit.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class EntityMainEditCtl : EntityEditCtlBase
{
	private const string cAddUsingsLabel = "Additional Usings";
	private const string cClassAttrsLabel = "Class Attributes";

	#region Fields

	private AssocEditForm _navPropEditForm;
	private StringListForm _slForm;

	#endregion

	#region Ctors / Init

	public EntityMainEditCtl() : base()
	{
	}

	public EntityMainEditCtl(EntityModel entity) : base(entity)
	{
		InitializeComponent();
	}

	private void EntityMainEditCtl_Load(object sender, EventArgs e)
	{
		this.PopulateControls();
	}

	private void PopulateControls()
	{
		_suspendUpdates = true;

		txtName.Text = _entity.Name;
		txtSchema.Text = _entity.Schema;
		txtTableName.Text = _entity.TableName;
		txtNamespace.Text = _entity.Namespace;
		ckbEnabled.Checked = _entity.Enabled;

		SetUsingsLabel();
		SetAttrsLabel();

		propGridCtl.DataSource = _entity.Properties;
		navPropGridCtl.DataSource = _entity.NavProperties;

		_suspendUpdates = false;
	}

	#endregion

	#region Properties

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public AssocEditForm NavPropEditForm
	{
		get {
			if (_navPropEditForm == null)
				_navPropEditForm = new AssocEditForm();
			return _navPropEditForm;
		}
	}

	#endregion

	#region Methods

	private void SetUsingsLabel()
	{
		lkbAddlUsings.Text = $"{cAddUsingsLabel} ({_entity.AddlUsings?.Count})";
	}

	private void SetAttrsLabel()
	{
		lkbClassAttributes.Text = $"{cClassAttrsLabel} ({_entity.Attributes?.Count})";
	}

	#endregion

	#region UI Events

	private void txtName_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.Name = txtName.Text;
	}

	private void txtNamespace_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.Namespace = txtNamespace.Text;
	}

	private void txtSchema_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.Schema = txtSchema.Text;
	}

	private void txtTableName_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.TableName = txtTableName.Text;
	}

	private void ckbEnabled_CheckedChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_entity.Enabled = ckbEnabled.Checked;
	}

	private void lkbAddNewProp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		_entity.Properties.Add(new PropertyModel(Guid.NewGuid()));
	}

	private void lkbAddNewNavProp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		if (NavPropEditForm.New() == DialogResult.Cancel)
			return;

		var navPropName = NavPropEditForm.NavPropertyName;
		var fkEntity = NavPropEditForm.FKEntity;
		var fkPropName = $"{_entity.Name}Id";
		var cardinality = NavPropEditForm.Cardinality;

		var assoc = new AssocModel();
		assoc.Id = Guid.NewGuid();
		assoc.PrimaryEntity = _entity;

		var navProperty = new NavPropertyModel(Guid.NewGuid(), assoc);
		navProperty.Name = navPropName;
		navProperty.Cardinality = cardinality;

		var fkProp = fkEntity.AddForeignKey(fkPropName, _entity, assoc);

		assoc.NavProperty = navProperty;
		assoc.FKEntity = navProperty.FKEntity;
		assoc.FKProperty = fkProp;

		navProperty.FKEntity = fkEntity;

		_entity.NavProperties.Add(navProperty);
		Doc.Instance.DbContexts[0].Assocs.Add(assoc);
	}

	private void navPropGridCtl_NavPropertyEdit(object sender, NavPropertyEditEventArgs e)
	{
		var navProperty = e.NavProperty;

		if (NavPropEditForm.Edit(navProperty.Name, navProperty.Cardinality, navProperty.FKEntity) == DialogResult.Cancel)
			return;

		navProperty.Name = NavPropEditForm.NavPropertyName;
		navProperty.Cardinality = NavPropEditForm.Cardinality;
		navProperty.FKEntity = NavPropEditForm.FKEntity;

		navPropGridCtl.Reload();
	}

	private void EditNavProp(NavPropertyModel navProp)
	{
		////See if the FK entity has changed
		//if (_assoc.FKEntity != entityListCtl.SelectedEntity) {
		//	// Remove the old fk property
		//	if (_assoc?.FKProperty != null)
		//		_assoc.FKEntity.Properties.Remove(_assoc.FKProperty);
		//	// Add the new
		//	_assoc.FKEntity = entityListCtl.SelectedEntity;
		//	_assoc.FKProperty = _assoc.FKEntity.AddForeignKey(txtFKPropName.Text, _assoc.PrimaryEntity);

		//} else {
		//	_assoc.FKProperty.Name = txtFKPropName.Text;
		//}

		//_assoc.NavProperty.Name = txtName.Text;
		//_assoc.Cardinality = (Cardinality)cmbCardinality.SelectedItem;
	}

	private void lkbAddlUsings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		this.StrListForm.Run("Additional Usings", _entity.AddlUsings);
		SetUsingsLabel();
	}

	private void lkbClassAttributes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		this.StrListForm.Run("Additional Usings", _entity.Attributes);
		SetAttrsLabel();
	}

	#endregion
}

