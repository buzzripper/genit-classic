using Dyvenix.Genit.Generators;
using Dyvenix.Genit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class TreeNav : UserControl
{
	public event EventHandler<NavTreeNodeSelectedEventArgs> DbContextModelSelected;
	public event EventHandler<NavTreeNodeSelectedEventArgs> EntityModelSelected;
	public event EventHandler<NavTreeNodeSelectedEventArgs> EntitiesNodeSelected;

	public event EventHandler<PropertyModelEventArgs> PropertyModelSelected;
	public event EventHandler<EnumsNodeEventArgs> EnumsNodeSelected;
	public event EventHandler<EnumModelEventArgs> EnumModelSelected;
	public event EventHandler<AssocsNodeEventArgs> AssocsNodeSelected;
	public event EventHandler<AssocModelEventArgs> AssocModelSelected;
	public event EventHandler<EventArgs> GeneratorsNodeSelected;
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
			BuildTree();
		}
	}

	private void BuildTree()
	{
		treeView1.Nodes.Clear();

		if (_dbContextModel == null)
			return;

		this.BuildDbContextNode();
		this.BuildEntitiesNode();
		this.BuildEnumsNode();
		this.BuildAssocsNode();
		this.BuildGeneratorsNode();

		 treeView1.SelectedNode = treeView1.Nodes[0];
	}

	public void Clear()
	{
		treeView1.Nodes.Clear();
	}

	private void BuildDbContextNode()
	{
		TreeNode dbNode = new TreeNode(cNodeName_Db) {
			SelectedImageKey = cKey_Db,
			ImageKey = cKey_Db,
			Tag = _dbContextModel.Id
		};
		treeView1.Nodes.Add(dbNode);
	}

	private void BuildEntitiesNode()
	{
		TreeNode entitiesNode = new TreeNode(cNodeName_Entities) {
			SelectedImageKey = cKey_Entity,
			ImageKey = cKey_Entity,
			Tag = _dbContextModel.Entities
		};

		foreach (var entity in _dbContextModel.Entities) {
			TreeNode entNode = new TreeNode(entity.Name) {
				SelectedImageKey = cKey_Entity,
				ImageKey = cKey_Entity,
				Tag = entity.Id
			};
			entitiesNode.Nodes.Add(entNode);
		}

		treeView1.Nodes.Add(entitiesNode);
		entitiesNode.Expand();
	}

	private void BuildEnumsNode()
	{
		TreeNode enumsNode = new TreeNode(cNodeName_Enums) {
			SelectedImageKey = cKey_Enum,
			ImageKey = cKey_Enum,
			Tag = Guid.NewGuid()
		};

		foreach (var enumMdl in _dbContextModel.Enums) {
			TreeNode enumNode = new TreeNode(enumMdl.Name) {
				SelectedImageKey = cKey_Enum,
				ImageKey = cKey_Enum,
				Tag = enumMdl.Id
			};
			enumsNode.Nodes.Add(enumNode);
		}

		treeView1.Nodes.Add(enumsNode);
		enumsNode.Collapse();
	}

	private void BuildAssocsNode()
	{
		TreeNode assocsNode = new TreeNode(cNodeName_Assocs) {
			SelectedImageKey = cKey_Assoc,
			ImageKey = cKey_Assoc,
			Tag = Guid.NewGuid()
		};

		foreach (var assocMdl in _dbContextModel.Assocs) {
			TreeNode assocNode = new TreeNode(assocMdl.Name) {
				SelectedImageKey = cKey_Assoc,
				ImageKey = cKey_Assoc,
				Tag = assocMdl.Id
			};
			assocsNode.Nodes.Add(assocNode);
		}

		treeView1.Nodes.Add(assocsNode);
		assocsNode.Collapse();
	}

	private void BuildGeneratorsNode()
	{
		TreeNode gensNode = new TreeNode(cNodeName_Gen) {
			SelectedImageKey = cKey_Gens,
			ImageKey = cKey_Gens,
			Tag = Guid.NewGuid()
		};

		foreach (var genMdl in _dbContextModel.Generators) {
			TreeNode genNode = new TreeNode(genMdl.Name) {
				SelectedImageKey = cKey_Gen,
				ImageKey = cKey_Gen,
				Tag = genMdl.Id
			};
			gensNode.Nodes.Add(genNode);
		}

		treeView1.Nodes.Add(gensNode);
		gensNode.Collapse();
	}

	private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
	{
		// Top level nodes

		if (!Guid.TryParse(e.Node.Tag.ToString(), out Guid id))
			return;

		if (e.Node.Text == cNodeName_Db) {
			DbContextModelSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

		} else if (e.Node.Level == 1 && e.Node.Parent?.Text == cNodeName_Entities) {
			EntityModelSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

		} else if (e.Node.Text == cNodeName_Entities) {
			EntitiesNodeSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

		} else if (e.Node.Text == cNodeName_Enums) {
			EnumsNodeSelected?.Invoke(this, new EnumsNodeEventArgs((List<EnumModel>)e.Node.Tag));

		} else if (e.Node.Text == cNodeName_Assocs) {
			AssocsNodeSelected?.Invoke(this, new AssocsNodeEventArgs((List<AssocModel>)e.Node.Tag));

		} else if (e.Node.Text == cNodeName_Gen) {
			GeneratorsNodeSelected?.Invoke(this, new EventArgs());

			// Other nodes

		} else if (e.Node.Tag is EntityModel) {
			EntityModelSelected?.Invoke(this, new NavTreeNodeSelectedEventArgs(id));

		} else if (e.Node.Text == cNodeName_Enums) {
			EnumModelSelected?.Invoke(this, new EnumModelEventArgs((EnumModel)e.Node.Tag));
		}
	}

	public bool Select(Guid id)
	{
		foreach(TreeNode node in treeView1.Nodes) {
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
	public PropertyModel Property { get; }

	public PropertyModelEventArgs(PropertyModel property)
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

public class AssocsNodeEventArgs : EventArgs
{
	public List<AssocModel> Assocs { get; }

	public AssocsNodeEventArgs(List<AssocModel> assocs)
	{
		Assocs = assocs;
	}
}

public class AssocModelEventArgs : EventArgs
{
	public AssocModel Assoc { get; }

	public AssocModelEventArgs(AssocModel assoc)
	{
		Assoc = assoc;
	}
}

//public class GeneratorsNodeEventArgs : EventArgs
//{
//	public List<GenModelBase> Generators { get; }

//	public GeneratorsNodeEventArgs(List<IGenerator> generators)
//	{
//		Generators = generators;
//	}
//}

public class GeneratorModelEventArgs : EventArgs
{
	public GenModelBase GenModel { get; }

	public GeneratorModelEventArgs(GenModelBase genModel)
	{
		GenModel = genModel;
	}
}
