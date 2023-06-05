using BankingSystem.Features.Users.Data;

namespace BankingSystem.Features.Users.DAL
{
    public interface IUserDAL
    {
        Task<User> GetUserById(int userId);
    }
}