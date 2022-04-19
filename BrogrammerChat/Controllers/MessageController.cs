using BrogrammerChat.Data;
using BrogrammerChat.Models;
using Microsoft.AspNetCore.Mvc;
using static BrogrammerChat.Data.BrogrammerChatContext;

namespace BrogrammerChat.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        [HttpGet(Name = "GetMessage")]
        public IEnumerable<MoMessage> Get()
        {
            return new List<MoMessage>();
        }

        [HttpPost(Name = "PostMessage")]
        public ActionResult Post(MoMessage message)
        {
            using (MyContext datacontenxt = new MyContext())
            {
                var m = new Message()
                {
                    ContentID = message.ContentID,
                    UserID = message.UserID
                };
                

                datacontenxt.Messages.Add(m);
                datacontenxt.SaveChanges();
                return CreatedAtAction(nameof(Post), message);
            }
        }
    }
}
