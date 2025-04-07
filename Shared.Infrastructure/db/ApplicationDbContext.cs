using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Infrastructure.db.models;

namespace Shared.Infrastructure.db;

public partial class ApplicationDbContext : DbContext
{
    private readonly IConfiguration configuration;   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    public virtual DbSet<CtlCountry> CtlCountries { get; set; }

    public virtual DbSet<CtlDepartment> CtlDepartments { get; set; }

    public virtual DbSet<CtlDistrict> CtlDistricts { get; set; }

    public virtual DbSet<CtlGender> CtlGenders { get; set; }

    public virtual DbSet<CtlMaritalStatus> CtlMaritalStatuses { get; set; }

    public virtual DbSet<CtlMunicipality> CtlMunicipalities { get; set; }

    public virtual DbSet<CtlPermission> CtlPermissions { get; set; }

    public virtual DbSet<CtlStatusPerson> CtlStatusPeople { get; set; }

    public virtual DbSet<CtlStatusRol> CtlStatusRols { get; set; }

    public virtual DbSet<CtlStatusUser> CtlStatusUsers { get; set; }

    public virtual DbSet<CtlTypeDocument> CtlTypeDocuments { get; set; }

    public virtual DbSet<CtlTypeInsurance> CtlTypeInsurances { get; set; }

    public virtual DbSet<DocumentPerson> DocumentPeople { get; set; }

    public virtual DbSet<MntAddress> MntAddresses { get; set; }

    public virtual DbSet<MntDocument> MntDocuments { get; set; }

    public virtual DbSet<MntInsurance> MntInsurances { get; set; }

    public virtual DbSet<MntPerson> MntPeople { get; set; }

    public virtual DbSet<MntRol> MntRols { get; set; }

    public virtual DbSet<MntUser> MntUsers { get; set; }

    public virtual DbSet<PeopleCountry> PeopleCountries { get; set; }

    public virtual DbSet<RolPermission> RolPermissions { get; set; }

    public virtual DbSet<UserRol> UserRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")).LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, Microsoft.Extensions.Logging.LogLevel.Information)
        .EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtlCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_country_pk");

            entity.ToTable("ctl_country");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasColumnType("character varying")
                .HasColumnName("abbreviation");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_department_pk");

