using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnlineCoding.Server.UnitTests
{
    [TestClass]
    public abstract class TestBase
    {
        #region Constructors

        #endregion

        #region Public Properties

        //protected IUnityContainer Container { get; set; }

        //protected Mock<IUnitOfWork> Moq { get; set; }

        #endregion

        #region Public Methods

        public abstract void Startup();
        public abstract void Cleanup();

        #endregion
    }
}