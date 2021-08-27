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

        public async Task<bool> RemoveBedFromRoom(Guid roomId, Guid bedId)
        {
            // TODO: what if the bed is occupied?
            var room = await _context.Rooms.FindAsync(roomId);
            var bed = room?.Beds.Find(b => b.Id == bedId);
            if (room is null || bed is null) return false;
            
            var result = room.RemoveBed(bed);
            _context.Beds.Remove(bed);
            _context.Rooms.Attach(room);
            await _context.SaveChangesAsync();
            
            return result;
        }

        public async Task<bool> AssignPatient(PatientBedAssignmentRequest request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            
            var room = await _context.Rooms
                .Where(r => r.Hospital.Name == request.HospitalName)
                .Include(r => r.Beds)
                .FirstAsync(r => r.RoomNumber == request.RoomNumber);
            var patient = await _context.Patients.FindAsync(request.PatientId);
            var bed = room.Beds.Find(b => b.Id == request.BedId);
            if (patient is null || bed is null) return false;
            
            var result = room.AssignPatientToBed(new PatientBedAssignment {Bed = bed, Patient = patient, RoomNumber = room.RoomNumber});

            _context.Beds.Attach(bed);
            _context.Patients.Attach(patient);
            _context.Rooms.Attach(room);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}