namespace BankingSystem.DAL.Users
{
    public class UserDAL : IUserDAL
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDAL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserById(int userId)
        {
            var result = await _unitOfWork.UserRepository.GetByID(userId);
            return result == null || result.IsDeleted ? null : result;
        }
    }
}
