using System;
using System.Collections.Generic;
using System.Linq;
using HospitalManager.Api.Beds;

namespace HospitalManager.Api.Rooms
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfBeds { get; set; }
        public int OccupiedBeds { get; set; }
        public bool HasVacancy { get; set; }
        public string HospitalName { get; set; }
        public List<BedDto>? Beds { get; set; }

        public RoomDto(Room room)
        {
            Id = room.Id;
            RoomNumber = room.RoomNumber;
            OccupiedBeds = room.OccupiedBeds;
            HasVacancy = room.HasVacancy;
            HospitalName = room.HospitalName;
            Beds = room.Beds?
                .Select(b => b.AsDto())
                .ToList();
            NumberOfBeds = Beds!.Count;
        }

        public RoomDto()
        {
        }
    }
}