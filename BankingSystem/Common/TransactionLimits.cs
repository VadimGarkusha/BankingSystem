namespace BankingSystem.Common
{
    public class TransactionLimits
    {
        public double MinimumAccountAmountLimit { get; set; }
        public double MaximumDepositLimit { get; set; }
        public double MaximumWithdrawRatioLimit { get; set; }
    }
}
