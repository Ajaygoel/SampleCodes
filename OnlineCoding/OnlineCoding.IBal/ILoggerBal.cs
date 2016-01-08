using System;

namespace OnlineCoding.IBal
{
    public interface ILoggerBal
    {
        bool LogErrorMessage(Exception log,string appName);
    }
}