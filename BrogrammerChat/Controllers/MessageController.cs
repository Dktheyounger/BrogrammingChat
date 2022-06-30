﻿using BrogrammerChatData.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrogrammerChat.Controllers
{
    [Route("[controller]/Messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetMessages()
        {
            using BrogrammerChatContext dataContext = new BrogrammerChatContext();
            var messages = dataContext.Messages.ToList();
            return Ok(messages);
        }

        [HttpGet("{_messageID}")]
        public ActionResult<Message> GetMessage(int _messageID)
        {
            using BrogrammerChatContext dataContext = new BrogrammerChatContext();
            var message = dataContext.Messages.Single(message => message.MessageId == _messageID);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        [HttpPost(Name = "PostMessage")]
        public ActionResult Post([FromBody]Message _message)
        {
            if (_message.UserId == 0)
            {
                return BadRequest();
            }

            using BrogrammerChatContext dataContext = new BrogrammerChatContext();

            var content = new Content()
            {
                TextAttachments = "",
                BinaryAttachments = new byte[0]
            };

            dataContext.Contents.Add(content);
            dataContext.SaveChanges();

            var message = new Message()
            {
                ContentId = content.ContentId,
                UserId = _message.UserId
            };

            dataContext.Messages.Add(message);
            dataContext.SaveChanges();
            return Ok();
        }
    }
}
