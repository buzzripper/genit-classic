using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models.Generators;

public class IntTestsGenModel : GenModelBase
{
	#region Static

	public static IntTestsGenModel CreateNew()
	{
		return new IntTestsGenModel(Guid.NewGuid()) {
			Enabled = true,
			InclHeader = true
		};
	}

	#endregion

	#region Ctors / Init

	public IntTestsGenModel(Guid id) : base(id, GeneratorType.IntegrationTest)
	{
	}

	#endregion

	#region Properties

	public string OutputFolder { get; set; }
	public string Namespace { get; set; }

	#endregion

	#region Methods

	protected override string GetName() => "Integration Tests";

	#endregion
}