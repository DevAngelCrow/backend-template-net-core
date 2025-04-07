using System;
using System.Collections.Generic;

namespace Shared.Infrastructure.db.models;

public partial class MntPerson
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateOnly Birthdate { get; set; }

    public int IdGender { get; set; }

    public string Email { get; set; } = null!;

    public int IdMaritalStatus { get; set; }

    public string? ImgPath { get; set; }

    public string Phone { get; set; } = null!;

    public bool? HasInsurance { get; set; }

    public int IdStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<DocumentPerson> DocumentPeople { get; set; } = new List<DocumentPerson>();

    public virtual CtlGender IdGenderNavigation { get; set; } = null!;

    public virtual CtlMaritalStatus IdMaritalStatusNavigation { get; set; } = null!;

    public virtual CtlStatusPerson IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<MntAddress> MntAddresses { get; set; } = new List<MntAddress>();

    public virtual ICollection<MntInsurance> MntInsurances { get; set; } = new List<MntInsurance>();

    public virtual ICollection<MntUser> MntUsers { get; set; } = new List<MntUser>();

    public virtual ICollection<PeopleCountry> PeopleCountries { get; set; } = new List<PeopleCountry>();
}
