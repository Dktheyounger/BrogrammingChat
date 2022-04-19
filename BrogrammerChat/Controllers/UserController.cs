using BrogrammerChat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrogrammerChat.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet(Name = "GetUser")]
        public IEnumerable<MoUser> Get()
        {
            return new List<MoUser>();
        }
    }
}
