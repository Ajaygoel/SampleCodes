using AvnonDemo.Domain.Security;
using AvnonDemo.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvnonDemo.Web.Controllers
{
    [System.Web.Http.Authorize]
    public class BaseController : BaseHttpsController
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

        public BaseController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


    }
}
