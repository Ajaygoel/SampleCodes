using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCoding.IBal;
using OnlineCoding.IDal.IUnitOfWork;

namespace OnlineCoding.Bal
{
    class TestResultBal :BalBase,ITestResultBal
    {
        public TestResultBal(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
