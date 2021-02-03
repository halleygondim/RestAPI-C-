using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using RestAPI.Models;

namespace RestAPI.Controllers
{

 
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AcessorioController : Controller
    {
      
        private AcessorioService _acessorioService;

      
        public AcessorioController(AcessorioService acessorioService)
        {
            _acessorioService = acessorioService;
        }

        
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Acessorio>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
           
            return new OkObjectResult(_acessorioService.buscarTodos());
        }

    
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Acessorio))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var acessorio = _acessorioService.buscarPorId(id);
            if (acessorio == null) return NotFound();
            return new OkObjectResult(acessorio);
        }



        [HttpPost]
        [ProducesResponseType((201), Type = typeof(Acessorio))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] Acessorio acessorio)
        {
            if (acessorio == null) return BadRequest();
            return new OkObjectResult(_acessorioService.salvar(acessorio));
        }

       
        [HttpPut]
        [ProducesResponseType((202), Type = typeof(Acessorio))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] Acessorio acessorio)
        {
            if (acessorio == null) return BadRequest();
            var updateAcessorio = _acessorioService.alterar(acessorio);
            if (updateAcessorio == null) return BadRequest();
            return new OkObjectResult(updateAcessorio);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _acessorioService.remover(_acessorioService.buscarPorId(id));
            return NoContent();
        }
    }
}
