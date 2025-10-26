using WEBProjekat2025.Data.Base;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Data.Services
{
    public class DiskontiService:EntityBaseRepository<Diskont>,IDiskontiService
    {
        public DiskontiService(appDbContext context) : base(context) 
        {
            
        }
    }
}
