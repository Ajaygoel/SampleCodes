using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using App.DemoCargoClix.common;
using Bal;
using domain.Model;

namespace App.DemoCargoClix.Controllers
{
    public class BookingsController : BaseApiController
    {
        private readonly IBookingsBal _bookingsBal = new BookingsBal();

        private readonly List<Slot> _slots = new List<Slot>();

        BookingsController()
        {
            _slots.Add(
                new Slot()
                {
                    Id = 1,
                    Place = "ohio",
                    Time = DateTime.Now
                });
            _slots.Add(
                new Slot()
                {
                    Id = 2,
                    Place = "alabama",
                    Time = DateTime.Now
                });
            _slots.Add(
                new Slot()
                {
                    Id = 3,
                    Place = "texas",
                    Time = DateTime.Now
                });
       
        }
            
        [HttpPost]
        public IEnumerable<Slot> GetBookings(User user)
        {
            _bookingsBal.GetBookings(user);
            return _slots;
        }

        [HttpGet]
        public Slot GetBookingDetails(int id)
        {
            _bookingsBal.GetBookingDetails(id);
            return _slots.FirstOrDefault(x => x.Id == id);
        }


        [HttpPost]
        public bool PostDelay(Delay delay)
        {
           // _bookingsBal.ReportDelay(delay);
            return true;
        }

        [HttpPost]
        public bool SendMessage(Message message)
        {
           // _bookingsBal.SendMessage(message);
            return true;
        }
    }
}
