using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManager.Api.Hospitals
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetAllHospitals();
        Task<Hospital> GetHospitalById(Guid hospitalId);
        Task<Hospital> GetHospitalByName(string name);
        Task<int> CreateHospital(string name, int numberOfRooms);
    }
}