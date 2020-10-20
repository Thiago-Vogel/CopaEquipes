using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Copa.App.Controllers
{
    [ApiController]
    [Route("Copa")]
    public class CopaController:ControllerBase
    {
        private readonly ILogger<CopaController> _logger;
        IServiceScopeFactory _factory;

        public CopaController(ILogger<CopaController> logger, IServiceScopeFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        [HttpPost]
        public async Task<IEnumerable<object>> Post([FromBody]IEnumerable<object> selecionadas)
        {
            using (var scope = _factory.CreateScope())
            {
                var json = JsonConvert.SerializeObject(selecionadas);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var client = scope.ServiceProvider.GetService<IHttpClientFactory>().CreateClient("CopaClient");
                var response = client.PostAsync("/Copa/GerarCopa",content);
                response.Result.EnsureSuccessStatusCode();
                var equipes = await response.Result.Content.ReadAsStringAsync();
                var objlist = JsonConvert.DeserializeObject<IEnumerable<object>>(equipes);
                return objlist;
            }
        }
    }
}
