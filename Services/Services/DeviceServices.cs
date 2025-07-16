using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
using Microsoft.EntityFrameworkCore;
using Services.Implements;

namespace Services.Impl
{
    public class DeviceService : IDeviceServices
    {
        private readonly MyDbContext _context;

        public DeviceService(MyDbContext context)
        {
            _context = context;
        }

        // GammaCalibration
        public async Task<GammaRes> AddGammaDataAsync(GammaReq req)
        {
            var entity = new GammaCalibration
            {
                Khoang = req.Khoang,
                HeSoChuanMay = req.HeSoChuanMay,
                MeasuringDeviceId = req.MeasuringDeviceId
            };
            _context.GammaCalibrations.Add(entity);
            await _context.SaveChangesAsync();
            return new GammaRes
            {
                Id = entity.Id,
                Khoang = entity.Khoang,
                HeSoChuanMay = entity.HeSoChuanMay,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<GammaRes?> GetGammaByIdAsync(int id)
        {
            var entity = await _context.GammaCalibrations.FindAsync(id);
            return entity == null ? null : new GammaRes
            {
                Id = entity.Id,
                Khoang = entity.Khoang,
                HeSoChuanMay = entity.HeSoChuanMay,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<GammaRes> UpdateGammaAsync(int id, GammaReq req)
        {
            var entity = await _context.GammaCalibrations.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("GammaCalibration not found");
            entity.Khoang = req.Khoang;
            entity.HeSoChuanMay = req.HeSoChuanMay;
            entity.MeasuringDeviceId = req.MeasuringDeviceId;
            await _context.SaveChangesAsync();
            return new GammaRes
            {
                Id = entity.Id,
                Khoang = entity.Khoang,
                HeSoChuanMay = entity.HeSoChuanMay,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<bool> DeleteGammaAsync(int id)
        {
            var entity = await _context.GammaCalibrations.FindAsync(id);
            if (entity == null) return false;
            _context.GammaCalibrations.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // PhoGammaInfo
        public async Task<PhoGammaRes> AddPhoGammaDataAsync(PhoGammaReq req)
        {
            var entity = new PhoGammaInfo
            {
                K = req.K,
                U = req.U,
                Th = req.Th,
                MeasuringDeviceId = req.MeasuringDeviceId
            };
            _context.PhoGammaInfos.Add(entity);
            await _context.SaveChangesAsync();
            return new PhoGammaRes
            {
                Id = entity.Id,
                K = entity.K,
                U = entity.U,
                Th = entity.Th,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<PhoGammaRes?> GetPhoGammaByIdAsync(int id)
        {
            var entity = await _context.PhoGammaInfos.FindAsync(id);
            return entity == null ? null : new PhoGammaRes
            {
                Id = entity.Id,
                K = entity.K,
                U = entity.U,
                Th = entity.Th,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<PhoGammaRes> UpdatePhoGammaAsync(int id, PhoGammaReq req)
        {
            var entity = await _context.PhoGammaInfos.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("PhoGammaInfo not found");
            entity.K = req.K;
            entity.U = req.U;
            entity.Th = req.Th;
            entity.MeasuringDeviceId = req.MeasuringDeviceId;
            await _context.SaveChangesAsync();
            return new PhoGammaRes
            {
                Id = entity.Id,
                K = entity.K,
                U = entity.U,
                Th = entity.Th,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<bool> DeletePhoGammaAsync(int id)
        {
            var entity = await _context.PhoGammaInfos.FindAsync(id);
            if (entity == null) return false;
            _context.PhoGammaInfos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // XRFInfo
        public async Task<XrfRes> AddXrfDataAsync(XrfReq req)
        {
            var entity = new XRFInfo
            {
                Note = req.Note,
                MeasuringDeviceId = req.MeasuringDeviceId
            };
            _context.XRFInfos.Add(entity);
            await _context.SaveChangesAsync();
            return new XrfRes
            {
                Id = entity.Id,
                Note = entity.Note,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<XrfRes?> GetXrfByIdAsync(int id)
        {
            var entity = await _context.XRFInfos.FindAsync(id);
            return entity == null ? null : new XrfRes
            {
                Id = entity.Id,
                Note = entity.Note,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<XrfRes> UpdateXrfAsync(int id, XrfReq req)
        {
            var entity = await _context.XRFInfos.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("XRFInfo not found");
            entity.Note = req.Note;
            entity.MeasuringDeviceId = req.MeasuringDeviceId;
            await _context.SaveChangesAsync();
            return new XrfRes
            {
                Id = entity.Id,
                Note = entity.Note,
                MeasuringDeviceId = entity.MeasuringDeviceId
            };
        }

        public async Task<bool> DeleteXrfAsync(int id)
        {
            var entity = await _context.XRFInfos.FindAsync(id);
            if (entity == null) return false;
            _context.XRFInfos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // MeasuringDevice
        public async Task<MeasuringDeviceRes> AddMeasuringDeviceAsync(MeasuringDeviceReq req)
        {
            var entity = new MeasuringDevice
            {
                SerialNumber = req.SerialNumber,
                DeviceTypeId = req.DeviceTypeId
            };
            _context.MeasuringDevices.Add(entity);
            await _context.SaveChangesAsync();
            return new MeasuringDeviceRes
            {
                Id = entity.Id,
                SerialNumber = entity.SerialNumber,
                DeviceTypeId = entity.DeviceTypeId
            };
        }

        public async Task<MeasuringDeviceRes?> GetMeasuringDeviceByIdAsync(int id)
        {
            var entity = await _context.MeasuringDevices.FindAsync(id);
            return entity == null ? null : new MeasuringDeviceRes
            {
                Id = entity.Id,
                SerialNumber = entity.SerialNumber,
                DeviceTypeId = entity.DeviceTypeId
            };
        }

        public async Task<MeasuringDeviceRes> UpdateMeasuringDeviceAsync(int id, MeasuringDeviceReq req)
        {
            var entity = await _context.MeasuringDevices.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("MeasuringDevice not found");
            entity.SerialNumber = req.SerialNumber;
            entity.DeviceTypeId = req.DeviceTypeId;
            await _context.SaveChangesAsync();
            return new MeasuringDeviceRes
            {
                Id = entity.Id,
                SerialNumber = entity.SerialNumber,
                DeviceTypeId = entity.DeviceTypeId
            };
        }

        public async Task<bool> DeleteMeasuringDeviceAsync(int id)
        {
            var entity = await _context.MeasuringDevices.FindAsync(id);
            if (entity == null) return false;
            _context.MeasuringDevices.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // DeviceType
        public async Task<DeviceTypeRes> AddDeviceTypeAsync(DeviceTypeReq req)
        {
            var entity = new DeviceType
            {
                TypeName = req.TypeName
            };
            _context.DeviceTypes.Add(entity);
            await _context.SaveChangesAsync();
            return new DeviceTypeRes
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };
        }

        public async Task<DeviceTypeRes?> GetDeviceTypeByIdAsync(int id)
        {
            var entity = await _context.DeviceTypes.FindAsync(id);
            return entity == null ? null : new DeviceTypeRes
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };
        }

        public async Task<DeviceTypeRes> UpdateDeviceTypeAsync(int id, DeviceTypeReq req)
        {
            var entity = await _context.DeviceTypes.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("DeviceType not found");
            entity.TypeName = req.TypeName;
            await _context.SaveChangesAsync();
            return new DeviceTypeRes
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };
        }

        public async Task<bool> DeleteDeviceTypeAsync(int id)
        {
            var entity = await _context.DeviceTypes.FindAsync(id);
            if (entity == null) return false;
            _context.DeviceTypes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}