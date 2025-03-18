using Dyvenix.Genit.Generators;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dyvenix.Genit.UserControls;

public partial class TreeNav : UserControl
{
	public event EventHandler<NavTreeNodeSelectedEventArgs> DbContextModelSelected;
	public event EventHandler<NavTreeNodeSelectedEventArgs> EntityModelSelected;
	public event EventHandler<NavTreeNodeSelectedEventArgs> EntitiesNodeSelected;
	public event EventHandler<NavTreeNodeSelectedEventArgs> EnumModelSelected;
	public event EventHandler<EntityDeletedEventArgs> EntityDeleted;
	public event EventHandler<EnumDeletedEventArgs> EnumDeleted;

	//public event EventHandler<PropertyModelEventArgs> PropertyModelSelected;
	//public event EventHandler<NavTreeNodeSelectedEventArgs> EnumsNodeSelected;
	//public event EventHandler<EventArgs> GeneratorsNodeSelected;
	public event EventHandler<GeneratorModelEventArgs> GeneratorModelSelected;

	private const string cKey_Db = "db";
	private const string cKey_Entity = "ent";
	private const string cKey_Property = "prop";
	private const string cKey_Enum = "enum";
	private const string cKey_Assoc = "assoc";
	private const string cKey_Gens = "gens";
	private const string cKey_Gen = "gen";

	private const string cNodeName_Db = "DbContext";
	private const string cNodeName_Entities = "Entities";
	private const string cNodeName_Enums = "Enums";
	private const string cNodeName_Assocs = "Assocations";
	private const string cNodeName_Gen = "Generators";

	private DbContextModel _dbContextModel;

	private TreeNode _dbContextNode;
	private TreeNode _entitiesNode;
	private TreeNode _enumsNode;
	private TreeNode _generatorsNode;

	public TreeNav()
	{
		InitializeComponent();
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DbContextModel DataSource
	{
		get {
			return _dbContextModel;
		}
		set {
			_dbContextModel = value;
			_dbContextModel.Entities.CollectionChanged += Entities_CollectionChanged;

			BuildTree();
			Populate();
		}
	}

	private void BuildTree()
	{
		treeView1.Nodes.Clear();

		if (_dbContextModel == null)
			return;

		_dbContextNode = this.BuildDbContextNode();

		_entitiesNode = this.BuildEntitiesNode();

		_enumsNode = this.BuildEnumsNode();

		_generatorsNode = this.BuildGeneratorsNode();

		//treeView1.SelectedNode = treeView1.Nodes[0];
	}

	public void Clear()
	{
		treeView1.Nodes.Clear();
	}

	private TreeNode BuildDbContextNode()
	{
		TreeNode dbNode = new TreeNode(cNodeName_Db) {
			SelectedImageKey = cKey_Db,
			ImageKey = cKey_Db,
			Tag = _dbContextModel.Id
		};
		treeView1.Nodes.Add(dbNode);

		return dbNode;
	}

	private TreeNode BuildEntitiesNode()
	{
		TreeNode entitiesNode = new TreeNode(cNodeName_Entities) {
			SelectedImageKey = cKey_Entity,
			ImageKey = cKey_Entity,
			Tag = _dbContextModel.Entities
		};

		treeView1.Nodes.Add(entitiesNode);

		return entitiesNode;
	}

	private TreeNode BuildEnumsNode()
	{
		TreeNode enumsNode = new TreeNode(cNodeName_Enums) {
			SelectedImageKey = cKey_Enum,
			ImageKey = cKey_Enum,
			Tag = Guid.NewGuid()
		};

		treeView1.Nodes.Add(enumsNode);
		enumsNode.Collapse();

		return enumsNode;
	}

	private TreeNode BuildGeneratorsNode()
	{
		TreeNode generatorsNode = new TreeNode(cNodeName_Gen) {
			SelectedImageKey = cKey_Gens,
			ImageKey = cKey_Gens,
			Tag = Guid.NewGuid()
		};

		treeView1.Nodes.Add(generatorsNode);
		generatorsNode.Collapse();

		return generatorsNode;
	}

	#region Populate methods

	private void Populate()
	{
		PopulateEntities();
		PopulateEnums();
		PopulateGenerators();
	}

	private void PopulateEntities()
	{
		_entitiesNode.Nodes.Clear();
		foreach (var entity in _dbContextModel.Entities) {
			TreeNode entNode = new TreeNode(entity.Name) {
				Name = entity.Id.ToString(),
				SelectedImageKey = cKey_Entity,
				ImageKey = cKey_Entity,
				Tag = entity.Id
			};
			_entitiesNode.Nodes.Add(entNode);
			entity.PropertyChanged += Entity_PropertyChanged;
		}
		_entitiesNode.Expand();
	}

	private void PopulateEnums()
	{
		_enumsNode.Nodes.Clear();
		foreach (var enumMdl in _dbContextModel.Enums) {
			TreeNode enumNode = new TreeNode(enumMdl.Name) {
				Name = enumMdl.Id.ToString(),
				SelectedImageKey = cKey_Enum,
				ImageKey = cKey_Enum,
				Tag = enumMdl.Id
			};
			_enumsNode.Nodes.Add(enumNode);
		}
		_enumsNode.Expand();
	}

	private void PopulateGenerators()
	{
		_generatorsNode.Nodes.Clear();

		foreach (var genMdl in _dbContextModel.Generators) {
			TreeNode genNode = new TreeNode(genMdl.Name) {
				Name = genMdl.Id.ToString(),
				SelectedImageKey = cKey_Gen,
				ImageKey = cKey_Gen,
				Tag = genMdl.Id
			};
			_generatorsNode.Nodes.Add(genNode);
		}
	}

	#endregion

	public bool Select(Guid id)
	{
		foreach (TreeNode node in treeView1.Nodes) {
			var tagId = node.Tag as Guid?;
			if (tagId.HasValue) {
				if (tagId.Value == id) {
					treeView1.SelectedNode = node;
					return true;
				}
			}
		}
		return false;
	}

	private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
	{
		// Top level nodes

		if (!Guid.TryParse(e.Node.Tag.ToString(), out Guid id))
			return;

		if (e.Node == _dbContextNode) {
			DbContextModelSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

		} else if (e.Node.Parent == _entitiesNode) {
			EntityModelSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

		} else if (e.Node == _enumsNode) {
			EntitiesNodeSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

		} else if (e.Node.Parent == _enumsNode) {
			EnumModelSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));
		}

