using Practice.Models;
using Practice.Services;
using Practice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Controllers
{
    internal class CountryController
    {
        private readonly ICountryService _countryService;

        public CountryController()
        {
            _countryService = new CountryService();
        }

        public async Task GetByIdAsync()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter Id:");
                int id = Convert.ToInt32(Console.ReadLine());

                var data = await _countryService.GetByIdAsync(id);

                await Console.Out.WriteLineAsync($"Name: {data.Name} | Population: {data.Population}");
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
                var datas = await _countryService.GetAllAsync();

                foreach (var data in datas)
                {
                    string result = $"Name: {data.Name} | Population: {data.Population}";
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task CreateAsync()
        {
            await Console.Out.WriteLineAsync("Enter the name:");
            string name = Console.ReadLine();

            await Console.Out.WriteLineAsync("Enter the population:");
            int population = Convert.ToInt32(Console.ReadLine());

            await _countryService.CreateAsync(new Country
            {
                Name = name,
                Population = population
            });

            await Console.Out.WriteLineAsync("Data sucessfully created!");
        }

        public async Task DeleteAsync()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter id:");
                int id = Convert.ToInt32(Console.ReadLine());

                await _countryService.DeleteAsync(id);

                await Console.Out.WriteLineAsync("Data sucessfully deleted!");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
