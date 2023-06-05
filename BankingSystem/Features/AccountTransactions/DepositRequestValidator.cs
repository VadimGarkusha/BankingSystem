using BankingSystem.Common;
using FluentValidation;

namespace BankingSystem.Features.AccountTransactions
{
    public class DepositRequestValidator : AbstractValidator<DepositRequest>
    {
        public DepositRequestValidator(ITransactionLimitsProvider transactionLimitsProvider)
        {
            var transactionLimits = transactionLimitsProvider.GetTransactionLimits();

            RuleFor(d => d.AccountId).GreaterThan(0);
            RuleFor(d => d.Amount).GreaterThan(0).LessThanOrEqualTo(transactionLimits.MaximumDepositLimit);
        }
    }
}
