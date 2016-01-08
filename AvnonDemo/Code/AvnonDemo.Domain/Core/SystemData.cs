using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvnonDemo.Domain.Core
{
    public static class SystemData
    {
        public static DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
