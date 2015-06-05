using System;

namespace Dal
{
    public sealed class CargoclixUnitOfWork : ICargoclixUnitofWork
    {

        //Prepare the variables here
        private readonly Context _userContext = new Context();


        private bool _disposed;


        public void SaveChange(bool isAsync = false)
        {
            if (isAsync)
            {
                _userContext.SaveChangesAsync();
            }
            else
            {
                _userContext.SaveChanges();
            }

        }

        #region "CleanUpCode"

        //To Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //To Dispose
        public void Dispose(bool disposing)
        {
            if (!_disposed & disposing)
                _userContext.Dispose();

            _disposed = true;
        }

        ~CargoclixUnitOfWork()
        {
            Dispose(false);
        }

        #endregion

        public IRepository<Booking, int> BookingRepository { get; private set; }
        public IRepository<Delay, int> DelayRepository { get; private set; }
        public IRepository<Message, int> MessageRepository { get; private set; }
    }
}
