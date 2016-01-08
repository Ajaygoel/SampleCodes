using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvnonDemo.Domain.Security
{
    public class AppUser : IRequester
    {
        public int? AccountId { get; set; }
    }
}
