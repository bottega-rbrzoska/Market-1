using Microsoft.AspNetCore.Mvc;

namespace Market.Web.Controllers
{
    [Route("api")]
    public class HomeController : ControllerBase
    {
        public ActionResult<string> Get() => "Welcome to Market API";
    }
}