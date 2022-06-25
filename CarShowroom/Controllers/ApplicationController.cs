using CarShowroom.Services;
using Microsoft.AspNetCore.Mvc;
using CarShowroom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CarShowroom.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly IApplications _applications;
        public ApplicationController(IApplications applications)
        {
            _applications = applications;
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
        public IActionResult ViewApplication(StatusApplicationViewModel model)
        {
            _applications.SetStatus(model);
            return Redirect("~/Admin/Applications");
        }
    }
}
