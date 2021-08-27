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
            var hospitals = new List<Hospital>
            {
                new Hospital("Sickhouse General", 50),
                new Hospital("Generic Hospital", 50),
                new Hospital("Animal Hospital", 50),
            };
            
            hospitals[0].Rooms[0].AddBed(new Bed());
            hospitals[0].Rooms[0].AddBed(new Bed());
            hospitals[0].Rooms[0].AddBed(new Bed());
            context.Hospitals.AddRange(hospitals);

            var patients = new List<Patient>
            {
                new Patient("John", "Wayne"),
                new Patient("Michael", "Jackson"),
                new Patient("Some", "Guy"),
                new Patient("Lita", "Ford"),
            };
            context.Patients.AddRange(patients);

            context.SaveChanges();
        }
        
    }
}