using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models.Generators;

public class DbContextGenModel : GenModelBase
{
	public DbContextGenModel(Guid id) : base(id, GeneratorType.DbContext)
	{
	}

	public string OutputFolder { get; set; }
	public string ContextNamespace { get; set; }

	protected override string GetName() => "DbContext Generator";
}