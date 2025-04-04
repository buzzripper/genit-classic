using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models.Generators;

public class EnumGenModel : GenModelBase
{
	public EnumGenModel(Guid id) : base(id, GeneratorType.Entity)
	{
	}

	public string OutputFolder { get; set; }
	public string EnumsNamespace { get; set; }

	protected override string GetName() => "Enum Generator";
}