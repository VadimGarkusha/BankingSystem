using BankingSystem.Common;
using BankingSystem.Features.Accounts.DAL;
using BankingSystem.Features.Accounts.Data;
using FluentValidation;

namespace BankingSystem.Features.AccountTransactions
{
    public class WithdrawRequestValidator : AbstractValidator<WithdrawRequest>
    {
        public WithdrawRequestValidator(ITransactionLimitsProvider transactionLimitsProvider, IAccountDAL accountDAL)
        {
            var transactionLimits = transactionLimitsProvider.GetTransactionLimits();

            RuleFor(d => d.AccountId).GreaterThan(0);
            RuleFor(d => d.Amount).GreaterThan(0);

            RuleFor(d => d).MustAsync(async (request, cancellationTkn) =>
            {
                var account = await accountDAL.GetAccountById(request.AccountId);

                if (account == null)
                {
                    return false;
                }

                var newAmount = account.CurrentAmount - request.Amount;

                return newAmount >= transactionLimits.MinimumAccountAmountLimit
                    && request.Amount <= account.CurrentAmount * transactionLimits.MaximumWithdrawRatioLimit;
            });
        }
    }
}
