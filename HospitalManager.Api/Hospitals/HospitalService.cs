using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManager.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Api.Hospitals
{
    public class HospitalService : IHospitalService
    {
        private readonly AppDbContext _context;

        public HospitalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hospital>> GetAllHospitals()
        {
            return await _context.Hospitals
                .AsNoTracking()
                .Include(h => h.Rooms)
                .ThenInclude(r => r.Beds)
                .ToListAsync();
        }

        public async Task<Hospital> GetHospitalById(Guid hospitalId)
        {
            return await _context.Hospitals.FindAsync(hospitalId);
        }

        public Task<Hospital> GetHospitalByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateHospital(HospitalInfo info)
        {
            throw new NotImplementedException();
        }
    }
}