using Microsoft.AspNetCore.Identity;

namespace UAWalks.API.Repository
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user,List<string> roles);
    }
}
