using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OnlineCoding.Server;

namespace Onlinecoding.ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var svcHost = new ServiceHost(typeof(CompilerClients));
            svcHost.Open();
            Console.WriteLine("Available Endpoints :\n");
            svcHost.Description.Endpoints.ToList().ForEach
            (endpoint => Console.WriteLine(endpoint.Address.ToString()));
            Console.ReadLine();
            svcHost.Close();
        }
    }
}
