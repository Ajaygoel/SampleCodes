using AvnonDemo.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvnonDemo.Domain.Message
{
    public class MessageDto : Dto
    {
        public string Text { get; set; }

        public List<ImageDto> Images { get; set; }

        public int UserId { get; set; }

        public MessageDto()
        {
            Images = new List<ImageDto>();
        }
    }
}
