using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCoding.Domain.Dto;
using OnlineCoding.Domain.Dto.Client;

namespace OnlineCoding.IBal
{
   public interface ICompilerClientBal
   {
       BaseDto AddClient(AddClient client);
       BaseDto ConnectClient(ConnectClient client);
       BaseDto DisconnectClient(DisconnectClient client);
   }
}
