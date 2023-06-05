namespace BankingSystem.Features.Accounts
{
    public class CreateAccountRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public double StartingAmount { get; set; }
    }
}
