using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class CtlStatusRol
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UdpataedAt { get; set; }

    public virtual ICollection<MntRol> MntRols { get; set; } = new List<MntRol>();
}
