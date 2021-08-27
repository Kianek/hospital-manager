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
        public string HospitalName {get;set;}
        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<Bed>? Beds { get; set; } = new ();
        public List<Patient>? Patients { get; set; } = new();

        public Room(int roomNumber, Hospital hospital)
        {
            RoomNumber = roomNumber;
            NumberOfBeds = 0;
            OccupiedBeds = 0;
            HospitalName = hospital.Name;
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
            Beds?.Add(bed);
            NumberOfBeds = Beds.Count;
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
            if (assignment is null) throw new ArgumentNullException(nameof(assignment));
            if (assignment.Patient is null) throw new ArgumentNullException(nameof(assignment));
            
            var bed = Beds?.Find(b => b.Id == assignment.Bed.Id);
            if (bed is null || bed.IsOccupied) return false;

            var patient = assignment.Patient;
            patient.RoomId = Id;
            patient.Room = this;
            Patients?.Add(patient);
            bed.AssignPatient(patient);
            OccupiedBeds++;

            return true;
        }

        public bool RemovePatientFromBed(Bed occupiedBed)
        {
            var bed = Beds?.Find(b => b.Id == occupiedBed.Id);
            if (bed is null || !bed.IsOccupied) return false;
            
            bed.Patient = null;
            bed.PatientId = null;
            bed.IsOccupied = !bed.IsOccupied;
            OccupiedBeds--;
            
            return true;
        }
        
        public RoomDto AsDto() => new RoomDto(this);
    }
}