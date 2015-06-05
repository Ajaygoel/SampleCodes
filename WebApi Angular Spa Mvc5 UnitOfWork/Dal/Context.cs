using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public sealed class Context : DbContext
    {
        public Context()
        {
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Delay> Delays { get; set; }


    }
}
