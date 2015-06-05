using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace domain.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int SlotId { get; set; }

        public Slot Slot { get; set; }

    }
}