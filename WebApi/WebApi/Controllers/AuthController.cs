using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _context.ms_user
                    .Where(u => u.user_name == request.user_name && u.is_active)
                    .FirstOrDefaultAsync();

                if (user == null || !VerifyPassword(user.password, request.password))
                {
                    return Unauthorized(); 
                }


                HttpContext.Response.Cookies.Append("auth", user.user_name);


                return Ok(new { UserId = user.user_id, UserName = user.user_name });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, "Terjadi kesalahan saat proses login.");
            }

        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {

            HttpContext.Response.Cookies.Delete("auth");


            return Ok("Logout berhasil");
        }

        private bool VerifyPassword(string hashedPassword, string plainPassword)
        {

            return hashedPassword == plainPassword;
        }
    }
}
