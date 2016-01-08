using AvnonDemo.DataAccess.Messages;
using AvnonDemo.Domain.Core;
using AvnonDemo.Domain.Message;
using System.Collections.Generic;
using AvnonDemo.Domain.Security;

namespace AvnonDemo.Services.Messages
{
    public class MessageService : IMessageService
    {
        public BaseResponse<List<MessageDto>> GetAll(IRequester requester)
        {
            MessageDbContext objMessageDbContext = null;
            try
            {
                objMessageDbContext = new MessageDbContext();
                var dtos = objMessageDbContext.GetMessagesByUserId((int)requester.AccountId);
                return ResponseFactory.SuccessForType(dtos);
            }
            finally
            {
                objMessageDbContext = null;
            }
        }

        public BaseResponse<MessageDto> Save(IRequester requester, MessageDto extDto)
        {
            MessageDbContext objMessageDbContext = null;
            try
            {
                objMessageDbContext = new MessageDbContext();
                if (requester.AccountId != null)
                { 
                    extDto.UserId = (int)requester.AccountId;
                }

                var dtos = objMessageDbContext.Save(extDto);
                return ResponseFactory.SuccessForType(dtos);
            }
            finally
            {
                objMessageDbContext = null;
            }
        }

        public BaseResponse Delete(IRequester requester, int id)
        {
            MessageDbContext objMessageDbContext = null;
            MessageDto dto = null;
            try
            {
                objMessageDbContext = new MessageDbContext();
                
                dto = new MessageDto
                {
                    Id = id,
                    _deleted = true
                };
                
                if (requester.AccountId != null)
                {
                    dto.UserId = (int)requester.AccountId;
                }

                objMessageDbContext.Save(dto);

                return ResponseFactory.Success(null, "Message deleted successfully");
            }
            finally
            {
                dto = null;
                objMessageDbContext = null;
            }
        }
    }
}
