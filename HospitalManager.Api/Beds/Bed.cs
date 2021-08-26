using System;
using HospitalManager.Api.Data;
using HospitalManager.Api.Patients;
using HospitalManager.Api.Rooms;

namespace HospitalManager.Api.Beds
{
    public class Bed : Entity
    {

        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public Guid? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public Bed(Room room)
        {
            Room = room;
            RoomId = room.Id;
        }

        public Bed()
        {
        }

        public bool IsOccupied()
        {
            throw new NotImplementedException();
        }
        
        public bool AssignPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool RemovePatient()
        {
            throw new NotImplementedException();
        }
    }
}