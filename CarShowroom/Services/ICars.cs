using CarShowroom.Models;
using CarShowroom.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarShowroom.Services
{
    public interface ICars
    {
        public Task<IEnumerable<Car>> GetAllCarsAsync();
        public Task<Car> GetAsync(int id);
        public Task<IEnumerable<Car>> GetCarsAsync(CarState carState, Color color, CarType carType, int year, string search, SortParam sortParam);
        public Task AddCarAsync(AddCarViewModel car);
        public Task RemoveCarAsync(int carId);
        public Task UpdateCarAsync(UpdateCarViewModel car);
    }
}
