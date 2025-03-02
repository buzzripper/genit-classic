using System;
using System.Text.Json.Serialization;

namespace Dyvenix.Genit.Models
{
	public class AssocModel
	{
		#region Ctors

		public AssocModel(Guid id, EntityModel primaryEntityMdl, EntityModel relatedEntityMdl, string primaryPropertyName, CardinalityModel cardinality)
			: this(id, primaryEntityMdl, relatedEntityMdl, null, primaryPropertyName, cardinality)
		{
		}

		public AssocModel(Guid id, EntityModel primaryEntityMdl, EnumModel relatedEnumMdl, string primaryPropertyName, CardinalityModel cardinality)
			: this(id, primaryEntityMdl, null, relatedEnumMdl, primaryPropertyName, cardinality)
		{
		}

		[JsonConstructor]
		public AssocModel(Guid id, EntityModel primaryEntityMdl, EntityModel relatedEntityMdl, EnumModel relatedEnumMdl, string primaryPropertyName, CardinalityModel cardinality)
		{
			Id = id;
			PrimaryEntity = primaryEntityMdl;
			PrimaryEntityId = primaryEntityMdl.Id;
			PrimaryPropertyName = primaryPropertyName;

			RelatedEntity = relatedEntityMdl;
			RelatedEntityId = relatedEntityMdl?.Id;

			Cardinality = cardinality;
		}

		#endregion

		public Guid Id { get; private set; }
		public string PrimaryPropertyName { get; private set; }
		public CardinalityModel Cardinality { get; set; }
		public Guid PrimaryEntityId { get; private set; }
		public Guid? RelatedEntityId { get; private set; }

		[JsonIgnore]
		public EntityModel PrimaryEntity { get; private set; }
		[JsonIgnore]
		public EntityModel RelatedEntity { get; private set; }
	}
}
