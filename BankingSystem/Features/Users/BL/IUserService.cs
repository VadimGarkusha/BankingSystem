namespace BankingSystem.Features.Users.BL
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(int userId);
    }
}