using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using RestAPI.Models.Data.DTO;
using RestAPI.Models;

namespace RestAPI.Controllers
{
 
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class VeiculoController : Controller
    {
        
        private VeiculoService _veiculoService;

       
        public VeiculoController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

         
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Veiculo>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_veiculoService.buscarTodos());
        }

         
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Veiculo))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var veiculo = _veiculoService.buscarPorId(id);
            if (veiculo == null) return NotFound();
            return new OkObjectResult(veiculo);
        }

        
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(Veiculo))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] VeiculoDTO veiculo)
        {
            if (veiculo == null) return BadRequest();
            return new OkObjectResult(_veiculoService.salvar(veiculo));
        }

         
        [HttpPut]
        [ProducesResponseType((202), Type = typeof(Veiculo))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] VeiculoDTO veiculo)
        {
            if (veiculo == null) return BadRequest();
            var updatedVeiculo = _veiculoService.alterar(veiculo);
            if (updatedVeiculo == null) return BadRequest();
            return new OkObjectResult(updatedVeiculo);
        }

       
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _veiculoService.remover(_veiculoService.buscarPorId(id));
            return NoContent();
        }
    }
}
