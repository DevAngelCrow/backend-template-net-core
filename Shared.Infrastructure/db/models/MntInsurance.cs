using System;
using System.Collections.Generic;
using Shared.Infrastructure.db.models;

namespace Shared.Infrastructure.db;

public partial class MntInsurance
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int IdPeople { get; set; }

    public int IdTypeMedicalInsurance { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? State { get; set; }

    public virtual MntPerson IdPeopleNavigation { get; set; } = null!;

    public virtual CtlTypeInsurance IdTypeMedicalInsuranceNavigation { get; set; } = null!;
}
