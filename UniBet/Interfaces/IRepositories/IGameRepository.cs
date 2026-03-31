using UniBet.Entities;

namespace UniBet.Interfaces.IRepositories
{
    public interface IGameRepository
    {
        public Game FindById(Guid id);
        public Game Save(Game game);
        public Game Update(Game game);
    }
}