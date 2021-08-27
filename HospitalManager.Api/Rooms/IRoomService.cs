using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManager.Api.Beds;
using HospitalManager.Api.Patients;

namespace HospitalManager.Api.Rooms
{
    public interface IRoomService
    {
        Task<Room> GetRoomById(string hospitalName, Guid roomId);
        Task<Room> GetRoomByRoomNumber(string hospitalName, int roomNumber);
        Task<List<Room>> GetRoomsByHospitalName(string name);
        Task<Bed> AddBedsToRoom(RoomBedOrder order);
        Task<bool> RemoveBedFromRoom(Guid bedId);
        Task<bool> AssignPatient(PatientBedAssignment assignment);
    }
}