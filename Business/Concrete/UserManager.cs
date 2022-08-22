using System;
using UserApi.Abstract;
using UserApi.Business.Abstract;
using UserApi.Concrete;
using UserApi.Entities;

namespace UserApi.Business.Concrete
{
    public class UserManager: IUserService
    {
        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            if (id > 0)
            {
                return _userRepository.GetUserById(id);
            }
            throw new Exception("id can not be less than 1");

        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

    }
}

