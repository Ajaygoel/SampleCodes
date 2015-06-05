using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
  public  class Delay
    {
        public int Id { get; set; }
        public string NewEta { get; set; }
        public string ReasonForDelay { get; set; }
        public string FreeText { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }

    }
}
