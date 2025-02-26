using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace DccMeter.API.Controllers
{
    [Route("api/v1")]
    //[SwaggerIgnore]
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("documentation")]
        public IActionResult Documentation()
        {
            return View();
        }
    }
}