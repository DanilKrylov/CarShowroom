using CarShowroom.Models;
using CarShowroom.ViewModels;
using System;
using System.Collections.Generic;
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
            var carmodel = car.GetCar();
            await Task.Run(() => _db.Cars.Add(carmodel));
            _db.SaveChanges();
        }

        async public Task<IEnumerable<Car>> GetAllCarsAsync()
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

        async public Task<IEnumerable<Car>> GetCarsAsync(CarState carState, Color color, CarType carType, int year, string search,int budget, SortParam sortParam)
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

            if(budget > 0)
            {
                cars = cars.Where(c => c.Cost <= budget).ToList();
            }

            if (search is not null)
            {
                cars = cars.Where(c => c.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            cars = cars.OrderBy(c => c.Cost).ToList();
            if (sortParam == SortParam.CostDecreasing)
            {
                cars.Reverse();
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
            var carmodel = await Task.Run(() =>_db.Cars.FirstOrDefault(c => c.Id == car.Id));
            if (carmodel is null)
            {
                throw new Exception();
            }

            carmodel.Update(car);
            _db.SaveChanges();
        }
    }
}
