using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Hello world";
        }

        [HttpPost]
        [Route("")]
        public object Post()
        {
            return new { Title = "Hello world" };
        }

    }
}
