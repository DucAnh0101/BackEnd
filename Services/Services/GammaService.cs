using BusinessObject;
using BusiniessObject.Models;
using BusinessObject.Models;
using DataAccessLayer.DTOs.request;
using DataAccessLayer.DTOs.response;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.DTOs;
using Services.Implements;

namespace Services.Impl
{
    public class GammaService : IGammaService
    {
        private readonly MyDbContext _context;
        public GammaService(MyDbContext context) => _context = context;

        public async Task<List<GammaDeviceResponse>> GetAllAsync()
        {
            var devices = await _context.GammaDevices
                .Where(d => d.Status == "Active")
                .Include(d => d.Calibrations)
                .ToListAsync();

            return devices.Select(d => new GammaDeviceResponse
            {
                Id = d.Id,
                SerialNumber = d.SerialNumber,
                Calibrations = d.Calibrations.Select(c => new GammaCalibrationDto
                {
                    RangeValue = c.RangeValue,
                    Coefficient = c.Coefficient
                }).ToList()
            }).ToList();
        }

        public async Task<GammaDeviceResponse?> GetByIdAsync(int id)
        {
            var device = await _context.GammaDevices
                .Include(d => d.Calibrations)
                .FirstOrDefaultAsync(d => d.Id == id && d.Status == "Active");

            if (device == null) return null;

            return new GammaDeviceResponse
            {
                Id = device.Id,
                SerialNumber = device.SerialNumber,
                Calibrations = device.Calibrations.Select(c => new GammaCalibrationDto
                {
                    RangeValue = c.RangeValue,
                    Coefficient = c.Coefficient
                }).ToList()
            };
        }

        public async Task CreateAsync(GammaDeviceRequest request)
        {
            var device = new GammaDevice
            {
                SerialNumber = request.SerialNumber,
                Calibrations = request.Calibrations.Select(c => new GammaCalibration
                {
                    RangeValue = c.RangeValue,
                    Coefficient = c.Coefficient
                }).ToList()
            };
            _context.GammaDevices.Add(device);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, GammaDeviceRequest request)
        {
            var device = await _context.GammaDevices.Include(d => d.Calibrations)
                .FirstOrDefaultAsync(d => d.Id == id && d.Status == "Active");

            if (device == null) return false;

            device.SerialNumber = request.SerialNumber;
            _context.GammaCalibrations.RemoveRange(device.Calibrations);
            device.Calibrations = request.Calibrations.Select(c => new GammaCalibration
            {
                RangeValue = c.RangeValue,
                Coefficient = c.Coefficient
            }).ToList();

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var device = await _context.GammaDevices.FindAsync(id);
            if (device == null || device.Status == "Deleted") return false;

            device.Status = "Deleted";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}