using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class CtlDepartment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int IdCountry { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CtlMunicipality> CtlMunicipalities { get; set; } = new List<CtlMunicipality>();

    public virtual CtlCountry IdCountryNavigation { get; set; } = null!;
}
