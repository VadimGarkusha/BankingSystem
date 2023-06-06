using BankingSystem.Common;
using FluentValidation;

namespace BankingSystem.AccountTransactions
{
    public class DepositRequestValidator : AbstractValidator<DepositRequest>
    {
        public DepositRequestValidator(ITransactionLimitsProvider transactionLimitsProvider)
        {
            var transactionLimits = transactionLimitsProvider.GetTransactionLimits();

            RuleFor(d => d.AccountId).GreaterThan(0).WithMessage($"Invalid account"); ;
            RuleFor(d => d.Amount).GreaterThan(0).LessThanOrEqualTo(transactionLimits.MaximumDepositLimit)
                .WithMessage($"Amount should be less or equal than {transactionLimits.MaximumDepositLimit} and greater than 0"); ;
        }
    }
}
