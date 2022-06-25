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

    [Authorize(Roles = "admin")]
    public class CarController : Controller
    {
        private readonly ICars _cars;
        public CarController(ICars cars)
        {
            _cars = cars;
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> AddCar(AddCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                await _cars.AddCarAsync(car);
                return Redirect("../Admin/Cars");
            }
            return View(car);
        }

        async public Task<IActionResult> RemoveCar(int carId)
        {
            try
            {
                await _cars.RemoveCarAsync(carId);
            }
            catch
            {
                return Redirect("../Home/Index");
            }
            return Redirect("../Admin/Cars");
        }

        async public Task<IActionResult> EditCar(int carId)
        {
            var car = await _cars.GetAsync(carId);
            return View(UpdateCarViewModel.GetViewModel(car));
        }

        [HttpPost]
        async public Task<IActionResult> EditCar(UpdateCarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await _cars.UpdateCarAsync(viewModel);
            return RedirectPermanent("~/Admin/Cars");
        }
    }
}
