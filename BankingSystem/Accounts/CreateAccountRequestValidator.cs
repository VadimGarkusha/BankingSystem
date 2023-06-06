using BankingSystem.Common;
using FluentValidation;

namespace BankingSystem.Accounts
{
    public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountRequestValidator(ITransactionLimitsProvider transactionLimitsProvider)
        {
            var transactionLimits = transactionLimitsProvider.GetTransactionLimits();

            RuleFor(a => a.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(a => a.StartingAmount).GreaterThanOrEqualTo(transactionLimits.MinimumAccountAmountLimit)
                .WithMessage($"Minimum account amount is {transactionLimits.MinimumAccountAmountLimit}");
            RuleFor(a => a.UserId).GreaterThan(0).WithMessage($"Invalid user");
        }
    }
}
