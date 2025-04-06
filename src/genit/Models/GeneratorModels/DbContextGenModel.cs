using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models.Generators;

public class DbContextGenModel : GenModelBase
{
	#region Static

	public static DbContextGenModel CreateNew()
	{
		return new DbContextGenModel(Guid.NewGuid()) {
			Enabled = true,
			InclHeader = true,
			OutputFolder = string.Empty,
			ContextNamespace = string.Empty
		};
	}

	#endregion

	#region Ctors / Init

	public DbContextGenModel(Guid id) : base(id, GeneratorType.DbContext)
	{
	}

	#endregion

	#region Properties

	public string OutputFolder { get; set; }
	public string ContextNamespace { get; set; }

	#endregion

	#region Methods

	protected override string GetName() => "DbContext Generator";

	#endregion
}