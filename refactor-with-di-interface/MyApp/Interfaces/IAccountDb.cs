namespace MyApp.Interfaces
{
    public interface IAccountDb
    {
        AccountInfo FindAccountInfo(string bankAccountNo);
    }
}