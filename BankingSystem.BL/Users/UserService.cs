using AutoMapper;
using BankingSystem.DAL.Users;

namespace BankingSystem.BL.Users
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;

        public UserService(IUserDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var result = await _userDAL.GetUserById(userId);
            return _mapper.Map<UserDTO>(result);
        }
    }
}
