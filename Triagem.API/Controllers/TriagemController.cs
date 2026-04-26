using Microsoft.AspNetCore.Mvc;
using Triagem.Domain;
using Triagem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Triagem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TriagemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TriagemController(AppDbContext context)
        {
            _context = context;
        }

        // POST - calcular e salvar triagem
        [HttpPost("calcular")]
        public IActionResult Calcular(int pacienteId, List<Resposta> respostas)
        {
            var calculadora = new CalculadoraTriagem();

            var pontuacao = respostas.Count(r => r.Valor);
            var risco = calculadora.CalcularRisco(respostas);

            var aplicacao = new AplicacaoTriagem
            {
                PacienteId = pacienteId,
                Data = DateTime.Now,
                Pontuacao = pontuacao,
                Risco = risco
            };

            _context.Aplicacoes.Add(aplicacao);
            _context.SaveChanges();

            return Ok(aplicacao);
        }

        // GET - listar todas as triagens
        [HttpGet]
        public IActionResult Listar()
        {
            var triagens = _context.Aplicacoes.ToList();
            return Ok(triagens);
        }

        // 🔹 GET - listar por paciente
        [HttpGet("paciente/{pacienteId}")]
        public IActionResult ListarPorPaciente(int pacienteId)
        {
            var triagens = _context.Aplicacoes
                .Where(t => t.PacienteId == pacienteId)
                .ToList();

            return Ok(triagens);
        }
    }
}