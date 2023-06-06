using BankingSystem.BL.Accounts;
using BankingSystem.Common;
using FluentValidation;

namespace BankingSystem.AccountTransactions
{
    public class WithdrawRequestValidator : AbstractValidator<WithdrawRequest>
    {
        public WithdrawRequestValidator(ITransactionLimitsProvider transactionLimitsProvider, IAccountService accountService)
        {
            var transactionLimits = transactionLimitsProvider.GetTransactionLimits();

            RuleFor(d => d.AccountId).GreaterThan(0).WithMessage("Invalid account");
            RuleFor(d => d.Amount).GreaterThan(0).WithMessage("Amount should be greater than 0");

            RuleFor(d => d).MustAsync(async (request, cancellationTkn) =>
            {
                var account = await accountService.GetAccountById(request.AccountId);

                if (account == null)
                {
                    return false;
                }

                var newAmount = account.CurrentAmount - request.Amount;

                return newAmount >= transactionLimits.MinimumAccountAmountLimit
                    && request.Amount <= account.CurrentAmount * transactionLimits.MaximumWithdrawRatioLimit;
            }).WithMessage($"You must leave minimum {transactionLimits.MinimumAccountAmountLimit} and cannot withdraw more than {transactionLimits.MaximumWithdrawRatioLimit * 100}%");
        }
    }
}
