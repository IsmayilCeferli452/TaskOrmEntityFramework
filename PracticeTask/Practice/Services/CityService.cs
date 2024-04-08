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
    internal class CityService : ICityService
    {
        private readonly AppDbContext _appDbContext;

        public CityService()
        {
            _appDbContext = new AppDbContext();
        }

        public async Task CreateAsync(City city)
        {
            await _appDbContext.Cities.AddAsync(city);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _appDbContext.Cities.FirstOrDefault(c => c.Id == id);

            if (data == null)
            {
                throw new NotFoundException("Data not found..");
            }
            else
            {
                _appDbContext.Cities.Remove(data);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<City>> GetAllAsync()
        {
            var cities = await _appDbContext.Cities.Include(m => m.Country).ToListAsync();

            if(cities.Count < 0)
            {
                throw new NotFoundException("Data not found..");
            }
            else
            {
                return cities;
            }            
        }

        public async Task<City> GetByIdAsync(int id)
        {
            var data = _appDbContext.Cities.Include(m => m.Country).FirstOrDefault(c => c.Id == id);

            if(data == null)
            {
                throw new NotFoundException("Data not found..");
            }
            return data;
        }

        public async Task<List<City>> GetAllByCountryIdAsync(int id)
        {
            var data = await _appDbContext.Cities.Include(m => m.Country).Where(c => c.CountryId == id).ToListAsync();   
            
            if(data.Count < 1)
            {
                throw new NotFoundException("Data not found..");
            }
            return data;
        }

    }
}
