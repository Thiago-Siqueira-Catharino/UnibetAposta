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

        public UserRepository(Context database)
        {
            _database = database;
        }

        public Player FindById(Guid userId)
        {
            Player player = _database.Users
                .Select(usr => usr)
                .Where(usr => usr.Id == userId).FirstOrDefault();

            return player;
        }

        public Player Update(Player player)
        {
            _database.Users.Update(player);
            _database.SaveChanges();
            
            return player;
        }
    }
}