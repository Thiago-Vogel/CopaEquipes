using Copa.AppCore.Dtos;
using Copa.AppCore.Implementations;
using Copa.AppCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Copa.Web.Controllers
{
    public class CopaController:ControllerBase
    {
        ICopa_Service _service;
        public CopaController(ICopa_Service equipes)
        {
            _service = equipes;
        }

        [HttpPost]
        [Route("Copa/GerarCopa")]
        public IEnumerable<Equipe> GerarCopa([FromBody]Equipe[] equipes)
        {
            //Minimo de equipes requerido para gerar uma copa = 8
            bool copaValida = (equipes.Count() == 8);
            if (copaValida)
            {
                var resultado =  _service.GerarCopa(equipes);
                return resultado;
            }
            else
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return null;
        }
    }
}
