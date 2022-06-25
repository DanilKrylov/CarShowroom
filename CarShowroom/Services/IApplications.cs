using CarShowroom.Models;
using CarShowroom.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarShowroom.Services
{
    public interface IApplications
    {
        public Task<AddApplicationViewModel> GetAddModelAsync(string userEmail);
        public Task<StatusApplicationViewModel> GetStatusModelAsync(int appId);
        public void Add(AddApplicationViewModel model, string userEmail);
        public Application Get(int id);
        public Task<IEnumerable<Application>> GetAllAsync();
        public void SetStatus(StatusApplicationViewModel viewModel);
    }
}
