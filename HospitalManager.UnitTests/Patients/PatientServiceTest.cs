using System;
using System.Threading.Tasks;
using HospitalManager.Api.Data;
using HospitalManager.Api.Patients;
using Xunit;

namespace HospitalManager.UnitTests.Patients
{
    public class PatientServiceTest : IClassFixture<DbFixture>
    {
        private readonly AppDbContext _context;
        private readonly IPatientService _service;

        public PatientServiceTest(DbFixture fixture)
        {
            _context = fixture.Context;
            _context.Database.EnsureCreated();
            _service = new PatientService(_context);
        }

        [Fact]
        public async Task RegisterPatient_IntakeValid_PatientCreated_ReturnsPatient()
        {
            var intake = Helpers.GetPatientIntake();

            var result = await _service.RegisterPatient(intake);
            
            Assert.NotNull(result);
            Assert.Equal(intake.FirstName, result.FirstName);
            Assert.Equal(intake.LastName, result.LastName);
        }

        [Fact]
        public async Task RegisterPatient_IntakeNull_ThrowsException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.RegisterPatient(null!));
        }

        [Fact]
        public async Task GetPatientById_ReturnsFoundPatient()
        {
            var patient = await _service.RegisterPatient(Helpers.GetPatientIntake());

            var result = await _service.GetPatientById(patient.Id);
            
            Assert.NotNull(result);
            Assert.Equal(patient.Id, result.Id);
        }

        [Fact]
        public async Task GetPatientById_PatientNotFound_ReturnsNull()
        {
            var result = await _service.GetPatientById(Guid.NewGuid());
            
            Assert.Null(result);
        }
    }
}