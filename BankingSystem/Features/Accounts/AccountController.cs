using BankingSystem.Features.Accounts.BL;
using BankingSystem.Features.Accounts.Data;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Features.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountsService;
        private IValidator<CreateAccountRequest> _createAccountRequestValidatorValidator;

        public AccountController(IAccountService accountsService, IValidator<CreateAccountRequest> createAccountRequestValidatorValidator)
        {
            _accountsService = accountsService;
            _createAccountRequestValidatorValidator = createAccountRequestValidatorValidator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountDTO>> CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
        {
            var validationResult = _createAccountRequestValidatorValidator.Validate(createAccountRequest);
            if (!validationResult.IsValid)
            {
                return new BadRequestResult();
            }

            var createdAccount = await _accountsService.CreateAccount(createAccountRequest.UserId, createAccountRequest.StartingAmount, createAccountRequest.Name);

            if (createdAccount == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(createdAccount);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAccount(int accountId)
        {
            var result = await _accountsService.DeleteAccount(accountId);

            if (!result)
            {
                return new NotFoundResult();
            }

            return new NoContentResult();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Account>>> GetAllAccountsAsync()
        {
            var accounts = await _accountsService.GetAllAccounts();

            return new OkObjectResult(accounts);
        }
    }
}
