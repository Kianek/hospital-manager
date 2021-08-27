using System.Collections.Generic;
using HospitalManager.Api.Hospitals;
using HospitalManager.Api.Patients;

namespace HospitalManager.IntegrationTests
{
    public static class Models
    {
        public static List<Hospital> Hospitals => new List<Hospital>
        {
            new Hospital("Sickhouse General", 50),
            new Hospital("Generic Hospital", 50),
            new Hospital("Animal Hospital", 50),
        };

        public static List<Patient> Patients => new List<Patient>
        {
            new Patient("John", "Wayne"),
            new Patient("Michael", "Jackson"),
            new Patient("Some", "Guy"),
            new Patient("Lita", "Ford"),
        };
    }
}