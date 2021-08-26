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

        public async Task<Patient> RegisterPatient(PatientIntake intake)
        {
            if (intake is null) throw new ArgumentNullException(nameof(intake));
            
            var patient = new Patient(intake);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient> GetPatientById(Guid patientId)
        {
            return await _context.Patients.FindAsync(patientId);
        }
    }
}