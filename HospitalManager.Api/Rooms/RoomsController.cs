using System;
using System.Threading.Tasks;
using HospitalManager.Api.Patients;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Api.Rooms
{
    [ApiController]
    [Route("api/hospitals")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet("{hospitalName:alpha}")]
        public async Task<IActionResult> GetRoomsByHospitalName()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{hospitalName:alpha}/rooms/{roomId:guid}")]
        public async Task<IActionResult> GetRoomById(string hospitalName, Guid roomId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{hospitalName:alpha}/rooms/{roomNumber:int}")]
        public async Task<IActionResult> GetRoomByRoomNumber(string hospitalName, int roomNumber)
        {
            throw new NotImplementedException();
        }

        [HttpPatch("{hospitalName:alpha}/rooms/{roomNumber:int}/beds")]
        public async Task<IActionResult> AddBedsToRoom(RoomBedOrder order)
        {
            throw new NotImplementedException();
        }

        [HttpPatch("{hospitalName:alpha}/rooms/{roomNumber:int}/beds/{bedId:guid}")]
        public async Task<IActionResult> AssignPatientToBed(PatientBedAssignmentRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{hospitalName:alpha}/rooms/{roomNumber:int}/beds")]
        public async Task<IActionResult> RemoveBedFromRoom()
        {
            throw new NotImplementedException();
        }
    }
}