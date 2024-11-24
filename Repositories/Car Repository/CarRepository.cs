using CarRental.Db_Context;
using CarRental.Models;
using CarRental.Repositories.Car_Repository;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext _context;

        public CarRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public void AddCar(CarClass car)
        {
            car.Id = 0;
            _context.Set<CarClass>().Add(car);
            _context.SaveChanges();
        }

        public CarClass GetCarById(int id)
        {
            return _context.Set<CarClass>().Find(id);
        }

        public IEnumerable<CarClass> GetAvailableCars()
        {
            return _context.Set<CarClass>().Where(c => c.IsAvailable).ToList();
        }

        public void UpdateCarAvailability(CarClass car)
        {
            _context.Set<CarClass>().Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = GetCarById(id);
            if (car != null)
            {
                _context.Set<CarClass>().Remove(car);
                _context.SaveChanges();
            }
        }
    }
}
