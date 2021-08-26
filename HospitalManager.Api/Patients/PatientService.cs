using System;
using System.Threading.Tasks;
using HospitalManager.Api.Data;

namespace HospitalManager.Api.Patients
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> RegisterPatient(PatientIntake intake)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetPatientById(Guid patientId)
        {
            throw new NotImplementedException();
        }
    }
}