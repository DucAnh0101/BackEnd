using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;

namespace Services.Implements
{
    public interface IDeviceServices
    {
        // --------- GammaCalibration ---------
        Task<GammaRes> AddGammaDataAsync(GammaReq req);
        Task<GammaRes?> GetGammaByIdAsync(int id);
        Task<GammaRes> UpdateGammaAsync(int id, GammaReq req);
        Task<bool> DeleteGammaAsync(int id);

        // --------- PhoGammaInfo ---------
        Task<PhoGammaRes> AddPhoGammaDataAsync(PhoGammaReq req);
        Task<PhoGammaRes?> GetPhoGammaByIdAsync(int id);
        Task<PhoGammaRes> UpdatePhoGammaAsync(int id, PhoGammaReq req);
        Task<bool> DeletePhoGammaAsync(int id);

        // --------- XRFInfo ---------
        Task<XrfRes> AddXrfDataAsync(XrfReq req);
        Task<XrfRes?> GetXrfByIdAsync(int id);
        Task<XrfRes> UpdateXrfAsync(int id, XrfReq req);
        Task<bool> DeleteXrfAsync(int id);

        // --------- MeasuringDevice ---------
        Task<MeasuringDeviceRes> AddMeasuringDeviceAsync(MeasuringDeviceReq req);
        Task<MeasuringDeviceRes?> GetMeasuringDeviceByIdAsync(int id);
        Task<MeasuringDeviceRes> UpdateMeasuringDeviceAsync(int id, MeasuringDeviceReq req);
        Task<bool> DeleteMeasuringDeviceAsync(int id);

        // --------- DeviceType ---------
        Task<DeviceTypeRes> AddDeviceTypeAsync(DeviceTypeReq req);
        Task<DeviceTypeRes?> GetDeviceTypeByIdAsync(int id);
        Task<DeviceTypeRes> UpdateDeviceTypeAsync(int id, DeviceTypeReq req);
        Task<bool> DeleteDeviceTypeAsync(int id);
    }
}
