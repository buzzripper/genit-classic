using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models.Generators;

public class EnumGenModel : GenModelBase
{
	#region Static

	public static EnumGenModel CreateNew()
	{
		return new EnumGenModel(Guid.NewGuid()) {
			Enabled = true,
			InclHeader = true
		};
	}

	#endregion

	#region Ctors / Init

	public EnumGenModel(Guid id) : base(id, GeneratorType.Entity)
	{
	}

	#endregion

	#region Properties

	public string OutputFolder { get; set; }
	public string EnumsNamespace { get; set; }

	protected override string GetName() => "Enum Generator";

	#endregion
}