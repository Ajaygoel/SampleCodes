using Microsoft.Owin;
using OnlineCoding.WebManagement;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace OnlineCoding.WebManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}