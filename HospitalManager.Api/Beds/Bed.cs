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
        public bool IsOccupied { get; set; } = false;

        public Bed(Room room)
        {
            Room = room;
            RoomId = room.Id;
        }

        public Bed()
        {
        }

        public bool AssignPatient(Patient patient)
        {
            if (patient is null)
                throw new ArgumentNullException(nameof(patient));

            if (IsOccupied) return false;

            PatientId = patient.Id;
            Patient = patient;
            patient.Bed = this;
            IsOccupied = !IsOccupied;

            return true;
        }

        public bool RemovePatient()
        {
            if (Patient is null) return false;
            
            PatientId = null;
            Patient = null;
            IsOccupied = !IsOccupied;
            
            return true;
        }

        public BedDto AsDto() => new(this);
    }
}