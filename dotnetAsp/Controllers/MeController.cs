using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetAsp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeController : EasyAuthControllerBase
    {
        [HttpGet]
        public IActionResult Index() => Ok(this.EasyAuthUser);
    }
}