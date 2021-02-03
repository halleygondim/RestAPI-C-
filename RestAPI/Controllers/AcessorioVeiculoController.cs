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
    public class AcessorioVeiculoController : Controller
    {
   
        private AcessorioVeiculoService _acessorioVeiculoService;

        public AcessorioVeiculoController(AcessorioVeiculoService acessorioVeiculoService)
        {
            _acessorioVeiculoService = acessorioVeiculoService;
        }


        [HttpGet]
        [Route("veiculo/{id}")]
        [ProducesResponseType((200), Type = typeof(List<AcessorioVeiculo>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetTodos(long id)
        {
            return new OkObjectResult(_acessorioVeiculoService.buscaAcessorioPorVeiculo(id));
        }


        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(AcessorioVeiculoDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var acessorioVeiculo = _acessorioVeiculoService.buscarPorId(id);
            if (acessorioVeiculo == null) return NotFound();
            return new OkObjectResult(acessorioVeiculo);
        }


        [HttpPost]
        [ProducesResponseType((201), Type = typeof(AcessorioVeiculoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] AcessorioVeiculoDTO acessorioVeiculo)
        {
            if (acessorioVeiculo == null) return BadRequest();
            return new OkObjectResult(_acessorioVeiculoService.salvar(acessorioVeiculo));
        }


        [HttpPut]
        [ProducesResponseType((202), Type = typeof(AcessorioVeiculoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] AcessorioVeiculoDTO acessorioVeiculo)
        {
            if (acessorioVeiculo == null) return BadRequest();
            var acessorioVeiculoAtualizado = _acessorioVeiculoService.alterar(acessorioVeiculo);
            if (acessorioVeiculoAtualizado == null) return BadRequest();
            return new OkObjectResult(acessorioVeiculoAtualizado);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _acessorioVeiculoService.remover(_acessorioVeiculoService.buscarPorId(id));
            return NoContent();
        }
    }
}
