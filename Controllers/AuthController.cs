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

            bool emailExists = await _context.Users
                .AnyAsync(u => u.EmailAddress == request.EmailAddress);

            if (emailExists)
            {
                return Ok(new ApiResponse
                {
                    Status = 0,
                    Message = "Email address is already registered."
                });
            }

            bool mobileExists = await _context.Users
                .AnyAsync(u => u.MobileNumber == request.MobileNumber);

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
                MobileNumber = request.MobileNumber,
                Password = request.Password,
                Address = request.Address,
                DeviceId = request.DeviceId,
                DeviceModelName = request.DeviceModelName
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse
            {
                Status = 1,
                Message = "Account has been created successfully."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Status = 0,
                    Message = "Invalid request data."
                });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u =>
                (u.EmailAddress == request.UserNameOrMobileNo ||
                 u.MobileNumber == request.UserNameOrMobileNo)
                 &&
                 u.Password == request.Password);

            if (user == null)
            {
                return Ok(new ApiResponse
                {
                    Status = 0,
                    Message = "Invalid username/mobile number or password."
                });
            }

            // Update device details
            user.DeviceId = request.ImeiNo;
            user.DeviceModelName = request.DeviceModel;

            await _context.SaveChangesAsync();

            // Dummy token
            string token = Guid.NewGuid().ToString();

            return Ok(new
            {
                status = 1,
                message = "Login successfully",
                token = token,
                username = user.FullName
            });
        }
    }
}