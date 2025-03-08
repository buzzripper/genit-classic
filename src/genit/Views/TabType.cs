using System;

namespace Dyvenix.Genit.Views;

public class TabData
{
	public TabType TabType { get; set; }
	public Guid? Id { get; set; }
}

public enum TabType
{
	DbContext,
	Entities,
	Entity,
	Properties,
	Property,
	Enums,
	Enum,
	Assocs,
	Asooc,
	Generators,
	Generator
}

