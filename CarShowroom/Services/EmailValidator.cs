using CarShowroom.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Services
{
    public class EmailValidator : IEmailValidator
    {
        private readonly CarShowroomDb _db;
        public EmailValidator(CarShowroomDb db)
        {
            _db = db;
        }

        async public Task<bool> EmailIsUniqueAsync(string email)
        {
            var user =  await Task.Run(() => _db.Users.FirstOrDefault(c => c.Email == email));
            if(user is null)
            {
                return true;
            }

            return false;
        }
    }
}
