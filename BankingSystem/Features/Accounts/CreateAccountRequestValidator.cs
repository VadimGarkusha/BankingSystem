using BankingSystem.Common;
using FluentValidation;

namespace BankingSystem.Features.Accounts
{
    public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountRequestValidator(ITransactionLimitsProvider transactionLimitsProvider)
        {
            var transactionLimits = transactionLimitsProvider.GetTransactionLimits();

            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.StartingAmount).GreaterThanOrEqualTo(transactionLimits.MinimumAccountAmountLimit);
            RuleFor(a => a.UserId).GreaterThan(0);
        }
    }
}
