using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UAWalks.API.Model.DTO;

namespace UAWalks.API.Repository
{
    public class Log : ILog
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public Log(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        public async Task<string?> Loging(RequestLoginDto request)
        {
            var user = await userManager.FindByEmailAsync(request.Username);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, request.Password);
                if (result)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        return tokenRepository.CreateToken(user, roles.ToList());
                    }
                }
            }
            return null;
        }
    }
}
