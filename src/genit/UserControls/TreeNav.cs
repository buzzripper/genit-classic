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

namespace Dyvenix.Genit.UserControls;

public partial class TreeNav : UserControl
{
	private const string cKey_Db = "db";
	private const string cKey_Entity = "ent";
	private const string cKey_Property = "prop";
	private const string cKey_Enum = "enum";
	private const string cKey_Assoc = "assoc";
	private const string cKey_Gen = "gen";

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
		TreeNode dbNode = new TreeNode(_dbContextModel.Name) {
			SelectedImageKey = cKey_Db,
			ImageKey = cKey_Db,
			Text = _dbContextModel.Name,
			Tag = _dbContextModel
		};
		treeView1.Nodes.Add(dbNode);
	}

	private void BuildEntitiesNode()
	{
		TreeNode entitiesNode = new TreeNode("Entities") {
			SelectedImageKey = cKey_Entity,
			ImageKey = cKey_Entity
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
		TreeNode enumsNode = new TreeNode("Enums") {
			SelectedImageKey = cKey_Enum,
			ImageKey = cKey_Enum
		};

		foreach (var enumMdl in _dbContextModel.Enums) {
			TreeNode enumNode = new TreeNode(enumMdl.Name) {
				Tag = enumMdl
			};
			enumsNode.Nodes.Add(enumNode);
		}

		treeView1.Nodes.Add(enumsNode);
		enumsNode.Collapse();
	}

	private void BuildAssocsNode()
	{
		TreeNode assocsNode = new TreeNode("Assocations") {
			SelectedImageKey = cKey_Assoc,
			ImageKey = cKey_Assoc
		};

		foreach (var assocMdl in _dbContextModel.Assocs) {
			TreeNode assocNode = new TreeNode(assocMdl.Name) {
				Tag = assocMdl
			};
			assocsNode.Nodes.Add(assocNode);
		}

		treeView1.Nodes.Add(assocsNode);
		assocsNode.Collapse();
	}

	private void BuildGeneratorsNode()
	{
		TreeNode assocsNode = new TreeNode("Generators") {
			SelectedImageKey = cKey_Gen,
			ImageKey = cKey_Gen
		};

		foreach (var assocMdl in _dbContextModel.Assocs) {
			TreeNode assocNode = new TreeNode(assocMdl.Name) {
				Tag = assocMdl
			};
			assocsNode.Nodes.Add(assocNode);
		}

		treeView1.Nodes.Add(assocsNode);
		assocsNode.Collapse();
	}

	private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
	{
	}
}
