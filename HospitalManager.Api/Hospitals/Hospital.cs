using System;
using System.Collections.Generic;
using HospitalManager.Api.Data;
using HospitalManager.Api.Rooms;

namespace HospitalManager.Api.Hospitals
{
    public class Hospital : Entity
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public Hospital(HospitalInfo info) : this(info.name, info.numberOfRooms)
        { }
        
        public Hospital(string name, int numberOfRooms)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            if (numberOfRooms <= 0) throw new ArgumentOutOfRangeException(nameof(numberOfRooms));
            
            Name = name;
            Rooms = GenerateRooms(numberOfRooms);
        }
        
        public Hospital() {}

        private List<Room> GenerateRooms(int numberOfRooms)
        {
            var rooms = new List<Room>(numberOfRooms);
            for (var i = 0; i < rooms.Capacity; i++)
            {
                rooms.Add(new Room(roomNumber: i + 1, this));
            }

            return rooms;
        }

        public HospitalDto AsDto() => new(this);
    }
}