		//} else if (e.Node.Text == cNodeName_Enums) {
		//	EnumsNodeSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

		//} else if (e.Node.Text == cNodeName_Gen) {
		//	GeneratorsNodeSelected?.Invoke(this, new EventArgs());

		// Other nodes

		//} else if (e.Node.Tag is EntityModel) {
		//	EntityModelSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

	}

	private void Entity_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name") {
			EntityModel entity = (EntityModel)sender;
			foreach (TreeNode node in _entitiesNode.Nodes) {
				if (node.Tag is Guid && (Guid)node.Tag == entity.Id) {
					node.Text = entity.Name;
					break;
				}
			}
		}
	}

	private void Entities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Remove) {
			foreach (EntityModel entity in e.OldItems) {
				foreach (TreeNode node in _entitiesNode.Nodes) {
					if (node.Tag is Guid && (Guid)node.Tag == entity.Id) {
						_entitiesNode.Nodes.Remove(node);
						break;
					}
				}
			}
		}
	}

	private void ctxMenuStrip_Opening(object sender, CancelEventArgs e)
	{
		if (treeView1.SelectedNode == _entitiesNode) {
			// Entities list
			mnuAdd.Text = "Add Entity";
			mnuAdd.Visible = true;
			mnuDelete.Visible = false;

		} else if (treeView1.SelectedNode.Parent == _entitiesNode) {
			// Single entity	
			mnuAdd.Visible = false;
			mnuDelete.Text = "Delete Entity";
			mnuDelete.Visible = true;

		} else if (treeView1.SelectedNode == _enumsNode) {
			// Enums list
			mnuAdd.Text = "Add Enum";
			mnuAdd.Visible = true;
			mnuDelete.Visible = false;


		} else if (treeView1.SelectedNode.Parent == _enumsNode) {
			// Single enum
			mnuAdd.Visible = false;
			mnuDelete.Text = "Delete Enum";
			mnuDelete.Visible = true;

		} else {
			e.Cancel = true;
		}
	}

	private void mnuAdd_Click(object sender, EventArgs e)
	{
		if (treeView1.SelectedNode == _entitiesNode) {
			AddNewEntity();

		} else if (treeView1.SelectedNode == _enumsNode) {
			AddNewEnum();
		}
	}

	private void mnuDelete_Click(object sender, EventArgs e)
	{
		if (treeView1.SelectedNode.Parent == _entitiesNode) {
			DeleteSelectedEntity();

		} else if (treeView1.SelectedNode.Parent == _enumsNode) {
			DeleteSelectedEnum();
		}
	}

	private void AddNewEntity()
	{
		var newEntityName = GetUniqueName("NewEntity");
		var newEntityMdl = new EntityModel(Guid.NewGuid()) {
			Name = newEntityName
		};
		_dbContextModel.Entities.Add(newEntityMdl);

		PopulateEnums();
		var nodes = _entitiesNode.Nodes.Find(newEntityMdl.Id.ToString(), false);
		if (nodes.Length == 0)
			MessageBox.Show("New node not found");

		treeView1.SelectedNode = nodes[0];
	}

	private void DeleteSelectedEntity()
	{
		var entityToDelete = _dbContextModel.Entities.FirstOrDefault(e => e.Id == Guid.Parse(treeView1.SelectedNode.Name));
		_dbContextModel.Entities.Remove(entityToDelete);
		
		_entitiesNode.Nodes.Remove(treeView1.SelectedNode);

		EntityDeleted?.Invoke(this, new EntityDeletedEventArgs(entityToDelete));
	}

	private void AddNewEnum()
	{
		var newEnumName = GetUniqueName("NewEnum");
		var newEnumMdl = new EnumModel {
			Id = Guid.NewGuid(),
			Name = newEnumName,
			IsExternal = false,
			IsFlags = false,
			Namespace = ""
		};
		_dbContextModel.Enums.Add(newEnumMdl);
		PopulateEnums();
		var nodes = _enumsNode.Nodes.Find(newEnumMdl.Id.ToString(), false);
		if (nodes.Length == 0)
			MessageBox.Show("New node not found");
		treeView1.SelectedNode = nodes[0];
	}

	private void DeleteSelectedEnum()
	{
		var enumToDelete = _dbContextModel.Enums.FirstOrDefault(e => e.Id == Guid.Parse(treeView1.SelectedNode.Name));
		_dbContextModel.Enums.Remove(enumToDelete);
		
		_enumsNode.Nodes.Remove(treeView1.SelectedNode);

		EnumDeleted?.Invoke(this, new EnumDeletedEventArgs(enumToDelete));
	}

	private string GetUniqueName(string prefix)
	{
		var name = prefix;
		var i = 1;
		while (_dbContextModel.Enums.Any(e => e.Name == name)) {
			name = $"{prefix}{i}";
			i++;
		}
		return name;
	}
}

