using Copa.AppCore.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Web;
using Xunit;

namespace FunctionalTests.Controllers
{
    public class CopaController_tests : IClassFixture<WebApplicationFactory<Startup>>
    {
        HttpClient client { get; }

        public CopaController_tests(WebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async void Get_ReturnsEquipeArray()
        {
            List<Equipe> equipes = new List<Equipe>();
            int i = 0;
            while (i < 8)
            {
                equipes.Add(new Equipe()
                {
                    Id = i.ToString(),
                    Nome = "teste" + i.ToString(),
                    Sigla = "tst" + i.ToString(),
                    Gols = i
                });
                i++;
            }
            var json = JsonConvert.SerializeObject(equipes);

            var response = await client.PostAsync("/Copa/GerarCopa",new StringContent(json,Encoding.UTF8,"application/json"));
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<IEnumerable<Equipe>>(stringResponse);
            Assert.IsAssignableFrom<IEnumerable<Equipe>>(obj);
        }
    }
}
