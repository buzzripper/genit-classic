using System;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models.Generators;

public class GeneratorsModel
{
	public static GeneratorsModel CreateNew()
	{
		return new GeneratorsModel() {
			Id = Guid.NewGuid(),
			Enabled = true,
			TemplatesFolder = string.Empty,
			DbContextGen = DbContextGenModel.CreateNew(),
			EntityGen = EntityGenModel.CreateNew(),
			EnumGen = EnumGenModel.CreateNew(),
			ServiceGen = ServiceGenModel.CreateNew()
		};
	}

	public Guid Id { get; set; }
	public bool Enabled { get; set; }
	public string TemplatesFolder { get; set; }
	public DbContextGenModel DbContextGen { get; set; }
	public EntityGenModel EntityGen { get; set; }
	public EnumGenModel EnumGen { get; set; }
	public ServiceGenModel ServiceGen { get; set; }

	[JsonIgnore]
	public string Name => "Generators";
}