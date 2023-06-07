namespace BankingSystem.DAL.Users
{
    public interface IUserDAL
    {
        Task<User> GetUserById(int userId);
    }
}