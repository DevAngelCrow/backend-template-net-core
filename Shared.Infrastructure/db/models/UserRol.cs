using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class UserRol
{
    public int Id { get; set; }

    public int IdRol { get; set; }

    public int IdUser { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual MntRol IdRolNavigation { get; set; } = null!;

    public virtual MntUser IdUserNavigation { get; set; } = null!;
}
