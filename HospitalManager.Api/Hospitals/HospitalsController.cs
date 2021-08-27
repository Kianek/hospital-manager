using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Api.Hospitals
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalsController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{hospitalId:guid}")]
        public async Task<IActionResult> GetHospitalById(Guid hospitalId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{name:alpha}")]
        public async Task<IActionResult> GetHospitalByName(string name)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHospital(HospitalInfo hospital)
        {
            throw new NotImplementedException();
        }
    }
}