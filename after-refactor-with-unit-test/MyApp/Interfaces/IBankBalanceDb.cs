namespace MyApp.Interfaces
{
    public interface IBankBalanceDb
    {
        AccountBalance[] GetAccountBalance(string accountNumber);
    }
}