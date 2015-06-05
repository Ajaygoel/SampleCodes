using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
   public interface ICargoclixUnitofWork :IDisposable
    {
        IRepository<Booking, int> BookingRepository { get; }
        IRepository<Delay, int> DelayRepository { get; }
        IRepository<Message, int> MessageRepository { get; }

        void SaveChange(bool isAsync = false);

       
    }
}
