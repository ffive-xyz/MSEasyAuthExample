using Microsoft.AspNetCore.Mvc;

namespace dotnetAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index() => Ok(Request.Headers);
    }
}