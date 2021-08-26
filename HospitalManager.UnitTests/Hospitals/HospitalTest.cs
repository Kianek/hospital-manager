using System;
using HospitalManager.Api.Hospitals;
using Xunit;

namespace HospitalManager.UnitTests.Hospitals
{
    public class HospitalTest
    {
        [Fact]
        public void Hospital_NameAndNumberOfBedsValid_InstantiatesSuccessfully()
        {
            var name = "Some Hospital";
            var hospital = new Hospital(name, 50);
            
            Assert.True(hospital != null);
            Assert.True(hospital.Name == name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Hospital_NumberOfRoomsZeroOrLess_ThrowsArgumentOutOfRangeException(int rooms)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => Helpers.GetHospital(numberOfRooms: rooms));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null!)]
        public void Hospital_NameEmptyOrNull_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => Helpers.GetHospital(name));
        }
    }
}