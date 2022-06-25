using CarShowroom.Models;

namespace CarShowroom.ViewModels
{
    public class CarViewModel
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }
        public CarState State { get; set; }
        public string Desc { get; set; }
        public Car GetCar()
        {
            return new Car()
            {
                Name = Name,
                Color = Color,
                Year = Year,
                Type = Type,
                State = State,
                Desc = Desc,
            };
        }
    }
}
