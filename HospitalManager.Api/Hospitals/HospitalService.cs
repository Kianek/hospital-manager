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

        public async Task<Hospital> GetHospitalByName(string name)
        {
            return await _context.Hospitals
                .AsNoTracking()
                .Include(h => h.Rooms)
                .ThenInclude(r => r.Beds)
                .FirstOrDefaultAsync(h => h.Name == name);
        }

        public async Task<Hospital> CreateHospital(HospitalInfo info)
        {
            var hospital = new Hospital(info);
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();

            return hospital;
        }
    }
}