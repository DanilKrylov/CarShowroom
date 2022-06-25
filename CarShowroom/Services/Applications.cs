using CarShowroom.Models;
using CarShowroom.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Services
{
    public class Applications : IApplications
    {
        private readonly CarShowroomDb _db;
        private readonly UserManager<User> _userManager;
        private readonly ICars _cars;
        public Applications(CarShowroomDb db, UserManager<User> userManager, ICars cars)
        {
            _db = db;
            _userManager = userManager;
            _cars = cars;
        }

        public void Add(AddApplicationViewModel model, string userEmail)
        {
            _db.Applications.Add(model.GetApplication(userEmail));
            _db.SaveChanges();
        }

        public Application Get(int id)
        {
            return _db.Applications.First(c => c.Id == id);
        }

        async public Task<AddApplicationViewModel> GetAddModelAsync(string userEmail)
        {
            User user = await _userManager.FindByNameAsync(userEmail);
            return new AddApplicationViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                Surname = user.Surname,
                Phone = user.PhoneNumber,
            };
        }

        async public Task<IEnumerable<Application>> GetAllAsync()
        {
            return await Task.Run(() => _db.Applications.ToList());
        }

        async public Task<StatusApplicationViewModel> GetStatusModelAsync(int appId)
        {
            var app = await Task.Run(() => _db.Applications.FirstOrDefault(c => c.Id == appId));
            IEnumerable<Car> cars = await _cars.GetCarsAsync(CarState.Any, app.Color, app.Type, 0, "", SortParam.CostIncreasing);
            return new StatusApplicationViewModel()
            {
                Id = app.Id,
                Name = app.Name,
                Surname = app.Surname,
                Email = app.Email,
                Budget = app.Budget,
                Color = app.Color,
                Phone = app.Phone,
                Type = app.Type,
                Cars =  cars.ToList(),
                State = app.State,
                Desc = app.Desc,
                CarId = app.CarId,
            };
        }

        public void SetStatus(StatusApplicationViewModel viewModel)
        {
            var application = Get(viewModel.Id);
            application.Update(viewModel);
            _db.SaveChanges();
        }
    }
}
