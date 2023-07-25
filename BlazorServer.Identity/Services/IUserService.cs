using BlazorServer.Identity.Models;

namespace BlazorServer.Identity.Services
{
    public interface IUserService
    {
        Task<bool> LoginAsync(LoginDto query);
    }
}
