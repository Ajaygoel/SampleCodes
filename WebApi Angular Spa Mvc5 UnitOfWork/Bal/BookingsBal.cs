using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using domain.Model;

namespace Bal
{
    public class BookingsBal :IBookingsBal
    {
        private readonly ICargoclixUnitofWork _unit = new CargoclixUnitOfWork();

        public IEnumerable<Slot> GetBookings(User user)
        {
            return null;
            //  _unit.BookingRepository.Get();
        }

        public Slot GetBookingDetails(int bookingId)
        {
            return null;
        }

        public bool ReportDelay(domain.Model.Delay delay)
        {
            try
            {
                Dal.Delay de = new Dal.Delay
                {
                    Id = delay.Id,
                    NewEta = delay.NewEta,
                    BookingId = delay.SlotId,
                    FreeText = delay.FreeText,
                    ReasonForDelay = delay.ReasonForDelay

                };
                _unit.DelayRepository.Insert(de);
                _unit.SaveChange();
                return true;
            }
            catch (Exception)
            {
                //log and handle exception
                throw;
            }
            //transform Dto to db entity

         
        }

        public bool SendMessage(domain.Model.Message message)
        {
            try
            {
                Dal.Message me = new Dal.Message()
                {
                    Id = message.Id,
                    BookingId = message.SlotId,
                    Description = message.Description
                };
                _unit.MessageRepository.Insert(me);
                _unit.SaveChange();
                return true;
            }
            catch (Exception)
            {
                //log and handle exception
                throw;
            }
            
        }
    }
}
