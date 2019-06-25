using System;
using System.Threading.Tasks;
using Market.Application.Users.Commands;
using Market.Application.Users.DTO;

namespace Market.Application.Users.Services
{
    public interface IIdentityService
    {
        Task<UserDto> GetAsync(Guid id);
        Task SignUpAsync(SignUp command);
        Task<JwtDto> SignInAsync(SignIn command);
    }
}