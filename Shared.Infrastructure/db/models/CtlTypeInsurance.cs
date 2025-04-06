using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class CtlTypeInsurance
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<MntInsurance> MntInsurances { get; set; } = new List<MntInsurance>();
}
