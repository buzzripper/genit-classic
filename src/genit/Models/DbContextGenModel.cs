using Dyvenix.Genit.Generators;

namespace Dyvenix.Genit.Models;

public class DbContextGenModel : GenModelBase
{
	public DbContextGenModel()
	{
		GeneratorType = GeneratorType.DbContext;
	}

	public bool InclHeader { get; set; }
	public string OutputFolder { get; set; }
	public bool Enabled { get; set; }

	protected override string GetName() => "DbContext Generator";
}