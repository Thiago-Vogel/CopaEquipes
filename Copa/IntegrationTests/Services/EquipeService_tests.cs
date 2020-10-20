using Copa.AppCore.Implementations;
using Copa.AppCore.Models;
using Copa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Web;
using Xunit;

namespace IntegrationTests.Services
{
    public class EquipeService_tests: IClassFixture<WebApplicationFactory<Startup>>
    {
        IEquipes_Service _service { get; }

        public EquipeService_tests(WebApplicationFactory<Startup> factory)
        {
            _service = factory.Services.GetRequiredService<IEquipes_Service>();
        }

        [Fact]
        public async void Get_ReturnsEquipeArray()
        {
            var response = await _service.GetEquipes();
            Assert.IsAssignableFrom<IEnumerable<Equipe>>(response);
        }
    }
}
