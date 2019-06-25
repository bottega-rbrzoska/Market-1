using System;
using System.Threading.Tasks;
using Market.Application.Users.Commands;
using Market.Application.Users.DTO;
using Market.Core.Entities;
using Market.Core.Repositories;

namespace Market.Application.Users.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtProvider _jwtProvider;

        public IdentityService(IUserRepository userRepository, IPasswordService passwordService,
            IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _jwtProvider = jwtProvider;
        }
        
        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return user is null ? null : new UserDto(user);
        }

        public async Task SignUpAsync(SignUp command)
        {
            var user = await _userRepository.GetAsync(command.Email);
            if (!(user is null))
            {
                throw new ArgumentException("Email already in use", nameof(command.Email));
            }
            
            var role = string.IsNullOrWhiteSpace(command.Role) ? "user" : command.Role;
            var hash = _passwordService.Hash(command.Password);
            user = new User(command.Id, command.Email, hash, role);
            await _userRepository.CreateAsync(user);
        }

        public async Task<JwtDto> SignInAsync(SignIn command)
        {
            var user = await _userRepository.GetAsync(command.Email);
            if (user is null)
            {
                throw new Exception("Invalid credentials.");
            }

            var isPasswordValid = _passwordService.IsValid(user.Password, command.Password);
            if (!isPasswordValid)
            {
                throw new Exception("Invalid credentials.");
            }

            return _jwtProvider.CreateToken(user.Id.ToString("N"), user.Role);
        }
    }
}