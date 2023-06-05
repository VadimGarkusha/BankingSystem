namespace BankingSystem.Common
{
    public interface ITransactionLimitsProvider
    {
        TransactionLimits GetTransactionLimits();
    }
}
