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
    }
}