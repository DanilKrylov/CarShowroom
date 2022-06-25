using CarShowroom.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarShowroom.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ICars _cars;
        public AdminController(ICars cars)
        {
            _cars = cars;
        }

        async public Task<IActionResult> Cars()
        {
            var cars = await _cars.GetAllCarsAsync();
            return View(cars);
        }
    }
}
