namespace AvnonDemo.Domain.Core
{
    public abstract class Dto : IDto
    {
        public int Id { get; set; }

        /// <summary>
        /// This field allows us to track deleted items from the client (web page) so that
        /// this can be appropriately updated on the server.
        /// This is only necessary for attached child objects eg Contact.Emails where there is no dedicated service to manage Emails
        /// </summary>
        public bool _deleted { get; set; }
    }
} 