using AvnonDemo.Domain.Core;
//using AvnonDemo.Domain.Login;
using AvnonDemo.Domain.Security;

namespace AvnonDemo.Services.Authentication
{
    public interface IAuthenticationService
    {


        AppUser GetCurrentUser(string currentUserName);

    }
}