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
    internal class CountryService : ICountryService
    {
        private readonly AppDbContext _appDbContext;

        public CountryService()
        {
            _appDbContext = new AppDbContext();
        }
        public async Task CreateAsync(Country country)
        {
            await _appDbContext.Countries.AddAsync(country);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _appDbContext.Countries.FirstOrDefault(c => c.Id == id);

            if (data == null)
            {
                throw new NotFoundException("Data not found..");
            }
            else
            {
                _appDbContext.Countries.Remove(data);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Country>> GetAllAsync()
        {
            var countries = await _appDbContext.Countries.ToListAsync();

            if (countries.Count < 0)
            {
                throw new NotFoundException("Data not found..");
            }
            else
            {
                return countries;
            }
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            var data = _appDbContext.Countries.FirstOrDefault(c => c.Id == id);

            if (data == null)
            {
                throw new NotFoundException("Data not found..");
            }
            return data;
        }
    }
}
