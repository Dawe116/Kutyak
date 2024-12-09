using Kutyak.Models;
using Kutyak.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpDelete("{id}")]

        public IActionResult DeleteKutya(int id)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Kutya kutya = new Kutya { Id = id };
                    context.Kutyas.Remove(kutya);
                    //context.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, "Kutya kitörölve.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]

        public async Task<IActionResult> Put([FromForm] string Json, [FromForm] IFormFile indexKep, [FromForm] IFormFile kep)
        {
            using(var context=new KutyakContext())
            {
                try
                {
                    Kutya kutya = JsonConvert.DeserializeObject<Kutya>(Json);
                    byte[] IndexKep;
                    using (var ms = new MemoryStream())
                    {
                        await indexKep.CopyToAsync(ms);
                        IndexKep = ms.ToArray();
                    }
                    byte[] Kep;
                    using (var ms = new MemoryStream())
                    {
                        await kep.CopyToAsync(ms);
                        Kep = ms.ToArray();
                    }
                    kutya.IndexKep = IndexKep;
                    kutya.Kep = Kep;
                    context.Kutyas.Update(kutya);
                    await context.SaveChangesAsync();
                    return Ok("A kutya adatainak a módosítása sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return BadRequest("A kutya adatainak a módosítása sikertelen!");
                }
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromForm] string Json, [FromForm] IFormFile indexKep, [FromForm] IFormFile kep)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Kutya kutya = JsonConvert.DeserializeObject<Kutya>(Json);
                    byte[] IndexKep;
                    using (var ms = new MemoryStream())
                    {
                        await indexKep.CopyToAsync(ms);
                        IndexKep = ms.ToArray();
                    }
                    byte[] Kep;
                    using (var ms = new MemoryStream())
                    {
                        await kep.CopyToAsync(ms);
                        Kep = ms.ToArray();
                    }
                    kutya.IndexKep = IndexKep;
                    kutya.Kep = Kep;
                    context.Kutyas.Add(kutya);
                    await context.SaveChangesAsync();
                    return Ok("A kutya adatainak a tárolása sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return BadRequest("A kutya adatainak a tárolása sikertelen!");
                }
            }
        }

    }
}
