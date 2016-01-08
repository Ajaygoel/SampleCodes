using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace OnlineCoding.Server
{
    [ServiceContract(CallbackContract = typeof(ICompilerClientsCallback))]
    public interface ICompilerClients
    {
        [OperationContract]
        void Client(int value);
        
        // TODO: Add your service operations here
    }
    

    public interface ICompilerClientsCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyUser(string userName);
        
    }
}