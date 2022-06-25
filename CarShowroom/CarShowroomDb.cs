using CarShowroom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom
{
    public class CarShowroomDb : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Application> Applications {get;set;}
        public CarShowroomDb(DbContextOptions<CarShowroomDb> options)
                : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
