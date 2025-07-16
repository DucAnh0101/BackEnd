using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Implements;
using Services.mapper;

namespace Services.Impl
{
    public class DeviceService : IDeviceService
    {
        private readonly MyDbContext _context;

        public DeviceService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<DeviceRes> CreateAsync(DeviceReq request)
        {
            var typeName = request.Type?.Trim().ToLower();

            var deviceType = await _context.DeviceTypes
                .FirstOrDefaultAsync(d => d.TypeName.ToLower() == typeName);

            if (deviceType == null)
                throw new Exception($"Loại thiết bị '{request.Type}' không tồn tại.");

            var device = new MeasuringDevice
            {
                SerialNumber = request.SerialNumber,
                DeviceTypeId = deviceType.Id
            };

            _context.MeasuringDevices.Add(device);
            await _context.SaveChangesAsync();

            switch (typeName)
            {
                case "gamma":
                    await CreateGammaInfoAsync(device.Id, request);
                    break;

                case "phogamma":
                    await CreatePhoGammaInfoAsync(device.Id, request);
                    break;

                case "xrf":
                    await CreateXrfInfoAsync(device.Id, request);
                    break;

                default:
                    throw new Exception("Loại thiết bị không hợp lệ.");
            }

            await _context.SaveChangesAsync();

            return new DeviceRes
            {
                Id = device.Id,
                SerialNumber = device.SerialNumber,
                Type = typeName,
                Calibrations = request.Calibrations?.Select(c => new GammaCalibrationRes
                {
                    Khoang = c.Khoang,
                    HeSoChuanMay = c.HeSoChuanMay
                }).ToList(),
                K = request.K,
                U = request.U,
                Th = request.Th,
                Note = request.Note
            };
        }

        public async Task<List<MeasuringDeviceDto>> GetByTypeAsync(int typeId)
        {
            var devices = await _context.MeasuringDevices
                .Where(md => md.DeviceTypeId == typeId)
                .Include(md => md.DeviceType)
                .Include(md => md.GammaInfo)
                    .ThenInclude(g => g.Calibrations)
                .Include(md => md.PhoGammaInfo)
                .Include(md => md.XRFInfo)
                .ToListAsync();

            return devices.Select(MeasuringDeviceMapper.ToDto).ToList();
        }

        private Task CreateGammaInfoAsync(int deviceId, DeviceReq request)
        {
            var gammaInfo = new GammaInfo
            {
                MeasuringDeviceId = deviceId,
                Calibrations = request.Calibrations?.Select(c => new GammaCalibration
                {
                    Khoang = c.Khoang,
                    HeSoChuanMay = c.HeSoChuanMay
                }).ToList()
            };

            _context.GammaInfos.Add(gammaInfo);
            return Task.CompletedTask;
        }

        private Task CreatePhoGammaInfoAsync(int deviceId, DeviceReq request)
        {
            var phoGamma = new PhoGammaInfo
            {
                MeasuringDeviceId = deviceId,
                K = request.K ?? 0,
                U = request.U ?? 0,
                Th = request.Th ?? 0
            };

            _context.PhoGammaInfos.Add(phoGamma);
            return Task.CompletedTask;
        }

        private Task CreateXrfInfoAsync(int deviceId, DeviceReq request)
        {
            var xrf = new XRFInfo
            {
                MeasuringDeviceId = deviceId,
                Note = request.Note
            }
            ;

            _context.XRFInfos.Add(xrf);
            return Task.CompletedTask;
        }

        public async Task<DeviceRes> UpdateAsync(int id, DeviceReq request)
        {
            var device = await _context.MeasuringDevices
                .Include(d => d.GammaInfo)
                    .ThenInclude(g => g.Calibrations)
                .Include(d => d.PhoGammaInfo)
                .Include(d => d.XRFInfo)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device == null)
                throw new Exception("Không tìm thấy thiết bị để cập nhật.");

            // Cập nhật serial
            device.SerialNumber = request.SerialNumber;

            // Cập nhật loại thiết bị nếu cần
            var typeName = request.Type?.Trim().ToLower();
            var deviceType = await _context.DeviceTypes
                .FirstOrDefaultAsync(d => d.TypeName.ToLower() == typeName);

            if (deviceType == null)
                throw new Exception($"Loại thiết bị '{request.Type}' không tồn tại.");

            device.DeviceTypeId = deviceType.Id;

            // Xoá thông tin cũ trước khi cập nhật
            if (device.GammaInfo != null)
                _context.GammaInfos.Remove(device.GammaInfo);
            if (device.PhoGammaInfo != null)
                _context.PhoGammaInfos.Remove(device.PhoGammaInfo);
            if (device.XRFInfo != null)
                _context.XRFInfos.Remove(device.XRFInfo);

            // Thêm lại thông tin mới
            switch (typeName)
            {
                case "gamma":
                    await CreateGammaInfoAsync(device.Id, request);
                    break;
                case "phogamma":
                    await CreatePhoGammaInfoAsync(device.Id, request);
                    break;
                case "xrf":
                    await CreateXrfInfoAsync(device.Id, request);
                    break;
                default:
                    throw new Exception("Loại thiết bị không hợp lệ.");
            }

            await _context.SaveChangesAsync();

            return new DeviceRes
            {
                Id = device.Id,
                SerialNumber = device.SerialNumber,
                Type = typeName,
                Calibrations = request.Calibrations?.Select(c => new GammaCalibrationRes
                {
                    Khoang = c.Khoang,
                    HeSoChuanMay = c.HeSoChuanMay
                }).ToList(),
                K = request.K,
                U = request.U,
                Th = request.Th,
                Note = request.Note
            };
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var device = await _context.MeasuringDevices
                .Include(d => d.GammaInfo)
                .Include(d => d.PhoGammaInfo)
                .Include(d => d.XRFInfo)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device == null)
                return false;

            // Xoá các bảng phụ nếu có
            if (device.GammaInfo != null)
                _context.GammaInfos.Remove(device.GammaInfo);
            if (device.PhoGammaInfo != null)
                _context.PhoGammaInfos.Remove(device.PhoGammaInfo);
            if (device.XRFInfo != null)
                _context.XRFInfos.Remove(device.XRFInfo);

            _context.MeasuringDevices.Remove(device);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
