using System;

namespace HospitalManager.Api.Hospitals
{
    public class HospitalDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }

        public HospitalDto(Hospital hospital)
        {
            Id = hospital.Id;
            Name = hospital.Name;
            CreatedAt = hospital.CreatedAt;
            LastModified = hospital.LastModified;
        }

        public HospitalDto()
        {
        }
    }
}