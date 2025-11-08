using FuelManagement.Core.Dtos.News;
using FuelManagement.Core.Dtos.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Services.Interface;

public interface IRulesService
{
    List<ListRulesDto> GetAll(string search);


    bool Add(CreateNewRule rule);


    //DetailRulesDto GetDetail(long id);
    bool Remove(long id, string userLog);
}
