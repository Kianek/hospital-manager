using System;
using System.Collections.Generic;
using HospitalManager.Api.Beds;
using HospitalManager.Api.Data;
using HospitalManager.Api.Hospitals;
using HospitalManager.Api.Patients;

namespace HospitalManager.Api.Rooms
{
    public class Room : Entity
    {
        public int RoomNumber { get; }
        public int AvailableBeds { get; private set; }
        public bool HasVacancy => AvailableBeds > 0;

        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<Bed> Beds { get; set; }
        
        public Room(int roomNumber, Hospital hospital)
        {
            RoomNumber = roomNumber;
            Beds = new List<Bed>();
            AvailableBeds = 0;
            HospitalId = hospital.Id;
            Hospital = hospital;
        }
        
        public Room() {}

        public bool AddBed(Bed bed)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBed(Bed bed)
        {
            throw new NotImplementedException();
        }

        // Assigns the patient to the first available bed, if any
        public bool AssignPatientToBed(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool AssignPatientToBed(Patient patient, Bed bed)
        {
            throw new NotImplementedException();
        }

        public bool RemovePatientFromBed(Bed bed)
        {
            throw new NotImplementedException();
        }
    }
}