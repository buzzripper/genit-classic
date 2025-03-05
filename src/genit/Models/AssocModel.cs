using System;
using System.Collections.Generic;
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

		public AssocModel(Guid id, EntityModel primaryEntityMdl, EntityModel relatedEntityMdl, string primaryPropertyName, string relatedPropertyName, CardinalityModel cardinality)
			: this(id, primaryEntityMdl.Id, relatedEntityMdl.Id, primaryPropertyName, relatedPropertyName, cardinality)
		{
			PrimaryEntity = primaryEntityMdl;
			RelatedEntity = relatedEntityMdl;
		}

		public AssocModel(Guid id, Guid primaryEntityMdlId, Guid relatedEntityMdlId, string primaryPropertyName, string relatedPropertyName, CardinalityModel cardinality)
		{
			Id = id;
			PrimaryEntityId = primaryEntityMdlId;
			PrimaryPropertyName = primaryPropertyName;
			RelatedEntityId = relatedEntityMdlId;
			RelatedPropertyName = relatedPropertyName;
			Cardinality = cardinality;
		}

		public void Initialize(EntityModel primaryEntityMdl, EntityModel relatedEntityMdl)
		{
			PrimaryEntity = primaryEntityMdl;
			RelatedEntity = relatedEntityMdl;
		}

		#endregion

		public Guid Id { get; init; }
		public Guid PrimaryEntityId { get; init; }
		public string PrimaryPropertyName { get; init; }
		public Guid RelatedEntityId { get; init; }
		public string RelatedPropertyName { get; init; }
		public CardinalityModel Cardinality { get; init; }

		[JsonIgnore]
		public EntityModel PrimaryEntity { get; private set; }
		[JsonIgnore]
		public EntityModel RelatedEntity { get; private set; }

		public void Validate(List<string> errorList)
		{
			if (string.IsNullOrWhiteSpace(PrimaryPropertyName))
				errorList.Add($"Invalid AssocModel. PrimaryPropertyName not defined.");

			if (string.IsNullOrWhiteSpace(RelatedPropertyName))
				errorList.Add($"Invalid AssocModel. RelatedPropertyName not defined.");

			if (this.PrimaryEntity == null)
				errorList.Add($"Invalid AssocModel for PrimaryPropertyName '{this.PrimaryPropertyName}'. No PrimaryEntity defined.");

			if (this.RelatedEntity == null)
				errorList.Add($"Invalid AssocModel for PrimaryPropertyName '{this.PrimaryPropertyName}'. No RelatedEntity defined.");

		}
	}
}



