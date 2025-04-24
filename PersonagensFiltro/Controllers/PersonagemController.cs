using Microsoft.AspNetCore.Mvc;
using PersonagensFiltro.SERVICES;

namespace PersonagensFiltro.Controllers
{
    [ApiController]
    [Route("api/personagens")]
    public class PersonagemController : ControllerBase
    {
        private readonly IServiceP _service;
        public PersonagemController(IServiceP serviceP)
        {

            _service = serviceP;
        }

        [HttpGet("ObterTodos")]
        public IActionResult MostrarTodos()
        {
            var personagens = _service.MostrarTodos();
            return Ok(new
            {
                Mensagem = "Lista de Personagens",
                Total = personagens.Count(),
                Personagens = personagens
            });
        }
        [HttpGet("ObterPorId/{id}")]
        public IActionResult MostrarPorId(int id)
        {
            var personagem = _service.MostrarPorId(id);
            if (personagem == null)
            {
                return Ok(new
                {
                    Mensagem = "Personagem não encontrado, tente outro ID"
                });
            }
            return Ok(new
            {
                Mensagem = "Personagem encontrado",
                Personagem = personagem
            });
        }
        [HttpPost("Adicionar")]
        public IActionResult Adicionar([FromBody] Entity.Personagens personagem)
        {
            if (personagem == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Personagem inválido"
                });
            }
            _service.Adicionar(personagem);
            return Ok(new
            {
                Mensagem = "Personagem adicionado com sucesso",
                Id = personagem.Id,
                Personagem = personagem
            });
        }
        [HttpPut("Atualizar")]
        public IActionResult Atualizar([FromBody] Entity.Personagens personagem)
        {
            if (personagem == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Personagem inválido"
                });
            }
            var personagemExistente = _service.MostrarPorId(personagem.Id);
            if (personagemExistente == null)
            {
                return NotFound(new
                {
                    Mensagem = "Personagem não encontrado"
                });
            }
            _service.Atualizar(personagem);
            return Ok(new
            {
                Mensagem = "Personagem atualizado com sucesso",
                Personagem = personagem
            });
        }
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var personagem = _service.MostrarPorId(id);
            if (personagem == null)
            {
                return NotFound(new
                {
                    Mensagem = "Personagem não encontrado"
                });
            }
            _service.Deletar(id);
            return Ok(new
            {
                Mensagem = "Personagem deletado com sucesso"
            });
        }
        [HttpGet("ObterPorRaca/{raca}")]
        public IActionResult ObterPorRaca(string raca)
        {
            var personagens = _service.MostrarPorRaca(raca);
            if (personagens == null || !personagens.Any())
            {
                return NotFound(new
                {
                    Mensagem = "Nenhum personagem encontrado com essa raça"
                });
            }
            return Ok(new
            {
                Mensagem = "Personagens encontrados",
                Personagens = personagens
            });
        }
        [HttpGet("ObterPorIdade/{idade}")]
        public IActionResult ObterPorIdade(int idade)
        {
            var personagens = _service.MostrarPorIdade(idade);
            if (personagens == null || !personagens.Any())
            {
                return NotFound(new
                {
                    Mensagem = "Nenhum personagem encontrado com essa idade"
                });
            }
            return Ok(new
            {
                Mensagem = "Personagens encontrados",
                Personagens = personagens
            });


        }
        [HttpGet("ObterPorIdadeIgualMenorQue/{idade}")]
        public IActionResult ObterPorIdadeIgualMenorQue(int idade)
        {
            var personagens = _service.MostrarPorIdadeIgualMenorQue(idade);
            if (personagens == null || !personagens.Any())
            {
                return NotFound(new
                {
                    Mensagem = "Nenhum personagem encontrado com essa idade"
                });
            }
            return Ok(new
            {
                Mensagem = "Personagens encontrados",
                Personagens = personagens
            });
        }
        [HttpGet("ObterPorIdadeIgualMaiorQue/{idade}")]
        public IActionResult ObterPorIdadeIgualMaiorQue(int idade)
        {
            var personagens = _service.MostrarPorIdadeIgualMaiorQue(idade);
            if (personagens == null || !personagens.Any())
            {
                return NotFound(new
                {
                    Mensagem = "Nenhum personagem encontrado com essa idade"
                });
            }
            return Ok(new
            {
                Mensagem = "Personagens encontrados",
                Personagens = personagens
            });
        }
    }
}

