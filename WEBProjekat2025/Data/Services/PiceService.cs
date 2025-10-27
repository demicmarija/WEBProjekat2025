using Microsoft.EntityFrameworkCore;
using WEBProjekat2025.Data.Base;
using WEBProjekat2025.Data.ViewModels;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;
using WEBProjekat2025.Data.Services;





namespace WEBProjekat2025.Data.Services
{
    public class PiceService : EntityBaseRepository<Pice>, IPiceService
    {
        private readonly appDbContext _context;
        public PiceService(appDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Pice> GetPiceByIdAsync(int id)
        {
            var piceDetails = await _context.Pice
                .Include(d => d.Diskont)
                .Include(p => p.Proizvodjac)
                .Include(ap => ap.Arome_Pice)
                    .ThenInclude(a => a.Aroma)
                .FirstOrDefaultAsync(n => n.Id == id);

            return piceDetails;
        }

        public async Task<NewPiceDropDownsVM> GetNewPiceDropDownsValues()
        {
            var response = new NewPiceDropDownsVM()
            {
                Aroma = await _context.Aroma.OrderBy(n => n.Ime).ToListAsync(),
                Diskont = await _context.Diskont.OrderBy(n => n.Naziv).ToListAsync(),
                Proizvodjac = await _context.Proizvodjac.OrderBy(n => n.Ime).ToListAsync()

            };


            return response;
        }

        public async Task AddNewPiceAsync(NewPiceVM data)
        {

            var newPice = new Pice()
            {
                Ime = data.Ime,
                Opis = data.Opis,
                Cena = data.Cena,
                SlikaURL = data.SlikaURL,
                ProizvodjacId = data.ProizvodjacId,
                DiskontId = data.DiskontId,
                Proizvedeno = data.Proizvedeno,
                KategorijaPica = data.KategorijaPica
            };

            await _context.Pice.AddAsync(newPice);
            await _context.SaveChangesAsync();

            //Add Pice Arome

            foreach (var aromaId in data.AromeIds)
            {
                var newAromaPice = new Arome_Pice()
                {
                    PiceId = newPice.Id,
                    AromaId = aromaId
                };

                await _context.Arome_Pice.AddAsync(newAromaPice);
            }

            await _context.SaveChangesAsync();
        }

        


        public async Task UpdateNewPiceAsync(NewPiceVM data)
        {

            var dbPice = await _context.Pice.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbPice != null)
            {

                dbPice.Ime = data.Ime;
                dbPice.Opis = data.Opis;
                dbPice.Cena = data.Cena;
                dbPice.SlikaURL = data.SlikaURL;
                dbPice.ProizvodjacId = data.ProizvodjacId;
                dbPice.DiskontId = data.DiskontId;
                dbPice.Proizvedeno = data.Proizvedeno;
                dbPice.KategorijaPica = data.KategorijaPica;

                await _context.SaveChangesAsync();
            }

            //remove existing Pice

            var existingAromeDb = _context.Arome_Pice.Where(n => n.PiceId == data.Id).ToList();
            _context.Arome_Pice.RemoveRange(existingAromeDb);
            await _context.SaveChangesAsync();

            //add Pice Aroma
            foreach (var aromaId in data.AromeIds)
            {
                var newAromaPice = new Arome_Pice()
                {
                    PiceId = data.Id,
                    AromaId = aromaId
                };
                await _context.Arome_Pice.AddAsync(newAromaPice);
            }

            await _context.SaveChangesAsync();
        }

    }

}
 