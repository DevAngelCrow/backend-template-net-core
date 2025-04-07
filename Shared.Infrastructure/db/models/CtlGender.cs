using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class CtlGender
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<MntPerson> MntPeople { get; set; } = new List<MntPerson>();
}
