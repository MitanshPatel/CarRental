using CarRental.Models;
using CarRental.Repositories.Car_Repository;

namespace CarRental.Services
{
    public class CarRentalService : ICarRentalService
    {
        private readonly ICarRepository _carRepository;

        public CarRentalService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public bool RentCar(int carId, int userId)
        {
            var car = _carRepository.GetCarById(carId);
            if (car == null || !car.IsAvailable)
            {
                return false;
            }

            car.IsAvailable = false;
            _carRepository.UpdateCarAvailability(car);
            return true;
        }

        public bool CheckCarAvailability(int carId)
        {
            var car = _carRepository.GetCarById(carId);
            return car != null && car.IsAvailable;
        }
    }
}
