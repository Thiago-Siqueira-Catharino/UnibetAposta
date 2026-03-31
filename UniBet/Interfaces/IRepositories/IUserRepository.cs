using UniBet.Entities;

namespace UniBet.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public User FindById(Guid userId);
        public User Update(User user);
        public User Save(User user);
    }
}