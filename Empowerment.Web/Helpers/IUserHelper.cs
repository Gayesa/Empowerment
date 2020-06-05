using Empowerment.Web.Data.Entities;
using Empowerment.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Empowerment.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();



    }
}
