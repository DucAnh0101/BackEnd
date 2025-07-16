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
    public class XrfService : IXrfService
    {
        private readonly MyDbContext _context;
        public XrfService(MyDbContext context) => _context = context;

        public async Task<List<XrfDevice>> GetAllAsync() => await _context.XrfDevices.ToListAsync();

        public async Task<XrfDevice> GetByIdAsync(int id) => await _context.XrfDevices.FindAsync(id);

        public async Task<XrfDevice> CreateAsync(XrfDeviceRequest request)
        {
            var device = new XrfDevice
            {
                SerialNumber = request.SerialNumber,
                Note = request.Note,
                Status = "Active"
            };
            _context.XrfDevices.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<XrfDevice> UpdateAsync(int id, XrfDeviceRequest request)
        {
            var device = await _context.XrfDevices.FindAsync(id);
            if (device == null) return null;
            device.SerialNumber = request.SerialNumber;
            device.Note = request.Note;
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var device = await _context.XrfDevices.FindAsync(id);
            if (device == null) return false;
            device.Status = "Deleted";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
