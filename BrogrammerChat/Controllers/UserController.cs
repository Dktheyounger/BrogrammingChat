using BrogrammerChatData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrogrammerChat.Controllers
{
    [Route("[controller]/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BrogrammerChatContext _brogrammerChatContext;
        public UserController(BrogrammerChatContext brogrammerChatContext)
        {
            _brogrammerChatContext = brogrammerChatContext;
        }

        [HttpGet("{_userID}")]
        public ActionResult<IEnumerable<Message>> GetUserMessages(int _userID)
        {
            //Garbage code just to get a byte[] as a string
            Byte[] data = new Byte[10];
            string dataAsString = Convert.ToBase64String(data);

            var messages = _brogrammerChatContext.Messages.Where(message => message.UserId == _userID).ToList();
            return Ok(messages);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _brogrammerChatContext.Users.ToList();
            return Ok(users);
        }

        [HttpPost(Name = "PostUser")]
        public ActionResult Post([FromBody] User _user)
        {
            if (_user.UserId != 0 || _user == null)
            {
                return BadRequest();
            }


            var user = new User()
            {
                UserName = _user.UserName,
                Password = _user.Password
            };

            _brogrammerChatContext.Users.Add(user);
            _brogrammerChatContext.SaveChanges();
            return Ok(user);
        }
    }
}
