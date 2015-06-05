using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using App.DemoCargoClix.common;

using domain.Model;

namespace App.DemoCargoClix.Controllers
{
    public class AccountController : BaseApiController
    {
        [HttpPost]
        public AuthenticationToken Login(User user)
        {
            if (user.MobileNumber == "7838846655")
            {
                return new AuthenticationToken()
                {
                    IsAuthorized = true,
                    MobileNumber = user.MobileNumber,
                    UserName = "Ajay Kumar Goel"
                };
            }
            return new AuthenticationToken
            {
                IsAuthorized = false
            };

        }


        public IEnumerable<string> GetNames()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return "ajay";
            }
        }
    }
}