using AutoMapper;
using BankingSystem.Features.Users.BL;
using BankingSystem.Features.Users.DAL;
using BankingSystem.Features.Users.Data;
using Moq;

namespace BankingSystem.UnitTests.Features.Users
{

    [TestFixture]
    internal class AccountServiceTests
    {
        IUserService _userService;
        Mock<IMapper> _mapperMock;
        Mock<IUserDAL> _userDALMock;

        const int USER_ID = 1;

        [SetUp]
        public void Setup() 
        {
            _mapperMock = new Mock<IMapper>();
            _userDALMock = new Mock<IUserDAL>();
            _userService = new UserService(_userDALMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetUserById_SuccessfullyReturns()
        {
            var user = new User { Name = "John" };
            _userDALMock.Setup(d => d.GetUserById(It.IsAny<int>())).ReturnsAsync(user);


            var userDto = new UserDTO { Name = "John" };
            _mapperMock.Setup(m => m.Map<UserDTO>(It.IsAny<User>())).Returns(userDto);

            var result = await _userService.GetUserById(USER_ID);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, userDto);
            _userDALMock.Verify(d => d.GetUserById(USER_ID), Times.Once);
            _mapperMock.Verify(m => m.Map<UserDTO>(user), Times.Once);
        }

        [Test]
        public async Task GetUserById_WhenExceptionIsThrown_Rethrows()
        {
            var message = "custom message";
            var exception = new NullReferenceException(message);
            _userDALMock.Setup(d => d.GetUserById(It.IsAny<int>())).ThrowsAsync(exception);

            var result = Assert.ThrowsAsync<NullReferenceException>(() => _userService.GetUserById(USER_ID));
            Assert.AreEqual(message, result.Message);
        }
    }
}
