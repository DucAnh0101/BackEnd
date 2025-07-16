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
    public interface IXrfService
    {
        Task<List<XrfDevice>> GetAllAsync();
        Task<XrfDevice> GetByIdAsync(int id);
        Task<XrfDevice> CreateAsync(XrfDeviceRequest request);
        Task<XrfDevice> UpdateAsync(int id, XrfDeviceRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
