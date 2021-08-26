using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManager.Api.Data;
using HospitalManager.Api.Patients;

namespace HospitalManager.Api.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Room> GetRoomById(Guid roomId)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetRoomByRoomNumber(int roomNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetRoomsByHospitalName(string name)
        {
            throw new NotImplementedException();
        }

        public Task AddBedsToRoom(int numberOfBedsToAdd = 1)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBedFromRoom(Guid bedId)
        {
            throw new NotImplementedException();
        }

        public Task AssignPatient(PatientBedAssignment assignment)
        {
            throw new NotImplementedException();
        }
    }
}