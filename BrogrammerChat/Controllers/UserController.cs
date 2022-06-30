using BrogrammerChatData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrogrammerChat.Controllers
{
    [Route("[controller]/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{_userID}")]
        public ActionResult<IEnumerable<Message>> GetUserMessages(int _userID)
        {
            //Garbage code just to get a byte[] as a string
            Byte[] data = new Byte[10];
            string dataAsString = Convert.ToBase64String(data);

            using BrogrammerChatContext dataContext = new BrogrammerChatContext();
            var messages = dataContext.Messages.Where(message => message.UserId == _userID).ToList();
            return Ok(messages);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            using BrogrammerChatContext dataContext = new BrogrammerChatContext();
            var users = dataContext.Users.ToList();
            return Ok(users);
        }

        [HttpPost(Name = "PostUser")]
        public ActionResult Post([FromBody] User _user)
        {
            if (_user.UserId != 0 || _user == null)
            {
                return BadRequest();
            }

            using BrogrammerChatContext dataContext = new BrogrammerChatContext();

            var user = new User()
            {
                UserName = _user.UserName,
                Password = _user.Password
            };

            dataContext.Users.Add(user);
            dataContext.SaveChanges();
            return Ok(user);
        }
    }
}
