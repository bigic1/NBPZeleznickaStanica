using Microsoft.AspNetCore.Mvc;
using NBPZeleznickaStanica.Extensions;
using NBPZeleznickaStanica.IServices;
using NBPZeleznickaStanica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBPZeleznickaStanica.Controllers
{
    public class RezervacijeController : Controller
    {
        private readonly IRezervacijeService _rezervacijeService;
        private readonly IPolasciService _polasciService;
        private readonly IUserService _userService;

        public RezervacijeController(IRezervacijeService ps, IPolasciService rs, IUserService us)
        {
            _rezervacijeService = ps;
            _polasciService = rs;
            _userService = us;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> CreateRezervacije([FromBody] Rezervacije rezervacije)
        {

            await _rezervacijeService.AddRezervacijeAsync(rezervacije);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Rezervacije(bool changed = false)
        {
            if (changed)
                ViewBag.Message = "Uspešno ste ažurirali polazak! ";

            var userId = HttpContext.Session.GetUserId();
            List<Rezervacije> UserRezervacije = null;
            UserRezervacije = await _rezervacijeService.GetUserRezervacije(userId);

            return View(UserRezervacije);
        }

        public async Task<IActionResult> DeleteRezervacije(string rezervacijeId)
        {
            await _rezervacijeService.DeleteRezervacijeAsync(rezervacijeId);
            return RedirectToAction("Rezervacije", "Rezervacije");
        }
        public async Task<IActionResult> UpdateRezervacije([FromBody] Rezervacije rezervacije)
        {
            await _rezervacijeService.UpdateRezervacijeAsync(rezervacije);
            return RedirectToAction("Rezervacije", "Rezervacije");
        }

        public async Task<IActionResult> ChangeRezervacije(string rezervacijeId)
        {
            var rezervacije = await _rezervacijeService.GetRezervacijeByIdAsync(rezervacijeId);
            return View(rezervacije);
        }


    }
}
