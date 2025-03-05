using System;
using System.Collections.Generic;

namespace Dyvenix.App1.Data.Entities;

public partial class AppUser
{
    public Guid Id { get; set; }

    public string IdentityId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Age { get; set; }

    public long? Population { get; set; }

    public bool? IsEnabled { get; set; }

    public double? Temp { get; set; }

    public byte[] VarBin { get; set; }

    public byte? TinyInteger { get; set; }

    public virtual ICollection<AccessClaim> AccessClaims { get; set; } = new List<AccessClaim>();
}
