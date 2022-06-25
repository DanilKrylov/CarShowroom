using System.Threading.Tasks;

namespace CarShowroom.Services
{
    public interface IEmailValidator
    {
        public Task<bool> EmailIsUniqueAsync(string email);
    }
}
