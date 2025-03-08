using Dyvenix.Genit.Generators;
using System;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public abstract class GenModelBase
{
	public Guid Id { get; set; }
	public GeneratorType GeneratorType { get; protected set; }
	public bool Enabled { get; set; }

	[JsonIgnore]
	public string Name { get { return GetName(); } }

	protected abstract string GetName();
}