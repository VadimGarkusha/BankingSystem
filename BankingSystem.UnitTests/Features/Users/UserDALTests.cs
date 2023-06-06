using AutoMapper;
using BankingSystem.DAL;
using BankingSystem.DAL.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Features.Users
{
    [TestFixture]
    internal class UserDALTests
    {
        Mock<IUnitOfWork> _unitOfWorkMock;
        IUserDAL _userDAL;

        const int USER_ID = 1;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _userDAL = new UserDAL(_unitOfWorkMock.Object);
        }

        [Test]
        public async Task GetUserById_SuccessfullyReturnsUser()
        {
            var user = new User();

            _unitOfWorkMock.Setup(u => u.UserRepository.GetByID(It.IsAny<int>()))
                .ReturnsAsync(user);

            var result = await _userDAL.GetUserById(USER_ID);
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result);
        }


        [Test]
        public async Task GetUserById_UserNotFound_ReturnsNull()
        {
            _unitOfWorkMock.Setup(u => u.UserRepository.GetByID(It.IsAny<int>()));

            var result = await _userDAL.GetUserById(USER_ID);
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetUserById_UserDeleted_ReturnsNull()
        {
            var user = new User { IsDeleted = true};

            _unitOfWorkMock.Setup(u => u.UserRepository.GetByID(It.IsAny<int>()))
                .ReturnsAsync(user);

            var result = await _userDAL.GetUserById(USER_ID);
            Assert.IsNull(result);
        }
    }
}
