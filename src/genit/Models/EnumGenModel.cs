using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models;

public class EnumGenModel : GenModelBase
{
	public EnumGenModel(Guid id) : base(id, GeneratorType.Entity)
	{
	}

	public string OutputFolder { get; set; }

	protected override string GetName() => "Enum Generator";
}