using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DTOs.request; 
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface IGammaService
    {
        Task<List<GammaDeviceResponse>> GetAllAsync();
        Task<GammaDeviceResponse?> GetByIdAsync(int id);
        Task CreateAsync(GammaDeviceRequest request);
        Task<bool> UpdateAsync(int id, GammaDeviceRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
