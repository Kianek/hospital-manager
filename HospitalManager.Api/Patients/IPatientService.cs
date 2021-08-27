using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManager.Api.Patients
{
    public interface IPatientService
    {
        Task<Patient> RegisterPatient(PatientIntake intake);
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(Guid patientId);
    }
}