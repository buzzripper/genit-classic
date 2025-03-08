using Dyvenix.Genit.Generators;

namespace Dyvenix.Genit.Models;

public class EntityGenModel : GenModelBase
{
	public EntityGenModel()
	{
		GeneratorType = GeneratorType.Entity;
	}

	public bool InclHeader { get; set; }
	public string OutputRootFolder { get; set; }
	public bool Enabled { get; set; }

	protected override string GetName() => "Entity Generator";
}