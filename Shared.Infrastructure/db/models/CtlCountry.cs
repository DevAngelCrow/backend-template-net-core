using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class CtlCountry
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Abbreviation { get; set; }

    public string? Code { get; set; }

    public bool? State { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CtlDepartment> CtlDepartments { get; set; } = new List<CtlDepartment>();

    public virtual ICollection<PeopleCountry> PeopleCountries { get; set; } = new List<PeopleCountry>();
}
