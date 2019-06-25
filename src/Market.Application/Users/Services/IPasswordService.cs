namespace Market.Application.Users.Services
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool IsValid(string hash, string password);
    }
}