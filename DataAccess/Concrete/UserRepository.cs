using System;
using UserApi.Abstract;
using UserApi.Database;
using UserApi.Entities;

namespace UserApi.Concrete
{
    public class UserRepository:IUserRepository
    {
        public UserRepository()
        {
        }

        public User CreateUser(User user)
        {
            using (var userDbContext = new UserDbContext())
            {
                userDbContext.Users.Add(user);
                userDbContext.SaveChanges();
                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (var userDbContext = new UserDbContext())
            {
                var deletedUser = GetUserById(id);
                userDbContext.Users.Remove(deletedUser);
                userDbContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var userDbContext = new UserDbContext())
            {
                return userDbContext.Users.ToList();
            }
        } 

        public User GetUserById(int id)
        {
            using (var userDbContext = new UserDbContext())
            {
                return userDbContext.Users.Find(id);
            }
        }

        public User UpdateUser(User user)
        {
            using (var userDbContext = new UserDbContext())
            {
                userDbContext.Users.Update(user);
                userDbContext.SaveChanges();
                return user;
            }
        }
    }
}

