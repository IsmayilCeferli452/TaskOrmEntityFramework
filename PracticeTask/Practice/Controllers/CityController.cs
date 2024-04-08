using Practice.Models;
using Practice.Services;
using Practice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Controllers
{
    internal class CityController
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CityController()
        {
            _cityService = new CityService();
            _countryService = new CountryService();
        }

        public async Task GetAllByCountryId()
        {
            try
            {
                Console.WriteLine("Enter Id:");
                int id = Convert.ToInt32(Console.ReadLine());

                var datas = await _cityService.GetAllByCountryIdAsync(id);

                foreach (var item in datas)
                {
                    Console.WriteLine($"City: {item.Name} | Country: {item.Country.Name}");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            try
            {
                var datas = await _cityService.GetAllAsync();

                foreach (var data in datas)
                {
                    string result = $"Name: {data.Name} | Country: {data.Country.Name}";
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task GetByIdAsync()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter Id:");
                int id = Convert.ToInt32(Console.ReadLine());

                var data = await _cityService.GetByIdAsync(id);

                await Console.Out.WriteLineAsync($"Name: {data.Name} | Country: {data.Country.Name}");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        public async Task CreateAsync()
        {
            await Console.Out.WriteLineAsync("Enter the name:");
            string name = Console.ReadLine();

            await Console.Out.WriteLineAsync("Enter the country:");
            string country = Console.ReadLine();

            await Console.Out.WriteLineAsync("Enter the population:");
            int population = Convert.ToInt32(Console.ReadLine());

            var countries = await _countryService.GetAllAsync();

            if (countries.Count < 1)
            {
                await _cityService.CreateAsync(new City
                {
                    Name = name,
                    Country = new Country
                    {
                        Name = country,
                        Population = population
                    }
                });
                await Console.Out.WriteLineAsync("Data sucessfully created!");
            }

            else
            {
                foreach (var item in countries)
                {
                    if (item.Name != country && item.Population != population)
                    {
                        await _cityService.CreateAsync(new City
                        {
                            Name = name,
                            Country = new Country
                            {
                                Name = country,
                                Population = population
                            }
                        });
                        await Console.Out.WriteLineAsync("Data sucessfully created!");
                        return;
                    }
                    else
                    {
                        await _cityService.CreateAsync(new City
                        {
                            Name = name,
                            Country = item
                        });
                        await Console.Out.WriteLineAsync("Data sucessfully created!");
                        return;
                    }
                }
            }            
        }

        public async Task DeleteAsync()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter id:");
                int id = Convert.ToInt32(Console.ReadLine());

                await _cityService.DeleteAsync(id);

                await Console.Out.WriteLineAsync("Data sucessfully deleted!");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
