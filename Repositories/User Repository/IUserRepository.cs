using CarRental.Models;

namespace CarRental.Repositories.User_Repository
{
    public interface IUserRepository
    {
        void AddUser(UserClass user);
        UserClass GetUserByEmail(string email);
        UserClass GetUserById(int id);
    }
}
