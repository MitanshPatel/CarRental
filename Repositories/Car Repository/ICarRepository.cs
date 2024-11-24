using CarRental.Models;

namespace CarRental.Repositories.Car_Repository
{
    public interface ICarRepository
    {
        void AddCar(CarClass car);
        CarClass GetCarById(int id);
        IEnumerable<CarClass> GetAvailableCars();
        void UpdateCarAvailability(CarClass car);
        void DeleteCar(int id);
    }
}
