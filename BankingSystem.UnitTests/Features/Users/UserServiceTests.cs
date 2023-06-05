using AutoMapper;
using BankingSystem.Features.Users.BL;
using BankingSystem.Features.Users.DAL;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Features.Users
{

    [TestFixture]
    internal class UserServiceTests
    {
        IUserService _userService;
        Mock<IMapper> _mapperMock;
        Mock<IUserDAL> _userDALMock;

        public UserServiceTests() 
        {
            _mapperMock = new Mock<IMapper>();
            _userDALMock = new Mock<IUserDAL>();
            _userService = new UserService(_userDALMock.Object, _mapperMock.Object);
        }
        
    }
}
