using BankingSystem.Data;
using BankingSystem.Features.Users.Data;

namespace BankingSystem.Features.Users.DAL
{
    public class UserDAL : IUserDAL
    {
        private IUnitOfWork _unitOfWork;

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
