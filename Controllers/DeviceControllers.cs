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

        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] Device device)
        {
            _context.Devices.Add(device);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevices), new { id = device.Id }, device);
        }

    }
}   