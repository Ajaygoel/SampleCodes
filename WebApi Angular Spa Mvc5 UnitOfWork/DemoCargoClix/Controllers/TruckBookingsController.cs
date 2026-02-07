using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using App.DemoCargoClix.common;
using domain.Model;

namespace App.DemoCargoClix.Controllers
{
    public class TruckBookingsController : BaseApiController
    {
        private static readonly List<Truck> Trucks = new List<Truck>
        {
            new Truck
            {
                Id = 1,
                PlateNumber = "TX-1042",
                Model = "Volvo FH16",
                CapacityTons = 18.5m,
                Status = "Available"
            },
            new Truck
            {
                Id = 2,
                PlateNumber = "CA-8831",
                Model = "Freightliner Cascadia",
                CapacityTons = 16.0m,
                Status = "Booked"
            },
            new Truck
            {
                Id = 3,
                PlateNumber = "NV-5519",
                Model = "Kenworth T680",
                CapacityTons = 20.0m,
                Status = "Available"
            }
        };

        private static readonly List<TruckBooking> Bookings = new List<TruckBooking>
        {
            new TruckBooking
            {
                Id = 1001,
                TruckId = 2,
                CustomerName = "Northern Retail Group",
                PickupLocation = "Phoenix, AZ",
                DropoffLocation = "Las Vegas, NV",
                PickupDate = DateTime.Today.AddDays(1),
                Notes = "Palletized goods, dock 7",
                Status = "Confirmed"
            }
        };

        private static int _nextBookingId = 1002;

        [HttpGet]
        public IEnumerable<Truck> GetTrucks()
        {
            return Trucks;
        }

        [HttpGet]
        public IEnumerable<TruckBooking> GetBookings()
        {
            return Bookings.OrderByDescending(booking => booking.PickupDate).ToList();
        }

        [HttpGet]
        public TruckBooking GetBooking(int id)
        {
            return Bookings.FirstOrDefault(booking => booking.Id == id);
        }

        [HttpPost]
        public TruckBooking CreateBooking(TruckBookingRequest request)
        {
            if (request == null)
            {
                return null;
            }

            var truck = Trucks.FirstOrDefault(candidate => candidate.Id == request.TruckId);
            if (truck == null || string.Equals(truck.Status, "Booked", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var booking = new TruckBooking
            {
                Id = _nextBookingId++,
                TruckId = request.TruckId,
                CustomerName = request.CustomerName,
                PickupLocation = request.PickupLocation,
                DropoffLocation = request.DropoffLocation,
                PickupDate = request.PickupDate,
                Notes = request.Notes,
                Status = "Confirmed"
            };

            Bookings.Add(booking);
            truck.Status = "Booked";

            return booking;
        }
    }
}
