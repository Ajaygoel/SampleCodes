﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineCoding.Client.CompilerClientServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CompilerClientServices.ICompilerClients", CallbackContract=typeof(OnlineCoding.Client.CompilerClientServices.ICompilerClientsCallback))]
    public interface ICompilerClients {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompilerClients/Client", ReplyAction="http://tempuri.org/ICompilerClients/ClientResponse")]
        void Client(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompilerClients/Client", ReplyAction="http://tempuri.org/ICompilerClients/ClientResponse")]
        System.Threading.Tasks.Task ClientAsync(int value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICompilerClientsCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICompilerClients/NotifyUser")]
        void NotifyUser(string userName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICompilerClientsChannel : OnlineCoding.Client.CompilerClientServices.ICompilerClients, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CompilerClientsClient : System.ServiceModel.DuplexClientBase<OnlineCoding.Client.CompilerClientServices.ICompilerClients>, OnlineCoding.Client.CompilerClientServices.ICompilerClients {
        
        public CompilerClientsClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CompilerClientsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CompilerClientsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CompilerClientsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CompilerClientsClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Client(int value) {
            base.Channel.Client(value);
        }
        
        public System.Threading.Tasks.Task ClientAsync(int value) {
            return base.Channel.ClientAsync(value);
        }
    }
}