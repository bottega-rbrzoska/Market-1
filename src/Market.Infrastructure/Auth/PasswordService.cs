using Market.Application.Users.Services;
using Microsoft.AspNetCore.Identity;

namespace Market.Infrastructure.Auth
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<IPasswordService> _passwordHasher;

        public PasswordService(IPasswordHasher<IPasswordService> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string Hash(string password)
            => _passwordHasher.HashPassword(this, password);

        public bool IsValid(string hash, string password)
            => _passwordHasher.VerifyHashedPassword(this, hash, password)
               != PasswordVerificationResult.Failed;
    }
}