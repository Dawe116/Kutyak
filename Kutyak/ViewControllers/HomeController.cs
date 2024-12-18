using Kutyak.Models;
using Kutyak.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kutyak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Kutyak()
        {
            return View(KutyaService.GetKutyak());
        }

        public IActionResult KutyakDTO()
        {
            return View(KutyaService.GetKutyakDTO());
        }

        public IActionResult Fajtak()
        {
            return View(FajtaService.GetFajtak());
        }

        public IActionResult FajtakDTO()
        {
            return View(FajtaService.GetFajtaDTOs());
        }

        public IActionResult KutyaKep(int id)
        {
            return View(KutyaService.GetKutyaGumi(id));
        }

        public IActionResult KutyaTorol(int id)
        {
            //KutyaService.KutyaTorol(id);
            return Redirect("/Home/KutyakDTO");
        }

        public async Task<IActionResult> KutyaKozmetika(int id)
        {
            await Task.Delay(500);
            Kutya kutya = KutyaService.GetKutya(id);
            if (kutya == null)
            {
                ViewBag.Kutya = new Kutya { Id = 0, IndexKep = new byte[0], Kep = new byte[0] };
            }
            else
            {
                ViewBag.Kutya = kutya;
            }
            ViewBag.Gazdak = GazdaService.GetGazdak();
            ViewBag.Fajtak = FajtaService.GetFajtak();
            return View(ViewBag);
        }

        public async Task<IActionResult> FajtaKozmetika(int id)
        {
            await Task.Delay(500);
            Fajtum fajta = FajtaService.GetFajta(id);
            

                ViewBag.Fajta = fajta;

            ViewBag.Fajtak = FajtaService.GetFajtak();
            return View(ViewBag);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
