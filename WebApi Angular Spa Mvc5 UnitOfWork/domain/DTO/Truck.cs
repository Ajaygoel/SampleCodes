using System;

namespace domain.Model
{
    public class Truck
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public decimal CapacityTons { get; set; }
        public string Status { get; set; }
    }
}
