namespace Demo.RealestateApp.App1.Contracts
{
    public interface IAuthenticationService
    {

        Task<bool> Register(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
        Task<bool> Login(string username, string password);

    }
}
