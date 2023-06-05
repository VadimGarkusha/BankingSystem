namespace BankingSystem.Common
{
    /// <summary>
    /// Abtraction for our limits, potentially we'd like to get it from DB/other system based on the system we're building this in
    /// </summary>
    public class TransactionLimitsProvider : ITransactionLimitsProvider
    {
        public TransactionLimits GetTransactionLimits()
        {
            return new TransactionLimits
            {
                MinimumAccountAmountLimit = 100,
                MaximumDepositLimit = 10000,
                MaximumWithdrawRatioLimit = 0.9,
            };
        }
    }
}
