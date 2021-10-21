using Microsoft.AspNetCore.Mvc;
using Payeh.Utilities.Services;
using Payeh.Utilities.Services.Translations;

namespace Payeh.Api.Sample.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        private IPayehService _payehService;

        public TestController(IPayehService payehService)
        {
            _payehService = payehService;
        }


        [HttpGet]
        public ActionResult Index()
        {
             _payehService.Logger.Log("hi", "fa");
             return Ok();
        }
    }
}