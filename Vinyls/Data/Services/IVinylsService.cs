using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data.Base;
using Vinyls.Data.ViewModels;
using Vinyls.Models;

namespace Vinyls.Data.Services
{
    public interface IVinylsService:IEntityBaseRepository<Vinyl>
    {
        Task<Vinyl> GetVinylByIdAsync(int id);
        Task<NewVinylDropdownVM> GetNewVinylDropdownsValues();
        Task AddNewVinylAsync(NewVinylVM data);
        Task UpdateVinylAsync(NewVinylVM data);

    }
}
