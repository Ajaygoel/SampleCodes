using System;

namespace domain.Model
{
    public class TruckBooking
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public string CustomerName { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public DateTime PickupDate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
