using System;
using OnlineCoding.IBal;
using OnlineCoding.IDal.IUnitOfWork;

namespace OnlineCoding.Bal
{
    internal class LoggerBal : BalBase, ILoggerBal
    {
        public LoggerBal(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool LogErrorMessage(Exception log,string appName)
        {
            Unit.LogException(log,appName);
            return true;
        }
    }
}