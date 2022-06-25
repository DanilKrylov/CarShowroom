using CarShowroom.Models;
using CarShowroom.ViewModels;
using System.Collections;
using System.Threading.Tasks;

namespace CarShowroom.Services
{
    public interface ICars
    {
        public Task<IEnumerable> GetAllCarsAsync();
        public Task<Car> GetAsync(int id);
        public Task<IEnumerable> GetCarsAsync(CarState carState, Color color, CarType carType, int year, string search);
        public void AddCar(CarViewModel car);
    }
}
