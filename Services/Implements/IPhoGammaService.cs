using BusinessObject.Models;
using DataAccessLayer.DTOs.request; 
using DataAccessLayer.DTOs.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public interface IPhoGammaService
    {
        Task<List<PhoGammaDevice>> GetAllAsync();
        Task<PhoGammaDevice> GetByIdAsync(int id);
        Task<PhoGammaDevice> CreateAsync(PhoGammaDeviceRequest request);
        Task<PhoGammaDevice> UpdateAsync(int id, PhoGammaDeviceRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
