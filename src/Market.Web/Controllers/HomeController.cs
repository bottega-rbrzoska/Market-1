using System;
using Market.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Market.Web.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly IOptions<AppOptions> _appOptions;

        public HomeController(IOptions<AppOptions> appOptions)
        {
            _appOptions = appOptions;
        }
        
        [HttpGet("api")]
        public ActionResult<string> Get() => "Welcome to Market API";
        
        [HttpGet("app")]
        public ActionResult<string> GetAppName() => _appOptions.Value.Name;
        
        [HttpGet("ex")]
        public ActionResult GetEx() => throw new ArgumentException("Ooopss...");
    }
}