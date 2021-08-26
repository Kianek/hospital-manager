using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManager.Api.Patients;

namespace HospitalManager.Api.Rooms
{
    public interface IRoomService
    {
        Task<Room> GetRoomById(Guid roomId);
        Task<Room> GetRoomByRoomNumber(int roomNumber);
        Task<IEnumerable<Room>> GetRoomsByHospitalName(string name);
        Task AddBedsToRoom(int numberOfBedsToAdd = 1);
        Task RemoveBedFromRoom(Guid bedId);
        Task AssignPatient(PatientBedAssignment assignment);
    }
}