using System;
using Market.Core.Entities;

namespace Market.Application.Users.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public UserDto()
        {
        }
        
        public UserDto(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Role = user.Role;
        }
    }
}