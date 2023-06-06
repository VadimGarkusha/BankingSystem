using AutoMapper;
using BankingSystem.DAL;
using BankingSystem.DAL.Accounts;
using BankingSystem.DAL.AccountTransactions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Features.Accounts
{
    [TestFixture]
    internal class AccountDALTests
    {
        IAccountDAL _accountDAL;
        Mock<IUnitOfWork> _unitOfWorkMock;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _accountDAL = new AccountDAL(_unitOfWorkMock.Object);
        }



        [Test]
        public async Task CreateAccount_SuccessfullyReturns()
        {
            var account = new Account();
            _unitOfWorkMock.Setup(u => u.AccountRepository.Create(It.IsAny<Account>())).ReturnsAsync(account);

            _unitOfWorkMock.Setup(u => u.AccountTransactionRepository.Create(It.IsAny<AccountTransaction>()));
            _unitOfWorkMock.Setup(u => u.Save());


            var result = await _accountDAL.CreateAccount(1, 1, "name");
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result, account);

            _unitOfWorkMock.Verify(u => u.AccountRepository.Create(It.IsAny<Account>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.AccountTransactionRepository.Create(It.IsAny<AccountTransaction>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
