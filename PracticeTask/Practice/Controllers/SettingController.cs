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
    internal class SettingController
    {
        private readonly ISettingService _settingService;

        public SettingController()
        {
            _settingService = new SettingService();
        }

        public async Task GetAllAsync()
        {
            try
            {
                var datas = await _settingService.GetAllAsync();

                foreach (var data in datas)
                {
                    string result = $"Name: {data.Name} | Address: {data.Address} | Email: {data.Email} | Phone: {data.Phone}";
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

                var data = await _settingService.GetById(id);
           
                await Console.Out.WriteLineAsync($"Name: {data.Name} | Address: {data.Address} | Email: {data.Email} | Phone: {data.Phone}");
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

            await Console.Out.WriteLineAsync("Enter the Address:");
            string address = Console.ReadLine();

            await Console.Out.WriteLineAsync("Enter the email:");
            string email = Console.ReadLine();

            await Console.Out.WriteLineAsync("Enter the phone:");
            string phone = Console.ReadLine();

            await _settingService.CreateAsync(new Setting
            {
                Name = name,
                Address = address,
                Email = email,
                Phone = phone
            });

            await Console.Out.WriteLineAsync("Data sucessfully created!");
        }

        public async Task DeleteAsync()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter id:");
                int id = Convert.ToInt32(Console.ReadLine());

                await _settingService.DeleteAsync(id);

                await Console.Out.WriteLineAsync("Data sucessfully deleted!");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
