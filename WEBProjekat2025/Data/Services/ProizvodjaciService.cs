using WEBProjekat2025.Data.Base;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Data.Services
{
    public class ProizvodjaciService : EntityBaseRepository<Proizvodjac>, IProizvodjaciService
    {
        public ProizvodjaciService(appDbContext context) : base(context)
        {

        }
    }
}
