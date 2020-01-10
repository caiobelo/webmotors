using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebMotors.Core;

namespace WebMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        // HttpGet: api/Anuncio
        [HttpGet("Listar")]
        public IEnumerable<Anuncio> Get()
        {
            return _anuncioService.Listar();
        }

        // HttpGet: api/Anuncio/5
        [HttpGet("Obter/{id}", Name = "Get")] 
        public IActionResult Get(int id)
        {
            return Ok(_anuncioService.Obter(id));
        }

        // HttpPost: api/Anuncio
        [HttpPost("Cadastrar")]
        public IActionResult Post([FromBody] Anuncio anuncio)
        {
            if (anuncio == null)
              return BadRequest(new Exception("Nao foi possivel identificar o anuncio na requisicao"));

            if (anuncio.Id > 0)
                _anuncioService.Atualizar(anuncio);
            else
                _anuncioService.Adicionar(anuncio);

            return Ok("Anuncio cadastrado com sucesso");
        }

        // HttpDelete: api/ApiWithActions/5
        [HttpDelete("Remover/{id}")]
        public IActionResult Delete(int id)
        {
            _anuncioService.Remover(id);

            return Ok("Anuncio removido com sucesso");
        }

        [HttpGet("ListarMarcas")]
        public IActionResult ListarMarcas()
        {
            return Ok(_anuncioService.ListarMarcas());
        }

        [HttpGet("ListarModelos/{makeId}")]
        public IActionResult ListarModelos([FromRoute] int makeId)
        {
            return Ok(_anuncioService.ListarModelos(makeId));
        }

        [HttpGet("ListarVersoes/{idModelo}")]
        public IActionResult ListarVersoes([FromRoute] int idModelo)
        {
            return Ok(_anuncioService.ListarVersoes(idModelo));
        }
    }
}
