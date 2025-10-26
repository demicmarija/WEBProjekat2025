using WEBProjekat2025.Data.Base;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Data.Services
{
    public class AromeService : EntityBaseRepository<Aroma>, IAromeService
    {
 

        public AromeService(appDbContext context) : base(context) { }
   

        
    }
}
