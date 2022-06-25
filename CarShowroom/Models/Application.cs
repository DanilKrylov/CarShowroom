using CarShowroom.ViewModels;

namespace CarShowroom.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserAccountEmail { get; set; }
        public int CarId { get; set; }
        public Color Color { get; set; }
        public CarType Type { get; set; }
        public int Budget { get; set; }
        public ApplicationState State { get; set; }
        public string Desc { get; set; }

        public void Update(StatusApplicationViewModel model)
        {
            CarId = model.CarId;
            State = model.State;
            Desc = model.Desc;
        }
    }
}
