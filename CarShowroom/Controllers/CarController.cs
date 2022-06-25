using CarShowroom.Models;
using CarShowroom.Services;
using CarShowroom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Controllers
{
    public class CarController : Controller
    {
        private readonly ICars _cars;
        public CarController(ICars cars)
        {
            _cars = cars;
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        async public Task<IActionResult> AddCar(AddCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                await _cars.AddCarAsync(car);
                return RedirectToAction("../Admin/Cars");
            }
            return View(car);
        }
    }
}
