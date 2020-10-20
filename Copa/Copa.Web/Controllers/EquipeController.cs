using AppCore.Implementations;
using Copa.AppCore.Dtos;
using Copa.AppCore.Implementations;
using Copa.AppCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Copa.Web.Controllers
{
    public class EquipeController: ControllerBase
    {
        IEquipes_Service _service;
        public EquipeController(IEquipes_Service service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Equipe/Get")]
        public async Task<string> Get([FromQuery] EquipeParams query)
        {
            //Evaluator no caso de uma implementação  futura via db
            //query = query != null ? query : new EquipeParams();
            //Expression<Func<Equipe, bool>> expression = e =>
            //     (e.Id == query.id || query.id == 0) &&
            //     (e.Nome == query.nome || query.nome == null);

            var obj = await _service.GetEquipes();
            return JsonConvert.SerializeObject(obj);
        }

        //[HttpPost]
        //[Route("Equipe/Post")]
        //public async Task<string> Post(Equipe entity)
        //{
        //    var obj = await _service.AddAsync(entity);
        //    return JsonConvert.SerializeObject(obj);
        //}

        //[HttpPut]
        //[Route("Equipe/Put")]
        //public async Task<string> Put(Equipe entity)
        //{
        //    var obj = await _service.UpdateAsync(entity);
        //    return JsonConvert.SerializeObject(obj);
        //}

        //[HttpDelete]
        //[Route("Equipe/Delete")]
        //public async Task<string> Delete(Equipe entity)
        //{
        //    var obj = await _service.DeleteAsync(entity);
        //    return JsonConvert.SerializeObject(obj);
        //}
    }
}
