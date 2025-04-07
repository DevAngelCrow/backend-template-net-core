using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class CtlDistrict
{
    public int Id { get; set; }

    public int IdMunicipality { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? State { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual CtlMunicipality IdMunicipalityNavigation { get; set; } = null!;

    public virtual ICollection<MntAddress> MntAddresses { get; set; } = new List<MntAddress>();
}
