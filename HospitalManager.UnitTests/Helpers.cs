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
            => new (name, numberOfRooms);

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

        public static Patient GetPatient() => new ("American", "McGee");

        public static PatientBedAssignment GetBedAssignment()
        {
            var room = GetRoom();
            var bed = GetBed();
            var patient = GetPatient();

            return new(room.RoomNumber, patient, bed);
        }
    }
}