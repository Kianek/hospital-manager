using System;
using System.Threading.Tasks;

namespace HospitalManager.Api.Patients
{
    public interface IPatientService
    {
        Task<Patient> RegisterPatient(PatientIntake intake);
        Task<Patient> GetPatientById(Guid patientId);
    }
}