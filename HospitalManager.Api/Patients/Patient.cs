using System;
using HospitalManager.Api.Beds;
using HospitalManager.Api.Data;
using HospitalManager.Api.Rooms;

namespace HospitalManager.Api.Patients
{
    public class Patient : Entity
    {
        private Guid? _bedId;
        private Bed? _bed;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? RoomId { get; set; }
        public Room? Room { get; set; }
        public Guid? BedId { get; set; }

        public Bed? Bed
        {
            get => _bed;
            set
            {
                _bed = value;
                _bedId = Bed?.Id;
            }
        }
        
        public Patient(PatientIntake intake): 
            this(intake.FirstName, intake.LastName) {}
        
        public Patient(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Patient() {}

        public PatientDto AsDto() => new(this);
    }
}