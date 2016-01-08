using AvnonDemo.Domain.Security;

namespace AvnonDemo.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {
        }


        public AppUser GetCurrentUser(string currentUserName)
        {
            return new AppUser
            {
                AccountId = 1
            };
        }



    }
}