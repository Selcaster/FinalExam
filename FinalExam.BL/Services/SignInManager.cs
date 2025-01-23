using Microsoft.AspNetCore.Identity;

namespace FinalExam.BL.Services
{
    internal class SignInManager
    {
        internal async Task SignInAsync(IdentityUser userDB, bool v)
        {
            throw new NotImplementedException();
        }

        internal async Task SignOutAsync()
        {
            throw new NotImplementedException();
        }

        public static implicit operator SignInManager(SignInManager<IdentityUser> v)
        {
            throw new NotImplementedException();
        }
    }
}