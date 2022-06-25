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
        private readonly IApplications _applications;
        public AdminController(ICars cars, IApplications applications)
        {
            _cars = cars;
            _applications = applications;
        }

        async public Task<IActionResult> Cars()
        {
            var cars = await _cars.GetAllCarsAsync();
            return View(cars);
        }

        async public Task<IActionResult> Applications()
        {
            var applications = await _applications.GetAllAsync();
            return View(applications);
        }
    }
}
