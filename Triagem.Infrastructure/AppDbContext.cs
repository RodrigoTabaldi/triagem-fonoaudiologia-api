using Microsoft.EntityFrameworkCore;
using Triagem.Domain;

namespace Triagem.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<AplicacaoTriagem> Aplicacoes { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
    }
}