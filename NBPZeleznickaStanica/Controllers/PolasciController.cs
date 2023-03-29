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
    public class PolasciController : Controller
    {
        private readonly IPolasciService _polasciService;
        private readonly IUserService _userService;

        public PolasciController(IPolasciService ps, IUserService us)
        {
            _polasciService = ps;
            _userService = us;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> CreatePolasci([FromBody] Polasci polasci)
        {

            await _polasciService.AddPolasciAsync(polasci);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AllPolasci(bool changed = false)
        {
            if (changed)
                ViewBag.Message = "Uspešno ste ažurirali polazak! ";

            List<Polasci> UserPolasci = null;
            UserPolasci = await _polasciService.GetPolasciAsync();

            return View(UserPolasci);
        }

        public async Task<IActionResult> DeletePolasci(string polasciId)
        {
            await _polasciService.DeletePolasciAsync(polasciId);
            return RedirectToAction("AllPolasci", "Polasci");
        }

        public async Task<IActionResult> UpdatePolasci([FromBody] Polasci polasci)
        {
            await _polasciService.UpdatePolasciAsync(polasci);
            return RedirectToAction("AllPolasci", "Polasci");
        }

        public async Task<IActionResult> ChangePolasci(string polasciId)
        {
            var polasci = await _polasciService.GetPolasciByIdAsync(polasciId);
            return View(polasci);
        }


    }
}
