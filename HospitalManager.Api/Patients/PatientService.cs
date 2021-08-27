using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManager.Api.Data;
using Microsoft.EntityFrameworkCore;

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
            // TODO: Validate intake info

            var patient = new Patient(intake);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientById(Guid patientId)
        {
            return await _context.Patients.FindAsync(patientId);
        }
    }
}