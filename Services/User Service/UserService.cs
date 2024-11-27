using CarRental.Repositories;
using CarRental.Models;
using CarRental.Repositories.User_Repository;

namespace CarRental.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenService _jwtTokenService;

        public UserService(IUserRepository userRepository, JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public bool RegisterUser(UserClass user)
        {
            if (_userRepository.GetUserByEmail(user.Email) != null)
            {
                return false;
            }

            _userRepository.AddUser(user);
            return true;
        }

        public string AuthenticateUser(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null || user.Password != password)
            {
                return null;
            }

            return _jwtTokenService.GenerateToken(user.Id, user.Role);
        }
    }
}

