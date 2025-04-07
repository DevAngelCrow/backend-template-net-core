using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class PeopleCountry
{
    public int Id { get; set; }

    public int IdPeople { get; set; }

    public int IdCountry { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public bool State { get; set; }

    public virtual CtlCountry IdCountryNavigation { get; set; } = null!;

    public virtual MntPerson IdPeopleNavigation { get; set; } = null!;
}
