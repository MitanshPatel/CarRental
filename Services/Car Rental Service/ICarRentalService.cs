namespace CarRental.Services
{
    public interface ICarRentalService
    {
        bool RentCar(int carId, int userId);
        bool CheckCarAvailability(int carId);
    }
}
