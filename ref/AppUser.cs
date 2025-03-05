using System;
using System.Collections.Generic;

namespace Dyvenix.App1.Server.Entities;

public partial class AppUser
{
    public Guid Id { get; set; }

    public string IdentityId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public virtual ICollection<AccessClaim> AccessClaims { get; set; } = new List<AccessClaim>();
}
