namespace BankingSystem.BL.Users
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(int userId);
    }
}