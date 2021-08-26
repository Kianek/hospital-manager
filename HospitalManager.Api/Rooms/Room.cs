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
        public int NumberOfBeds { get; private set; }
        public int OccupiedBeds { get; private set; }
        public bool HasVacancy => NumberOfBeds > OccupiedBeds;

        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<Bed> Beds { get; set; }

        public Room(int roomNumber, Hospital hospital)
        {
            RoomNumber = roomNumber;
            Beds = new List<Bed>();
            NumberOfBeds = 0;
            OccupiedBeds = 0;
            HospitalId = hospital.Id;
            Hospital = hospital;
        }

        public Room()
        {
        }

        public void AddBed(Bed bed)
        {
            if (bed is null) throw new ArgumentNullException(nameof(bed));

            bed.Room = this;
            Beds.Add(bed);
            NumberOfBeds++;
        }

        public bool RemoveBed(Bed bed)
        {
            if (bed is null) throw new ArgumentNullException(nameof(bed));
            
            var bedRemoved = Beds.Remove(bed);

            if (bedRemoved)
            {
                NumberOfBeds--;
            }

            return bedRemoved;
        }

        public bool AssignPatientToBed(PatientBedAssignment assignment)
        {
            throw new NotImplementedException();
        }

        public bool RemovePatientFromBed(Bed bed)
        {
            throw new NotImplementedException();
        }
    }
}