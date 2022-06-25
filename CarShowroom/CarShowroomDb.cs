using CarShowroom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom
{
    public class CarShowroomDb : IdentityDbContext<User>
    {
        public CarShowroomDb(DbContextOptions<CarShowroomDb> options)
                : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
