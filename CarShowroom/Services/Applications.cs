using CarShowroom.Models;
using CarShowroom.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Services
{
    public class Applications : IApplications
    {
        private readonly CarShowroomDb _db;
        private readonly UserManager<User> _userManager;
        public Applications(CarShowroomDb db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
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

        async public Task<IEnumerable> GetAllAsync()
        {
            return await Task.Run(() => _db.Applications.ToList());
        }

        async public Task<AddApplicationViewModel> GetStatusModelAsync(int appId)
        {
            
        }

        public void SetStatus(StatusApplicationViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
