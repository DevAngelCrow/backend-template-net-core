using System;
using System.Collections.Generic;
using Shared.Infrastructure.db.models;

namespace Shared.Infrastructure.db;

public partial class MntDocument
{
    public int Id { get; set; }

    public int IdTypeDocument { get; set; }

    public string? Description { get; set; }

    public bool? State { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<DocumentPerson> DocumentPeople { get; set; } = new List<DocumentPerson>();

    public virtual CtlTypeDocument IdTypeDocumentNavigation { get; set; } = null!;
}
