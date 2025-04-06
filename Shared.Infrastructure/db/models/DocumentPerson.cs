using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class DocumentPerson
{
    public int Id { get; set; }

    public int IdDocument { get; set; }

    public int IdPeople { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual MntDocument IdDocumentNavigation { get; set; } = null!;

    public virtual MntPerson IdPeopleNavigation { get; set; } = null!;
}
