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
using Dyvenix.Genit.Generators;
using System.CodeDom;

namespace Dyvenix.Genit.UserControls;

public partial class TreeNav : UserControl
{
	public event EventHandler<EntitiesNodeEventArgs> EntitiesNodeSelected;
	public event EventHandler<EntityModelEventArgs> EntityModelSelected;
	public event EventHandler<PropertyModelEventArgs> PropertyModelSelected;
	public event EventHandler<EnumsNodeEventArgs> EnumsNodeSelected;
	public event EventHandler<EnumModelEventArgs> EnumModelSelected;
	public event EventHandler<AssocsNodeEventArgs> AssocsNodeSelected;
	public event EventHandler<AssocModelEventArgs> AssocModelSelected;
	public event EventHandler<DbContextModelEventArgs> DbContextModelSelected;
	public event EventHandler<GeneratorModelEventArgs> GeneratorModelSelected;
	public event EventHandler<GeneratorsNodeEventArgs> GeneratorsNodeSelected;
	

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
	}

	private void BuildDbContextNode()
	{
		TreeNode dbNode = new TreeNode(cNodeName_Db) {
			SelectedImageKey = cKey_Db,
			ImageKey = cKey_Db,
			Tag = _dbContextModel
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
				Tag = entity
			};
			entitiesNode.Nodes.Add(entNode);
		}

		treeView1.Nodes.Add(entitiesNode);
		entitiesNode.Collapse();
	}

	private void BuildEnumsNode()
	{
		TreeNode enumsNode = new TreeNode(cNodeName_Enums) {
			SelectedImageKey = cKey_Enum,
			ImageKey = cKey_Enum
		};

		foreach (var enumMdl in _dbContextModel.Enums) {
			TreeNode enumNode = new TreeNode(enumMdl.Name) {
				SelectedImageKey = cKey_Enum,
				ImageKey = cKey_Enum,
				Tag = enumMdl
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
			ImageKey = cKey_Assoc
		};

		foreach (var assocMdl in _dbContextModel.Assocs) {
			TreeNode assocNode = new TreeNode(assocMdl.Name) {
				SelectedImageKey = cKey_Assoc,
				ImageKey = cKey_Assoc,
				Tag = assocMdl
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
			ImageKey = cKey_Gens
		};

		foreach (var genMdl in _dbContextModel.Generators) {
			TreeNode genNode = new TreeNode(genMdl.Name) {
				SelectedImageKey = cKey_Gen,
				ImageKey = cKey_Gen,
				Tag = genMdl
			};
			gensNode.Nodes.Add(genNode);
		}

		treeView1.Nodes.Add(gensNode);
		gensNode.Collapse();
	}

	private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
	{
		// Top level nodes

		if (e.Node.Text == cNodeName_Db) {
			DbContextModelSelected?.Invoke(this, new DbContextModelEventArgs((DbContextModel)e.Node.Tag));

		} else if (e.Node.Text == cNodeName_Entities) {
			EntitiesNodeSelected?.Invoke(this, new EntitiesNodeEventArgs((List<EntityModel>)e.Node.Tag));

		} else if (e.Node.Text == cNodeName_Enums) {
			EnumsNodeSelected?.Invoke(this, new EnumsNodeEventArgs((List<EnumModel>)e.Node.Tag));

		} else if (e.Node.Text == cNodeName_Assocs) {
			AssocsNodeSelected?.Invoke(this, new AssocsNodeEventArgs((List<AssocModel>)e.Node.Tag));

		} else if (e.Node.Text == cNodeName_Gen) {
			GeneratorsNodeSelected?.Invoke(this, new GeneratorsNodeEventArgs((List<IGeneratorModel>)e.Node.Tag));

			// Other nodes

		} else if (e.Node.Tag is EntityModel) {
			EntityModelSelected?.Invoke(this, new EntityModelEventArgs((EntityModel)e.Node.Tag));

		} else if (e.Node.Text == cNodeName_Enums) {
			EnumModelSelected?.Invoke(this, new EnumModelEventArgs((EnumModel)e.Node.Tag));
		}
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

public class GeneratorsNodeEventArgs : EventArgs
{
	public List<IGeneratorModel> Generators { get; }

	public GeneratorsNodeEventArgs(List<IGeneratorModel> generators)
	{
		Generators = generators;
	}
}

public class GeneratorModelEventArgs : EventArgs
{
	public IGeneratorModel Generator { get; }

	public GeneratorModelEventArgs(IGeneratorModel generator)
	{
		Generator = generator;
	}
}