public class NavTreeNodeSelectedEventArgs : EventArgs
{
	public Guid Id { get; }

	public NavTreeNodeSelectedEventArgs(Guid id)
	{
		Id = id;
	}
}

public class DbContextModelEventArgs : EventArgs
{
	public DbContextModel DbContext { get; }

	public DbContextModelEventArgs(DbContextModel dbContext)
	{
		DbContext = dbContext;
	}
}

public class EntitiesNodeEventArgs : EventArgs
{
	public List<EntityModel> Entities { get; }

	public EntitiesNodeEventArgs(List<EntityModel> entities)
	{
		Entities = entities;
	}
}

public class EntityModelEventArgs : EventArgs
{
	public EntityModel Entity { get; }

	public EntityModelEventArgs(EntityModel entity)
	{
		Entity = entity;
	}
}

public class PropertyModelEventArgs : EventArgs
{
	public Models.PropertyModel Property { get; }

	public PropertyModelEventArgs(Models.PropertyModel property)
	{
		Property = property;
	}
}

public class EnumsNodeEventArgs : EventArgs
{
	public List<EnumModel> Enums { get; }

	public EnumsNodeEventArgs(List<EnumModel> enums)
	{
		Enums = enums;
	}
}

public class EnumModelEventArgs : EventArgs
{
	public EnumModel Enum { get; }

	public EnumModelEventArgs(EnumModel enumModel)
	{
		Enum = enumModel;
	}
}

public class GeneratorModelEventArgs : EventArgs
{
	public GenModelBase GenModel { get; }

	public GeneratorModelEventArgs(GenModelBase genModel)
	{
		GenModel = genModel;
	}
}

public class EntityDeletedEventArgs : EventArgs
{
	public EntityModel Entity { get; }

	public EntityDeletedEventArgs(EntityModel entity)
	{
		Entity = entity;
	}
}

public class EnumDeletedEventArgs : EventArgs
{
	public EnumModel EnumModel { get; }

	public EnumDeletedEventArgs(EnumModel enumMdl)
	{
		EnumModel = enumMdl;
	}
}
