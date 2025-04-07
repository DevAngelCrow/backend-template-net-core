using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class MntUser
{
    public int Id { get; set; }

    public int IdPeople { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdStatus { get; set; }

    public DateTime LastAccess { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual MntPerson IdPeopleNavigation { get; set; } = null!;

    public virtual CtlStatusUser IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}
