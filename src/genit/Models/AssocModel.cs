using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models
{
	public class AssocModel
	{
		#region Ctors

		[JsonConstructor]
		public AssocModel()
		{
		}

		public AssocModel(Guid id, EntityModel primaryEntityMdl, string name, EntityModel relatedEntityMdl, string relatedPropertyName, CardinalityModel cardinality)
		{
			Id = id;
			PrimaryEntity = primaryEntityMdl;
			PrimaryEntityId = primaryEntityMdl.Id;
			PrimaryPropertyName = name;
			RelatedEntity = relatedEntityMdl;
			RelatedEntityId = relatedEntityMdl.Id;
			RelatedPropertyName = relatedPropertyName;
			Cardinality = cardinality;

			PrimaryPKType = primaryEntityMdl.Properties.FirstOrDefault(p => p.IsPrimaryKey)?.PrimitiveType;
		}

		public void Initialize(EntityModel primaryEntityMdl, EntityModel relatedEntityMdl)
		{
			this.PrimaryEntity = primaryEntityMdl;
			this.RelatedEntity = relatedEntityMdl;
		}

		#endregion

		#region Properties 

		public Guid Id { get; init; }
		public Guid PrimaryEntityId { get; init; }
		public string PrimaryPropertyName { get; init; }
		public PrimitiveType PrimaryPKType { get; init; }
		public Guid RelatedEntityId { get; init; }
		public string RelatedPropertyName { get; init; }
		public CardinalityModel Cardinality { get; init; }

		[JsonIgnore]
		public EntityModel PrimaryEntity { get; private set; }
		[JsonIgnore]
		public EntityModel RelatedEntity { get; private set; }

		#endregion

		public void Validate(List<string> errorList)
		{
			if (string.IsNullOrWhiteSpace(PrimaryPropertyName))
				errorList.Add($"Invalid AssocModel. PrimaryPropertyName not defined.");

			if (PrimaryEntityId == Guid.Empty)
				errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No PrimaryEntityId defined.");

			if (this.PrimaryEntity == null)
				errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No PrimaryEntity defined.");

			if (string.IsNullOrWhiteSpace(RelatedPropertyName))
				errorList.Add($"Invalid AssocModel. RelatedPropertyName not defined.");

			if (RelatedEntityId == Guid.Empty)
				errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No RelatedEntityId defined.");

			if (this.RelatedEntity == null)
				errorList.Add($"Invalid AssocModel '{this.PrimaryPropertyName}'. No RelatedEntity defined.");

		}
	}
}