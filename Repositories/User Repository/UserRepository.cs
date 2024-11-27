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
            var user = _context.Set<UserClass>().FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with email '{email}' not found.");
            }
            return user;
        }

        public UserClass GetUserById(int id)
        {
            var user = _context.Set<UserClass>().Find(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID '{id}' not found.");
            }
            return user;
        }

    }
}
