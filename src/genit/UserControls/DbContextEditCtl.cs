using System.Windows.Forms;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class DbContextEditCtl : UserControlBase
{
	private DbContextModel _dbContextMdl;

	public DbContextEditCtl(DbContextModel dbContextMdl)
	{
		InitializeComponent();
		SetDbContext(dbContextMdl);
	}

	private void SetDbContext(DbContextModel dbContextMdl)
	{
		_dbContextMdl = dbContextMdl;

		txtName.Text = dbContextMdl.Name;
		txtContextNamespace.Text = dbContextMdl.ContextNamespace;
		txtEntitiesNamespace.Text = dbContextMdl.EntitiesNamespace;
		//txtEnumsNamespace.Text = dbContextMdl.EnumsNamespace;
		stringListEditor1.Items = dbContextMdl.AddlUsings;
	}

	private void stringListEditor1_ItemAdded(object sender, ItemAddedEventArgs e)
	{
		//_dbContextMdl.AddlUsings.Add(e.Value);
	}

	private void stringListEditor1_ItemChanged(object sender, ItemChangedEventArgs e)
	{
		//_dbContextMdl.AddlUsings[e.Index] = e.Value;
	}

	private void stringListEditor1_ItemDeleted(object sender, ItemDeletedEventArgs e)
	{
		//_dbContextMdl.AddlUsings.RemoveAt(e.Index);
	}

	private void DbContextEditCtl_Load(object sender, System.EventArgs e)
	{

	}
}
