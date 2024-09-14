using MyLoginApp.Models;

namespace MyLoginApp.Services;

public interface ILoginRepository
{
    Task<UserInfo?> Login(string username, string password);
}
