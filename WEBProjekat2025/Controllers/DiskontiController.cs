using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBProjekat2025.Data.Services;
using WEBProjekat2025.Data.Static;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class DiskontiController : Controller
    {
        private readonly IDiskontiService _service;
        

        public DiskontiController(IDiskontiService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            var sviDiskonti = await _service.GetAllAsync();
            return View(sviDiskonti);

        }

        //get: Diskonti/create/

        public IActionResult Create() {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind ("LogoURL,Naziv,Adresa")] Diskont diskont) 
        {
            if (!ModelState.IsValid)
            {
                return View(diskont);

            }
            await _service.AddAsync(diskont);
            return RedirectToAction(nameof(Index));
        }

        //Details
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            var diskontDetails = await _service.GetByIdAsync(id);

            if (diskontDetails == null) return View("NotFound");
            return View(diskontDetails);
        }

        //Get Arome/Edit1

        public async Task<IActionResult> Edit(int id)
        {
            var diskontDetails = await _service.GetByIdAsync(id);

            if (diskontDetails == null) return View("NotFound");
            return View(diskontDetails);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id,LogoURL,Naziv,Adresa")] Diskont diskont)
        {
            if (!ModelState.IsValid)
            {
                return View(diskont);

            }
            await _service.UpdateAsync(id, diskont);
            return RedirectToAction(nameof(Index));
        }

        //Get Arome/Delete1

        public async Task<IActionResult> Delete(int id)
        {
            var diskontDetails = await _service.GetByIdAsync(id);

            if (diskontDetails == null) return View("NotFound");
            return View(diskontDetails);
        }

        [HttpPost, ActionName("Delete")]


        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diskontDetails = await _service.GetByIdAsync(id);
            if (diskontDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}

