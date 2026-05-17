using MeraRakshak.Data;
using MeraRakshak.DTOs;
using MeraRakshak.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeraRakshak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CallLogsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("add-contact")]
        public async Task<IActionResult> AddContact([FromBody] AddContactRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Status = 0,
                    Message = "Invalid request data."
                });
            }

            var contact = new Contact
            {
                Token = request.Token,
                CallerName = request.CallerName,
                CallerNo = request.CallerNo,
                CallerImg = request.CallerImg,
                DeviceModel = request.DeviceModel
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse
            {
                Status = 1,
                Message = "Inserted"
            });
        }

        [HttpPost("add-calllogs")]
        public async Task<IActionResult> AddCallLogs([FromBody] AddCallLogsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Status = 0,
                    Message = "Invalid request data."
                });
            }

            var callLog = new CallLog
            {
                Token = request.Token,
                CallerName = request.CallerName,
                CallerNo = request.CallerNo,
                CallType = request.CallType,
                CallDuration = request.CallDuration,
                DateTime = request.DateTime,
                ImeiNo = request.ImeiNo,
                DeviceModel = request.DeviceModel
            };

            _context.CallLogs.Add(callLog);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse
            {
                Status = 1,
                Message = "Account has been created successfully"
            });
        }
    }
}