using UniBet.Contexts.Betting.Domain.Entities;
using UniBet.Contexts.Betting.Domain.IRepositories;
using UniBet.Contexts.Betting.Infrastructure.Persistance;

namespace UniBet.Contexts.Betting.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BettingDbContext _database;
        public PlayerRepository() 
        {
        }

        public PlayerRepository(BettingDbContext database)
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