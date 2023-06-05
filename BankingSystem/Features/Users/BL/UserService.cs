using AutoMapper;
using BankingSystem.Features.Users.DAL;

namespace BankingSystem.Features.Users.BL
{
    public class UserService : IUserService
    {
        private IUserDAL _userDAL;
        private IMapper _mapper;

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
