using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class CtlMunicipality
{
    public int Id { get; set; }

    public int IdDepartament { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CtlDistrict> CtlDistricts { get; set; } = new List<CtlDistrict>();

    public virtual CtlDepartment IdDepartamentNavigation { get; set; } = null!;
}
