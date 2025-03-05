using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models;

public class PropertyModel
{
	private string _name;

	#region Ctors

	[JsonConstructor]
	public PropertyModel()
	{
	}

	public PropertyModel(Guid id)
	{
		Id = id;
	}

	#endregion

	public Guid Id { get; init; }
	public string Name
	{
		get {
			if (FKAssoc != null)
				return FKAssoc.RelatedPropertyName;
			return _name;
		}
		set {
			if (FKAssoc != null)
				throw new ApplicationException($"Can't rename property, it is a FK association property.");
			_name = value;
		}
	}
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PrimitiveType PrimitiveType { get; set; }
	public EnumModel EnumType { get; set; }
	public AssocModel FKAssoc { get; set; }
	public bool Nullable { get; set; }
	public bool IsPrimaryKey { get; set; }
	public bool IsIdentity { get; set; }
	public int MaxLength { get; set; }

	public bool IsIndexed { get; set; }
	public bool IsIndexUnique { get; set; }
	public bool IsIndexClustered { get; set; }
	public bool MultiIndex1 { get; set; }
	public bool MultiIndex1Unique { get; set; }
	public bool MultiIndex2 { get; set; }
	public bool MultiIndex2Unique { get; set; }

	public bool IsSortCol { get; set; }
	public bool IsSortDesc { get; set; }

	public List<string> Attributes { get; set; } = new List<string>();
	public List<string> AddlUsings { get; set; } = new List<string>();

	#region Methods

	public void Initialize(EntityModel primaryEntityMdl, EntityModel relatedEntityMdl)
	{
	}

	public bool Validate(string entityName, List<string> errorList)
	{
		var errs = new List<string>();

		if (this.PrimitiveType != PrimitiveType.None) {
			if (this.PrimitiveType == PrimitiveType.String) {
				if (this.MaxLength < 0)
					errs.Add($"Property {entityName}.{this.Name}: String values must have a MaxLength >= 0 (0 == NVARCHAR(MAX))");

			} else if (this.PrimitiveType == PrimitiveType.ByteArray) {
				if (this.MaxLength <= 0)
					errs.Add($"Property {entityName}.{this.Name}: Byte array type must have a MaxLength > 0");
			}

		} else if (this.EnumType != null) {


		} else if (this.FKAssoc != null) {


		} else {
			errs.Add($"Property {entityName}.{this.Name}: No data type defined.");
		}

		errorList.AddRange(errs);
		return (errs.Count == 0);
	}

	#endregion
}
