using System.Linq;
using System.Threading.Tasks;
using HospitalManager.Api.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Api.Hospitals
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;
        private readonly IRoomService _roomService;

        public HospitalsController(IHospitalService hospitalService, IRoomService roomService)
        {
            _hospitalService = hospitalService;
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
            var result = await _hospitalService.GetAllHospitals();
            return Ok(result);
        }

        [HttpGet("{name:alpha}")]
        public async Task<IActionResult> GetHospitalByName(string name)
        {
            var result = await _hospitalService.GetHospitalByName(name);

            if (result is null) return NotFound(name);

            return Ok(result.AsDto());
        }
        
        [HttpGet("{hospitalName:alpha}/rooms")]
        public async Task<IActionResult> GetAllHospitalRooms(string hospitalName)
        {
            var result =  await _roomService.GetRoomsByHospitalName(hospitalName);
            
            return Ok(result.Select(r => r.AsDto()).ToList());
        }
        
        [HttpGet("{hospital:alpha}/rooms/{roomNumber:int}")]
        public async Task<IActionResult> GetHospitalRoomByNumber(string hospital, int roomNumber)
        {
            var result = await _roomService.GetRoomByRoomNumber(hospital, roomNumber);

            if (result is null) return NotFound(new { Hospital = hospital, RoomId = roomNumber });
            
            return Ok(result.AsDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateHospital(HospitalInfo hospital)
        {
            var result = await _hospitalService.CreateHospital(hospital);

            if (result is null) return BadRequest();

            return CreatedAtAction(nameof(CreateHospital), result.AsDto());
        }
    }
}