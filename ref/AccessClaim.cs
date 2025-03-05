using System;
using System.Collections.Generic;

namespace Dyvenix.App1.Server.Entities;

public partial class AccessClaim
{
    public int Id { get; set; }

    public string ClaimName { get; set; }

    public string ClaimValue { get; set; }

    public Guid AppUserId { get; set; }

    public virtual AppUser AppUser { get; set; }
}
