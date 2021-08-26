using System;

namespace HospitalManager.Api.Patients
{
    public class PatientDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? RoomId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }

        public PatientDto(Patient patient)
        {
            Id = patient.Id;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            RoomId = patient.RoomId;
            CreatedAt = patient.CreatedAt;
            LastModified = patient.LastModified;
        }

        public PatientDto()
        {
        }
    }
}