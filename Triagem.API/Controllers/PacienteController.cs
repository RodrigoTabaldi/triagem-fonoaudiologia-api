using Microsoft.AspNetCore.Mvc;
using Triagem.Domain;
using Triagem.Infrastructure;
using System.Linq;

namespace Triagem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacienteController(AppDbContext context)
        {
            _context = context;
        }

        //  POST - Criar paciente
        [HttpPost]
        public IActionResult CriarPaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();

            return Ok(paciente);
        }

        // GET - Listar todos
        [HttpGet]
        public IActionResult ListarPacientes()
        {
            var pacientes = _context.Pacientes.ToList();
            return Ok(pacientes);
        }

        //  GET por ID
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var paciente = _context.Pacientes.Find(id);

            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        //  Atualizar
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Paciente pacienteAtualizado)
        {
            var paciente = _context.Pacientes.Find(id);

            if (paciente == null)
                return NotFound();

            paciente.Nome = pacienteAtualizado.Nome;
            paciente.Idade = pacienteAtualizado.Idade;
            paciente.Sexo = pacienteAtualizado.Sexo;
            paciente.Observacao = pacienteAtualizado.Observacao;

            _context.SaveChanges();

            return Ok(paciente);
        }

        //   Remover
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var paciente = _context.Pacientes.Find(id);

            if (paciente == null)
                return NotFound();

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();

            return NoContent();

      
        }
        [HttpGet("{id}/triagens")]
        public IActionResult BuscarPacienteComTriagens(int id)
        {
            var paciente = _context.Pacientes
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Idade,
                    p.Sexo,
                    p.Observacao,
                    Triagens = _context.Aplicacoes
                        .Where(a => a.PacienteId == p.Id)
                        .ToList()
                })
                .FirstOrDefault();

            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }



    }

}