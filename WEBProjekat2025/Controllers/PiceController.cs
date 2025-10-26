using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using WEBProjekat2025.Data.Services;
using WEBProjekat2025.Data.ViewModels;
using WEBProjekat2025.Models;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WEBProjekat2025.Controllers
{
    public class PiceController : Controller
    {
        private readonly IPiceService _service;

        public PiceController(IPiceService service)
        {
            _service = service;
        }

        // GET: Pice
        public async Task<IActionResult> Index()
        {
          

            var svaPica = await _service.GetAllAsync(p => p.Diskont);
            return View(svaPica);
        }

        public async Task<IActionResult> Filter(string searchString)
        {


            var svaPica = await _service.GetAllAsync(p => p.Diskont);
            if (!string.IsNullOrEmpty(searchString)) 
            {
                var filteredResult = svaPica.Where(n => n.Ime.Contains(searchString) || n.Opis.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", svaPica);
        }


        // GET: Pice/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var piceDetail = await _service.GetPiceByIdAsync(id);

            if (piceDetail == null)
                return View("NotFound"); 

            return View(piceDetail);
        }

        //GET : Pice/Create

        public async Task<IActionResult> Create()
        {

            var piceDropdownsData = await _service.GetNewPiceDropDownsValues();

            ViewBag.DiskontId = new SelectList(piceDropdownsData.Diskont, "Id", "Naziv");
            ViewBag.Proizvodjac = new SelectList(piceDropdownsData.Proizvodjac, "Id", "Ime");
            ViewBag.Aroma = new SelectList(piceDropdownsData.Aroma, "Id", "Ime");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPiceVM pice)
        {

            if (ModelState.IsValid) 
            {
                var piceDropdownsData = await _service.GetNewPiceDropDownsValues();

                ViewBag.DiskontId = new SelectList(piceDropdownsData.Diskont, "Id", "Naziv");
                ViewBag.Proizvodjac = new SelectList(piceDropdownsData.Proizvodjac, "Id", "Ime");
                ViewBag.Aroma = new SelectList(piceDropdownsData.Aroma, "Id", "Ime");
                return View(pice);
            }

            await _service.AddNewPiceAsync(pice);
            return RedirectToAction(nameof(Index));
        }


        // GET: Pice/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var piceDetails = await _service.GetPiceByIdAsync(id);
            if (piceDetails == null) return View("NotFound");

            var response = new NewPiceVM()
            {
                Ime = piceDetails.Ime,
                Opis = piceDetails.Opis,
                Cena = piceDetails.Cena,
                SlikaURL = piceDetails.SlikaURL,
                DiskontId = piceDetails.DiskontId,
                ProizvodjacId = piceDetails.ProizvodjacId,
                AromeIds = piceDetails.Arome_Pice.Select(n => n.AromaId).ToList(),
                KategorijaPica = piceDetails.KategorijaPica,
                Proizvedeno = piceDetails.Proizvedeno
            };

            var piceDropdownsData = await _service.GetNewPiceDropDownsValues();
            ViewBag.Diskont = new SelectList(piceDropdownsData.Diskont, "Id", "Naziv");
            ViewBag.Proizvodjac = new SelectList(piceDropdownsData.Proizvodjac, "Id", "Ime");
            ViewBag.Aroma = new SelectList(piceDropdownsData.Aroma, "Id", "Ime");

            return View(response);
        }

        // POST: Pice/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPiceVM pice)
        {
            if (id != pice.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var piceDropdownsData = await _service.GetNewPiceDropDownsValues();
                ViewBag.Diskont = new SelectList(piceDropdownsData.Diskont, "Id", "Naziv");
                ViewBag.Proizvodjac = new SelectList(piceDropdownsData.Proizvodjac, "Id", "Ime");
                ViewBag.Aroma = new SelectList(piceDropdownsData.Aroma, "Id", "Ime");
                return View(pice);
            }

            await _service.UpdateNewlAsync(pice);
            return RedirectToAction(nameof(Index));
        }
    }
}
