using AvnonDemo.Domain.Core;
using AvnonDemo.Domain.Message;
using AvnonDemo.Domain.Security;
using System.Collections.Generic;

namespace AvnonDemo.Services.Messages
{
    public interface IMessageService
    {
        BaseResponse<List<MessageDto>> GetAll(IRequester requester);
        BaseResponse<MessageDto> Save(IRequester requester, MessageDto extDto);
        BaseResponse Delete(IRequester requester, int id);
    }
}
