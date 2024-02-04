using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("Hello")]
        public string ReturnHello()
        {
            return "Hello !!!!!!";
        }

        [HttpGet("Hello1")]
        public string ReturnHello1()
        {
            return "Hello World!!!!!!";
        }
    }
}
