using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.db.models;

namespace Shared.Infrastructure.db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CtlCountry> CtlCountry { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CtlCountry>().ToTable("ctl_country");

            modelBuilder.Entity<CtlCountry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Abbreviation).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Code).HasMaxLength(100).IsRequired();
                entity.Property(e => e.State).IsRequired();
            });
        }
    }
}
