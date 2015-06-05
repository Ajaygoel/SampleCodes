using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
   public class Booking
    {

        public int Id { get; set; }
        public DateTime Time { get; set; }

        public string Place { get; set; }

        public IEnumerable<Delay> Delay { get; set; }

        public IEnumerable<Message> Message { get; set; }
    }
}
