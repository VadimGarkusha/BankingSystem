namespace BankingSystem.Features.Accounts.BL
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CurrentAmount { get; set; }
        public int UserId { get; set; }
    }
}