using HospitalManager.Api.Beds;
using HospitalManager.Api.Hospitals;
using HospitalManager.Api.Patients;
using HospitalManager.Api.Rooms;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hospital>(entity =>
            {
                entity.HasKey(hospital => hospital.Id);
                
                entity.HasMany(h => h.Rooms)
                    .WithOne(r => r.Hospital)
                    .IsRequired();

                entity.Property(h => h.Name)
                    .HasMaxLength(200);
            });

            builder.Entity<Room>(entity =>
            {
                entity.HasKey(r => r.Id);
                
                entity.HasOne(r => r.Hospital)
                    .WithMany(h => h.Rooms)
                    .IsRequired();
                
                entity.HasMany(r => r.Beds)
                    .WithOne(b => b.Room);

                entity.HasMany(r => r.Patients)
                    .WithOne(p => p.Room)
                    .HasForeignKey(p => p.RoomId);

                entity.Property(r => r.RoomNumber)
                    .IsRequired();

                entity.Property(r => r.NumberOfBeds)
                    .HasDefaultValue(0);
                
                entity.Property(r => r.OccupiedBeds)
                    .HasDefaultValue(0);
            });

            builder.Entity<Bed>(entity =>
            {
                entity.HasKey(b => b.Id);
                
                entity.HasOne(b => b.Room)
                    .WithMany(r => r.Beds)
                    .IsRequired();

                entity.HasOne(b => b.Patient)
                    .WithOne(p => p.Bed);

                entity.Property(b => b.IsOccupied)
                    .HasDefaultValue(false);
            });

            builder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.Room)
                    .WithMany(r => r!.Patients)
                    .HasForeignKey(p => p.RoomId);
                
                entity.HasOne(p => p.Bed)
                    .WithOne(b => b.Patient)
                    .HasForeignKey<Bed>(b => b.PatientId);
                
                entity.Property(p => p.FirstName)
                    .HasMaxLength(200)
                    .IsRequired();
                
                entity.Property(p => p.LastName)
                    .HasMaxLength(200)
                    .IsRequired();
            });
        }
    }
}