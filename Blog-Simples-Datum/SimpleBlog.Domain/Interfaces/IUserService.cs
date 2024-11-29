using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IUserService
    {
        string GetUserIdFromClaim(ClaimsPrincipal user);
    }

    //public class UserService : IUserService
    //{
    //    private readonly IHttpContextAccessor _httpContextAccessor;

    //    public UserService(IHttpContextAccessor httpContextAccessor)
    //    {
    //        _httpContextAccessor = httpContextAccessor;
    //    }

    //    public string GetUserIdFromClaim(ClaimsPrincipal user)
    //    {
    //        // Aqui assumimos que o 'sub' no JWT representa o ID do usuário
    //        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    //    }
    //}
}
