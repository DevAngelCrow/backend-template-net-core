using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class RolPermission
{
    public int Id { get; set; }

    public int IdPermission { get; set; }

    public int IdRol { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual CtlPermission IdPermissionNavigation { get; set; } = null!;

    public virtual MntRol IdRolNavigation { get; set; } = null!;
}
