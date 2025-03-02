using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class EntityModel
{
	[JsonConstructor]
	public EntityModel(DbContextModel dbContextModel, Guid id)
	{
		Id = id;
		DbContextModel = dbContextModel;
	}

	[JsonIgnore]
	public DbContextModel DbContextModel { get; set; }

	public Guid Id { get; private set; }
	public string Name { get; set; }
	public string Schema { get; set; }
	public string TableName { get; set; }
	public bool Enabled { get; set; }
	public string Namespace { get; set; }
	public List<string> Attributes { get; set; } = new List<string>();
	public List<string> AddlUsings { get; set; } = new List<string>();

	public bool InclSingleQuery { get; set; }
	public bool InclListQuery { get; set; }
	public bool UseListPaging { get; set; }
	public bool UseListSorting { get; set; }

	public List<PropertyModel> Properties { get; set; } = new List<PropertyModel>();
	public List<AssocModel> Assocs { get; set; } = new List<AssocModel>();

	public Guid AddForeignKey(AssocModel assoc)
	{
		var propId = Guid.NewGuid();
		var fkProp = new PropertyModel(this, propId) {
			FKAssocId = assoc.Id,
			Name = $"{assoc.PrimaryEntity.Name}Id"
		};

		this.Properties.Add(fkProp);

		return propId;
	}
}
