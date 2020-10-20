using Copa.AppCore.Implementations;
using Copa.AppCore.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Copa.Infrastructure.Services
{
    public class EquipesService : IEquipes_Service
    {
        IServiceScopeFactory _service;
        public EquipesService(IServiceScopeFactory service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Equipe>> GetEquipes()
        {
            using (var scope = _service.CreateScope())
            {
                var client = scope.ServiceProvider.GetService<IHttpClientFactory>().CreateClient("Equipes");
                var response = client.GetAsync(client.BaseAddress.AbsoluteUri + "/equipes.json");
                response.Result.EnsureSuccessStatusCode();
                var content = await response.Result.Content.ReadAsStringAsync();
                var objList = JsonConvert.DeserializeObject<IEnumerable<Equipe>>(content);
                return objList;
            }
        }
    }
}
