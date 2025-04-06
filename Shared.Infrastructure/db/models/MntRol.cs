using System;
using System.Collections.Generic;
using Shared.Infrastructure.db.models;

namespace Shared.Infrastructure.db;

public partial class MntRol
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int IdStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual CtlStatusRol IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<RolPermission> RolPermissions { get; set; } = new List<RolPermission>();

    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}
