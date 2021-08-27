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
            return await _context.Rooms
                .Where(r => r.Hospital.Name == hospitalName)
                .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
        }

        public async Task<List<Room>> GetRoomsByHospitalName(string name)
        {
            return await _context.Rooms
                .AsNoTracking()
                .Where(r => r.Hospital.Name == name)
                .ToListAsync();
        }

        public async Task<Room> AddBedsToRoom(RoomBedOrder order)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));
            
            var room = await _context.Rooms
                .AsTracking()
                .Where(r => r.Hospital.Name == order.HospitalName)
                .FirstOrDefaultAsync(r => r.RoomNumber == order.RoomNumber);

            for (var i = 0; i < order.NumberOfBedsToAdd; i++)
            {
                room.AddBed(new Bed(room));
            }

            // TODO: does this still work if saved beds are present?
            _context.Beds.AddRange(room.Beds);
            _context.Rooms.Attach(room);
            await _context.SaveChangesAsync();
            return room;
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