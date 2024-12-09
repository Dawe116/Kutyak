using Kutyak.Models;
using Kutyak.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kutyak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FajtaController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetKutya()
        {
            return StatusCode(StatusCodes.Status200OK, FajtaService.GetFajtak());
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteFajta(int id)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Fajtum fajta = new Fajtum { Id = id };
                    context.Fajtas.Remove(fajta);
                    context.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, "Fajta kitörölve.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}