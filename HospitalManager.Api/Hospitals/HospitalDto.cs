using System;
using System.Collections.Generic;
using System.Linq;
using HospitalManager.Api.Rooms;

namespace HospitalManager.Api.Hospitals
{
    public class HospitalDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }

        public HospitalDto(Hospital hospital)
        {
            Id = hospital.Id;
            Name = hospital.Name;
            CreatedAt = hospital.CreatedAt;
            LastModified = hospital.LastModified;
            NumberOfRooms = hospital.NumberOfRooms;
            Rooms = hospital.Rooms
                .Select(r => r.AsDto())
                .ToList();
        }

        public HospitalDto()
        {
        }
    }
}