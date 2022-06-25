namespace CarShowroom.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }
        public CarState State { get; set; }
        public string Desc { get; set; }
    }
}
