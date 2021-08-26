using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManager.Api.Data;
using HospitalManager.Api.Hospitals;
using Xunit;

namespace HospitalManager.UnitTests.Hospitals
{
    public class HospitalServiceTest : IClassFixture<DbFixture>
    {
        private readonly AppDbContext _context;
        private readonly IHospitalService _service;

        public HospitalServiceTest(DbFixture fixture)
        {
            _context = fixture.Context;
            _context.Database.EnsureCreated();
            _service = new HospitalService(_context);
        }

        [Fact]
        public async Task GetAllHospitals_HospitalsReturned()
        {
            var numberOfHospitals = 5;
            await PrepDbWithHospitals(numberOfHospitals);

            var hospitals = await _service.GetAllHospitals();
            
            Assert.True(hospitals.Count == numberOfHospitals);
        }

        [Fact]
        public async Task GetAllHospitals_NoHospitals_ReturnsEmptySequence()
        {
            var hospitals = await _service.GetAllHospitals();
            
            Assert.True(hospitals.Count == 0);
        }

        [Fact]
        public async Task GetHospitalById_HospitalFound_ReturnsHospital()
        {
            var savedHospitals = await PrepDbWithHospitals();
            var hospitalId = savedHospitals[0].Id;

            var result = await _service.GetHospitalById(hospitalId);
            
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetHospitalById_NotFound_ReturnsNull()
        {
            var result = await _service.GetHospitalById(Guid.NewGuid());
            
            Assert.Null(result);
        }

        [Fact]
        public async Task GetHospitalByName_HospitalFound_ReturnsHospital()
        {
            var hospitals = await PrepDbWithHospitals();
            var hospital = hospitals[0];

            var result = await _service.GetHospitalByName(hospital.Name);
            
            Assert.NotNull(result);
            Assert.True(hospital.Name == result.Name);
        }

        [Fact]
        public async Task GetHospitalByName_HospitalNotFound_ReturnsNull()
        {
            var result = await _service.GetHospitalByName("Nonexistent Hospital");
            
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateHospital_HospitalCreated_ReturnsHospital()
        {
            var info = Helpers.GetHospitalInfo();
            
            var result = await _service.CreateHospital(info);
            
            Assert.NotNull(result);
            Assert.Equal(info.Name, result.Name);
        }

        [Fact]
        public async Task CreateHospital_InvalidArgs_ThrowsException()
        {
            var info = Helpers.GetHospitalInfo(numberOfRooms: -4);
            
            await Assert.ThrowsAnyAsync<Exception>(() => _service.CreateHospital(info));
        }
        
        private async Task<List<Hospital>> PrepDbWithHospitals(int numberOfHospitals = 3)
        {
            var hospitals = new List<Hospital>();
            for (var i = 1; i <= numberOfHospitals; i++)
            {
                hospitals.Add(Helpers.GetHospital($"Hospital {i}", 10));
            }

            _context.Hospitals.AddRange(hospitals);
            await _context.SaveChangesAsync();

            return hospitals;
        }
    }
}