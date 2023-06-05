using BankingSystem.Features.AccountTransactions.BL;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Features.AccountTransactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTransactionController : Controller
    {
        private IAccountTransactionService _accountTransactionService;
        private IValidator<DepositRequest> _depositRequestValidator;
        private IValidator<WithdrawRequest> _withdrawRequestValidator;


        public AccountTransactionController(IAccountTransactionService accountTransactionService, IValidator<DepositRequest> depositRequestValidator,
            IValidator<WithdrawRequest> withdrawRequestValidator)
        {
            _accountTransactionService = accountTransactionService;
            _depositRequestValidator = depositRequestValidator;
            _withdrawRequestValidator = withdrawRequestValidator;
        }

        [HttpPost("deposit")]
        [ProducesResponseType(typeof(AccountTransactionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountTransactionDTO>> Deposit([FromBody] DepositRequest depositRequest)
        {
            var validationResult = _depositRequestValidator.Validate(depositRequest);
            if (!validationResult.IsValid)
            {
                return new BadRequestResult();
            }

            var transaction = await _accountTransactionService.ProcessTransaction(depositRequest.AccountId, depositRequest.Amount);

            if (transaction == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(transaction);
        }

        [HttpPost("withdraw")]
        [ProducesResponseType(typeof(AccountTransactionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountTransactionDTO>> Withdraw([FromBody] WithdrawRequest withdrawRequest)
        {
            var validationResult = await _withdrawRequestValidator.ValidateAsync(withdrawRequest);
            if (!validationResult.IsValid)
            {
                return new BadRequestResult();
            }

            var negativeAmount = -withdrawRequest.Amount;

            var transaction = await _accountTransactionService.ProcessTransaction(withdrawRequest.AccountId, negativeAmount);

            if (transaction == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(transaction);
        }
    }
}
