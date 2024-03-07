using System.Net.Http;

namespace Demo.RealestateApp.App1.Service.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient { get { return HttpClient; } }
    }
}
