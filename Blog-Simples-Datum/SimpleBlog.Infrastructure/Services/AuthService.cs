using Microsoft.AspNetCore.Identity;
using SimpleBlog.Application.DTOs;
using SimpleBlog.Domain.Entidades;
using SimpleBlog.Domain.Interfaces;

namespace SimpleBlog.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<AuthResult> RegisterAsync(RegisterDto registerDto)
        {
            var userExists = await _userRepository.GetUserByUsernameAsync(registerDto.Username);
            if (userExists != null)
                return new AuthResult(false, "Username already exists.", "");

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = await _passwordHasher.HashPasswordAsync(registerDto.Password)
            };

            await _userRepository.AddAsync(user);

            return new AuthResult ( true, "","" ); 
        }

        public async Task<AuthResult> LoginAsync(LoginDto loginDto)
        {
            // Buscar o usuário
            var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);
            if (user == null || !await _passwordHasher.VerifyPasswordAsync(user.PasswordHash, loginDto.Password))
                return new AuthResult (false, "Invalid credentials.","");

            // Gerar um token JWT
            var token = _tokenService.GenerateToken(user); // Corrigido para lidar com assincronismo

            return new AuthResult ( true, "", token );
        }
    }
}
