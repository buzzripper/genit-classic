using Dyvenix.Genit.Generators;
using System;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models.Generators;

public abstract class GenModelBase
{
	public GenModelBase(Guid id, GeneratorType generatorType)
	{
		Id = id;
		GeneratorType = generatorType;
	}

	public Guid Id { get; protected set; }
	public GeneratorType GeneratorType { get; protected set; }
	public bool Enabled { get; set; }
	public bool InclHeader { get; set; }

	[JsonIgnore]
	public string Name { get { return GetName(); } }

	protected abstract string GetName();
}