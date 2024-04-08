using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Helpers.Exceptions;
using Practice.Models;
using Practice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Services
{
    internal class SettingService : ISettingService
    {

        private readonly AppDbContext _appDbContext;

        public SettingService()
        {
            _appDbContext = new AppDbContext();
        }
        public async Task CreateAsync(Setting setting)
        {
            await _appDbContext.Settings.AddAsync(setting);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _appDbContext.Settings.FirstOrDefault(m => m.Id == id);

            if (data == null)
            {
                throw new NotFoundException("Data not found..");
            }
            _appDbContext.Settings.Remove(data);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            return await _appDbContext.Settings.ToListAsync();
        }

        public async Task<Setting> GetById(int id)
        {
            var data = _appDbContext.Settings.FirstOrDefault(m => m.Id == id);

            if (data == null)
            {
                throw new NotFoundException("DataNotFound");
            }
            return data;
        }
    }
}
