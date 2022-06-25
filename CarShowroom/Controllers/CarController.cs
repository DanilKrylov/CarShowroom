using CarShowroom.Models;
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
        [HttpGet("admin")]
        [Authorize(Roles ="admin")]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(CarViewModel car)
        {
            return View();
        }
    }
}
