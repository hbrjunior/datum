using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.DTOs;
using SimpleBlog.Domain.Interfaces;
using System.Threading.Tasks;

namespace SimpleBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        // Injeção de dependência do serviço de autenticação
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Endpoint de registro (sign-up)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _authService.RegisterAsync(registerDto);
            if (!result.Success)
            {
                return BadRequest(result.Message); // Retorna a mensagem de erro caso falhe
            }

            return Ok(new { Message = "Registration successful." }); // Retorna sucesso no registro
        }

        // Endpoint de login (sign-in)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _authService.LoginAsync(loginDto);
            if (!result.Success)
            {
                return Unauthorized(result.Message); // Retorna erro de login se não for válido
            }

            return Ok(new { Token = result.Token }); // Retorna o token JWT se o login for bem-sucedido
        }
    }
}
