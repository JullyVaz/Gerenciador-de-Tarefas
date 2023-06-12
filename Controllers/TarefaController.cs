using Microsoft.AspNetCore.Mvc;
using ApiTarefas.Context;
using ApiTarefas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }
        [HttpPost("Cadastrar a Tarefa")]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }


        
[HttpGet("ObterPorData")]
[Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "Sucesso", typeof(List<Tarefa>))]
public IActionResult ObterPorData([FromQuery][SwaggerParameter("Informe a data no formato MM/dd/yyyy.")] DateTime data)
{
    // Verifica se a data é igual a DateTime.MinValue
    if (data == DateTime.MinValue)
    {
        return BadRequest(new { Erro = "Data inválida. Informe a data no formato dd/MM/yyyy." });
    }

    List<Tarefa> tarefaPorData = _context.Tarefas.Where(x => x.Data.Date == data.Date).ToList();
    return Ok(tarefaPorData);
}

        
    


        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            List<Tarefa> tarefaPorStatus = _context.Tarefas.Where(x => x.Status == status).ToList();
            return Ok(tarefaPorStatus);
        }
       
        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            
            List<Tarefa> tarefas = _context.Tarefas.ToList();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
             Tarefa tarefa = _context.Tarefas.Find(id);
                if (tarefa == null)
                return NotFound();
                return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Tarefa tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

                _context.Tarefas.Remove(tarefaBanco);
                _context.SaveChanges();
                return NoContent();
        }

        [HttpPut("{id}/Alterar o status")]
         
         public IActionResult Atualizar(int id, Tarefa tarefaAtualizada)
        {
          var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefaAtualizada.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

                // Atualiza apenas as propriedades de status da tarefa
                tarefaBanco.Status = tarefaAtualizada.Status;
                _context.Tarefas.Update(tarefaBanco);
                _context.SaveChanges();

                var statusDisponiveis = Enum.GetValues(typeof(EnumStatusTarefa));

                return Ok(new { TarefaAtualizada = tarefaBanco, StatusDisponiveis = statusDisponiveis });
         
        
        }
    }
}