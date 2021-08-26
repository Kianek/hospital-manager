using System;
using HospitalManager.Api.Data;
using HospitalManager.Api.Rooms;

namespace HospitalManager.Api.Patients
{
    public class Patient : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        
        public Patient(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Patient() {}
    }
}