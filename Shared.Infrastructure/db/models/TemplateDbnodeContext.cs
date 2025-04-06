using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.db.models;

namespace Shared.Infrastructure.db;

public partial class TemplateDbnodeContext : DbContext
{
    public TemplateDbnodeContext()
    {
    }

    public TemplateDbnodeContext(DbContextOptions<TemplateDbnodeContext> options)
        : base(options)
    {
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=templateDBnode;User id=angel;Password=123a");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtlCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_country_pkey");

            entity.ToTable("ctl_country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasColumnType("character varying")
                .HasColumnName("abbreviation");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_department_pkey");

            entity.ToTable("ctl_department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.CtlDepartments)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("fk_country");
        });

        modelBuilder.Entity<CtlDistrict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_district_pkey");

            entity.ToTable("ctl_district");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
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
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdMunicipalityNavigation).WithMany(p => p.CtlDistricts)
                .HasForeignKey(d => d.IdMunicipality)
                .HasConstraintName("fk_municipality");
        });

        modelBuilder.Entity<CtlGender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_gender_pkey");

            entity.ToTable("ctl_gender");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlMaritalStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_marital_status_pkey");

            entity.ToTable("ctl_marital_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<CtlMunicipality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_municipality_pkey");

            entity.ToTable("ctl_municipality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdDepartament).HasColumnName("id_departament");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdDepartamentNavigation).WithMany(p => p.CtlMunicipalities)
                .HasForeignKey(d => d.IdDepartament)
                .HasConstraintName("fk_department");
        });

        modelBuilder.Entity<CtlPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_permission_pkey");

            entity.ToTable("ctl_permission");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlStatusPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_status_people_pkey");

            entity.ToTable("ctl_status_people");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlStatusRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_status_rol_pkey");

            entity.ToTable("ctl_status_rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UdpataedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("udpataed_at");
        });

        modelBuilder.Entity<CtlStatusUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_status_user_pkey");

            entity.ToTable("ctl_status_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlTypeDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_type_document_pkey");

            entity.ToTable("ctl_type_document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CtlTypeInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctl_type_insurance_pkey");

            entity.ToTable("ctl_type_insurance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DocumentPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_people_pkey");

            entity.ToTable("document_people");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdDocument).HasColumnName("id_document");
            entity.Property(e => e.IdPeople).HasColumnName("id_people");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdDocumentNavigation).WithMany(p => p.DocumentPeople)
                .HasForeignKey(d => d.IdDocument)
                .HasConstraintName("fk_document");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.DocumentPeople)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("fk_people");
        });

        modelBuilder.Entity<MntAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_address_pkey");

            entity.ToTable("mnt_address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Block)
                .HasColumnType("character varying")
                .HasColumnName("block");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Current).HasColumnName("current");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
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
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdDistrictNavigation).WithMany(p => p.MntAddresses)
                .HasForeignKey(d => d.IdDistrict)
                .HasConstraintName("fk_district");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.MntAddresses)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("fk_people");
        });

        modelBuilder.Entity<MntDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_document_pkey");

            entity.ToTable("mnt_document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdTypeDocument).HasColumnName("id_type_document");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdTypeDocumentNavigation).WithMany(p => p.MntDocuments)
                .HasForeignKey(d => d.IdTypeDocument)
                .HasConstraintName("fk_type_document");
        });

        modelBuilder.Entity<MntInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_insurance_pkey");

            entity.ToTable("mnt_insurance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
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
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.MntInsurances)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("fk_people");

            entity.HasOne(d => d.IdTypeMedicalInsuranceNavigation).WithMany(p => p.MntInsurances)
                .HasForeignKey(d => d.IdTypeMedicalInsurance)
                .HasConstraintName("fk_type_insurance");
        });

        modelBuilder.Entity<MntPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_people_pkey");

            entity.ToTable("mnt_people");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
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
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.MntPeople)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("fk_gender");

            entity.HasOne(d => d.IdMaritalStatusNavigation).WithMany(p => p.MntPeople)
                .HasForeignKey(d => d.IdMaritalStatus)
                .HasConstraintName("fk_marital_status");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.MntPeople)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("fk_status_people");
        });

        modelBuilder.Entity<MntRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_rol_pkey");

            entity.ToTable("mnt_rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.MntRols)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("fk_status_rol");
        });

        modelBuilder.Entity<MntUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mnt_user_pkey");

            entity.ToTable("mnt_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdPeople).HasColumnName("id_people");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.LastAccess)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("last_access");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.MntUsers)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("fk_people");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.MntUsers)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("fk_status_user");
        });

        modelBuilder.Entity<PeopleCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("people_country_pkey");

            entity.ToTable("people_country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdPeople).HasColumnName("id_people");
            entity.Property(e => e.State)
                .HasDefaultValue(true)
                .HasColumnName("state");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("update_at");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.PeopleCountries)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("fk_country");

            entity.HasOne(d => d.IdPeopleNavigation).WithMany(p => p.PeopleCountries)
                .HasForeignKey(d => d.IdPeople)
                .HasConstraintName("fk_people");
        });

        modelBuilder.Entity<RolPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rol_permission_pkey");

            entity.ToTable("rol_permission");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdPermission).HasColumnName("id_permission");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdPermissionNavigation).WithMany(p => p.RolPermissions)
                .HasForeignKey(d => d.IdPermission)
                .HasConstraintName("fk_permission");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolPermissions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_rol");
        });

        modelBuilder.Entity<UserRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_rol_pkey");

            entity.ToTable("user_rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_rol");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
