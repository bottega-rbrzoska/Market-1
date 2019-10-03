using Market.Application.Users.DTO;

namespace Market.Application.Users.Services
{
    public interface IJwtProvider
    {
        JwtDto CreateToken(string userId, string role);
    }
}