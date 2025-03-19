using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models;

public class EntityGenModel : GenModelBase
{
	public EntityGenModel(Guid id) : base(id, GeneratorType.Entity)
	{
	}

	public string OutputFolder { get; set; }

	protected override string GetName() => "Entity Generator";
}