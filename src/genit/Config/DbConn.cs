using System;

namespace Dyvenix.Genit.Config;

public class DbConn
{
	public DbConn()
	{
		Id = Guid.NewGuid();
	}

	public Guid Id { get; private set; }
	public string Name { get; set; }
	public string ConnString { get; set; }
	public bool IsDefault { get; set; }

	public override string ToString()
	{
		return Name;
	}
}