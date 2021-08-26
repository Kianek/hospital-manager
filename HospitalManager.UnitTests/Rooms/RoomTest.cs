using System;
using HospitalManager.Api.Beds;
using HospitalManager.Api.Patients;
using HospitalManager.Api.Rooms;
using Xunit;

namespace HospitalManager.UnitTests.Rooms
{
    public class RoomTest
    {
        private Room _room;
        private Bed _bed;
        private Patient _patient;

        public RoomTest()
        {
            _room = Helpers.GetRoom();
            _bed = Helpers.GetBed();
            _patient = Helpers.GetPatient();
        }

        [Fact]
        public void AddBed_BedAdded_AvailableBedsIncremented_ReturnsTrue()
        {
            var result = _room.AddBed(Helpers.GetBed());
            
            Assert.True(result);
            Assert.True(_room.Beds.Count == 1);
            Assert.True(_room.AvailableBeds == 1);
        }

        [Fact]
        public void AddBed_BedNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _room.AddBed(null!));
        }

        [Fact]
        public void RemoveBed_BedFoundAndRemoved_AvailableBedsDecremented_ReturnsTrue()
        {
            _room.AddBed(_bed);

            var result = _room.RemoveBed(_bed);
            
            Assert.True(result);
            Assert.True(_room.Beds.Count == 0);
            Assert.True(_room.AvailableBeds == 0);
        }

        [Fact]
        public void RemoveBed_BedNotFound_ReturnsFalse()
        {
            Assert.False(_room.RemoveBed(_bed));
        }

        [Fact]
        public void RemoveBed_BedNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _room.RemoveBed(null!));
        }

        [Fact]
        public void AssignBedToPatient_BedAvailableAndPatientValid_ReturnsTrue()
        {
            Assert.True(_room.AssignPatientToBed(Helpers.GetBedAssignment()));
        }

        [Fact]
        public void AssignBedToPatient_BedOccupied_ReturnsFalse()
        {
            _room.AddBed(_bed);
            _bed.AssignPatient(_patient);
            
            var bedAssignment = new PatientBedAssignment(_room.RoomNumber, _patient, _bed);
            var result = _room.AssignPatientToBed(bedAssignment);

            Assert.False(result);
        }

        [Fact]
        public void AssignBedToPatient_PatientNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _room.AssignPatientToBed(null!));
        }

        [Fact]
        public void AssignBedToPatient_PatientBedAssignmentNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _room.AssignPatientToBed(null!));
        }

        [Fact]
        public void RemovePatientFromBed_BedOccupied_PatientRemoved_ReturnsTrue()
        {
            _room.AddBed(_bed);
            _bed.AssignPatient(_patient);

            Assert.True(_room.RemovePatientFromBed(_bed));

        }

        [Fact]
        public void RemovePatientFromBed_BedUnoccupied_PatientRemoved_ReturnsTrue()
        {
            Assert.False(_room.RemovePatientFromBed(_bed));
        }
    }
}