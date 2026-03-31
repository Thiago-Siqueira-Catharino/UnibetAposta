using UniBet.Data.Contexts;
using UniBet.Entities;
using UniBet.Interfaces.IRepositories;

namespace UniBet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _database;
        public UserRepository() 
        {
        }

        public User FindById(Guid userId)
        {
            User user = _database.Users
                .Select(usr => usr)
                .Where(usr => usr.Id == userId).FirstOrDefault();

            return user;
        }
    }
}