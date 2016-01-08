using AvnonDemo.Domain.Core;
using AvnonDemo.Domain.Message;
using AvnonDemo.Services.Authentication;
using AvnonDemo.Services.Messages;
using AvnonDemo.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AvnonDemo.Web.Api.Messages
{
    public class MessageController : BaseApiController
    {

        private readonly IMessageService _service;
        public MessageController(IAuthenticationService authenticationService, IMessageService service)
            : base(authenticationService)
        {
            _service = service;
        }

        /// <summary>
        /// This gets all the Message
        /// </summary> 
        [ActionName("Default")]
        [HttpGet]
        public virtual BaseResponse<List<MessageDto>> GetAll()
        {
            if (LoggedInUser.AccountId != null)
                return _service.GetAll(LoggedInUser);
            return null;
        }

        //[ActionName("Default")]
        //[HttpGet]
        //public virtual BaseResponse<MessageDto> Read(int id)
        //{
        //    var data = _service.Get(LoggedInUser, id);
        //    return data;
        //}

        [ActionName("Default")]
        [HttpPost]
        public virtual BaseResponse<MessageDto> Create([FromBody]MessageDto dto)
        {
            var data = _service.Save(LoggedInUser, dto);
            return data;
        }

        [ActionName("Default")]
        [HttpPut]
        public virtual BaseResponse<MessageDto> Update(int id, [FromBody]MessageDto dto)
        {
            var data = _service.Save(LoggedInUser, dto);
            return data;
        }

        [ActionName("Default")]
        [HttpDelete]
        public BaseResponse Delete(int id)
        {
            var data = _service.Delete(LoggedInUser, id);
            return data;
        }
    }
}