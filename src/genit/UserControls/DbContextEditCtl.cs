using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class DbContextEditCtl : UserControlBase
{
	#region Fields

	private DbContextModel _dbContextMdl;
	private bool _suspendUpdates;

	#endregion

	#region Ctors / Init

	public DbContextEditCtl(DbContextModel dbContextMdl)
	{
		InitializeComponent();
		SetDbContext(dbContextMdl);
	}

	private void DbContextEditCtl_Load(object sender, System.EventArgs e)
	{
	}

	private void SetDbContext(DbContextModel dbContextMdl)
	{
		_suspendUpdates = true;

		_dbContextMdl = dbContextMdl;

		txtName.Text = dbContextMdl.Name;
		txtContextNamespace.Text = dbContextMdl.ContextNamespace;
		txtEntitiesNamespace.Text = dbContextMdl.EntitiesNamespace;
		txtEnumsNamespace.Text = dbContextMdl.EnumsNamespace;
		txtServicesNamespace.Text = dbContextMdl.ServicesNamespace;
		stringListEditor1.Items = dbContextMdl.AddlUsings;

		_suspendUpdates = false;
	}


	#endregion

	private void stringListEditor1_ItemAdded(object sender, ItemAddedEventArgs e)
	{
	}

	private void stringListEditor1_ItemChanged(object sender, ItemChangedEventArgs e)
	{
	}

	private void stringListEditor1_ItemDeleted(object sender, ItemDeletedEventArgs e)
	{
	}

	private void txtName_TextChanged(object sender, System.EventArgs e)
	{
		if (!_suspendUpdates)
			_dbContextMdl.Name = txtName.Text;
	}

	private void txtContextNamespace_TextChanged(object sender, System.EventArgs e)
	{
		if (!_suspendUpdates)
			_dbContextMdl.ContextNamespace = txtContextNamespace.Text;
	}

	private void txtEntitiesNamespace_TextChanged(object sender, System.EventArgs e)
	{
		if (!_suspendUpdates)
			_dbContextMdl.EntitiesNamespace = txtEntitiesNamespace.Text;
	}

	private void txtEnumsNamespace_TextChanged(object sender, System.EventArgs e)
	{
		if (!_suspendUpdates)
			_dbContextMdl.EnumsNamespace = txtEnumsNamespace.Text;
	}

	private void txtServicesNamespace_TextChanged(object sender, System.EventArgs e)
	{
		if (!_suspendUpdates)
			_dbContextMdl.ServicesNamespace = txtServicesNamespace.Text;
	}
}
