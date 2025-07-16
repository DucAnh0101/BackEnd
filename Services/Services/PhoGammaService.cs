using Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DTOs.request; 
using DataAccessLayer.DTOs.response;
using BusinessObject;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;


namespace Services.Services
{
    public class PhoGammaService : IPhoGammaService
    {
        private readonly MyDbContext _context;
        public PhoGammaService(MyDbContext context) => _context = context;

        public async Task<List<PhoGammaDevice>> GetAllAsync() => await _context.PhoGammaDevices.ToListAsync();

        public async Task<PhoGammaDevice> GetByIdAsync(int id) => await _context.PhoGammaDevices.FindAsync(id);

        public async Task<PhoGammaDevice> CreateAsync(PhoGammaDeviceRequest request)
        {
            var device = new PhoGammaDevice
            {
                SerialNumber = request.SerialNumber,
                K = request.K,
                U = request.U,
                Th = request.Th,
                Status = "Active"
            };
            _context.PhoGammaDevices.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<PhoGammaDevice> UpdateAsync(int id, PhoGammaDeviceRequest request)
        {
            var device = await _context.PhoGammaDevices.FindAsync(id);
            if (device == null) return null;
            device.SerialNumber = request.SerialNumber;
            device.K = request.K;
            device.U = request.U;
            device.Th = request.Th;
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var device = await _context.PhoGammaDevices.FindAsync(id);
            if (device == null) return false;
            device.Status = "Deleted";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
