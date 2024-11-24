using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Services;
using CarRental.Repositories.Car_Repository;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarRentalService _carRentalService;

        public CarsController(ICarRepository carRepository, ICarRentalService carRentalService)
        {
            _carRepository = carRepository;
            _carRentalService = carRentalService;
        }

        [HttpGet]
        public IActionResult GetAvailableCars()
        {
            var cars = _carRepository.GetAvailableCars();
            return Ok(cars);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCar([FromBody] CarClass car)
        {
            _carRepository.AddCar(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] CarClass car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _carRepository.UpdateCarAvailability(car);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            _carRepository.DeleteCar(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [Authorize(Roles = "User")]
        [HttpPost("rentcar")]
        public IActionResult RentCar(int carId, int userId)
        {
            var success = _carRentalService.RentCar(carId, userId);
            if (!success)
            {
                return BadRequest("Car is not available.");
            }

            var car = _carRepository.GetCarById(carId);
            car.IsAvailable = false;
            _carRepository.UpdateCarAvailability(car);

            return Ok("Car rented successfully.");
        }

        [Authorize(Roles = "User")]
        [HttpPost("returncar/{carId}")]
        public IActionResult ReturnCar(int carId)
        {
            var car = _carRepository.GetCarById(carId);
            if (car == null)
            {
                return NotFound();
            }

            car.IsAvailable = true;
            _carRepository.UpdateCarAvailability(car);

            return Ok("Car returned successfully.");
        }
    }
}
