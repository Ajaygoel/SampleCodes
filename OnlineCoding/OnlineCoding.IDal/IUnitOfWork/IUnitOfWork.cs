#region usings

using System;
using OnlineCoding.Domain.Entities;

#endregion

namespace OnlineCoding.IDal.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        #region Public Methods

        void SaveChange(bool isAsync = false);
        bool LogException(Exception exception,string applicationName);
        #endregion

        #region Public Properties

        IGenericRepository<CompilerClient, int> CompilerClientRepository { get; }
        IGenericRepository<CompileResult, int> CompileResultRepository { get; }
        IGenericRepository<TestResult, int> TestResultRepository { get; }

        #endregion
    }
}