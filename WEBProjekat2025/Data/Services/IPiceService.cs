using WEBProjekat2025.Data.Base;
using WEBProjekat2025.Data.ViewModels;
using WEBProjekat2025.Models;

namespace WEBProjekat2025.Data.Services
{
    public interface IPiceService : IEntityBaseRepository<Pice>
    {
        Task<Pice> GetPiceByIdAsync(int id);
        Task<NewPiceDropDownsVM> GetNewPiceDropDownsValues();
        Task AddNewPiceAsync(NewPiceVM data);
        Task UpdateNewPiceAsync(NewPiceVM data);
    }
}
