#region usings

using System;
using System.Configuration;
using OnlineCoding.Dal.Contexts;
using OnlineCoding.Domain.Entities;
using OnlineCoding.IDal.IUnitOfWork;

#endregion

namespace OnlineCoding.Dal.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Constructors

        public UnitOfWork(OnlineCompilerContext context)
        {
            _onlineCompilerContext = context;
        }

        #endregion

        #region Public Methods

        //To Dispose
        public void Dispose(bool disposing)
        {
            if (!_disposed & disposing)
            {
                _onlineCompilerContext.Dispose();
            }
            _disposed = true;
        }

        #endregion

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #region Fields

        private readonly OnlineCompilerContext _onlineCompilerContext; //makig readonly creates issue in windows service

        private bool _disposed;

        private IGenericRepository<CompilerClient, int> _compilerClientRepository;
        private IGenericRepository<CompileResult, int> _compileResultRepository;
        private IGenericRepository<TestResult, int> _testResultRepository;

        #endregion

        #region Public Properties

        public bool LogException(Exception exception,string applicationName)
        {
            try
            {
                var connection = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

                var errorLog = new Elmah.SqlErrorLog(connection)
                {
                    ApplicationName =applicationName
                };

                errorLog.Log(new Elmah.Error(exception));
                return true;
            }
            catch (Exception ex)
            {
                //catch sql error
                return false;
            }
        }

        public IGenericRepository<CompilerClient, int> CompilerClientRepository => _compilerClientRepository ??
                                                                                   (_compilerClientRepository =
                                                                                       GenericRepository
                                                                                           <CompilerClient, int>.Create(
                                                                                               _onlineCompilerContext));

        public IGenericRepository<CompileResult, int> CompileResultRepository => _compileResultRepository ??
                                                                                 (_compileResultRepository =
                                                                                     GenericRepository
                                                                                         <CompileResult, int>.Create(
                                                                                             _onlineCompilerContext));

        public IGenericRepository<TestResult, int> TestResultRepository => _testResultRepository ??
                                                                           (_testResultRepository =
                                                                               GenericRepository<TestResult, int>.Create
                                                                                   (_onlineCompilerContext));

        #endregion

        #region Interface Implementation

        public void SaveChange(bool isAsync = false)
        {
            if (isAsync)
            {
                _onlineCompilerContext.SaveChangesAsync();
            }
            else
            {
                _onlineCompilerContext.SaveChanges();
            }
        }


        //To Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}