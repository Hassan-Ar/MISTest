namespace BlazorApp2.Contracts
{
    public interface IAuthenticationService
    {

        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
        Task<bool> Login(string username, string password);

    }
}
