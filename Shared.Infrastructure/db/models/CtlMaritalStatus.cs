using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class CtlMaritalStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<MntPerson> MntPeople { get; set; } = new List<MntPerson>();
}
