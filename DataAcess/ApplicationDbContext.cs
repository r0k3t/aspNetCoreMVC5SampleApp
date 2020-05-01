using System;
using System.IO;
using System.Linq;
using Core.Enums;
using Core.Interfaces.Types;
using Core.Models;
using DataAccess.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactAddress> ContactAddresses { get; set; }
        public virtual DbSet<ContactPhone> ContactPhones { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        

        public override int SaveChanges()
        {
            //var UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            const string UserId = "knagorski";

            base.ChangeTracker.DetectChanges();
            var added = base.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in added)
                if (entity is ITrackableEntity track)
                {
                    track.CreatedDate = DateTime.Now;
                    track.CreatedUser = UserId;
                    track.ModifiedDate = DateTime.Now;
                    track.ModifiedUser = UserId;
                }

            foreach (var entity in added)
                if (entity is ITrackable track)
                {
                    track.CreatedDate = DateTime.Now;
                    track.CreatedUser = UserId;
                    track.ModifiedDate = DateTime.Now;
                    track.ModifiedUser = UserId;
                }

            var modified = base.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in modified)
                if (entity is ITrackable track)
                {
                    track.ModifiedDate = DateTime.Now;
                    track.ModifiedUser = UserId;
                }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureTrackable<Address>();
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressOne)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.AddressTwo)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasColumnName("StateId")
                    .HasConversion(x => (int) x, x => (StateEnum) x);

                entity.Property(e => e.AddressType)
                    .HasColumnName("AddressTypeId")
                    .HasConversion(x => (int) x, x => (AddressTypeEnum) x);
            });

            modelBuilder.ConfigureTrackable<Contact>();
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactType)
                    .HasColumnName("ContactTypeId")
                    .HasConversion(x => (int) x, x => (ContactTypeEnum) x);
            });

            modelBuilder.ConfigureTrackable<ContactAddress>();
            modelBuilder.Entity<ContactAddress>(entity =>
            {
                entity.HasOne(ca => ca.Contact).WithMany(a => a.ContactAddresses).HasForeignKey(ca => ca.ContactId);
                entity.HasOne(ca => ca.Address).WithMany(c => c.ContactAddresses).HasForeignKey(ca => ca.AddressId);

                entity.ToTable("Contact_Address");
                entity.HasKey(i => new {i.ContactId, i.AddressId});

            });

            modelBuilder.ConfigureTrackable<ContactPhone>();
            modelBuilder.Entity<ContactPhone>(entity =>
            {
                entity.HasOne(ca => ca.Contact).WithMany(p => p.ContactPhoneNumbers).HasForeignKey(ca => ca.ContactId);
                entity.HasOne(ca => ca.Phone).WithMany(c => c.ContactPhoneNumbers).HasForeignKey(ca => ca.PhoneId);

                entity.ToTable("Contact_Phone");
                entity.HasKey(i => new {i.ContactId, i.PhoneId});
            });

            modelBuilder.ConfigureTrackable<Note>();
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Text)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.ConfigureTrackable<Phone>();
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.PhoneType)
                    .HasColumnName("PhoneTypeId")
                    .HasConversion(x => (int) x, x => (PhoneTypeEnum) x);
            });
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Get environment
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("TekOnSiteConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}