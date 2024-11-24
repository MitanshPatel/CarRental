using CarRental.Models;

namespace CarRental.Services
{
    public interface IUserService
    {
        bool RegisterUser(UserClass user);
        string AuthenticateUser(string email, string password);
    }
}
