using Microsoft.AspNetCore.Identity;
using UAWalks.API.Model.DTO;

namespace UAWalks.API.Repository
{
    public interface IRegistration
    {
        Task<IdentityResult?> RegisterAsync(RequestRegDto request);
    }
}
