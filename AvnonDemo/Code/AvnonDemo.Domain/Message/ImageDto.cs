using AvnonDemo.Domain.Core;

namespace AvnonDemo.Domain.Message
{
    public class ImageDto : Dto
    {
        public string Url { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
    }
}
