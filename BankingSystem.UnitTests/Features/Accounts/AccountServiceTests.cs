using AutoMapper;
using BankingSystem.BL.Accounts;
using BankingSystem.BL.Users;
using BankingSystem.DAL.Accounts;
using Moq;

namespace BankingSystem.UnitTests.Features.Accounts
{

    [TestFixture]
    internal class AccountServiceTests
    {
        IAccountService _accountService;
        Mock<IMapper> _mapperMock;
        Mock<IUserService> _userServiceMock;
        Mock<IAccountDAL> _accountDALMock;

        [SetUp]
        public void Setup() 
        {
            _mapperMock = new Mock<IMapper>();
            _userServiceMock = new Mock<IUserService>();
            _accountDALMock = new Mock<IAccountDAL>();
            _accountService = new AccountService(_accountDALMock.Object, _userServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task CreateAccount_SuccessfullyReturns()
        {
            var user = new UserDTO();
            _userServiceMock.Setup(s => s.GetUserById(It.IsAny<int>()))
                .ReturnsAsync(user);

            var account = new Account();
            _accountDALMock.Setup(d => d.CreateAccount(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<string>()))
                .ReturnsAsync(account);

            var accountDto = new AccountDTO();

            _mapperMock.Setup(m => m.Map<AccountDTO>(It.IsAny<Account>()))
                .Returns(accountDto);

            var result = await _accountService.CreateAccount(1, 1, "name");

            Assert.IsNotNull(result);
            Assert.AreEqual(result, accountDto);
        }

        [Test]
        public async Task CreateAccount_UserNotFound_ReturnsNull()
        {
            _userServiceMock.Setup(s => s.GetUserById(It.IsAny<int>()));

           var result = await _accountService.CreateAccount(1, 1, "name");

            Assert.IsNull(result);
        }
    }
}
