using System;
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

		public AssocModel(Guid id, EntityModel primaryEntityMdl, EntityModel relatedEntityMdl, string primaryPropertyName, CardinalityModel cardinality)
			: this(id, primaryEntityMdl.Id, relatedEntityMdl.Id, primaryPropertyName, cardinality)
		{
			PrimaryEntity = primaryEntityMdl;
			RelatedEntity = relatedEntityMdl;
		}

		public AssocModel(Guid id, Guid primaryEntityMdlId, Guid relatedEntityMdlId, string primaryPropertyName, CardinalityModel cardinality)
		{
			Id = id;
			PrimaryEntityId = primaryEntityMdlId;
			RelatedEntityId = relatedEntityMdlId;
			PrimaryPropertyName = primaryPropertyName;
			Cardinality = cardinality;
		}

		public void Initialize(EntityModel primaryEntityMdl, EntityModel relatedEntityMdl)
		{
			PrimaryEntity = primaryEntityMdl;
			RelatedEntity = relatedEntityMdl;
		}

		#endregion

		public Guid Id { get; init; }
		public string PrimaryPropertyName { get; init; }
		public CardinalityModel Cardinality { get; init; }
		public Guid PrimaryEntityId { get; init; }
		public Guid? RelatedEntityId { get; init; }

		[JsonIgnore]
		public EntityModel PrimaryEntity { get; private set; }
		[JsonIgnore]
		public EntityModel RelatedEntity { get; private set; }
	}
}
