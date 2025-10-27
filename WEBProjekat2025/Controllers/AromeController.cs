using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WEBProjekat2025.Data.Services;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Controllers
{
    [Authorize]
    public class AromeController : Controller
    {
        private readonly IAromeService _service;

        public AromeController(IAromeService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var sveArome = await _service.GetAllAsync();
            return View(sveArome);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("Ime,SlikaURL,Opis")]Aroma aroma) 
        {
            if (!ModelState.IsValid) 
            {
                return View(aroma);

            }
            await _service.AddAsync(aroma);
            return RedirectToAction(nameof(Index));
        }

        //Details
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            var aromaDetails = await _service.GetByIdAsync(id);

            if (aromaDetails == null) return View("NotFound");
            return View(aromaDetails);
        }

        //Get Arome/Edit1

        public async Task<IActionResult> Edit(int id)
        {
            var aromaDetails = await _service.GetByIdAsync(id);

            if (aromaDetails == null) return View("NotFound");
            return View(aromaDetails);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,SlikaURL,Opis")] Aroma aroma)
        {
            if (!ModelState.IsValid)
            {
                return View(aroma);

            }
            await _service.UpdateAsync(id,aroma);
            return RedirectToAction(nameof(Index));
        }

        //Get Arome/Delete1

        public async Task<IActionResult> Delete(int id)
        {
            var aromaDetails = await _service.GetByIdAsync(id);

            if (aromaDetails == null) return View("NotFound");
            return View(aromaDetails);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aromaDetails = await _service.GetByIdAsync(id);
            if (aromaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

   

 }
