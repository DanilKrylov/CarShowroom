using CarShowroom.Services;
using Microsoft.AspNetCore.Mvc;
using CarShowroom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CarShowroom.Models;
using System.Linq;

namespace CarShowroom.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly IApplications _applications;
        private readonly ICars _cars;
        public ApplicationController(IApplications applications, ICars cars)
        {
            _applications = applications;
            _cars = cars;
        }

        async public Task<IActionResult> Add()
        {
            var addmodel = await _applications.GetAddModelAsync(User.Identity.Name);
            return View(addmodel);
        }

        [HttpPost]
        public IActionResult Add(AddApplicationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _applications.Add(viewModel, User.Identity.Name);
                return Redirect("~/Home/Index");
            }

            return View(viewModel);
        }

        async public Task<IActionResult> ViewApplication(int appId)
        {
            var application = await _applications.GetStatusModelAsync(appId);
            return View(application);
        }

        [HttpPost]
        async public Task<IActionResult> ViewApplication(StatusApplicationViewModel model)
        {
            if(model.State == ApplicationState.Confirmed && model.CarId == 0)
            {
                ModelState.AddModelError("CarId", "Оберіть машину");
            }

            if (ModelState.IsValid)
            {
                _applications.SetStatus(model);
                return Redirect("~/Admin/Applications");
            }

            return View(await _applications.GetStatusModelAsync(model.Id));
        }
    }
}
