using UniBet.DTOs;
using UniBet.Entities;

namespace UniBet.Interfaces.IServices
{
    public interface IUserService
    {
        public User GetUserData(int Id);
        public void Deposit(DepositDTO depositDTO);
    }
}
