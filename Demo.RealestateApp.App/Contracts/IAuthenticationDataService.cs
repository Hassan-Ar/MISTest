namespace Demo.RealestateApp.App.Contracts
{
    public interface IAuthenticationDataService
    {

        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(string firstName, string lastName, string userName, string email, string password);
        Task Logout();

    }
}
