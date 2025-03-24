using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models.Generators;

public class ServiceGenModel : GenModelBase
{
	public ServiceGenModel(Guid id) : base(id, GeneratorType.Service)
	{
	}

	public string OutputFolder { get; set; }

	protected override string GetName() => "Service Generator";
}