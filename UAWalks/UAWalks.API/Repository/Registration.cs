using Microsoft.AspNetCore.Identity;
using UAWalks.API.Model.DTO;

namespace UAWalks.API.Repository
{
    public class Registration : IRegistration
    {
        private readonly UserManager<IdentityUser> userManager;

        public Registration(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        async Task<IdentityResult?> IRegistration.RegisterAsync(RequestRegDto request)
        {
            var user = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Username
            };

            var result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (request.Roles != null && request.Roles.Any())
                {
                    result = await userManager.AddToRolesAsync(user, request.Roles);
                    if (result.Succeeded)
                    {
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
