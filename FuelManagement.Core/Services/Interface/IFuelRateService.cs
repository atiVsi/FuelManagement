using FuelManagement.Core.Dtos.FuelRate;
using FuelManagement.DataLayer.Entities.FuelRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Services.Interface
{
    public interface IFuelRateService : IRepository<long, FuelRate>
    {
        bool Add(CreateFuelRateDto FuelRate);
 
        bool Edit(EditFuelRateDto FuelRate);

        bool Remove(long id, string userLog);

        List<ListFuelRateDto> GetAll(string search);

        DetailFuelRateDto GetDetail(long id);

    }
}
