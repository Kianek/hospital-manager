using System.Net.Http;
using HospitalManager.Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HospitalManager.IntegrationTests
{
    public class TestBase
    {
        protected readonly WebAppFactory<Startup> _factory;
        protected readonly HttpClient _client;

        public TestBase(WebAppFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}