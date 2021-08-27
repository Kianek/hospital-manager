using System;
using HospitalManager.Api.Beds;
using HospitalManager.Api.Hospitals;
using HospitalManager.Api.Patients;
using HospitalManager.Api.Rooms;

namespace HospitalManager.UnitTests
{
    public static class Helpers
    {
        public static Hospital GetHospital(
            string name = "Sickhouse General", int numberOfRooms = 50)
            => new(name, numberOfRooms);

        public static Room GetRoom(
            int roomNumber = 1) => new(
            roomNumber, GetHospital()
        );

        public static Room GetRoomWithBed()
        {
            var room = GetRoom();
            room.AddBed(GetBed());
            return room;
        }

        public static Bed GetBed() => new(GetRoom());

        public static Patient GetPatient() => new("American", "McGee");

        public static PatientIntake GetPatientIntake() => new() { FirstName = "American", LastName = "McGee" };

        public static PatientBedAssignment GetBedAssignment(Room room, Bed bed = null, Patient patient = null)
        {
            var _room = room ?? GetRoom();

            return new(_room.RoomNumber, patient, bed);
        }

        public static PatientBedAssignmentRequest GetBedAssignmentRequest(
            Guid bedId, Guid patientId, string hospitalName = "Sickhouse General", int roomNumber = 1)
            => new(hospitalName, roomNumber, patientId, bedId);

        public static HospitalInfo GetHospitalInfo(string name = "Sickhouse General", int numberOfRooms = 10)
            => new(name, numberOfRooms);
    }
}