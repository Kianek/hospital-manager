using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Api.Patients
{
    [ApiController]
    [Route("api/[patients]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(PatientIntake intake)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{patientId:guid}")]
        public async Task<IActionResult> GetPatientById(Guid patientId)
        {
            throw new NotImplementedException();
        }
    }
}