using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class PropertyModel
{
	[JsonConstructor]
	public PropertyModel(EntityModel entityModel, Guid id)
	{
		Id = id;
		Entity = entityModel;
	}

	[JsonIgnore]
	public EntityModel Entity { get; set; }

	public Guid Id { get; private set; }
	public string Name { get; set; }
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PrimitveType PrimitiveType { get; set; }
	public EnumModel EnumType { get; set; }
	public bool Nullable { get; set; }
	public bool IsPrimaryKey { get; set; }
	public bool IsIdentity { get; set; }
	public int? MaxLength { get; set; }
	public Guid? FKAssocId { get; set; }

	public bool IsIndexed { get; set; }
	public bool IsIndexUnique { get; set; }
	public bool MultiIndex1 { get; set; }
	public bool MultiIndex1Unique { get; set; }
	public bool MultiIndex2 { get; set; }
	public bool MultiIndex2Unique { get; set; }

	public bool IsSortCol { get; set; }
	public bool IsSortDesc { get; set; }

	public List<string> Attributes { get; set; } = new List<string>();
	public List<string> AddlUsings { get; set; } = new List<string>();
}
