using Microsoft.AspNetCore.Identity;

namespace FinalExam.BL.Services
{
    internal class UserManager
    {
        internal async Task AddToRoleAsync(IdentityUser user, string v)
        {
            throw new NotImplementedException();
        }

        internal async Task<bool> CheckPasswordAsync(IdentityUser userDB, string password)
        {
            throw new NotImplementedException();
        }

        internal async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            throw new NotImplementedException();
        }

        internal async Task<IdentityUser?> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public static implicit operator UserManager(UserManager<IdentityUser> v)
        {
            throw new NotImplementedException();
        }
    }
}