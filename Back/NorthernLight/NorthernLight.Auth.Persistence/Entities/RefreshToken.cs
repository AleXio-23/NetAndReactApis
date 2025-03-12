using System;
using System.Collections.Generic;

namespace NorthernLight.Auth.Persistence.Entities;

public partial class RefreshToken
{
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public virtual User? User { get; set; }
}
