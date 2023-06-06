using AutoMapper;
using BankingSystem.BL.Accounts;
using BankingSystem.Features.Accounts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UnitTests.Features.Accounts
{
    [TestFixture]
    internal class AccountsControllerTests
    {
        AccountController _accountController;
        Mock<IAccountService> _accountServiceMock;
        Mock<IValidator<CreateAccountRequest>> _validatorMock;

        [SetUp]
        public void Setup()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _validatorMock = new Mock<IValidator<CreateAccountRequest>>();
            _accountController = new AccountController(_accountServiceMock.Object, _validatorMock.Object);
        }

        [Test]
        public async Task CreateAccount_ReturnsAccount()
        {
            _validatorMock.Setup(v => v.Validate(It.IsAny<CreateAccountRequest>())).Returns(new ValidationResult());

            var account = new AccountDTO();
            _accountServiceMock.Setup(s => s.CreateAccount(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<string>()))
                .ReturnsAsync(account);

            var createAccountRequest = new CreateAccountRequest();
            var result = await _accountController.CreateAccount(createAccountRequest);
            var okResult = result.Result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(okResult);

            Assert.AreEqual(okResult.Value, account);
            _validatorMock.Verify(v => v.Validate(createAccountRequest), Times.Once);
        }

        [Test]
        public async Task CreateAccount_InvalidRequest_ReturnsBadRequest()
        {
            _validatorMock.Setup(v => v.Validate(It.IsAny<CreateAccountRequest>()))
                .Returns(new ValidationResult(new List<ValidationFailure> { new ValidationFailure() }));

            var createAccountRequest = new CreateAccountRequest();
            var result = await _accountController.CreateAccount(createAccountRequest);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestResult>(result.Result);
            _validatorMock.Verify(v => v.Validate(createAccountRequest), Times.Once);
        }

        [Test]
        public async Task CreateAccount_NullAccountReturned_ReturnsNotFound()
        {
            _validatorMock.Setup(v => v.Validate(It.IsAny<CreateAccountRequest>()))
                .Returns(new ValidationResult());

            _accountServiceMock.Setup(s => s.CreateAccount(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<string>()));

            var createAccountRequest = new CreateAccountRequest();
            var result = await _accountController.CreateAccount(createAccountRequest);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
            _validatorMock.Verify(v => v.Validate(createAccountRequest), Times.Once);
        }
    }
}
