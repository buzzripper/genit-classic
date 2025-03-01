//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dyvenix.Genit.Config;
//internal class DbConnManager
//{
//	private readonly List<DbConn> _dbConns;

//	public DbConnManager(List<DbConn> dbConns)
//	{
//		_dbConns = dbConns;
//	}

//	public void Add(DbConn dbConn)
//	{
//		_dbConns.Add(dbConn);
//	}

//	public void Remove(DbConn dbConn)
//	{
//		_dbConns.Remove(dbConn);
//	}

//	public void Update(DbConn dbConn)
//	{
//		var existing = _dbConns.FirstOrDefault(x => x.Id == dbConn.Id);
//		if (existing != null)
//		{
//			existing.ConnString = dbConn.ConnString;
//		}
//	}

//	public DbConn Get(string name)
//	{
//		return _dbConns.FirstOrDefault(x => x.Name == name);
//	}

//	public List<DbConn> GetAll()
//	{
//		return _dbConns;
//	}
//}
