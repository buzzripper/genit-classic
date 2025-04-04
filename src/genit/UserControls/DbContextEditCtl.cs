using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.UserControls;

public partial class DbContextEditCtl : UserControlBase
{
	#region Fields

	private DbContextModel _dbContextMdl;

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
}
