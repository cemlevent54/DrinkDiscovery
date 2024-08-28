using DrinkDiscovery_Revised.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using NuGet.Packaging.Signing;

namespace DrinkDiscovery_Revised.Controllers
{
    public class UserService
    {
        private readonly UserManager<DrinkDiscovery_Revised_User> _userManager;

        public UserService(UserManager<DrinkDiscovery_Revised_User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<DrinkDiscovery_Revised_User> GetUserDetailsByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        

        
    }
}
