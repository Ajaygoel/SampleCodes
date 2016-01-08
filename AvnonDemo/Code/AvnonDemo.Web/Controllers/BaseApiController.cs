using AvnonDemo.Domain.Security;
using AvnonDemo.Services.Authentication;


namespace AvnonDemo.Web.Controllers
{
    public class BaseApiController : BaseHttpsApiController
    {
        private readonly IAuthenticationService _authenticationService;

        protected AppUser LoggedInUser
        {
            get
            {
                var currentusername = "Tarun";
                return _authenticationService.GetCurrentUser(currentusername);
            }
        }

        public BaseApiController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


    }
}
