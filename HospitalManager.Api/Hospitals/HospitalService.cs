using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManager.Api.Data;

namespace HospitalManager.Api.Hospitals
{
    public class HospitalService : IHospitalService
    {
        private readonly AppDbContext _context;

        public HospitalService(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Hospital>> GetAllHospitals()
        {
            throw new NotImplementedException();
        }

        public Task<Hospital> GetHospitalById(Guid hospitalId)
        {
            throw new NotImplementedException();
        }

        public Task<Hospital> GetHospitalByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task CreateHospital(string name, int numberOfRooms)
        {
            throw new NotImplementedException();
        }

        public Task RenameHospital(string oldName, HospitalInfo updatedInfo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHospital(string name)
        {
            throw new NotImplementedException();
        }
    }
}