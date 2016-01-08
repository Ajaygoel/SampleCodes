#region usings

using Microsoft.Practices.Unity;
using OnlineCoding.IBal;

#endregion

namespace OnlineCoding.Bal
{
    public class UnityBootstrapper
    {
        #region Public Methods

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ILoggerBal, LoggerBal>();
        }

        #endregion
    }
}