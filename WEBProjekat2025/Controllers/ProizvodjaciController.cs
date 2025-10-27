using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WEBProjekat2025.Data.Services;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Controllers
{
    [Authorize]
    public class ProizvodjaciController : Controller
    {
       
        private readonly IProizvodjaciService _service;

        public ProizvodjaciController(IProizvodjaciService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
           
            var sviProizvodjaci = await _service.GetAllAsync();
            return View(sviProizvodjaci);

        }

        //Get: proizvodjaci/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id) 
        {
            var proizvodjacDetails = await _service.GetByIdAsync(id);
            if (proizvodjacDetails == null) return View("NotFound");
            return View(proizvodjacDetails);
        }

        //Get: producers/create

        public IActionResult Create() 
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create([Bind("LogoURL,Ime,Opis")]Proizvodjac proizvodjac) 
        {
            if (!ModelState.IsValid) return View(proizvodjac);

            await _service.AddAsync(proizvodjac);
            return RedirectToAction(nameof(Index));
        }

        //Get: producers/edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var proizvodjacDetails = await _service.GetByIdAsync(id);
            if(proizvodjacDetails == null) return View("NotFound");
            return View(proizvodjacDetails);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LogoURL,Ime,Opis")] Proizvodjac proizvodjac)
        {
            if (!ModelState.IsValid) return View(proizvodjac);

            if (id == proizvodjac.Id) {

                await _service.UpdateAsync(id, proizvodjac);
                return RedirectToAction(nameof(Index));
            }

            await _service.UpdateAsync(id,proizvodjac);
            return RedirectToAction(nameof(Index));
        }
        //Get: producers/delete/1

      
        public async Task<IActionResult> Delete(int id)
        {
            var proizvodjacDetails = await _service.GetByIdAsync(id);
            if (proizvodjacDetails == null) return View("NotFound");
            return View(proizvodjacDetails);

            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvodjacDetails = await _service.GetByIdAsync(id);
            if (proizvodjacDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
