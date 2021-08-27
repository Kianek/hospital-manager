using System;
using System.Threading.Tasks;
using HospitalManager.Api.Patients;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Api.Rooms
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        [HttpPatch("{roomNumber:int}/beds")]
        public async Task<IActionResult> AddBedsToRoom(RoomBedOrder order)
        {
            var result = await _service.AddBedsToRoom(order);

            if (result is null) return BadRequest(order);

            return Ok(result.AsDto());
        }

        [HttpPatch("{roomNumber:int}/beds/{bedId:guid}")]
        public async Task<IActionResult> AssignPatientToBed(PatientBedAssignmentRequest request)
        {
            var result = await _service.AssignPatient(request);

            // TODO: this could be either a bad request or not found
            if (!result) return BadRequest();

            return Ok();
        }

        [HttpDelete("{roomId:guid}/beds/{bedId:guid}")]
        public async Task<IActionResult> RemoveBedFromRoom(Guid roomId, Guid bedId)
        {
            var result = await _service.RemoveBedFromRoom(roomId, bedId);
            
            return result ? Ok() : BadRequest();
        }
    }
}