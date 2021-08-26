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
            Name = name;
            Rooms = GenerateRooms(numberOfRooms);
        }
        
        public Hospital() {}

        private List<Room> GenerateRooms(int numberOfRooms)
        {
            throw new NotImplementedException();
        }

        public HospitalDto AsDto() => new(this);
    }
}