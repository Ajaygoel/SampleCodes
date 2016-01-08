using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCoding.Domain.Dto;
using OnlineCoding.Domain.Dto.Client;
using OnlineCoding.IBal;
using OnlineCoding.IDal.IUnitOfWork;

namespace OnlineCoding.Bal
{
    class CompilerClientBal :BalBase,ICompilerClientBal 
    {
        public CompilerClientBal(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public BaseDto AddClient(AddClient client)
        {
            throw new NotImplementedException();
        }

        public BaseDto ConnectClient(ConnectClient client)
        {
            throw new NotImplementedException();
        }

        public BaseDto DisconnectClient(DisconnectClient client)
        {
            throw new NotImplementedException();
        }
    }
}
