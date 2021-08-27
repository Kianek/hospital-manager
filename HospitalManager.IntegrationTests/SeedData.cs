using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManager.Api.Beds;
using HospitalManager.Api.Data;
using HospitalManager.Api.Hospitals;
using HospitalManager.Api.Patients;
using HospitalManager.UnitTests;

namespace HospitalManager.IntegrationTests
{
    public static class SeedData
    {
        public static void InitializeDatabase(AppDbContext context)
        {
            var hospitals = Models.Hospitals;
            
            hospitals[0].Rooms[0].AddBed(new Bed());
            hospitals[0].Rooms[0].AddBed(new Bed());
            hospitals[0].Rooms[0].AddBed(new Bed());
            context.Hospitals.AddRange(hospitals);

            var patients = Models.Patients;
            context.Patients.AddRange(patients);

            context.SaveChanges();
        }
        
    }
}