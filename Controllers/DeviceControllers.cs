using Microsoft.AspNetCore.Mvc;
using SmartInventoryAPI.Data;
using SmartInventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartInventoryAPI.Contollers
{
    [Route("api/devices")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DeviceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _context.Devices.ToListAsync();
            return Ok(devices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound("Aradığınız ID'ye sahip cihaz bulunamadı.");
            }

            return Ok(device);
}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, [FromBody] Device updatedDevice)
        {
            var existingDevice = await _context.Devices.FindAsync(id);

            if (existingDevice == null)
            {
                return NotFound("Güncellenecek cihaz bulunamadı.");
            }

            existingDevice.DeviceName = updatedDevice.DeviceName;
            existingDevice.SerialNumber = updatedDevice.SerialNumber;
            existingDevice.Status = updatedDevice.Status;
            existingDevice.LastMaintenanceDate = updatedDevice.LastMaintenanceDate;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] Device device)
        {
            _context.Devices.Add(device);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevices), new { id = device.Id }, device);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound("Silinecek cihaz bulunamadı.");
            }

            _context.Devices.Remove(device);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}   