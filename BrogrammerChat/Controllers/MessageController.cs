using BrogrammerChatData.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrogrammerChat.Controllers
{
    [Route("[controller]/Messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly BrogrammerChatContext _brogrammerChatContext;
        public MessageController(BrogrammerChatContext brogrammerChatContext)
        {
            _brogrammerChatContext = brogrammerChatContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetMessages()
        {
            //using BrogrammerChatContext dataContext = new BrogrammerChatContext();
            var messages = _brogrammerChatContext.Messages.ToList();
            return Ok(messages);
        }

        [HttpGet("{_messageID}")]
        public ActionResult<Message> GetMessage(int _messageID)
        {;
            var message = _brogrammerChatContext.Messages.Single(message => message.MessageId == _messageID);

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


            var content = new Content()
            {
                TextAttachments = "",
                BinaryAttachments = new byte[0]
            };

            _brogrammerChatContext.Contents.Add(content);
            _brogrammerChatContext.SaveChanges();

            var message = new Message()
            {
                ContentId = content.ContentId,
                UserId = _message.UserId
            };

            _brogrammerChatContext.Messages.Add(message);
            _brogrammerChatContext.SaveChanges();
            return Ok();
        }
    }
}
