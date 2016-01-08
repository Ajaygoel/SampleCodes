using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvnonDemo.Domain.Security
{
    public interface IRequester
    {
        /// <summary>
        /// AccountId is nullable
        /// </summary>
        int? AccountId { get; set; }
        
    }
}
