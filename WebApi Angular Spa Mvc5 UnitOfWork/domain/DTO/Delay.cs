using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace domain.Model
{
    public class Delay
    {
        public int Id { get; set; }
        public string NewEta { get; set; }
        public string ReasonForDelay { get; set; }
        public string FreeText { get; set; }

        public int SlotId { get; set; }

        public Slot Slot { get; set; }
    }
}