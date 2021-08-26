using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManager.Api.Hospitals
{
    public interface IHospitalService
    {
        Task<List<Hospital>> GetAllHospitals();
        Task<Hospital> GetHospitalById(Guid hospitalId);
        Task<Hospital> GetHospitalByName(string name);
        Task<int> CreateHospital(HospitalInfo info);
    }
}