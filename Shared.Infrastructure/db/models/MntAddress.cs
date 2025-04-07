using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class MntAddress
{
    public int Id { get; set; }

    public int IdPeople { get; set; }

    public string? Street { get; set; }

    public string? StreetNumber { get; set; }

    public string? Neighborhood { get; set; }

    public int IdDistrict { get; set; }

    public int HouseNumber { get; set; }

    public string? Block { get; set; }

    public string? Pathway { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? Current { get; set; }

    public bool Active { get; set; }

    public virtual CtlDistrict IdDistrictNavigation { get; set; } = null!;

    public virtual MntPerson IdPeopleNavigation { get; set; } = null!;
}
