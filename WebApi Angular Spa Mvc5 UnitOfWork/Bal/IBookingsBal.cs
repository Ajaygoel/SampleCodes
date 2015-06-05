using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Model;

namespace Bal
{
    public interface IBookingsBal
    {
        Slot GetBookingDetails(int bookingId);
        bool ReportDelay(domain.Model.Delay delay);
        bool SendMessage(domain.Model.Message message);
        IEnumerable<Slot> GetBookings(User user);


    }
}
