using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using RestAPI.Models.Data.DTO;
using RestAPI.Models;
using System;

namespace RestAPI.Controllers
{

    /* Classe que irá receber as requisições
  * Temos que definir a rota que esse recurso será oferecido
  * Algo do tipo:
  * http://localhost:52103/api/proprietario/v1
 */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ProprietarioController : Controller
    {

        //Interface de serviço, disponibilizamos só os métodos que queremos.
        private ProprietarioService _proprietarioService;


        /* Injeção de dependência ao iniciar o construtor. */
        public ProprietarioController(ProprietarioService proprietario)
        {
            _proprietarioService = proprietario;
        }

        /*TEMOS QUE DEFINIR O VERBO, GET
         * TIPOS DE RESPOSTAS SÃO POR NÚMEROS*/
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Proprietario>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            
            //CHAMAMOS O SERVICE
            List<Proprietario> lista = _proprietarioService.buscarTodos();
                return new OkObjectResult(lista);
            
             
        }

        /*PODEMOS ESPERAR PARÂMETROS*/
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Proprietario))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var proprietario = _proprietarioService.buscarPorId(id);
            if (proprietario == null) return NotFound();
            return new OkObjectResult(proprietario);
        }


        /*É O NOSSO INSERT*/
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(Proprietario))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] Proprietario proprietario)
        {
            if (proprietario == null) return BadRequest();
            return new OkObjectResult(_proprietarioService.salvar(proprietario));
        }


        /*ALTERAR*/
        [HttpPut]
        [ProducesResponseType((202), Type = typeof(Proprietario))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] Proprietario proprietario)
        {
            if (proprietario == null) return BadRequest();
            var updatedProprietario = _proprietarioService.alterar(proprietario);
            if (updatedProprietario == null) return BadRequest();
            return new OkObjectResult(updatedProprietario);
        }


        /*DELETAR*/
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _proprietarioService.remover(_proprietarioService.buscarPorId(id));
            return NoContent();
        }
    }
}
