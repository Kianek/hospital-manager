using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManager.Api.Beds;
using HospitalManager.Api.Data;
using HospitalManager.Api.Patients;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Api.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Room> GetRoomById(string hospitalName, Guid roomId)
        {
            return await _context.Rooms
                .FindAsync(roomId);
        }

        public async Task<Room> GetRoomByRoomNumber(string hospitalName, int roomNumber)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetRoomsByHospitalName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Bed> AddBedsToRoom(RoomBedOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveBedFromRoom(Guid bedId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AssignPatient(PatientBedAssignment assignment)
        {
            throw new NotImplementedException();
        }
    }
}