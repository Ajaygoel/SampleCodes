using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
   public class Message
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }

    }
}
