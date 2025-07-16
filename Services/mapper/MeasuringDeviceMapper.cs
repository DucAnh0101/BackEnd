using BusinessObject.Models;
using DataAccessLayer.DTOs.request;

namespace Services.mapper
{
    public static class MeasuringDeviceMapper
    {
        public static MeasuringDeviceDto ToDto(MeasuringDevice entity)
        {
            return new MeasuringDeviceDto
            {
                SerialNumber = entity.SerialNumber,
                DeviceTypeId = entity.DeviceTypeId,

                GammaInfo = entity.GammaInfo != null ? new GammaInfoDto
                {
                    Calibrations = entity.GammaInfo.Calibrations?.Select(c => new GammaCalibrationDto
                    {
                        Khoang = c.Khoang,
                        HeSoChuanMay = c.HeSoChuanMay
                    }).ToList()
                } : null,

                PhoGammaInfo = entity.PhoGammaInfo != null ? new PhoGammaInfoDto
                {
                    K = entity.PhoGammaInfo.K,
                    U = entity.PhoGammaInfo.U,
                    Th = entity.PhoGammaInfo.Th
                } : null,

                XRFInfo = entity.XRFInfo != null ? new XRFInfoDto
                {
                    Note = entity.XRFInfo.Note
                } : null
            };
        }

        public static MeasuringDevice ToEntity(MeasuringDeviceDto dto)
        {
            return new MeasuringDevice
            {
                SerialNumber = dto.SerialNumber,
                DeviceTypeId = dto.DeviceTypeId,

                GammaInfo = dto.GammaInfo != null ? new GammaInfo
                {
                    Calibrations = dto.GammaInfo.Calibrations?.Select(c => new GammaCalibration
                    {
                        Khoang = c.Khoang,
                        HeSoChuanMay = c.HeSoChuanMay
                    }).ToList()
                } : null,

                PhoGammaInfo = dto.PhoGammaInfo != null ? new PhoGammaInfo
                {
                    K = dto.PhoGammaInfo.K,
                    U = dto.PhoGammaInfo.U,
                    Th = dto.PhoGammaInfo.Th
                } : null,

                XRFInfo = dto.XRFInfo != null ? new XRFInfo
                {
                    Note = dto.XRFInfo.Note
                } : null
            };
        }
    }
}
