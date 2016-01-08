using System;
using System.ServiceModel;

namespace OnlineCoding.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CompilerClients : ICompilerClients
    {
      
        public void Client(int value)
        {
            ICompilerClientsCallback callback = OperationContext.Current.GetCallbackChannel<ICompilerClientsCallback>();
            callback.NotifyUser("Calling from Call Back");
        }
        
    }

    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CompierClientsCallBack : ICompilerClientsCallback
    {
       
        public void NotifyUser(string userName)
        {
            Console.WriteLine(userName);
            Console.ReadLine();
        }
    }
}