using MeraRakshak.Data;
using MeraRakshak.DTOs;
using MeraRakshak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeraRakshak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Status = 0,
                    Message = "Invalid request data."
                });
            }

            bool emailExists = await _context.Users.AnyAsync(u => u.EmailAddress == request.EmailAddress);
            if (emailExists)
            {
                return Ok(new ApiResponse
                {
                    Status = 0,
                    Message = "Email address is already registered."
                });
            }

            bool mobileExists = await _context.Users.AnyAsync(u => u.MobileNo == request.MobileNo);
            if (mobileExists)
            {
                return Ok(new ApiResponse
                {
                    Status = 0,
                    Message = "Mobile number is already registered."
                });
            }

            var user = new User
            {
                FullName = request.FullName,
                EmailAddress = request.EmailAddress,
                MobileNo = request.MobileNo,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Address = request.Address,
                ImeiNo = request.ImeiNo,
                DeviceModel = request.DeviceModel,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse
            {
                Status = 1,
                Message = "Account has been created successfully."
            });
        }
    }
}
