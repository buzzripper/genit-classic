using Dyvenix.Genit.Generators;
using System;

namespace Dyvenix.Genit.Models.Generators;

public class EntityGenModel : GenModelBase
{
	#region Static

	public static EntityGenModel CreateNew()
	{
		return new EntityGenModel(Guid.NewGuid()) {
			Enabled = true,
			InclHeader = true
		};
	}

	#endregion

	#region Ctors / Init

	public EntityGenModel(Guid id) : base(id, GeneratorType.Entity)
	{
	}

	#endregion

	#region Properties

	public string OutputFolder { get; set; }
	public string EntitiesNamespace { get; set; }

	protected override string GetName() => "Entity Generator";

	#endregion
}