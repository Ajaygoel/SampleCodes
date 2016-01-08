using System;
using System.ServiceModel;
using System.Windows;
using OnlineCoding.Client.CompilerClientServices;
using ICompilerClients = OnlineCoding.Client.CompilerClientServices.ICompilerClients;

namespace OnlineCoding.Client
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CompierClientsCallBack Obj = new CompierClientsCallBack();
            Obj.Client();

            Obj.Dispose();
        }
    }

    public class CompierClientsCallBack : ICompilerClientsCallback,IDisposable
    {
        private CompilerClientsClient proxy;

        public void NotifyUser(string userName)
        {
           MessageBox.Show(userName);
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