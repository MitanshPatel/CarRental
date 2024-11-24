using CarRental.Db_Context;
using CarRental.Models;
using CarRental.Repositories.User_Repository;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarRentalDbContext _context;

        public UserRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserClass user)
        {
            _context.Set<UserClass>().Add(user);
            _context.SaveChanges();
        }

        public UserClass GetUserByEmail(string email)
        {
            return _context.Set<UserClass>().FirstOrDefault(u => u.Email == email);
        }

        public UserClass GetUserById(int id)
        {
            return _context.Set<UserClass>().Find(id);
        }
    }
}
