using System;
using System.Threading.Tasks;
using HospitalManager.Api.Data;
using HospitalManager.Api.Hospitals;
using HospitalManager.Api.Rooms;
using Xunit;

namespace HospitalManager.UnitTests.Rooms
{
    public class RoomServiceTest : IClassFixture<DbFixture>
    {
        private readonly AppDbContext _context;
        private readonly IRoomService _service;
        private readonly Hospital _hospital;

        public RoomServiceTest(DbFixture fixture)
        {
            _context = fixture.GetContext();
            _context.Database.EnsureCreated();
            _service = new RoomService(_context);
            _hospital = PrepDbWithHospitalAndRooms(5).GetAwaiter().GetResult();
        }

        [Fact]
        public async Task GetRoomById_RoomFound_ReturnsRoom()
        {
            var room = _hospital.Rooms[3];

            var result = await _service.GetRoomById(_hospital.Name, room.Id);
            
            Assert.NotNull(result);
            Assert.Equal(room.Id, result.Id);
        }

        [Fact]
        public async Task GetRoombyId_NotFound_ReturnsNull()
        {
            var result = await _service.GetRoomById(_hospital.Name, Guid.NewGuid());
            
            Assert.Null(result);
        }

        [Fact]
        public async Task GetRoomByRoomNumber_RoomFound_ReturnsRoom()
        {
            var result = await _service.GetRoomByRoomNumber(_hospital.Name, 1);
            
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetRoomByRoomNumber_NotFound_ReturnsNull()
        {
            var result = await _service.GetRoomByRoomNumber(_hospital.Name, 100);
            
            Assert.Null(result);
        }

        [Fact]
        public async Task GetRoomsByHospitalName_ReturnsRooms()
        {
            var result = await _service.GetRoomsByHospitalName(_hospital.Name);
            
            Assert.Equal(_hospital.Rooms.Count, result.Count);
        }

        [Fact]
        public async Task GetRoomsByHospitalName_NotFound_ReturnsEmptySequence()
        {
            var result = await _service.GetRoomsByHospitalName("Imaginary General");

            Assert.True(result.Count == 0);
        }

        [Fact]
        public async Task AddBedsToRoom_BedAdded()
        {
            var room = _hospital.Rooms[0];
            var bedOrder = new RoomBedOrder(_hospital.Name, room.RoomNumber, 1);

            var result = await _service.AddBedsToRoom(bedOrder);
            
            Assert.NotNull(result);
            Assert.Equal(result.Id, room.Id);
        }

        [Fact]
        public async Task AddBedsToRoom_RoomBedOrderNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.AddBedsToRoom(null!));
        }

        [Fact]
        public async Task RemoveBedFromRoom_BedRemoved_ReturnsTrue()
        {
            var bed = Helpers.GetBed();
            var room = _hospital.Rooms[0];
            
            room.AddBed(bed);
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            var result = await _service.RemoveBedFromRoom(bed.Id);

            Assert.True(result);
        }

        [Fact]
        public async Task RemoveBedFromRoom_BedNotFound_ReturnsFalse()
        {
            var result = await _service.RemoveBedFromRoom(Guid.NewGuid());

            Assert.False(result);
        }

        [Fact]
        public async Task AssignPatient_PatientAssigned_ReturnsTrue()
        {
            var patient = Helpers.GetPatient();
            var room = _hospital.Rooms[0];
            room.AddBed(Helpers.GetBed());
            var assignment = Helpers.GetBedAssignment(room, room.Beds[0], patient);

            var result = await _service.AssignPatient(assignment);
            
            Assert.True(result);
        }

        [Fact]
        public async Task AssignPatient_BedAssignInvalid_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.AssignPatient(null!));
        }

        private async Task<Hospital> PrepDbWithHospitalAndRooms(int numberOfRooms = 1)
        {
            var hospital = Helpers.GetHospital(numberOfRooms: numberOfRooms);
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();

            return hospital;
        }
    }
}