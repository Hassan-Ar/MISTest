
namespace BlazorApp2.Service.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient { get { return HttpClient; } }
    }
}
