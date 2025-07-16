using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface IDeviceService
    {
        Task<DeviceRes> CreateAsync(DeviceReq request);
        Task<List<MeasuringDeviceDto>> GetByTypeAsync(int typeId);
        Task<DeviceRes> UpdateAsync(int id, DeviceReq request);
        Task<bool> DeleteAsync(int id);
    }
}
