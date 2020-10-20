using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Copa.App.Controllers
{
    [ApiController]
    [Route("Equipe")]
    public class EquipeController : ControllerBase
    {
        private readonly ILogger<EquipeController> _logger;
        IServiceScopeFactory _factory;

        public EquipeController(ILogger<EquipeController> logger, IServiceScopeFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            using (var scope = _factory.CreateScope())
            {
                var client = scope.ServiceProvider.GetService<IHttpClientFactory>().CreateClient("CopaClient");
                var response = client.GetAsync("/Equipe/Get");
                response.Result.EnsureSuccessStatusCode();
                var equipes = await response.Result.Content.ReadAsStringAsync();
                var objlist = JsonConvert.DeserializeObject<IEnumerable<object>>(equipes);
                return new JsonResult(objlist);
            }
        }
    }
}
