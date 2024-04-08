using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Services.Interfaces
{
    internal interface ISettingService
    {
        Task<List<Setting>> GetAllAsync();
        Task CreateAsync(Setting setting);
        Task DeleteAsync(int id);
        Task<Setting> GetById(int id);
    }
}