            entity.ToTable("ctl_department");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.CtlDepartments)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("ctl_department_ctl_country_fk");
        });

        modelBuilder.Entity<CtlDistrict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_district_pk");

            entity.ToTable("ctl_district");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdMunicipality).HasColumnName("id_municipality");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdMunicipalityNavigation).WithMany(p => p.CtlDistricts)
                .HasForeignKey(d => d.IdMunicipality)
                .HasConstraintName("ctl_district_ctl_municipality_fk");
        });

        modelBuilder.Entity<CtlGender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_gender_pk");

            entity.ToTable("ctl_gender");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlMaritalStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_marital_status_pk");

            entity.ToTable("ctl_marital_status");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<CtlMunicipality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_municipality_pk");

            entity.ToTable("ctl_municipality");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdDepartament).HasColumnName("id_departament");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdDepartamentNavigation).WithMany(p => p.CtlMunicipalities)
                .HasForeignKey(d => d.IdDepartament)
                .HasConstraintName("ctl_municipality_ctl_department_fk");
        });

        modelBuilder.Entity<CtlPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_permission_pk");

            entity.ToTable("ctl_permission");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlStatusPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_status_people_pk");

            entity.ToTable("ctl_status_people");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlStatusRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_status_rol_pk");

            entity.ToTable("ctl_status_rol");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UdpataedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("udpataed_at");
        });

        modelBuilder.Entity<CtlStatusUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_status_user_pk");

            entity.ToTable("ctl_status_user");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlTypeDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_type_document_pk");

            entity.ToTable("ctl_type_document");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlTypeInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_type_insurance_pk");

            entity.ToTable("ctl_type_insurance");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DocumentPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_people_pk");

            entity.ToTable("document_people");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdDocument).HasColumnName("id_document");
            entity.Property(e => e.IdPeople).HasColumnName("id_people");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdDocumentNavigation).WithMany(p => p.DocumentPeople)
                .HasForeignKey(d => d.IdDocument)
                .HasConstraintName("document_people_mnt_document_fk");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.DocumentPeople)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("document_people_mnt_people_fk");
        });

        modelBuilder.Entity<MntAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_address_pk");

            entity.ToTable("mnt_address");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Block)
                .HasColumnType("character varying")
                .HasColumnName("block");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Current).HasColumnName("current");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.HouseNumber).HasColumnName("house_number");
            entity.Property(e => e.IdDistrict).HasColumnName("id_district");
            entity.Property(e => e.IdPeople).HasColumnName("id_people");
            entity.Property(e => e.Neighborhood)
                .HasColumnType("character varying")
                .HasColumnName("neighborhood");
            entity.Property(e => e.Pathway)
                .HasColumnType("character varying")
                .HasColumnName("pathway");
            entity.Property(e => e.Street)
                .HasColumnType("character varying")
                .HasColumnName("street");
            entity.Property(e => e.StreetNumber)
                .HasColumnType("character varying")
                .HasColumnName("street_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdDistrictNavigation).WithMany(p => p.MntAddresses)
                .HasForeignKey(d => d.IdDistrict)
                .HasConstraintName("mnt_address_ctl_district_fk");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.MntAddresses)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("mnt_address_mnt_people_fk");
        });

        modelBuilder.Entity<MntDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_document_pk");

            entity.ToTable("mnt_document");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdTypeDocument).HasColumnName("id_type_document");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdTypeDocumentNavigation).WithMany(p => p.MntDocuments)
                .HasForeignKey(d => d.IdTypeDocument)
                .HasConstraintName("mnt_document_ctl_type_document_fk");
        });

        modelBuilder.Entity<MntInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_insurance_pk");

            entity.ToTable("mnt_insurance");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdPeople).HasColumnName("id_people");
            entity.Property(e => e.IdTypeMedicalInsurance).HasColumnName("id_type_medical_insurance");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.MntInsurances)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("mnt_insurance_mnt_people_fk");

            entity.HasOne(d => d.IdTypeMedicalInsuranceNavigation).WithMany(p => p.MntInsurances)
                .HasForeignKey(d => d.IdTypeMedicalInsurance)
                .HasConstraintName("mnt_insurance_ctl_type_insurance_fk");
        });

        modelBuilder.Entity<MntPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_people_pk");

            entity.ToTable("mnt_people");

            entity.HasIndex(e => e.Email, "mnt_people_email_idx").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.HasInsurance).HasColumnName("has_insurance");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.IdMaritalStatus).HasColumnName("id_marital_status");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.ImgPath)
                .HasColumnType("character varying")
                .HasColumnName("img_path");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasColumnType("character varying")
                .HasColumnName("middle_name");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.MntPeople)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("mnt_people_ctl_gender_fk");

            entity.HasOne(d => d.IdMaritalStatusNavigation).WithMany(p => p.MntPeople)
                .HasForeignKey(d => d.IdMaritalStatus)
                .HasConstraintName("mnt_people_ctl_marital_status_fk");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.MntPeople)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("mnt_people_ctl_status_people_fk");
        });

        modelBuilder.Entity<MntRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_rol_pk");

            entity.ToTable("mnt_rol");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.MntRols)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("mnt_rol_ctl_status_rol_fk");
        });

        modelBuilder.Entity<MntUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_user_pk");

            entity.ToTable("mnt_user");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdPeople).HasColumnName("id_people");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.LastAccess)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_access");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.MntUsers)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("mnt_user_mnt_people_fk");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.MntUsers)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("mnt_user_ctl_status_user_fk");
        });

        modelBuilder.Entity<PeopleCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("people_country_pk");

            entity.ToTable("people_country");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdPeople).HasColumnName("id_people");
            entity.Property(e => e.State)
                .HasDefaultValue(true)
                .HasColumnName("state");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.PeopleCountries)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("people_country_ctl_country_fk");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.PeopleCountries)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("people_country_mnt_people_fk");
        });

        modelBuilder.Entity<RolPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rol_permission_pk");

            entity.ToTable("rol_permission");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdPermission).HasColumnName("id_permission");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdPermissionNavigation).WithMany(p => p.RolPermissions)
                .HasForeignKey(d => d.IdPermission)
                .HasConstraintName("rol_permission_ctl_permission_fk");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolPermissions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("rol_permission_mnt_rol_fk");
        });

        modelBuilder.Entity<UserRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_rol_pk");

            entity.ToTable("user_rol");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("user_rol_mnt_rol_fk");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("user_rol_mnt_user_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
