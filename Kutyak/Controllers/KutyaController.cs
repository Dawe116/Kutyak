using Kutyak.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutyak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KutyaController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetKutya()
        {
            return StatusCode(StatusCodes.Status200OK, KutyaService.GetKutyak());
        }
    }
}
