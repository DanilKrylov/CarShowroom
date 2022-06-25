using CarShowroom.Models;
using CarShowroom.ViewModels;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Services
{
    public class Cars : ICars
    {
        private readonly CarShowroomDb _db;
        public Cars(CarShowroomDb db)
        {
            _db = db;
        }

        async public Task AddCarAsync(AddCarViewModel car)
        {
            var carmodel = new Car()
            {
                Color = car.Color,
                Desc = car.Desc,
                Name = car.Name,
                Year = car.Year,
                State = car.State,
                Type = car.Type,
            };
            await Task.Run(() => _db.Cars.Add(carmodel));
            _db.SaveChanges();
        }

        async public Task<IEnumerable> GetAllCarsAsync()
        {
            var cars = await Task.Run(() => _db.Cars.ToList());
            return cars;
        }

        async public Task<Car> GetAsync(int id)
        {
            var car = await Task.Run(() => _db.Cars.FirstOrDefault(c => c.Id == id));
            if(car is null)
            {
                throw new Exception();
            }

            return car;
        }

        async public Task<IEnumerable> GetCarsAsync(CarState carState, Color color, CarType carType, int year, string search)
        {
            var cars = await Task.Run(() => _db.Cars.ToList());

            if (carState != CarState.Any)
            {
                cars = cars.Where(c => c.State == carState).ToList();
            }

            if (color != Color.Any)
            {
                cars = cars.Where(c => c.Color == color).ToList();
            }

            if (carType != CarType.Any)
            {
                cars = cars.Where(c => c.Type == carType).ToList();
            }

            if(year > 0)
            {
                cars = cars.Where(c => c.Year == year).ToList();
            }

            if (search is not null)
            {
                cars = cars.Where(c => c.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return cars;
        }

        async public Task RemoveCarAsync(int carId)
        {
            var car = await _db.Cars.FindAsync(carId);
            if(car is null)
            {
                throw new Exception();
            }

            await Task.Run(() => _db.Remove(car));
            _db.SaveChanges();
        }

        async public Task UpdateCarAsync(UpdateCarViewModel car)
        {
            var carmodel = await _db.Cars.FindAsync(car.Id);
            if (car is null)
            {
                throw new Exception();
            }

            carmodel.Update(car);
            _db.SaveChanges();
        }
    }
}
