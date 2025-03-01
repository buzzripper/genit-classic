using System;
using System.Collections.Generic;

namespace Dyvenix.Genit.DocModel;

public class EntityModel
{
	public Guid Id { get; set; }
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
}
