using System;

namespace Dyvenix.Genit.Models
{
    public class AssocModel
    {
		public Guid Id { get; set; }
		public Guid RelatedId { get; set; }
		public CardinalityModel Cardinality { get; set; }
		public string PropertyName { get; set; }
	}
}
