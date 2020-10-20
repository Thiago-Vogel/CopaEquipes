using AppCore.Models;
using Copa.AppCore.Models;
using IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Web;
using Xunit;

namespace FunctionalTests.Controllers
{
    public class EquipeController_tests : IClassFixture<WebApplicationFactory<Startup>>
    {
        HttpClient client { get; }

        public EquipeController_tests(WebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async void Get_ReturnsEquipeArray()
        {
            var response = await client.GetAsync("/Equipe/Get");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<IEnumerable<Equipe>>(stringResponse);
            Assert.IsAssignableFrom<IEnumerable<Equipe>>(obj);
        }
    }
}
