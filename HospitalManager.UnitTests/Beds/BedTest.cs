using System;
using HospitalManager.Api.Beds;
using HospitalManager.Api.Patients;
using Xunit;

namespace HospitalManager.UnitTests.Beds
{
    public class BedTest
    {
        private readonly Bed _bed;
        private readonly Patient _patient;

        public BedTest()
        {
            _bed = new Bed();
            _patient = Helpers.GetPatient();
        }

        [Fact]
        public void AssignPatient_PatientNotNull_SetPatientAndPatientId_ReturnsTrue()
        {
            Assert.True(_bed.AssignPatient(_patient));
            Assert.True(_bed.Patient != null);
            Assert.True(_bed.PatientId != null);
        }

        [Fact]
        public void AssignPatient_PatientNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _bed.AssignPatient(null!));
        }

        [Fact]
        public void AssignPatient_IsOccupied_ReturnsFalse()
        {
            var patient = Helpers.GetPatient();
            _bed.AssignPatient(_patient);

            // Patient assignment unsuccessful
            Assert.False(_bed.AssignPatient(_patient));
        }

        [Fact]
        public void RemovePatient_PatientNotNull_SetsPatientToNull_ReturnsTrue()
        {
            _bed.AssignPatient(_patient);
            
            Assert.True(_bed.RemovePatient());
        }

        [Fact]
        public void RemovePatient_PatientNull_ReturnsFalse()
        {
            Assert.False(_bed.RemovePatient());
        }
    }
}