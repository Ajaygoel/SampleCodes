using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OnlineCoding.ConsoleClient.Services;

namespace OnlineCoding.ConsoleClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CompierClientsCallBack Obj = new CompierClientsCallBack();
            Obj.Client();
            Console.ReadLine();
        }


    }

    public class CompierClientsCallBack : ICompilerClientsCallback, IDisposable
    {
        private CompilerClientsClient proxy;

        public void NotifyUser(string userName)
        {
            Console.WriteLine(userName);
        }

        public void Client()
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new CompilerClientsClient(context);
            proxy.Client(23);
        }

        public void Dispose()
        {

        }
    }
}
