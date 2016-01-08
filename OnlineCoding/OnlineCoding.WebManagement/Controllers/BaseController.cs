using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCoding.Dal.Contexts;

namespace OnlineCoding.WebManagement.Controllers
{
    public class BaseController : Controller
    {
        protected OnlineCompilerContext Db = new OnlineCompilerContext();
    }
}