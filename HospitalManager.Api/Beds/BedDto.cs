using System;

namespace HospitalManager.Api.Beds
{
    public class BedDto
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid? PatientId { get; set; }
        public bool IsOccupied { get; set; }

        public BedDto(Bed bed)
        {
            Id = bed.Id;
            RoomId = bed.RoomId;
            PatientId = bed.PatientId;
            IsOccupied = bed.IsOccupied();
        }

        public BedDto()
        {
        }
    }
}