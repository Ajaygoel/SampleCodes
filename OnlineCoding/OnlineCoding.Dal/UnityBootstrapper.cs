#region usings

using Microsoft.Practices.Unity;
using OnlineCoding.Dal.Contexts;
using OnlineCoding.IDal.IUnitOfWork;

#endregion

namespace OnlineCoding.Dal
{
    public class UnityBootstrapper
    {
        #region Public Methods

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
            container.RegisterType<OnlineCompilerContext>(new InjectionConstructor());
        }

        #endregion
    }
}