using System;
using System.Collections.Generic;
using Shared.Infrastructure.db.models;

namespace Shared.Infrastructure.db;

public partial class RolPermission
{
    public int Id { get; set; }

    public int IdPermission { get; set; }

    public int IdRol { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual CtlPermission IdPermissionNavigation { get; set; } = null!;

    public virtual MntRol IdRolNavigation { get; set; } = null!;
}
