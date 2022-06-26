using CarShowroom.Models;
using CarShowroom.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICars _cars;
        public HomeController(ICars cars)
        {
            _cars = cars;
        }

        async public Task<IActionResult> Index()
        {
            var cars = await _cars.GetAllCarsAsync();
            return View(cars);
        }

        [HttpPost]
        async public Task<IActionResult> Index(CarState carState, Color color, CarType carType, int year, string search, SortParam sortParam)
        {
            var cars = await _cars.GetCarsAsync(carState, color, carType, year, search, 10000000, sortParam);
            return View(cars);
        }
    }
}
